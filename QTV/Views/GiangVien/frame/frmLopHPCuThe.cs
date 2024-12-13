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
    public partial class frmLopHPCuThe : Form
    {
        private Guna2HtmlLabel lblNoData;
        private LopHP _lopHPHienTai;
        private string _maMonHienTai;
        private UcBaiThiItem _baiThiDangDuocChon = null;
        public frmLopHPCuThe(string maMon, LopHP lopHP)
        {
            InitializeComponent();
            this._lopHPHienTai = lopHP;
            this._maMonHienTai = maMon;

            CreateNoDataLabel();
            LoadData(_lopHPHienTai.MaLHP);
        }
        private void frmLopHPCuThe_Load(object sender, EventArgs e)
        {
            containerPanel.Left = (this.ClientSize.Width - containerPanel.Width) / 2;
            containerPanel.Top = (this.ClientSize.Height - containerPanel.Height) / 2;

            this.Text = $"{_lopHPHienTai.TenLHP}";
            if (tbTenLopHPCuThe != null && tbTenLopHPCuThe.Text == "")
            {
                tbTenLopHPCuThe.Text = _lopHPHienTai.TenLHP;
            }
        }
        private void CreateNoDataLabel()
        {
            lblNoData = new Guna2HtmlLabel
            {
                Text = "Không có dữ liệu",
                TextAlignment = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                Visible = false
            };
            flpDanhSachBaiThi.Controls.Add(lblNoData);
        }
        private void LoadData(string maLopHP)
        {
            if (!string.IsNullOrEmpty(maLopHP))
            {
                QuizController quizController = new QuizController();
                DataTable dataTable = quizController.LoadQuiz(maLopHP);

                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    lblNoData.Visible = true;
                }
                else
                {
                    lblNoData.Visible = false;
                    flpDanhSachBaiThi.Controls.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var baiThi = new BaiThi
                        {
                            MaBaiThi = row["MaBaiThi"].ToString(),
                            TenBaiThi = row["TenBaiThi"].ToString(),
                            MoTa = row["MoTa"]?.ToString(),
                            MaDeThi = row["MaDeThi"]?.ToString(),
                            TGBatDau = DateTime.Parse(row["TGBatDau"].ToString()),
                            TGKetThuc = DateTime.Parse(row["TGKetThuc"].ToString()),
                            ThoiLuong = short.Parse(row["ThoiLuong"].ToString()),
                            MaGV = row["GV"].ToString(),
                            LopHP = row["LopHP"].ToString(),
                            // TenGiangVien = row["TenGiangVien"].ToString(),
                            // TenLopHP = row["TenLopHP"].ToString()
                        };

                        // Tạo một UserControl item cho mỗi bài thi
                        UcBaiThiItem ucItem = new UcBaiThiItem
                        {
                            BaiThi = baiThi,
                            TenBaiThi = baiThi.TenBaiThi,
                            TGThi = baiThi.TGBatDau.ToString(),
                        };

                        ucItem.ItemClicked += (s, baiThi) =>
                        {
                            // Nếu đã có item được chọn, bỏ chọn item cũ
                            if (_baiThiDangDuocChon != null)
                            {
                                _baiThiDangDuocChon.BackColor = System.Drawing.Color.Transparent;
                            }
                            _baiThiDangDuocChon = ucItem;
                            _baiThiDangDuocChon.BackColor = System.Drawing.Color.LightBlue;
                        };

                        flpDanhSachBaiThi.Controls.Add(ucItem);
                    }
                }
            }
            else
            {
                lblNoData.Visible = true;
            }
        }

        private void btnThemBaiThi_Click(object sender, EventArgs e)
        {
            string maGV = UserSession.Instance.UserId;
            bool editMode = false;

            frmThemBaiThi frmThemBaiThi = new frmThemBaiThi(editMode, _maMonHienTai, _lopHPHienTai.MaLHP);
            frmThemBaiThi.ShowDialog();
            LoadData(_lopHPHienTai.MaLHP);
        }

        private void btnSuaBaiThi_Click(object sender, EventArgs e)
        {
            bool editMode = true;
            if (_baiThiDangDuocChon != null)
            {
                QuizController quizController = new QuizController();

                var baiThiDangDuocChon = _baiThiDangDuocChon.BaiThi;
                DataTable dt = quizController.GetQuizByMaBaiThi(baiThiDangDuocChon.MaBaiThi);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Gán giá trị từ DataTable vào đối tượng baiThiDangDuocChon
                    baiThiDangDuocChon.MaBaiThi = row["MaBaiThi"].ToString();
                    baiThiDangDuocChon.TenBaiThi = row["TenBaiThi"].ToString();
                    baiThiDangDuocChon.MoTa = row["MoTa"].ToString();
                    baiThiDangDuocChon.MaDeThi = row["MaDeThi"].ToString();
                    baiThiDangDuocChon.TGBatDau = Convert.ToDateTime(row["TGBatDau"]);
                    baiThiDangDuocChon.TGKetThuc = Convert.ToDateTime(row["TGKetThuc"]);
                    baiThiDangDuocChon.ThoiLuong = Convert.ToInt32(row["ThoiLuong"]);
                    baiThiDangDuocChon.HienThi = Convert.ToInt32(row["HienThiDiem"]);
                    baiThiDangDuocChon.XemLai = Convert.ToInt32(row["XemBaiLam"]);
                    baiThiDangDuocChon.XaoTron = Convert.ToInt32(row["TronCauHoi"]);

                    Debug.WriteLine("Mã bài thi: " + baiThiDangDuocChon.MaBaiThi);
                    Debug.WriteLine("Tên bài thi: " + baiThiDangDuocChon.TenBaiThi);
                    Debug.WriteLine("Mô tả bài thi: " + baiThiDangDuocChon.MoTa);
                    Debug.WriteLine("Mã đề thi: " + baiThiDangDuocChon.MaDeThi);
                    Debug.WriteLine("Thời lượng bài thi: " + baiThiDangDuocChon.ThoiLuong);
                    Debug.WriteLine("Thời gian bắt đầu làm bài thi: " + baiThiDangDuocChon.TGBatDau);
                    Debug.WriteLine("Thời gian kết thúc làm bài thi: " + baiThiDangDuocChon.TGKetThuc);
                    Debug.WriteLine("Hiển thị: " + baiThiDangDuocChon.HienThi);
                    Debug.WriteLine("Xem lại: " + baiThiDangDuocChon.XemLai);
                    Debug.WriteLine("Xáo trộn: " + baiThiDangDuocChon.XaoTron);

                    frmThemBaiThi frmThemBaiThi = new frmThemBaiThi(editMode, _maMonHienTai, _lopHPHienTai.MaLHP, baiThiDangDuocChon);
                    frmThemBaiThi.ShowDialog();
                    _baiThiDangDuocChon = null;
                    LoadData(_lopHPHienTai.MaLHP);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bài thi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài thi để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhatDuLieu_Click(object sender, EventArgs e)
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            LoadData(_lopHPHienTai.MaLHP);
            loadingBox.Close();
        }

        private void btnXoaBaiThi_Click(object sender, EventArgs e)
        {
            if (_baiThiDangDuocChon != null)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bài thi này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    QuizController quizController = new QuizController();
                    bool isDeleted = quizController.DeleteQuiz(_baiThiDangDuocChon.BaiThi.MaBaiThi);

                    if (isDeleted)
                    {
                        MessageBox.Show("Bài thi đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(_lopHPHienTai.MaLHP);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa bài thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài thi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbTenLopHPCuThe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
