using QL_Trac_Nghiem.UserControls;
using System;
using System.CodeDom;
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
    public partial class frmDeThi : Form
    {
        public frmDeThi()
        {
            InitializeComponent();
            UC_MonHoc uc = new UC_MonHoc();
        }

        private void btnThemDeThi_Click(object sender, EventArgs e)
        {
            // Tạo nền mờ
            Form frmBackGround = new Form();

            try
            {
                // Cấu hình nền mờ
                frmBackGround.StartPosition = FormStartPosition.Manual;
                frmBackGround.FormBorderStyle = FormBorderStyle.None;
                frmBackGround.Opacity = 0.70d;
                frmBackGround.BackColor = Color.Black;
                frmBackGround.WindowState = FormWindowState.Maximized;
                frmBackGround.TopMost = true;
                frmBackGround.Location = this.Location;
                frmBackGround.ShowInTaskbar = false;

                // Hiện nền mờ trước
                frmBackGround.Show();

                // Sử dụng form ThemCauHoi đã có sẵn
                //using (frmThemDeThi uu = new frmThemDeThi())
                //{
                //    uu.Owner = frmBackGround; // Đặt owner cho form ThemCauHoi

                //    // Hiện form ThemCauHoi như một modal dialog
                //    uu.ShowDialog(frmBackGround); // Gọi ShowDialog với frmBackGround làm owner
                //}

                // Đóng nền mờ sau khi form ThemCauHoi đã được đóng
                frmBackGround.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                frmBackGround.Dispose(); // Giải phóng tài nguyên
            }
        }
    }
    }

