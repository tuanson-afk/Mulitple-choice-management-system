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

namespace QTV.Usercontrol.giangVien
{

    public partial class UcBaiThiItem : UserControl
    {
        public BaiThi BaiThi { get; set; }
        public event EventHandler<BaiThi> ItemClicked;
        public string TenBaiThi { get => lblTenBaiThi.Text; set => lblTenBaiThi.Text = value; }
        public string TGThi { get => lblTGThi.Text; set => lblTGThi.Text = value; }
        public UcBaiThiItem()
        {
            InitializeComponent();
            SetupEvents();
        }
        private void SetupEvents()
        {
            this.Click += UcBaiThiItem_Click;
            mainPanel.Click += UcBaiThiItem_Click;
            img.Click += UcBaiThiItem_Click;
            lblTenBaiThi.Click += UcBaiThiItem_Click;
            lblTGThi.Click += UcBaiThiItem_Click;
            LabelTenBaiThi.Click += UcBaiThiItem_Click;
            LabelTGThi.Click += UcBaiThiItem_Click;
        }
        private void UcBaiThiItem_Click(object sender, EventArgs e)
        {
            ItemClicked?.Invoke(this, BaiThi);
        }
    }
}
