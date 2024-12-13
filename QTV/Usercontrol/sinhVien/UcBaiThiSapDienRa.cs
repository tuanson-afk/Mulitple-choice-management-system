using QTV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QTV.Usercontrol.sinhVien
{
    public partial class UcBaiThiSapDienRa : UserControl

    {
        public List<String> imgList = new List<string>();

        public BaiThi BaiThi { get; set; }
        public event EventHandler<BaiThi> LamBaiClicked;
        public event EventHandler<BaiThi> ItemClicked; // Sự kiện Click toàn bộ item
        public string TenBaiThi { get => lblTenBaiThi.Text; set => lblTenBaiThi.Text = value; }
        public string TenLopHP { get => lblTenLopHP.Text; set => lblTenLopHP.Text = value; }
        public DateTime NgayThi { get => DateTime.Parse(lblTGBatDau.Text); set => lblTGBatDau.Text = value.ToString("dd/MM/yyyy HH:mm"); }

        public UcBaiThiSapDienRa()
        {
            InitializeComponent();
            SetupEvents();
            randomImg();

            // Thêm sự kiện Click cho UserControl
            // btnLamBai.Click += btnLamBai_Click; // Làm bài
            // this.Click += UcBaiThiSapDienRa_Click; // Toàn bộ UserControl
            // SetupControl();
        }

        private void randomImg()
        {
            List<string> imageResources = new List<string>
{
                "abstract-6284460_19201",
                "abstract-6655422_640",
                "abstract-6655422_6401",
                "art-6812247_6402",
                "art-7008029_6402",
                "art-7008029_6403",
                "art-7065738_6404",
                "background-6055745_640",
                "background-6055791_6405",
                "background-6055795_6401",
                "background-6055853_6401",
                "background-6490417_640",
                "background-6655444_6406",
                "background-6906321_640",
                "background-6906321_6401",
                "background-7009746_6402",
                "background-7036097_640",
                "background-7037896_640",
                "background-7054265_6401",
                "blue-5520553_1920"
            };

            Random random = new Random();

            string selectedImageResource = imageResources[random.Next(imageResources.Count)];
            if((Image)Properties.Resources.ResourceManager.GetObject(selectedImageResource) != null)
            {
                img.Image = (Image)Properties.Resources.ResourceManager.GetObject(selectedImageResource);
            }
            else
            {
                img.Image = (Image)Properties.Resources.ResourceManager.GetObject("abstract-6284460_1920");
            }

        }
        private void SetupEvents()
        {
            this.Click += UcBaiThiSapDienRa_Click;
            mainPanel.Click += UcBaiThiSapDienRa_Click;
            img.Click += UcBaiThiSapDienRa_Click;
            lblTenBaiThi.Click += UcBaiThiSapDienRa_Click;
            lblTenLopHP.Click += UcBaiThiSapDienRa_Click;
            lblTGBatDau.Click += UcBaiThiSapDienRa_Click;
            container.Click += UcBaiThiSapDienRa_Click;

            btnLamBai.Click += btnLamBai_Click;
        }
        private void SetupControl()
        {
            // Thiết lập main panel
            mainPanel = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = new Size(300, 80),
                FillColor = Color.White,
                BorderRadius = 10,
                Dock = DockStyle.Fill
            };

            // Thiết lập image
            img = new Guna.UI2.WinForms.Guna2PictureBox
            {
                Size = new Size(60, 60),
                BorderRadius = 5,
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Thiết lập Tên bài thi
            lblTenBaiThi = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(80, 10),
                MaximumSize = new Size(200, 0),
                AutoSize = false
            };

            // Thiết lập tên lớp
            lblTenLopHP = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Font = new Font("Segoe UI", 9),
                Location = new Point(80, 35),
                ForeColor = Color.Gray,
                MaximumSize = new Size(200, 0),
                AutoSize = false
            };

            // Thiết lập thời gian
            lblTGBatDau = new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Font = new Font("Segoe UI", 9),
                Location = new Point(80, 60),
                ForeColor = Color.Gray,
                MaximumSize = new Size(200, 0),
                AutoSize = false
            };

            // Thiết lập nút "Làm bài"
            btnLamBai = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Làm bài",
                Location = new Point(200, 80),
                Size = new Size(80, 25),
                BorderRadius = 5
            };

            // Thêm controls vào panel
            mainPanel.Controls.Add(lblTenBaiThi);
            mainPanel.Controls.Add(lblTenLopHP);
            mainPanel.Controls.Add(lblTGBatDau);
            mainPanel.Controls.Add(btnLamBai);
            mainPanel.Controls.Add(img);

            // Thêm panel vào UserControl
            this.Controls.Add(mainPanel);
        }
        private void btnLamBai_Click(object sender, EventArgs e)
        {
            // LamBaiClicked?.Invoke(this, EventArgs.Empty);
            LamBaiClicked?.Invoke(this, BaiThi);
        }
        private void UcBaiThiSapDienRa_Click(object sender, EventArgs e)
        {
            // ItemClicked?.Invoke(this, EventArgs.Empty); // Kích hoạt sự kiện khi item được nhấn
            ItemClicked?.Invoke(this, BaiThi);
        }

        private void btnLamBai_Click_1(object sender, EventArgs e)
        {

        }

        private void showExamBox(string ExamID)
        {

        }

        private void img_Click(object sender, EventArgs e)
        {

        }
    }
}
