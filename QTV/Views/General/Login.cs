using QL_Trac_Nghiem;
using QTV;
using QTV.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTracNghiem
{
    public partial class FrmLogin : Form
    {

        private string init_role = "";

        public FrmLogin(string init_role = "QTV")
        {
            InitializeComponent();
            this.init_role = init_role;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Đặt vị trí của mainPanel ở giữa form
            mainPanel.Left = (this.ClientSize.Width - mainPanel.Width) / 2;
            mainPanel.Top = (this.ClientSize.Height - mainPanel.Height) / 2;

            // Đặt vị trí PictureBox vào giữa mainPanel
            //img.Left = (mainPanel.ClientSize.Width - img.Width) / 2;
            //img.Top = (mainPanel.ClientSize.Height - img.Height) / 2;

            // Đặt PictureBox căn giữa theo chiều ngang trong mainPanel
            img.Left = (mainPanel.ClientSize.Width - img.Width) / 2;
            // Giữ nguyên vị trí theo chiều dọc
            img.Top = img.Top;

            title.Left = (mainPanel.ClientSize.Width - title.Width) / 2;
            title.Top = title.Top;

            txttaikhoan.Left = (mainPanel.ClientSize.Width - txttaikhoan.Width) / 2;
            txttaikhoan.Top = txttaikhoan.Top;

            txtmatkhau.Left = (mainPanel.ClientSize.Width - txtmatkhau.Width) / 2;
            txtmatkhau.Top = txtmatkhau.Top;

            buttdangnhap.Left = (mainPanel.ClientSize.Width - buttdangnhap.Width) / 2;
            buttdangnhap.Top = buttdangnhap.Top;

            buttChonVaiTro.Left = (mainPanel.ClientSize.Width - buttChonVaiTro.Width) / 2;
            buttChonVaiTro.Top = buttChonVaiTro.Top;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txttaikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttdangnhap_Click(object sender, EventArgs e)
        {
            this.performLogin(this.init_role);
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmPhanquyen frm = new frmPhanquyen();
            frm.Show();
            this.Hide();
        }

        private void performLogin(string role)
        {
            string username = txttaikhoan.Text;
            string password = txtmatkhau.Text;
            AuthController authController = new AuthController();

            bool isAuthenticated = authController.Authenticate(username, password, role);
            if (isAuthenticated)
            {
                var userSession = UserSession.Instance;
                switch (UserSession.Instance.UserRole)
                {
                    case "QTV":
                        giaodienQTV giaodienQTV = new giaodienQTV();
                        giaodienQTV.Show();
                        this.Hide();
                        break;
                    case "GiangVien":
                        frmMonHoc frmMonHoc = new frmMonHoc();
                        frmMonHoc.Show();
                        this.Hide();
                        break;
                    case "SinhVien":
                        frmtrangchusv frmtrangchusv = new frmtrangchusv();
                        frmtrangchusv.Show();
                        this.Hide();
                        break;
                }
            }
            else
            {
                // if the user is not authenticated, show an error message
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi đóng form
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi màn hình này và quay lại trang phân quyền không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                // Hủy việc đóng form
                e.Cancel = true;
                return;
            }

            // Nếu người dùng xác nhận, mở form phân quyền
            frmPhanquyen phanquyen = new frmPhanquyen();
            phanquyen.Show();
        }

        private void chkboxnhomatkhau_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ImageCheckBox2.Checked)
            {
                txtmatkhau.PasswordChar = '\0';
            }
            else
            {
                txtmatkhau.PasswordChar = '*';
            }
        }

        private void txtmatkhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
