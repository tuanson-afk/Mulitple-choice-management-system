using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTV.Controllers;
using QTV.Models;
using QTV.Usercontrol.sinhVien;
using DocumentFormat.OpenXml.Spreadsheet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using QTV.Views.General;

namespace QuanLyTracNghiem.Thanhcongcu
{
    public partial class TCC_Baithi : UserControl
    {

        public TCC_Baithi()
        {
            InitializeComponent();
            loadData();

            // SetupFlowLayout();
            // StudentController studentController = new StudentController();
            // var upcomingexam = studentController.LoadComingExam();
            // AddExamBoxes(upcomingexam);

        }

        private void loadData()
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            // Test();
            // Debug.WriteLine("List: " + list.ToString());
            loadListBaiThiSapDienRa();
            loadListBaiThiDaKetThuc();
            loadingBox.Close();
        }

        private void loadListBaiThiSapDienRa(string searchString = "")
        {
            StudentController studentController = new StudentController();
            var baiThiSapDienRa = studentController.transformBaiThiSapDienRa(searchString);

            foreach (var baiThi in baiThiSapDienRa)
            {
                UcBaiThiSapDienRa ucItem = new UcBaiThiSapDienRa();
                ucItem.TenBaiThi = baiThi.TenBaiThi;
                ucItem.TenLopHP = baiThi.TenLopHP;
                ucItem.NgayThi = baiThi.TGBatDau;

                ucItem.BaiThi = baiThi; // Gán đối tượng BaiThi

                // Đăng ký sự kiện OnItemClicked
                // ucItem.OnItemClicked += Item_Clicked;   

                // Đăng ký sự kiện click vào UserControl
                // ucItem.ItemClicked += ItemControl_UserControlClicked;

                // Đăng ký sự kiện click vào nút "Làm Bài"
                ucItem.LamBaiClicked += UcItem_LamBaiClicked;

                ucItem.ItemClicked += (s, baiThi) =>
                {
                    ShowExamDetails(baiThi);
                };

                flpBaiThiSapDienRaMain.Controls.Add(ucItem);
            }
        }

        private void clearListBaiThiSapDienRa()
        {
            flpBaiThiSapDienRaMain.Controls.Clear();
        }

        private void ItemControl_UserControlClicked(object sender, BaiThi baiThi)
        {
            // Xử lý khi click vào toàn bộ UserControl
            MessageBox.Show("Bạn đã click vào bài thi: " + baiThi.TenBaiThi);
        }

        private void UcItem_LamBaiClicked(object sender, BaiThi baiThi)
        {
            // Xử lý khi click vào nút "Làm Bài"
            ShowExamDetails(baiThi);
        }

        private void ShowExamDetails(BaiThi baiThi)
        {
            Baithicuthe baithicuthe = new Baithicuthe();
            baithicuthe.BaiThi = baiThi;
            baithicuthe.ShowDialog();

        }

