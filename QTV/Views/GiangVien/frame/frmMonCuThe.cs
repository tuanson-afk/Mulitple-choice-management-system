using DocumentFormat.OpenXml.Spreadsheet;
using Guna.UI2.WinForms;
using QTV.Controllers;
using QTV.Models;
using QTV.Usercontrol;
using QTV.Usercontrol.giangVien;
using QTV.Views.General;
using QTV.Views.GiangVien;
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
using System.Xml.Linq;

namespace QL_Trac_Nghiem
{
    public partial class frmMonCuThe : Form
    {
        private MonHoc currentMonHoc;
        private Guna2HtmlLabel lblNoData;
        public event Action MonHocFormClosed; // Sự kiện khi form đóng
        public frmMonCuThe(MonHoc monHoc)
        {
            InitializeComponent();

            this.currentMonHoc = monHoc;

            // Cài đặt để form hiển thị toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            lblTenMonHienTai.Text = currentMonHoc.TenMon;

            CreateNoDataLabel();
            loadData(maMon: monHoc.MaMon);
        }

        private void CreateNoDataLabel()
        {
            lblNoData = new Guna2HtmlLabel
            {
                Text = "Không có dữ liệu",
                TextAlignment = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = System.Drawing.Color.Gray,
                BackColor = System.Drawing.Color.Transparent,
                Visible = false
            };
            flpLopHP.Controls.Add(lblNoData);
            flpDeThi.Controls.Add(lblNoData);
        }

        private void loadData(String maMon)
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            loadListLopHP(maMon);
            loadListDeThi(maMon);
            loadNHCauHoi(maMon);
            loadingBox.Close();
        }

        private void loadListLopHP(String maMon)
        {
            SubjectController subjectController = new SubjectController();
            DataTable dataTable = subjectController.LoadLopHPFromMonHoc(maMon: maMon);

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                Guna2HtmlLabel lblNoDataLopHP = new Guna2HtmlLabel
                {
                    Text = "Không có lớp học phần - Xin hãy liên lạc quản trị viên!",
                    TextAlignment = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    ForeColor = System.Drawing.Color.Gray,
                    BackColor = System.Drawing.Color.Transparent,
                    Visible = true
                };
                flpLopHP.Controls.Add(lblNoDataLopHP);
            }
            else
            {
                lblNoData.Visible = false;
                flpLopHP.Controls.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    var lopHP = new LopHP()
                    {
                        MaLHP = row["MaLHP"].ToString(),
                        TenLHP = row["TenLHP"].ToString(),
                    };

                    UcLopHPItem ucItem = new UcLopHPItem
                    {
                        lopHP = lopHP,
                        MaLHP = lopHP.MaLHP,
                        TenLHP = lopHP.TenLHP
                    };

                    ucItem.ItemClicked += (s, lopHP) =>
                    {
                        frmLopHPCuThe frmLopHPCuThe = new frmLopHPCuThe(maMon, lopHP);
                        frmLopHPCuThe.Show();
                    };

                    flpLopHP.Controls.Add(ucItem);
                }
            }
        }
        private void loadListDeThi(String maMon)
        {
            SubjectController subjectController = new SubjectController();
            DataTable dataTable = subjectController.LoadDeThiFromMonHoc(maMon: maMon);

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                lblNoData.Visible = true;
            }
            else
            {
                lblNoData.Visible = false;
                flpDeThi.Controls.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    var deThi = new DeThi()
                    {
                        MaDeThi = row["MaDeThi"].ToString(),
                        TenDeThi = row["TenDeThi"].ToString(),
                    };

                    UcDeThiItem ucItem = new UcDeThiItem
                    {
                        DeThi = deThi,
                        MaDeThi = deThi.MaDeThi,
                        TenDeThi = deThi.TenDeThi
                    };

                    ucItem.ItemClicked += (s, deThi) =>
                    {
                        // MessageBox.Show("Chi tiết Đề thi: " + deThi.TenDeThi);

                        frmDanhSachDeThi frmDanhSachDeThi = new frmDanhSachDeThi(currentMonHoc);
                        frmDanhSachDeThi.Show();
                    };

                    flpDeThi.Controls.Add(ucItem);
                }
            }
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelNHCauHoi.Controls.Clear();
            panelNHCauHoi.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void loadNHCauHoi(String maMon)
        {

            UcNHCauHoi ucNHCauHoi = new UcNHCauHoi(currentMonHoc);
            ucNHCauHoi.LoadData(maMon);

            addUserControl(((UserControl)ucNHCauHoi));


            // frmNganHangCauHoi childForm = new frmNganHangCauHoi(maMon);

            // Xóa tất cả các control đang hiển thị trên panel
            // panelNHCauHoi.Controls.Clear();

            // Cài đặt các thuộc tính để nhúng form con
            // childForm.TopLevel = false;                        // Biến Form thành Control
            // childForm.FormBorderStyle = FormBorderStyle.None;  // Xóa viền và thanh tiêu đề của form con
            // childForm.Dock = DockStyle.Fill;

            // Thêm vào panel
            // panelNHCauHoi.Controls.Add(childForm);

            // Hiển thị form con
            // childForm.Show();
        }
        private void btnNHCauHoi_Click(object sender, EventArgs e)
        {
            loadNHCauHoi(maMon: currentMonHoc.MaMon);
        }
        private void frmMonCuThe_Load(object sender, EventArgs e)
        {
            groupBox1.Left = (this.ClientSize.Width - groupBox1.Width) / 2;
            groupBox1.Top = groupBox1.Top;

            groupBox2.Left = (this.ClientSize.Width - groupBox2.Width) / 2;
            groupBox2.Top = groupBox2.Top;

            groupBox3.Left = (this.ClientSize.Width - groupBox3.Width) / 2;
            groupBox3.Top = groupBox3.Top;

            lblTenMonHienTai.Left = (this.ClientSize.Width - lblTenMonHienTai.Width) / 2;
            lblTenMonHienTai.Top = lblTenMonHienTai.Top;
        }

        private void btnDeThi_Click(object sender, EventArgs e)
        {
            frmDanhSachDeThi frmDanhSachDeThi = new frmDanhSachDeThi(currentMonHoc);
            frmDanhSachDeThi.Show();
        }
    }
}
