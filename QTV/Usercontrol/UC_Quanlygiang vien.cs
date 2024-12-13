using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using QTV.Controllers;
using QTV.Views.General;

namespace QTV.Usercontrol
{
    public partial class UC_Quanlygiang_vien : UserControl
    {


        string connectstring = @"Data Source=LAPTOP;Initial Catalog=QLTN;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt;
        private DataGridViewImageColumn deleteColumn;

        public UC_Quanlygiang_vien()
        {
            InitializeComponent();
            LoadTeacherData();
        }
        public void NapCT()
        {
            int i = dataGridView1.CurrentRow.Index;//lấy số thứ tự dòng hiện thời
            txtmagv.Text = dataGridView1.Rows[i].Cells["MaGV"].Value.ToString();
            txthotengv.Text = dataGridView1.Rows[i].Cells["TenGV"].Value.ToString();
            txtemail.Text = dataGridView1.Rows[i].Cells["MailGV"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void UC_Quanlygiang_vien_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;




            con = new SqlConnection(connectstring);
            // Tạo cột biểu tượng xóa
            deleteColumn = new DataGridViewImageColumn();
            deleteColumn.HeaderText = "Xóa";
            deleteColumn.Name = "deleteColumn";

            // Chuyển đổi byte[] sang Image
            byte[] iconBytes = Properties.Resources.trash;
            using (MemoryStream ms = new MemoryStream(iconBytes))
            {
                deleteColumn.Image = Image.FromStream(ms);
            }

            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            deleteColumn.Width = 50;








            dataGridView1.Columns.Add(deleteColumn);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Time New Roman", 9, FontStyle.Bold);

            // Đăng ký sự kiện khi thêm hàng mới
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            // Thêm phương thức này vào lớp UC_Quanlygiang_vien



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
                    if (dataGridView1.Rows[e.RowIndex].Cells["MaGV"].Value.ToString() != null)
                    {
                        bool result1 = userManagerController.deleteTeacher(dataGridView1.Rows[e.RowIndex].Cells["MaGV"].Value.ToString());
                        if (result1)
                        {
                            MessageBox.Show("Xóa thành công");
                            ClearTextBoxes();
                            dataGridView1.Rows.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }   
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            dataGridView1.Columns["Magv"].HeaderText = "Mã giảng viên";
            dataGridView1.Columns["TenGV"].HeaderText = "Họ và tên";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            // Thêm dữ liệu mới vào DataTable
            if (string.IsNullOrWhiteSpace(txtmagv.Text) || string.IsNullOrWhiteSpace(txthotengv.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            try {
                UserManagerController userManagerController = new UserManagerController();
                bool result = userManagerController.addTeacher(txtmagv.Text, txthotengv.Text, txtemail.Text);
                if(result)
                {
                    MessageBox.Show("Đã thêm giảng viên mới thành công vào cơ sở dữ liệu!");
                    LoadTeacherData();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Thêm giảng viên mới thất bại!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }


            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                // Cập nhật giá trị của hàng đã chọn trong DataGridView
                int rowIndex = dataGridView1.CurrentRow.Index;

                // Lấy mã giảng viên của hàng hiện tại để xác định hàng cần update trong cơ sở dữ liệu
                // string maSinhVienCu = dataGridView1.Rows[rowIndex].Cells["MaGV"].Value.ToString();

                // Cập nhật dữ liệu trên DataGridView
                dataGridView1.Rows[rowIndex].Cells["MaGV"].Value = txtmagv.Text;
                dataGridView1.Rows[rowIndex].Cells["TenGV"].Value = txthotengv.Text;
                dataGridView1.Rows[rowIndex].Cells["MailGV"].Value = txtemail.Text;

                UserManagerController userManagerController = new UserManagerController();
                bool result = userManagerController.updateTeacher(txtmagv.Text, txthotengv.Text, txtemail.Text);
                if(result)
                {
                    MessageBox.Show("Cập nhật thông tin giảng viên thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin giảng viên thất bại!");
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
        // View Specific Functions
        private void LoadTeacherData()
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            UserManagerController userManagerController = new UserManagerController();
            DataTable teacherList = userManagerController.LoadTeacherList();
            dataGridView1.DataSource = teacherList;
            dataGridView1.Columns["Magv"].HeaderText = "Mã giảng viên";
            dataGridView1.Columns["TenGV"].HeaderText = "Họ và tên";
            dataGridView1.Columns["TenGV"].HeaderText = "EMail Giảng viên";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.Width = 200;
            }
            ClearTextBoxes();
            loadingBox.Close();
        }

        private void ClearTextBoxes()
        {
            txtmagv.Clear();
            txthotengv.Clear();
            txtemail.Clear();
        }
    }
}