using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTV.Views.General
{
    public partial class LoadingBox : Form
    {
        public LoadingBox()
        {
            InitializeComponent();
            CenterTextBox();
        }

        private void CenterTextBox()
        {
            guna2TextBox1.Location = new Point(
                (this.ClientSize.Width - guna2TextBox1.Width) / 2,
                (this.ClientSize.Height - guna2TextBox1.Height) / 2
            );
        }
    }
}
