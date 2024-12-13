using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Trac_Nghiem
{
    public partial class frmCTBaiThi : Form
    {
        public frmCTBaiThi()
        {
            InitializeComponent();
        }
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            Form f = new frmChinhSuaBaiThi();
            f.Owner = this; // "this" là form popup hiện tại
            f.TopMost = true;
            f.ShowDialog();
        }
    }
}
