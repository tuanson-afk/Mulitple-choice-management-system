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
    public partial class UcMonHocItem : UserControl
    {
        public MonHoc MonHoc { get; set; }
        public event EventHandler<MonHoc> ItemClicked;
        public string MaMon { get => lblMaMon.Text; set => lblMaMon.Text = value; }
        public string TenMon { get => lblTenMon.Text; set => lblTenMon.Text = value; }
        public UcMonHocItem()
        {
            InitializeComponent();
            SetupEvents();
        }
        private void SetupEvents()
        {
            this.Click += UcMonHoc_Click;
            mainPanel.Click += UcMonHoc_Click;
            img.Click += UcMonHoc_Click;
            container.Click += UcMonHoc_Click;
            randomImage();

        }

        private void UcMonHoc_Click(object sender, EventArgs e)
        {
            ItemClicked?.Invoke(this, MonHoc);
        }

        private void randomImage()
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

            if ((Image)Properties.Resources.ResourceManager.GetObject(selectedImageResource) != null)
            {
                img.Image = (Image)Properties.Resources.ResourceManager.GetObject(selectedImageResource);
            }
            else
            {
                img.Image = (Image)Properties.Resources.ResourceManager.GetObject("abstract-6284460_1920");
            }
        }
    }
}
