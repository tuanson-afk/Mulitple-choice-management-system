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

namespace QTV.Usercontrol.sinhVien
{
    public partial class UcBaiThiDaKetThuc : UserControl
    {
        public BaiThi BaiThi { get; set; }
        public event EventHandler<BaiThi> ItemClicked; // Sự kiện Click toàn bộ item
        public string TenBaiThi { get => lblTenBaiThi.Text; set => lblTenBaiThi.Text = value; }
        public string TenLopHP { get => lblTenLopHP.Text; set => lblTenLopHP.Text = value; }
        public DateTime TGBatDau { get => DateTime.Parse(lblTGBatDau.Text); set => lblTGBatDau.Text = value.ToString("dd/MM/yyyy HH:mm"); }
        public UcBaiThiDaKetThuc()
        {
            InitializeComponent();
            SetupEvents(); // Gọi hàm thiết lập sự kiện khi khởi tạo UserControl
        }

        private void SetupEvents()
        {
            this.Click += UcBaiThiDaKetThuc_Click;
            mainPanel.Click += UcBaiThiDaKetThuc_Click;
            img.Click += UcBaiThiDaKetThuc_Click;
            lblTenBaiThi.Click += UcBaiThiDaKetThuc_Click;
            lblTenLopHP.Click += UcBaiThiDaKetThuc_Click;
            lblTGBatDau.Click += UcBaiThiDaKetThuc_Click;
            container.Click += UcBaiThiDaKetThuc_Click;
        }

        private void UcBaiThiDaKetThuc_Click(object sender, EventArgs e)
        {
            ItemClicked?.Invoke(this, BaiThi);
        }

        private void lblTenBaiThi_Click(object sender, EventArgs e)
        {

        }
    }
}
