using QTV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTracNghiem.Thanhcongcu;
using PdfiumViewer;
using System.Drawing.Printing;
using QTV.Views;

namespace QuanLyTracNghiem
{
    public partial class frmPhanquyen : Form
    {
        public frmPhanquyen()
        {
            InitializeComponent();
            // SetUp();
        }

        private void SetUp()
        {
            this.FormClosing -= frmPhanquyen_FormClosing;
            // this.FormClosing += frmPhanquyen_FormClosing;
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin("SinhVien");
            frmLogin.Show();
            this.Hide();
        }

        private void guna2Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin("GiangVien");
            frmLogin.Show();
            this.Hide();
        }

        private void guna2Panel3_MouseDown(object sender, MouseEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin("QTV");
            frmLogin.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // debug only
            TCC_Baithi frm = new TCC_Baithi();
            frm.Show();
            this.Hide();
        }

        private void frmPhanquyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn kết thúc chương trình không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát chương trình
            }
            else
            {
                e.Cancel = true; // Hủy đóng form nếu chọn No
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void buttChonVaiTro_Click(object sender, EventArgs e)
        {
            frmHDSD frmHDSD = new frmHDSD();
            frmHDSD.Show();
        }
    }
}
