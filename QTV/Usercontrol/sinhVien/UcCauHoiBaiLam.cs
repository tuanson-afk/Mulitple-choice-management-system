using Guna.UI2.WinForms;
using QTV.Controllers;
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

namespace QTV.Usercontrol.sinhVien
{
    public partial class UcCauHoiBaiLam : UserControl
    {

        // info of a questions
        public CauHoi CauHoi { get; set; }
        public PhuongAn DapAnA { get; set; }
        public PhuongAn DapAnB { get; set; }
        public PhuongAn DapAnC { get; set; }
        public PhuongAn DapAnD { get; set; }
        public string MaBaiLam { get; set; }
        public string q_cnt { get; set; }

        public UcCauHoiBaiLam()
        {
            InitializeComponent();
        }

        public void UcCauHoiBaiLam_Load(object sender, EventArgs e)
        {
            // update value of txtTenbaithicuthe and make them uneditable
            txtNoiDungCH.Text = CauHoi.NoiDung;
            txtNoiDungCH.Enabled = false;
            radioButton1.Text = DapAnA.NoiDung;
            radioButton2.Text = DapAnB.NoiDung;
            radioButton3.Text = DapAnC.NoiDung;
            radioButton4.Text = DapAnD.NoiDung;
            // update value of radioButton content to MaPhuongAn to send to the database
            radioButton1.Tag = DapAnA.MaPhuongAn;
            radioButton2.Tag = DapAnB.MaPhuongAn;
            radioButton3.Tag = DapAnC.MaPhuongAn;
            radioButton4.Tag = DapAnD.MaPhuongAn;
            // add Click Action
            radioButton1.CheckedChanged += selectAnswer;
            radioButton2.CheckedChanged += selectAnswer;
            radioButton3.CheckedChanged += selectAnswer;
            radioButton4.CheckedChanged += selectAnswer;
            // handle question number
            guna2HtmlLabel1.Text = "Câu hỏi " + q_cnt + ": ";


        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void CauHoi_Content_Click(object sender, EventArgs e)
        {

        }

        private void CauHoi_Content_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void selectAnswer(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                StudentController studentController = new StudentController();
                if(!studentController.createOrUpdateChiTietBaiLam(MaBaiLam, CauHoi.MaCauHoi, radioButton.Tag.ToString()))
                {
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại");
                }
            }
        }

        private void txtNoiDungCH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
