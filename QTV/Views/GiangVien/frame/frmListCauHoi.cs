using DocumentFormat.OpenXml.Spreadsheet;
using QTV.Controllers;
using QTV.Models;
using QTV.Views.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QL_Trac_Nghiem
{
    public partial class frmListCauHoi : Form
    {
        private string _maMonHienTai;
        private NHCauHoi _nhCauHoiHienTai;

        private System.Windows.Forms.Timer searchTimer = new System.Windows.Forms.Timer();

        public frmListCauHoi(String maMonHienTai, NHCauHoi nhCauHoiHienTai)
        {
            InitializeComponent();
            this._maMonHienTai = maMonHienTai;
            this._nhCauHoiHienTai = nhCauHoiHienTai;
            LoadData();
        }

        private void LoadData(string searchString = "", string chuong = "", string mucDo = "")
        {
            try
            {
                LoadingBox loadingBox = new LoadingBox();
                loadingBox.Show();

                dataGridViewDanhSachCauHoi.DataSource = null;
                dataGridViewDanhSachCauHoi.Columns.Clear();

                // Hủy đăng ký sự kiện cũ trước khi đăng ký sự kiện mới
                // dataGridViewNHCauHoi.CellClick -= dataGridViewNHCauHoi_CellClick;

                // Gọi hàm LoadQuestionsList để lấy dữ liệu
                QuestionBankController questionBankController = new QuestionBankController();
                DataTable dt = questionBankController.LoadQuestionsList(_maMonHienTai, searchString);

                // Thực hiện lọc dữ liệu theo Chuong và MucDo
                if (!string.IsNullOrEmpty(chuong))
                {
                    LabelLocTheoChuong.Enabled = false;
                    dt = dt.AsEnumerable()
                           .Where(row => row.Field<string>("Chuong") == chuong)
                           .CopyToDataTable();
                }
                if (!string.IsNullOrEmpty(mucDo))
                {
                    LabelLocTheoMucDo.Enabled = false;
                    dt = dt.AsEnumerable()
                           .Where(row => row.Field<string>("MucDo") == mucDo)
                           .CopyToDataTable();
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridViewDanhSachCauHoi.DataSource = dt;

                    // Thêm cột nút "Xóa"
                    DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                    {
                        Name = "DeleteColumn",
                        HeaderText = "Xóa",
                        Text = "Xóa",
                        UseColumnTextForButtonValue = true,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    };
                    dataGridViewDanhSachCauHoi.Columns.Add(deleteButtonColumn);
                }
                else
                {
                    // Tạo bảng rỗng với cấu trúc
                    dataGridViewDanhSachCauHoi.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "ThongBao",
                        HeaderText = "Không có dữ liệu",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    });
                    // MessageBox.Show("Không thể tải dữ liệu câu hỏi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadingBox.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTaiLenFile_Click(object sender, EventArgs e)
        {
            frmTaiFileCH frmTaiFileCH = new frmTaiFileCH(_maMonHienTai, _nhCauHoiHienTai.MaNHCauHoi);
            frmTaiFileCH.ShowDialog();
            LoadData();
        }

        private void frmListCauHoi_Load(object sender, EventArgs e)
        {
            mainPanel.Left = (this.ClientSize.Width - mainPanel.Width) / 2;
            mainPanel.Top = mainPanel.Top;

            // Đổi tiêu đề form theo tên Ngân hàng câu hỏi
            this.Text = $"Danh sách câu hỏi - {_nhCauHoiHienTai.TenNHCauHoi}";

            // Đổi text của một TextBox
            if (tbTenNHCauHoi != null && tbTenNHCauHoi.Text == "")
            {
                tbTenNHCauHoi.Text = _nhCauHoiHienTai.TenNHCauHoi;
            }

            PopulateDropdowns();
        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Interval = 500; // Đợi 500ms trước khi thực hiện tìm kiếm
            searchTimer.Tick += (s, args) =>
            {
                searchTimer.Stop();
                string searchString = tbTimKiem.Text.Trim();
                LoadData(searchString);
            };
            searchTimer.Start();
        }

        private void comChuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedChuong = comChuong.SelectedItem.ToString();
            string selectedMucDo = comMucDo.SelectedItem?.ToString() ?? "";

            if (selectedChuong == "Tất cả") selectedChuong = "";
            if (selectedMucDo == "Tất cả") selectedMucDo = "";

            LoadData(tbTimKiem.Text.Trim(), selectedChuong, selectedMucDo);
        }

        private void comMucDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedChuong = comChuong.SelectedItem?.ToString() ?? "";
            string selectedMucDo = comMucDo.SelectedItem.ToString();

            if (selectedChuong == "Tất cả") selectedChuong = "";
            if (selectedMucDo == "Tất cả") selectedMucDo = "";

            LoadData(tbTimKiem.Text.Trim(), selectedChuong, selectedMucDo);
        }

        private void PopulateDropdowns()
        {
            QuestionBankController questionBankController = new QuestionBankController();
            DataTable dt = questionBankController.LoadQuestionsList(_maMonHienTai);

            var chuongList = dt.AsEnumerable()
                               .Select(row => row.Field<string>("Chuong"))
                               .Distinct()
                               .ToList();
            comChuong.Items.Clear();
            comChuong.Items.Add("Tất cả");
            comChuong.Items.AddRange(chuongList.ToArray());

            var mucDoList = dt.AsEnumerable()
                              .Select(row => row.Field<string>("MucDo"))
                              .Distinct()
                              .ToList();
            comMucDo.Items.Clear();
            comMucDo.Items.Add("Tất cả");
            comMucDo.Items.AddRange(mucDoList.ToArray());
        }

        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            frmThemCauHoi frmThemCauHoi = new frmThemCauHoi(maNHCauHoiHienTai: _nhCauHoiHienTai.MaNHCauHoi, _maMonHienTai);
            frmThemCauHoi.ShowDialog();
            LoadData();
        }

        private void dataGridViewDanhSachCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if (isProcessing) return; // Nếu đang xử lý, không tiếp tục

            // Bỏ qua nếu nhấp vào tiêu đề hoặc ngoài vùng dữ liệu
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                // isProcessing = true; // Đánh dấu bắt đầu xử lý

                // Kiểm tra nếu cột được click là cột "Xóa"
                if (e.RowIndex >= 0 && dataGridViewDanhSachCauHoi.Columns[e.ColumnIndex].Name == "DeleteColumn")
                {
                    // Lấy giá trị của MaNHCauHoi từ dòng được chọn
                    string maCauHoi = dataGridViewDanhSachCauHoi.Rows[e.RowIndex].Cells["MaCauHoi"].Value?.ToString();

                    if (!string.IsNullOrEmpty(maCauHoi))
                    {
                        // Hiển thị hộp thoại xác nhận
                        DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (confirm == DialogResult.Yes)
                        {
                            // Gọi phương thức xóa từ QuestionBankController
                            QuestionBankController questionBankController = new QuestionBankController();
                            bool isDeleted = questionBankController.DeleteQuestion(maCauHoi);

                            if (isDeleted)
                            {
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // isProcessing = false; // Đặt lại cờ sau khi hoàn tất xử lý
            }
        }

        private void btnSuaCauHoi_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ dòng được chọn trong DataGridView
            if (dataGridViewDanhSachCauHoi.SelectedRows.Count > 0)
            {
                QuestionBankController questionBankController = new QuestionBankController();

                var selectedRow = dataGridViewDanhSachCauHoi.SelectedRows[0];
                string chuong = selectedRow.Cells["Chuong"].Value.ToString();
                string mucDo = selectedRow.Cells["MucDo"].Value.ToString();
                string noiDung = selectedRow.Cells["NoiDung"].Value.ToString();
                string maCauHoi = selectedRow.Cells["MaCauHoi"].Value.ToString();

                // Lấy danh sách các phương án (câu trả lời) từ database
                List<PhuongAn> phuongAns = questionBankController.LoadPhuongAnsByMaCauHoi(maCauHoi);

                string maNHCauHoi = selectedRow.Cells["MaNHCauHoi"].Value.ToString();

                // Gọi form sửa
                frmThemCauHoi frmThemCauHoi = new frmThemCauHoi(maNHCauHoi, _maMonHienTai, noiDung, chuong, mucDo, maCauHoi, phuongAns);
                DialogResult result = frmThemCauHoi.ShowDialog();

                // Nếu người dùng nhấn OK trong form sửa, tải lại dữ liệu
                if (result == DialogResult.OK)
                {
                    LoadData(); // Tải lại dữ liệu
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatDuLieu_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
