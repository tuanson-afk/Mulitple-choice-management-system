using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTV.Controllers;

namespace QTV.Usercontrol
{
    public partial class Form_thêm_LHP : Form
    {
        public Form_thêm_LHP()
        {
            InitializeComponent();
            LoadTeacherListToDropDown();
            LoadSubjectListToDropDown();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form_thêm_LHP_Load(object sender, EventArgs e)
        {
            // Tạo cột "Mã Lớp học phần"
            DataGridViewTextBoxColumn maLopHocPhanColumn = new DataGridViewTextBoxColumn();
            maLopHocPhanColumn.HeaderText = "Mã Lớp học phần";
            maLopHocPhanColumn.Name = "maLopHocPhanColumn";

            // Tạo cột "Tên Lớp"
            DataGridViewTextBoxColumn tenLopColumn = new DataGridViewTextBoxColumn();
            tenLopColumn.HeaderText = "Tên Lớp";
            tenLopColumn.Name = "tenLopColumn";

            // Tạo cột "Mã Giảng viên"
            DataGridViewTextBoxColumn maGiangVienColumn = new DataGridViewTextBoxColumn();
            maGiangVienColumn.HeaderText = "Mã Giảng viên";
            maGiangVienColumn.Name = "maGiangVienColumn";

            // Tạo cột "Mã Sinh viên"
            DataGridViewTextBoxColumn maSinhVienColumn = new DataGridViewTextBoxColumn();
            maSinhVienColumn.HeaderText = "Mã Sinh viên";
            maSinhVienColumn.Name = "maSinhVienColumn";

            // Thêm các cột vào DataGridView
            // dataGridView1.Columns.Add(maLopHocPhanColumn);
            // dataGridView1.Columns.Add(tenLopColumn);
            // dataGridView1.Columns.Add(maGiangVienColumn);
            // dataGridView1.Columns.Add(maSinhVienColumn);
            //
            // // Thiết lập phông chữ cho toàn bộ DataGridView
            // dataGridView1.DefaultCellStyle.Font = new Font("Times New Roman", 12);
            //
            // // Thiết lập phông chữ cho tiêu đề cột và điều chỉnh kích thước
            // dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            //
            // // Tự động điều chỉnh kích thước các cột cho vừa với nội dung và tiêu đề
            // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //
            // // Đảm bảo chữ trong các ô vừa khít
            // dataGridView1.AutoResizeColumns();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Get Form TextBox1
            string maLopHocPhan = textBox1.Text;
            string tenLop = textBox2.Text;
            string maGiangVien = guna2ComboBox1.SelectedValue?.ToString();
            string maMon = guna2ComboBox2.SelectedValue?.ToString();
            
            // Add class to database
            ClassController classController = new ClassController();
            bool result = classController.AddClass(maLopHocPhan, tenLop, maGiangVien, maMon);
            if (result)
            {
                MessageBox.Show("Thêm lớp học phần thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm lớp học phần thất bại!");
            }
            
            
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadTeacherListToDropDown()
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            ClassController classController = new ClassController();
            var teacherList = classController.LoadGiangVienList();
    
            if (teacherList != null)
            {
                foreach (var teacher in teacherList)
                {
                    comboSource.Add(teacher.MaGV, teacher.TenGV);
                }

                guna2ComboBox1.DataSource = new BindingSource(comboSource, null);
                guna2ComboBox1.DisplayMember = "Value";
                guna2ComboBox1.ValueMember = "Key";
            }
        }
        
        private void LoadSubjectListToDropDown()
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            ClassController classController = new ClassController();
            var subjectList = classController.LoadMonHocList();
    
            if (subjectList != null)
            {
                foreach (var subject in subjectList)
                {
                    comboSource.Add(subject.MaMon, subject.TenMon);
                }

                guna2ComboBox2.DataSource = new BindingSource(comboSource, null);
                guna2ComboBox2.DisplayMember = "Value";
                guna2ComboBox2.ValueMember = "Key";
            }
        }
    }
}
