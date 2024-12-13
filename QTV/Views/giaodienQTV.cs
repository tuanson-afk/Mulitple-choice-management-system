using QTV.Controllers;
using QTV.Usercontrol;
using QuanLyTracNghiem;

namespace QTV
{
    public partial class giaodienQTV : Form
    {
        public giaodienQTV()
        {
            InitializeComponent();
            UC_Quanlysinhvien uc = new UC_Quanlysinhvien();
            addUsserControl((UserControl)uc);

            // update guna2Button4 text to UserSession.Instance.UserName
            guna2Button4.Text = "Xin chào, " + UserSession.Instance.UserName + ". Thoát?";
        }

        private void addUsserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            UC_Quanlysinhvien uc = new UC_Quanlysinhvien();
            addUsserControl((UserControl)uc);
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            UC_Quanlygiang_vien uc = new UC_Quanlygiang_vien();
            addUsserControl(((UserControl)uc));
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            UC_QLLHP uc = new UC_QLLHP();
            addUsserControl(((UserControl)uc));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // show dialog to confirm logout
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // if yes, logout
                this.Hide();
                FrmLogin login = new FrmLogin();
                login.Show();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UC_QLMonHoc uc = new UC_QLMonHoc();
            addUsserControl(((UserControl)uc));
        }

    }
}
