using Guna.UI2.WinForms;
using QL_Trac_Nghiem;
using QTV.Controllers;
using QTV.Models;
using QTV.Views.General;
using QTV.Views.GiangVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTV.Usercontrol.giangVien
{
    public partial class UcNHCauHoi : UserControl
    {
        private MonHoc monHocHienTai;
        private bool isProcessing = false; // Cờ kiểm tra trạng thái xử lý
        public UcNHCauHoi(MonHoc monHoc)
        {
            monHocHienTai = monHoc;
            InitializeComponent();
            LoadData(monHoc.MaMon);
        }

        public void LoadData(string maMon)
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            // Xóa dữ liệu cũ
            dataGridViewNHCauHoi.DataSource = null;
            dataGridViewNHCauHoi.Columns.Clear(); // Xóa toàn bộ các cột cũ

            // Hủy đăng ký sự kiện cũ trước khi đăng ký sự kiện mới
            dataGridViewNHCauHoi.CellClick -= dataGridViewNHCauHoi_CellClick;

            // Gọi phương thức LoadQuestionBank từ lớp chứa phương thức này
            QuestionBankController questionBankController = new QuestionBankController();
            DataTable dt = questionBankController.LoadQuestionBank(maMon);

            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridViewNHCauHoi.DataSource = dt; // Gán dữ liệu vào DataGridView

                // Thêm cột nút "Xóa"
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "DeleteColumn",
                    HeaderText = "Xóa",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true,
                    // AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dataGridViewNHCauHoi.Columns.Add(deleteButtonColumn);

                // Thêm cột "Danh sách câu hỏi"
                DataGridViewButtonColumn questionsButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "QuestionsColumn",
                    HeaderText = "Danh sách câu hỏi",
                    Text = "Xem câu hỏi",
                    UseColumnTextForButtonValue = true,
                    // AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                dataGridViewNHCauHoi.Columns.Add(questionsButtonColumn);

                dataGridViewNHCauHoi.CellClick += dataGridViewNHCauHoi_CellClick;
            }
            else
            {
                // Tạo bảng rỗng với cấu trúc
                dataGridViewNHCauHoi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ThongBao",
                    HeaderText = "Không có dữ liệu",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            }
            loadingBox.Close();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadData(monHocHienTai.MaMon);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maMon = monHocHienTai.MaMon;
            string maGV = UserSession.Instance.UserId; // Lấy mã giảng viên từ session

            frmThemNHCauHoi frmThemNHCauHoi = new frmThemNHCauHoi(maMon: maMon, maGV: maGV);
            frmThemNHCauHoi.ShowDialog();
            LoadData(maMon);
        }

        private void dataGridViewNHCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isProcessing) return; // Nếu đang xử lý, không tiếp tục

            // Bỏ qua nếu nhấp vào tiêu đề hoặc ngoài vùng dữ liệu
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                isProcessing = true; // Đánh dấu bắt đầu xử lý

                // Kiểm tra nếu cột được click là cột "Xóa"
                if (e.RowIndex >= 0 && dataGridViewNHCauHoi.Columns[e.ColumnIndex].Name == "DeleteColumn")
                {
                    // Lấy giá trị của MaNHCauHoi từ dòng được chọn
                    string maNHCauHoi = dataGridViewNHCauHoi.Rows[e.RowIndex].Cells["MaNHCauHoi"].Value?.ToString();

                    if (!string.IsNullOrEmpty(maNHCauHoi))
                    {
                        // Hiển thị hộp thoại xác nhận
                        DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (confirm == DialogResult.Yes)
                        {
                            // Gọi phương thức xóa từ QuestionBankController
                            QuestionBankController questionBankController = new QuestionBankController();
                            bool isDeleted = questionBankController.DeleteQuestionBank(maNHCauHoi);

                            if (isDeleted)
                            {
                                // Xóa dòng trong DataGridView
                                dataGridViewNHCauHoi.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                // Kiểm tra nếu người dùng bấm vào cột "Danh sách câu hỏi"
                else if (e.RowIndex >= 0 && dataGridViewNHCauHoi.Columns[e.ColumnIndex].Name == "QuestionsColumn")
                {
                    // Lấy mã môn từ dữ liệu trong dòng hiện tại
                    string maMon = monHocHienTai.MaMon;

                    if (!string.IsNullOrEmpty(maMon))
                    {
                        // Lấy dữ liệu của dòng hiện tại
                        var selectedRow = dataGridViewNHCauHoi.Rows[e.RowIndex];
                        NHCauHoi nhCauHoi = new NHCauHoi
                        {
                            MaNHCauHoi = selectedRow.Cells["MaNHCauHoi"].Value?.ToString(),
                            TenNHCauHoi = selectedRow.Cells["TenNHCauHoi"].Value?.ToString(),
                            MaGV = selectedRow.Cells["MaGV"].Value?.ToString(),
                            MaMon = selectedRow.Cells["MaMon"].Value?.ToString(),
                        };

                        if (!string.IsNullOrEmpty(nhCauHoi.MaNHCauHoi))
                        {
                            // Mở frmListCauHoi và truyền đối tượng NHCauHoi
                            frmListCauHoi listCauHoi = new frmListCauHoi(maMonHienTai: monHocHienTai.MaMon, nhCauHoiHienTai: nhCauHoi);
                            listCauHoi.Show();
                        }
                        else
                        {
                            MessageBox.Show("Thông tin Ngân hàng câu hỏi không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Mở frmListCauHoi và truyền mã môn vào
                        // frmListCauHoi listCauHoi = new frmListCauHoi(maMonHienTai: maMon, nhCauHoiHienTai: );
                        // listCauHoi.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Mã môn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false; // Đặt lại cờ sau khi hoàn tất xử lý
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ dòng được chọn trong DataGridView
            if (dataGridViewNHCauHoi.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewNHCauHoi.SelectedRows[0];
                string maNHCauHoi = selectedRow.Cells["MaNHCauHoi"].Value.ToString();
                string tenNHCauHoi = selectedRow.Cells["TenNHCauHoi"].Value.ToString();

                // Gọi form sửa
                frmThemNHCauHoi frmThemNHCauHoi = new frmThemNHCauHoi(monHocHienTai.MaMon, UserSession.Instance.UserId, maNHCauHoi, tenNHCauHoi);
                DialogResult result = frmThemNHCauHoi.ShowDialog();

                // Nếu người dùng nhấn OK trong form sửa, tải lại dữ liệu
                if (result == DialogResult.OK)
                {
                    LoadData(monHocHienTai.MaMon); // Tải lại dữ liệu
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần sửa.");
            }
        }

        private void btnListCauHoi_Click(object sender, EventArgs e)
        {

        }
    }
}
