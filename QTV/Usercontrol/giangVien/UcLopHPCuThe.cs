using QL_Trac_Nghiem;
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
    public partial class UcLopHPCuThe : UserControl
    {
        private LopHP _lopHP;
        public UcLopHPCuThe(LopHP lopHP)
        {
            InitializeComponent();
            _lopHP = lopHP;

            tbTenLopHP.Text = _lopHP.TenLHP;
        }
        private void tbTenLopHP_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem UserControl này có thuộc về một Panel cha không
            var parent = this.Parent;
            if (parent != null)
            {
                parent.Controls.Remove(this); // Xóa UserControl hiện tại khỏi Panel cha
            }
        }
        private void UcLopHPCuThe_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
