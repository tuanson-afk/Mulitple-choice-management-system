using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using QTV.Controllers;
using QTV.DataAccess;
using QTV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Trac_Nghiem
{
    public partial class frmTaiFileCH : Form
    {
        private string _maMonHienTai;
        private string _maNHCauHoiHienTai;

        public frmTaiFileCH(string maMonHienTai, string maNHCauHoiHienTai)
        {
            InitializeComponent();
            _maMonHienTai = maMonHienTai;
            _maNHCauHoiHienTai = maNHCauHoiHienTai;
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDanhSachCauHoi.Rows)
            {
                if (!row.IsNewRow)
                {
                    string noiDungCauHoi = row.Cells["Câu hỏi"].Value?.ToString();
                    string traLoiA = row.Cells["Câu trả lời A"].Value?.ToString();
                    string traLoiB = row.Cells["Câu trả lời B"].Value?.ToString();
                    string traLoiC = row.Cells["Câu trả lời C"].Value?.ToString();
                    string traLoiD = row.Cells["Câu trả lời D"].Value?.ToString();
                    string dapAnDung = row.Cells["Câu trả lời đúng"].Value?.ToString();
                    string chuong = row.Cells["Chương"].Value?.ToString();
                    string mucDo = row.Cells["Mức độ"].Value?.ToString();

                    // Lưu vào bảng CauHoi
                    string maCauHoi = InsertCauHoi(noiDungCauHoi, _maMonHienTai, chuong, mucDo, _maNHCauHoiHienTai);

                    // Lưu vào bảng PhuongAn
                    InsertPhuongAn(maCauHoi, traLoiA, dapAnDung == "A" ? 1 : 0);
                    InsertPhuongAn(maCauHoi, traLoiB, dapAnDung == "B" ? 1 : 0);
                    InsertPhuongAn(maCauHoi, traLoiC, dapAnDung == "C" ? 1 : 0);
                    InsertPhuongAn(maCauHoi, traLoiD, dapAnDung == "D" ? 1 : 0);
                }
            }

            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private string InsertCauHoi(string noiDung, string maMon, string chuong, string mucDo, string maNHCauHoi)
        {
            try
            {
                var ado = ADO.Instance;
                string maCauHoi = Guid.NewGuid().ToString("N").Substring(0, 8);
                string query = @"INSERT INTO CauHoi (MaCauHoi, NoiDung, MaMon, Chuong, MucDo, MaNHCauHoi) 
                         VALUES (@MaCauHoi, @NoiDung, @MaMon, @Chuong, @MucDo, @MaNHCauHoi)";

                // Tạo danh sách các tham số
                var parameters = new List<SqlParameter>
                {
                    ado.CreateParameter("@MaCauHoi", maCauHoi),
                    ado.CreateParameter("@NoiDung", noiDung),
                    ado.CreateParameter("@MaMon", maMon),
                    ado.CreateParameter("@Chuong", chuong),
                    ado.CreateParameter("@MucDo", mucDo),
                    ado.CreateParameter("@MaNHCauHoi", maNHCauHoi)
                };

                int result = ado.ExecuteNonQuery(query, parameters.ToArray());

                // Kiểm tra kết quả
                if (result > 0)
                {
                    return maCauHoi;
                }
                else
                {
                    throw new Exception("Không thể thêm câu hỏi.");
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý lỗi theo yêu cầu
                Debug.WriteLine($"Lỗi khi thêm câu hỏi: {ex.Message}");
                return null;
            }
        }

        private void InsertPhuongAn(string maCauHoi, string noiDung, int dungSai)
        {
            try
            {
                var ado = ADO.Instance;
                string maPhuongAn = "PA" + Guid.NewGuid().ToString("N").Substring(0, 6);
                string query = @"INSERT INTO QTV3.dbo.PhuongAn (MaPhuongAn, NoiDung, MaCauHoi, DungSai) 
                         VALUES (@MaPhuongAn, @NoiDung, @MaCauHoi, @DungSai)";
                var parameters = new List<SqlParameter>
                {
                    ado.CreateParameter("@MaPhuongAn", maPhuongAn),
                    ado.CreateParameter("@NoiDung", noiDung),
                    ado.CreateParameter("@MaCauHoi", maCauHoi),
                    ado.CreateParameter("@DungSai", dungSai)
                };

                int result = ado.ExecuteNonQuery(query, parameters.ToArray());

                if (result > 0)
                {
                    Console.WriteLine($"Thêm phương án thành công: {maPhuongAn}");
                }
                else
                {
                    Console.WriteLine("Không thể thêm phương án.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi thêm phương án: {ex.Message}");
            }
        }

        private void btnTaiFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dataGridViewDanhSachCauHoi.DataSource = null;
                    dataGridViewDanhSachCauHoi.Columns.Clear();

                    string filePath = openFileDialog.FileName;
                    DataTable dataTable = ReadExcelFile(filePath);
                    dataGridViewDanhSachCauHoi.DataSource = dataTable;
                }
            }
        }

        private DataTable ReadExcelFile(string filePath)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                DataTable dt = new DataTable();

                // Tạo cột
                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                {
                    dt.Columns.Add(worksheet.Cells[1, col].Text);
                }

                // Tạo hàng
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    DataRow newRow = dt.NewRow();
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        newRow[col - 1] = worksheet.Cells[row, col].Text;
                    }
                    dt.Rows.Add(newRow);
                }

                return dt;
            }
        }

       
    }
}
