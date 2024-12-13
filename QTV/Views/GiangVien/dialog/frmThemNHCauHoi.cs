using DocumentFormat.OpenXml.Spreadsheet;
using QTV.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTV.Views.GiangVien
{
    public partial class frmThemNHCauHoi : Form
    {
        private string _maMon;
        private string _maGV;
        private string _maNHCauHoi;
        private string _tenNHCauHoi;
        public frmThemNHCauHoi(string maMon, string maGV, string maNHCauHoi = "", string tenNHCauHoi = "")
        {
            InitializeComponent();
            _maMon = maMon;
            _maGV = maGV;
            _maNHCauHoi = maNHCauHoi;
            _tenNHCauHoi = tenNHCauHoi;

            if (!string.IsNullOrEmpty(maNHCauHoi) && !string.IsNullOrEmpty(tenNHCauHoi))
            {
                title.Text = "Sửa thông tin ngân hàng câu hỏi";
                tbMaNHCauHoi.Text = _maNHCauHoi;
                tbTenNHCauHoi.Text = _tenNHCauHoi;
                tbMaMon.Text = _maMon;
                tbMaGV.Text = _maGV;
                btnThem.Text = "Sửa";
            }
            else
            {
                title.Text = "Thêm mới ngân hàng câu hỏi";
                tbMaNHCauHoi.Text = "";
                tbTenNHCauHoi.Text = "";
                // Hiển thị mã môn học và mã giảng viên trong các tb
                tbMaMon.Text = _maMon; //  hiển thị mã môn
                tbMaGV.Text = _maGV;  //  hiển thị mã giảng viên
                btnThem.Text = "Thêm";
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNHCauHoi = tbMaNHCauHoi.Text.Trim();
            string tenNHCauHoi = tbTenNHCauHoi.Text.Trim();

            if (string.IsNullOrEmpty(maNHCauHoi) || string.IsNullOrEmpty(tenNHCauHoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuestionBankController questionBankController = new QuestionBankController();

            if (!string.IsNullOrEmpty(_maNHCauHoi) && !string.IsNullOrEmpty(_tenNHCauHoi)) // Nếu có mã ngân hàng câu hỏi và tên, là chế độ sửa
            {
                bool isUpdated = questionBankController.UpdateQuestionBank(maNHCauHoi, tenNHCauHoi, _maMon);
                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            else
            {
                bool isAdded = questionBankController.AddQuestionBank(maNHCauHoi, tenNHCauHoi, _maMon);

                if (isAdded)
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
