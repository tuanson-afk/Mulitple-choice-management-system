using QuanLyTracNghiem.Thanhcongcu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTV.Controllers;

namespace QuanLyTracNghiem
{
    public partial class frmtrangchusv : Form
    {
        public frmtrangchusv()
        {
            InitializeComponent();
            TCC_Baithi uc = new TCC_Baithi();
            addThanhcongcu(uc);
            
            guna2Button4.Text = "Xin chào, " + UserSession.Instance.UserName + ". Thoát?";
        }

        private void addThanhcongcu(UserControl thanhcongcu)
        {
            thanhcongcu.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(thanhcongcu);
            thanhcongcu.BringToFront();
        }

        private void buttBaithi_Click(object sender, EventArgs e)
        {
            TCC_Baithi uc = new TCC_Baithi();
            addThanhcongcu(uc);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panThanhcongcu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            frmPhanquyen frm = new frmPhanquyen();
            frm.Show();
            this.Hide();
        }
    }
}
