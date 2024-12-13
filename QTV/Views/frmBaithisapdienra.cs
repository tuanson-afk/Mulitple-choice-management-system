using QTV.Controllers;
using QTV.Models;
using QTV.Usercontrol.sinhVien;
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

namespace QuanLyTracNghiem
{
    public partial class frmBaithisapdienra : Form
    {
        public frmBaithisapdienra()
        {
            InitializeComponent();
            loadListBaiThiSapDienRa();
        }
        private void loadListBaiThiSapDienRa(string searchString = "")
        {
            StudentController studentController = new StudentController();
            var baiThiSapDienRa = studentController.transformBaiThiSapDienRa(searchString);

            foreach (var baiThi in baiThiSapDienRa)
            {
                UcBaiThiSapDienRa ucItem = new UcBaiThiSapDienRa();
                ucItem.TenBaiThi = baiThi.TenBaiThi;
                ucItem.TenLopHP = baiThi.TenLopHP;
                ucItem.NgayThi = baiThi.TGBatDau;

                ucItem.BaiThi = baiThi; // Gán đối tượng BaiThi

                // Đăng ký sự kiện OnItemClicked
                // ucItem.OnItemClicked += Item_Clicked;   

                // Đăng ký sự kiện click vào UserControl
                // ucItem.ItemClicked += ItemControl_UserControlClicked;

                // Đăng ký sự kiện click vào nút "Làm Bài"
                ucItem.LamBaiClicked += UcItem_LamBaiClicked;

                ucItem.ItemClicked += (s, baiThi) =>
                {
                    ShowExamDetails(baiThi);
                };

                flpBaiThiSapDienRaMain.Controls.Add(ucItem);
            }
        }

        private void clearListBaiThiSapDienRa()
        {
            flpBaiThiSapDienRaMain.Controls.Clear();
        }

        private void UcItem_LamBaiClicked(object sender, BaiThi baiThi)
        {
            // Xử lý khi click vào nút "Làm Bài"
            ShowExamDetails(baiThi);
        }

        private void ShowExamDetails(BaiThi baiThi)
        {
            Baithicuthe baithicuthe = new Baithicuthe();
            baithicuthe.BaiThi = baiThi;
            baithicuthe.ShowDialog();

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmBaithisapdienra_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
