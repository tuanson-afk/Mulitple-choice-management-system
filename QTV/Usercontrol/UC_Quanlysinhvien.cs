using DocumentFormat.OpenXml.Office.Word;
using QTV.Controllers;
using QTV.DataAccess;
using QTV.Views.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTV.Usercontrol
{
    public partial class UC_Quanlysinhvien : UserControl

    {
        DataTable dt;
        private DataGridViewImageColumn deleteColumn;
        public UC_Quanlysinhvien()
        {
            InitializeComponent();
            loadStudentData();

        }
        public void NapCT()
        {
            int i = dataGridView1.CurrentRow.Index;
            txtmasv.Text = dataGridView1.Rows[i].Cells["MaSV"].Value.ToString();
            txthotensv.Text = dataGridView1.Rows[i].Cells["TenSV"].Value.ToString();
            txtemail.Text = dataGridView1.Rows[i].Cells["MailSV"].Value.ToString();
        }


        private void UC_Quanlysinhvien_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            dataGridView1.Font = new Font("Times New Roman", 12);
            deleteColumn = new DataGridViewImageColumn();
            deleteColumn.HeaderText = "Xóa";
            deleteColumn.Name = "deleteColumn";

            deleteColumn.Width = 10;

            // Chuyển đổi byte[] sang Image
            byte[] iconBytes = Properties.Resources.trash;
            using (MemoryStream ms = new MemoryStream(iconBytes))
            {
                deleteColumn.Image = Image.FromStream(ms);
            }

            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            deleteColumn.Width = 40;



            // Thêm các cột vào DataGridView

            dataGridView1.Columns.Add(deleteColumn);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Roman", 10, FontStyle.Bold);
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Khi thêm hàng mới, tự động thêm biểu tượng xóa vào cột cuối
            for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells["deleteColumn"].Value == null)
                {
                    dataGridView1.Rows[i].Cells["deleteColumn"].Value = deleteColumn.Image;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
            // Kiểm tra xem người dùng có click vào cột xóa không
            if (e.ColumnIndex == dataGridView1.Columns["deleteColumn"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa dòng này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    UserManagerController userManagerController = new UserManagerController();
                    if (dataGridView1.Rows[e.RowIndex].Cells["MaSV"].Value.ToString() != null)
                    {
                        bool result1 = userManagerController.deleteStudent(dataGridView1.Rows[e.RowIndex].Cells["MaSV"].Value.ToString());
                        if (result1)
                        {
                            MessageBox.Show("Xóa thành công");
                            clearTextBoxes();
                            dataGridView1.Rows.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa dòng này");
                    }
                }
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadStudentData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                // Cập nhật giá trị của hàng đã chọn trong DataGridView
                int rowIndex = dataGridView1.CurrentRow.Index;

                // Lấy mã giảng viên của hàng hiện tại để xác định hàng cần update trong cơ sở dữ liệu
                string maSinhVienCu = dataGridView1.Rows[rowIndex].Cells["MaSV"].Value.ToString();

                // Cập nhật dữ liệu trên DataGridView
                dataGridView1.Rows[rowIndex].Cells["MaSV"].Value = txtmasv.Text;
                dataGridView1.Rows[rowIndex].Cells["TenSV"].Value = txthotensv.Text;
                dataGridView1.Rows[rowIndex].Cells["MailSV"].Value = txtemail.Text;

                UserManagerController userManagerController = new UserManagerController();
                bool result = userManagerController.updateStudent(txtmasv.Text, txthotensv.Text, txtemail.Text);
                if (result)
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thất bại!");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng cần sửa.");
            }
        }
        public void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Đặt màu cho header
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64,64,128);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;

            // Đặt màu cho cell
            e.CellStyle.BackColor = Color.White;
            e.CellStyle.ForeColor = Color.Black; // Màu chữ cho cell
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmasv.Text) || string.IsNullOrWhiteSpace(txthotensv.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            try
            {
                UserManagerController userManagerController = new UserManagerController();
                bool result = userManagerController.addStudent(txtmasv.Text, txthotensv.Text, txtemail.Text);
                if (result)
                {
                    MessageBox.Show("Đã thêm sinh viên mới thành công vào cơ sở dữ liệu!");
                    loadStudentData();
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên mới thất bại!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }


            dataGridView1.DataSource = dt;

            txtmasv.Clear();
            txthotensv.Clear();
            txtemail.Clear();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            }
        }

        // View Specific Functions
        private void loadStudentData()
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            UserManagerController userManagerController = new UserManagerController();
            DataTable studentList = userManagerController.loadStudentList();
            dataGridView1.DataSource = studentList;
            dataGridView1.Columns["MaSV"].HeaderText = "Mã sinh viên";
            dataGridView1.Columns["TenSV"].HeaderText = "Họ và tên";
            dataGridView1.Columns["MailSV"].HeaderText = "MailSV";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.Width = 200;
            }
            clearTextBoxes();
            loadingBox.Close();
        }

        private void clearTextBoxes()
        {
            txtmasv.Clear();
            txthotensv.Clear();
            txtemail.Clear();
        }

        private void txtmasv_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txthotensv_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
