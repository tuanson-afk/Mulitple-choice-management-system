using QTV.Controllers;
using QTV.Models;
using QTV.Usercontrol.sinhVien;
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

namespace QuanLyTracNghiem.Thanhcongcu
{
    public partial class frmLambai : Form
    {
        public BaiThi BaiThi { get; set; }


        public frmLambai()
        {
            InitializeComponent();
        }

        // onload
        private void frmLambai_Load(object sender, EventArgs e)
        {
            // Update information
            txtTenbaithi.Text = BaiThi.TenBaiThi + " - " + BaiThi.ThoiLuong.ToString();
            txtTenbaithi.Enabled = false;
            txtTongsocau.Text = BaiThi.SoCauHoi.ToString();
            txtTongsocau.Enabled = false;
            txtThoigianlam.Enabled = false;
            // Create NewBaiLam
            StudentController studentController = new StudentController();
            string maBaiLam = studentController.NewBaiLam(BaiThi.MaBaiThi);
            if (maBaiLam == null)
            {
                MessageBox.Show("Lỗi xảy ra khi bắt đầu làm bài");
                this.Close();
                return;
            }
            txtMaBaiLamCode.Text = maBaiLam;
            txtMaBaiLamCode.Enabled = false;

            // Count down
            var now = DateTime.Now;
            var thoiLuong = BaiThi.ThoiLuong;
            var endTime = now.AddMinutes(thoiLuong);
            var timeLeft = endTime - now;
            txtThoigianlam.Text = BaiThi.ThoiLuong.ToString();
            Demnguoc.Text = timeLeft.ToString(@"hh\:mm\:ss");
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, ev) =>
            {
                timeLeft = endTime - DateTime.Now;
                if (timeLeft.TotalSeconds <= 0)
                {
                    timer.Stop();
                    MessageBox.Show("Hết giờ làm bài");
                    return;
                }
                //txtThoigianlam.Text = timeLeft.ToString(@"hh\:mm\:ss");
                Demnguoc.Text = timeLeft.ToString(@"hh\:mm\:ss");
            };
            timer.Start();

            // loadCauHoi
            var questions = studentController.loadCauHoi(BaiThi.MaDeThi);
            Debug.WriteLine(BaiThi.XaoTron.ToString());
            if(BaiThi.XaoTron == 1)
            {
                Random rng = new Random();
                questions = questions.OrderBy(q => rng.Next()).ToList();
            }
            var q_cnt = 0;
            foreach (var question in questions)
            {
                q_cnt++;
                UcCauHoiBaiLam ucItem = new UcCauHoiBaiLam();
                ucItem.CauHoi = question;
                ucItem.DapAnA = question.PhuongAns != null && question.PhuongAns.Count > 0 ? question.PhuongAns.ElementAtOrDefault(0) : null;
                ucItem.DapAnB = question.PhuongAns != null && question.PhuongAns.Count > 1 ? question.PhuongAns.ElementAtOrDefault(1) : null;
                ucItem.DapAnC = question.PhuongAns != null && question.PhuongAns.Count > 2 ? question.PhuongAns.ElementAtOrDefault(2) : null;
                ucItem.DapAnD = question.PhuongAns != null && question.PhuongAns.Count > 3 ? question.PhuongAns.ElementAtOrDefault(3) : null;
                ucItem.MaBaiLam = maBaiLam;
                ucItem.q_cnt = q_cnt.ToString();

                flowLayoutPanel1.Controls.Add(ucItem);
            }

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void txtTongsocau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTenbaithi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThoigianlam_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSttCau_TextChanged(object sender, EventArgs e)
        {

        }

        private void Demnguoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void Demnguoc_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtSttCau_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn nộp bài?", "Nộp bài", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Nop bai
                StudentController studentController = new StudentController();
                if (studentController.submitBaiLam(txtMaBaiLamCode.Text))
                {
                    MessageBox.Show("Nộp bài thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại");
                }
            }
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }
    }
}
