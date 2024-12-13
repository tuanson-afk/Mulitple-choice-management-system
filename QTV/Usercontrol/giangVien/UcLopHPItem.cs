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

namespace QTV.Usercontrol.giangVien
{
    public partial class UcLopHPItem : UserControl
    {
        public LopHP lopHP { get; set; }
        public event EventHandler<LopHP> ItemClicked;
        public string MaLHP { get => lblMaLHP.Text; set => lblMaLHP.Text = value; }
        public string TenLHP { get => lblTenLHP.Text; set => lblTenLHP.Text = value; }
        public UcLopHPItem()
        {
            InitializeComponent();
            SetupEvents();
        }

        private void SetupEvents()
        {
            this.Click += UcLopHPItem_Click;
            mainPanel.Click += UcLopHPItem_Click;
            img.Click += UcLopHPItem_Click;
            lblMaLHP.Click += UcLopHPItem_Click;
            lblTenLHP.Click += UcLopHPItem_Click;
            LabelMaLHP.Click += UcLopHPItem_Click;
            LabelTenLHP.Click += UcLopHPItem_Click;
        }

        private void UcLopHPItem_Click(object sender, EventArgs e)
        {
            ItemClicked?.Invoke(this, lopHP);
        }
    }
}
