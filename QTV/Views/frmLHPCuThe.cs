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
    public partial class frmLHPCuThe : Form
    {
        public frmLHPCuThe()
        {
            InitializeComponent();
        }

        private void btnThemBaiThi_Click(object sender, EventArgs e)
        {
           /* Form f = new frmThemBaiThi();
            f.TopMost = true;
            f.ShowDialog();*/
        }

        private void guna2Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Form frmBackGround = new Form();
            try
            {
                using (frmCTBaiThi uu = new frmCTBaiThi())
                {
                    frmBackGround.StartPosition = FormStartPosition.Manual;
                    frmBackGround.FormBorderStyle = FormBorderStyle.None;
                    frmBackGround.Opacity = .70d;
                    frmBackGround.BackColor = Color.Black;
                    frmBackGround.WindowState = FormWindowState.Maximized;
                    frmBackGround.TopMost = true;
                    frmBackGround.Location = this.Location;
                    frmBackGround.ShowInTaskbar = false;
                    frmBackGround.Show();

                    uu.Owner = frmBackGround;
                    uu.ShowDialog();

                    frmBackGround.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmBackGround.Dispose();
            }
        }

        private void guna2PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Form frmBackGround = new Form();
            try
            {
                using (frmCTBaiThi uu = new frmCTBaiThi())
                {
                    frmBackGround.StartPosition = FormStartPosition.Manual;
                    frmBackGround.FormBorderStyle = FormBorderStyle.None;
                    frmBackGround.Opacity = .70d;
                    frmBackGround.BackColor = Color.Black;
                    frmBackGround.WindowState = FormWindowState.Maximized;
                    frmBackGround.TopMost = true;
                    frmBackGround.Location = this.Location;
                    frmBackGround.ShowInTaskbar = false;
                    frmBackGround.Show();

                    uu.Owner = frmBackGround;
                    uu.ShowDialog();

                    frmBackGround.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmBackGround.Dispose();
            }
        }
    }
}