        private void Test()
        {
            StudentController studentController = new StudentController();
            var dataTable = studentController.LoadComingExam();

            // Kiểm tra nếu có dữ liệu
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    // Tạo một UcBaiThiSapDienRa mới cho mỗi hàng
                    UcBaiThiSapDienRa ucItem = new UcBaiThiSapDienRa();

                    // Gán các giá trị từ DataRow vào UcBaiThiSapDienRa
                    ucItem.TenBaiThi = row["TenBaiThi"].ToString();  // Giả sử cột là "TenBaiThi"
                    ucItem.TenLopHP = row["TenLopHP"].ToString();    // Giả sử cột là "TenLopHP"
                    ucItem.NgayThi = DateTime.Parse(row["TGBatDau"].ToString()); // Giả sử cột là "TGBatDau"

                    // Thêm sự kiện click cho mỗi bài thi
                    ucItem.LamBaiClicked += UcItem_LamBaiClicked;

                    // Thêm UcBaiThiSapDienRa vào FlowLayoutPanel
                    flpBaiThiSapDienRaMain.Controls.Add(ucItem);
                }
            }
            else
            {
                MessageBox.Show("Không có bài thi nào sắp diễn ra.");
            }
        }

        private void loadListBaiThiDaKetThuc()
        {
            StudentController studentController = new StudentController();
            var baiThiDaKetThuc = studentController.transformBaiThiDaKetThuc();

            foreach (var baiThi in baiThiDaKetThuc)
            {
                UcBaiThiDaKetThuc ucItem = new UcBaiThiDaKetThuc();
                ucItem.BaiThi = baiThi;
                ucItem.TenBaiThi = baiThi.TenBaiThi;
                ucItem.TenLopHP = baiThi.TenLopHP;
                ucItem.TGBatDau = baiThi.TGBatDau;

                ucItem.ItemClicked += (s, baiThi) =>
                {
                    BaithidaKTcuthe baithidaKTcuthe = new BaithidaKTcuthe();
                    baithidaKTcuthe.baithi = baiThi;
                    baithidaKTcuthe.ShowDialog();
                };

                flpBaiThiDaKetThucMain.Controls.Add(ucItem);
            }
        }

        private void UcItem_LamBaiClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Bắt đầu làm bài thi!");
        }

        private void AddExamBoxes(DataTable examResults)
        {
            flpBaiThiSapDienRa.Controls.Clear();

            // Configure FlowLayoutPanel
            flpBaiThiSapDienRa.FlowDirection = FlowDirection.TopDown;
            flpBaiThiSapDienRa.WrapContents = false;
            flpBaiThiSapDienRa.AutoScroll = true;
            flpBaiThiSapDienRa.Padding = new Padding(10);

            foreach (DataRow row in examResults.Rows)
            {
                ExamBox examBox = new ExamBox();
                examBox.Width = flpBaiThiSapDienRa.ClientSize.Width - 25;

                examBox.TenLop = $"{row["TenLHP"]} ({row["MaLHP"]})";
                examBox.ThoiGian = $"{((DateTime)row["TGBatDau"]).ToString("dd/MM/yyyy HH:mm")} - {((DateTime)row["TGKetThuc"]).ToString("HH:mm")}";

                examBox.OnLamBaiClick += (sender, e) =>
                {
                    string maLHP = row["MaLHP"].ToString();
                    // Handle exam button click
                };

                flpBaiThiSapDienRa.Controls.Add(examBox);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimkiem_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void guna2Panel1_Paint(object sender, EventArgs e)
        {
            Form formbackground = new Form();
            try
            {
                using (Baithicuthe uu = new Baithicuthe())
                {
                    formbackground.StartPosition = FormStartPosition.Manual;
                    formbackground.FormBorderStyle = FormBorderStyle.None;
                    formbackground.Opacity = .70d;
                    // formbackground.BackColor = Color.Black;
                    formbackground.WindowState = FormWindowState.Maximized;
                    formbackground.TopMost = true;
                    formbackground.Location = this.Location;
                    formbackground.ShowInTaskbar = false;
                    formbackground.Show();

                    uu.Owner = formbackground;
                    uu.ShowDialog();

                    formbackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formbackground.Dispose();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TCC_Baithi_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, EventArgs e)
        {
            {
                Form formbackground = new Form();
                try
                {
                    using (Baithicuthe uu = new Baithicuthe())
                    {
                        formbackground.StartPosition = FormStartPosition.Manual;
                        formbackground.FormBorderStyle = FormBorderStyle.None;
                        formbackground.Opacity = .70d;
                        // formbackground.BackColor = Color.Black;
                        formbackground.WindowState = FormWindowState.Maximized;
                        formbackground.TopMost = true;
                        formbackground.Location = this.Location;
                        formbackground.ShowInTaskbar = false;
                        formbackground.Show();

                        uu.Owner = formbackground;
                        uu.ShowDialog();

                        formbackground.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    formbackground.Dispose();
                }
            }
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Form formbackground = new Form();
            try
            {
                using (Baithicuthe uu = new Baithicuthe())
                {
                    formbackground.StartPosition = FormStartPosition.Manual;
                    formbackground.FormBorderStyle = FormBorderStyle.None;
                    formbackground.Opacity = .70d;
                    // formbackground.BackColor = Color.Black;
                    formbackground.WindowState = FormWindowState.Maximized;
                    formbackground.TopMost = true;
                    formbackground.Location = this.Location;
                    formbackground.ShowInTaskbar = false;
                    formbackground.Show();

                    uu.Owner = formbackground;
                    uu.ShowDialog();

                    formbackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formbackground.Dispose();
            }
        }

        /*private void guna2Panel5_MouseDown(object sender, MouseEventArgs e)
        {

            Form formbackground = new Form();
            try
            {
                using (BaithidaKTcuthe uu = new BaithidaKTcuthe())
                {
                    formbackground.StartPosition = FormStartPosition.Manual;
                    formbackground.FormBorderStyle = FormBorderStyle.None;
                    formbackground.Opacity = .70d;
                    formbackground.BackColor = Color.Black;
                    formbackground.WindowState = FormWindowState.Maximized;
                    formbackground.TopMost = true;
                    formbackground.Location = this.Location;
                    formbackground.ShowInTaskbar = false;
                    formbackground.Show();

                    uu.Owner = formbackground;
                    uu.ShowDialog();

                    formbackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formbackground.Dispose();
            }
        }*/

        private void guna2TextBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            Form formbackground = new Form();
            try
            {
                using (BaithidaKTcuthe uu = new BaithidaKTcuthe())
                {
                    formbackground.StartPosition = FormStartPosition.Manual;
                    formbackground.FormBorderStyle = FormBorderStyle.None;
                    formbackground.Opacity = .70d;
                    // formbackground.BackColor = Color.Black;
                    formbackground.WindowState = FormWindowState.Maximized;
                    formbackground.TopMost = true;
                    formbackground.Location = this.Location;
                    formbackground.ShowInTaskbar = false;
                    formbackground.Show();

                    uu.Owner = formbackground;
                    uu.ShowDialog();

                    formbackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formbackground.Dispose();
            }

        }

        private void flpBaiThiSapDienRa_Paint(object sender, PaintEventArgs e)
        {
            // flpBaiThiSapDienRa.Dock = DockStyle.Fill;
        }

        private void txtBtnListBaiThiSapDienRa_Click(object sender, EventArgs e)
        {
            frmBaithisapdienra frmBaithisapdienra = new frmBaithisapdienra();
            frmBaithisapdienra.ShowDialog();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBtnListBaiThiDaKetThuc_Click(object sender, EventArgs e)
        {
            frmBaithidaKT frmBaithidaKT = new frmBaithidaKT();
            frmBaithidaKT.ShowDialog();
        }

        private void guna2TextBox1_TextChanged_2(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm" + txtTimkiem.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearListBaiThiSapDienRa();
            loadListBaiThiSapDienRa(txtTimkiem.Text);
        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
    

