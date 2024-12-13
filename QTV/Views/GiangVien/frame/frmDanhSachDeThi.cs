using DocumentFormat.OpenXml.Spreadsheet;
using Guna.UI2.WinForms;
using QL_Trac_Nghiem;
using QTV.Controllers;
using QTV.Models;
using QTV.Usercontrol.giangVien;
using QTV.Views.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTV.Views.GiangVien
{
    public partial class frmDanhSachDeThi : Form
    {
        private Guna2HtmlLabel lblNoData;
        private MonHoc _monHocHienTai;
        private UcDeThiItem _deThiDangDuocChon = null;

        public frmDanhSachDeThi(MonHoc monHoc)
        {
            InitializeComponent();
            this._monHocHienTai = monHoc;

            CreateNoDataLabel();
            LoadData(_monHocHienTai.MaMon);
        }
        private void CreateNoDataLabel()
        {
            lblNoData = new Guna2HtmlLabel
            {
                Text = "Không có dữ liệu",
                TextAlignment = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = System.Drawing.Color.Gray, // Chỉ rõ namespace
                BackColor = System.Drawing.Color.Transparent, // Chỉ rõ namespace
                Visible = false
            };
            flpDanhSachDeThi.Controls.Add(lblNoData);
        }
        private void LoadData(string maMon)
        {
            SubjectController subjectController = new SubjectController();
            DataTable dataTable = subjectController.LoadDeThiFromMonHoc(_monHocHienTai.MaMon);

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                lblNoData.Visible = true;
            }
            else
            {
                lblNoData.Visible = false;
                flpDanhSachDeThi.Controls.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    var deThi = new DeThi
                    {
                        MaDeThi = row["MaDeThi"].ToString(),
                        TenDeThi = row["TenDeThi"].ToString(),
                        MaGiaoVien = row["MaGV"].ToString(),
                        MaMon = row["MaMon"].ToString(),
                    };
                    UcDeThiItem ucItem = new UcDeThiItem
                    {
                        DeThi = deThi,
                        TenDeThi = deThi.TenDeThi,
                        MaDeThi = deThi.MaDeThi,
                    };
                    ucItem.ItemClicked += (s, deThi) =>
                    {
                        // Nếu đã có item được chọn, bỏ chọn item cũ
                        if (_deThiDangDuocChon != null)
                        {
                            _deThiDangDuocChon.BackColor = System.Drawing.Color.Transparent;
                        }
                        _deThiDangDuocChon = ucItem;
                        _deThiDangDuocChon.BackColor = System.Drawing.Color.LightBlue;
                    };
                    flpDanhSachDeThi.Controls.Add(ucItem);
                }
            }
        }
        private void frmDanhSachDeThi_Load(object sender, EventArgs e)
        {
            containerPanel.Left = (mainPanel.Width - containerPanel.Width) / 2;
            containerPanel.Top = (mainPanel.Height - containerPanel.Height) / 2;
        }

        private void btnCapNhatDuLieu_Click(object sender, EventArgs e)
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            LoadData(_monHocHienTai.MaMon);
            loadingBox.Close();
        }

        private void btnThemDeThi_Click(object sender, EventArgs e)
        {
            bool editMode = false;

            frmThemDeThi frmThemDeThi = new frmThemDeThi(editMode, _monHocHienTai);
            frmThemDeThi.ShowDialog();
            LoadData(_monHocHienTai.MaMon);
        }

        private void btnSuaDeThi_Click(object sender, EventArgs e)
        {
            if (_deThiDangDuocChon != null)
            {
                QuizController quizController = new QuizController();
                bool editMode = true;
                var selectedExam = _deThiDangDuocChon.DeThi; // Lấy thông tin đề thi đã chọn
                // DataTable dt = quizController.GetQuestionsByExamId(selectedExam.MaDeThi);
                selectedExam.MaChuong = quizController.GetMaChuongByMaDeThi(_deThiDangDuocChon.MaDeThi);
                selectedExam.MaMucDo = quizController.GetMaMucDoByMaDeThi(_deThiDangDuocChon.MaDeThi);
                selectedExam.DanhSachMaCauHoiDaChon = quizController.GetQuestionsByExamId(selectedExam.MaDeThi);

                Debug.WriteLine("Mã đề thi: " + selectedExam.MaDeThi);
                Debug.WriteLine("Tên đề thi: " + selectedExam.TenDeThi);
                Debug.WriteLine("Mã chương đề thi: " + selectedExam.MaChuong);
                Debug.WriteLine("Mã mức độ đề thi: " + selectedExam.MaMucDo);
                for (int i = 0; i < selectedExam.DanhSachMaCauHoiDaChon.Count; i++)
                {
                    Debug.WriteLine("Mã câu hỏi: " + selectedExam.DanhSachMaCauHoiDaChon[i]);
                }

                // Truyền thông tin đề thi sang form frmThemDeThi
                frmThemDeThi frmThemDeThi = new frmThemDeThi(editMode, _monHocHienTai, selectedExam);
                frmThemDeThi.ShowDialog();

                LoadData(_monHocHienTai.MaMon); // Cập nhật lại danh sách sau khi sửa
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đề thi để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaDeThi_Click(object sender, EventArgs e)
        {
            if (_deThiDangDuocChon != null)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa đề thi này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Gọi phương thức xóa đề thi từ cơ sở dữ liệu (ví dụ gọi vào controller)
                    QuizController quizController = new QuizController();
                    bool isDeleted = quizController.DeleteExam(_deThiDangDuocChon.DeThi.MaDeThi);

                    if (isDeleted)
                    {
                        MessageBox.Show("Đề thi đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(_monHocHienTai.MaMon); // Cập nhật lại dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa đề thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đề thi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void containerPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
