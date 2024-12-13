using QTV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTracNghiem.Thanhcongcu
{
    public partial class Baithicuthe : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );

        public BaiThi BaiThi { get; set; }

        public Baithicuthe()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void Baithicuthe_Load(object sender, EventArgs e)
        {
            // update value of txtTenbaithicuthe and make them uneditable
            txtTenbaithicuthe.Text = BaiThi.TenBaiThi;
            txtTenbaithicuthe.Enabled = false;
            txtLopbaithi.Text = BaiThi.TenLopHP;
            txtLopbaithi.Enabled = false;
            txtMotabaithi.Text = BaiThi.MoTa;
            txtMotabaithi.Enabled = false;
            guna2TextBox2.Text = BaiThi.TGBatDau.ToString();
            guna2TextBox2.Enabled = false;
            guna2TextBox3.Text = BaiThi.TGKetThuc.ToString();
            guna2TextBox3.Enabled = false;
            guna2TextBox1.Text = BaiThi.ThoiLuong.ToString();
            guna2TextBox1.Enabled = false;
            txtSocauhoi.Text = BaiThi.SoCauHoi.ToString();
            txtSocauhoi.Enabled = false;


        }



        private void txtSocauhoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Baithicuthe_deactivate(object sender, EventArgs e)
        {
            this.Close();
        }


        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime baiThi_Start = BaiThi.TGBatDau;
            DateTime baiThi_End = BaiThi.TGKetThuc;
            DateTime now = DateTime.Now;
            if(now < baiThi_Start)
            {
                MessageBox.Show("Chưa đến thời gian làm bài");
            }
            else if(now > baiThi_End)
            {
                MessageBox.Show("Đã hết thời gian làm bài");
            }
            else
            {
                this.Hide();
                frmLambai frmLambai = new frmLambai();
                frmLambai.BaiThi = BaiThi;
                frmLambai.ShowDialog();
            }
        }
    }
}
