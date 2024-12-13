using QTV.Controllers;
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
    public partial class BaithidaKTcuthe : Form
    {

        public BaiThi baithi { get; set; }

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

        public BaithidaKTcuthe()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }




        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        private void BaithidaKTcuthe_deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BaithidaKTcuthe_leave(object sender, EventArgs e)
        {

        }

        private void BaithidaKTcuthe_Load(object sender, EventArgs e)
        {
            StudentController studentController = new StudentController();
            var baiLam = studentController.LoadBaiLam(baithi.MaBaiThi);
            txtTenbaithicuthe.Text = baithi.TenBaiThi;
            txtTenbaithicuthe.Enabled = false;
            txtLopbaithi.Text = baithi.TenLopHP;
            txtLopbaithi.Enabled = false;
            txtMotabaithi.Text = baithi.MoTa;
            txtMotabaithi.Enabled = false;
            txtSocauhoi.Text = baiLam.BatDau.ToString() + " - " + baiLam.KetThuc.ToString();
            txtSocauhoi.Enabled = false;
            // H:i:s of diff of KetThuc and BatDau
            if (baiLam.KetThuc == null)
            {
                guna2TextBox1.Text = "Chưa hoàn thành";
                return;
            }
            else
            {
                DateTime batDau = baiLam.BatDau;
                DateTime ketThuc = baiLam.KetThuc ?? DateTime.Now;

                TimeSpan difference = ketThuc - batDau;


                guna2TextBox1.Text = (string.Format("{0:D2}:{1:D2}:{2:D2}",
                                                           (int)difference.TotalHours,
                                                           difference.Minutes,
                                                           difference.Seconds));
            }
            guna2TextBox1.Enabled = false;
            if(baithi.HienThi == 1)
            {
                guna2TextBox2.Text = baiLam.Diem.ToString();
            } else
            {
                guna2TextBox2.Text = "Bài thi không cho xem điểm";
            }
            guna2TextBox2.Enabled = false;

            if(baithi.XemLai != 1)
            {
                guna2Button1.Hide();
            }



        }

        private void txtTenbaithicuthe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSocauhoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
