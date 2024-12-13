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
    public partial class UcDeThiItem : UserControl
    {
        public DeThi DeThi { get; set; }
        public event EventHandler<DeThi> ItemClicked;
        public string MaDeThi { get => lblMaDeThi.Text; set => lblMaDeThi.Text = value; }
        public string TenDeThi { get => lblTenDeThi.Text; set => lblTenDeThi.Text = value; }
        public UcDeThiItem()
        {
            InitializeComponent();
            SetupEvents();
        }
        private void SetupEvents()
        {
            this.Click += UcDeThiItem_Click;
            mainPanel.Click += UcDeThiItem_Click;
            img.Click += UcDeThiItem_Click;
            lblMaDeThi.Click += UcDeThiItem_Click;
            lblTenDeThi.Click += UcDeThiItem_Click;
            LabelMaDeThi.Click += UcDeThiItem_Click;
            LabelTenDeThi.Click += UcDeThiItem_Click;
        }

        private void UcDeThiItem_Click(object sender, EventArgs e)
        {
            ItemClicked?.Invoke(this, DeThi);
        }
    }
}
