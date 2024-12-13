using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTV.Controllers;
using QTV.Views;


namespace QTV.Usercontrol
{
    public partial class UC_QLLHP : UserControl
    {


        private DataGridViewImageColumn deleteColumn;
        public UC_QLLHP()
        {
            InitializeComponent();
            LoadData();
            InitializeFluentDesign();

        }


        private void InitializeFluentDesign()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 128);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.GridColor = Color.Gainsboro;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            DataGridViewImageColumn studentColumn = new DataGridViewImageColumn();
            studentColumn.Name = "DSSV";
            studentColumn.HeaderText = "Sinh Viên";
            studentColumn.Image = Properties.Resources.cu2;
            studentColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            studentColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(studentColumn);

            DataGridViewImageColumn editButtonColumn = new DataGridViewImageColumn();
            editButtonColumn.Name = "EditColumn";
            editButtonColumn.HeaderText = "Sửa";
            editButtonColumn.Image = Properties.Resources.p2;
            editButtonColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            editButtonColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(editButtonColumn);

            DataGridViewImageColumn deleteButtonColumn = new DataGridViewImageColumn();
            deleteButtonColumn.Name = "DeleteColumn";
            deleteButtonColumn.HeaderText = "Xóa";
            deleteButtonColumn.Image = Properties.Resources.t2;
            deleteButtonColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            deleteButtonColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(deleteButtonColumn);

            dataGridView1.Columns["EditColumn"].DisplayIndex = dataGridView1.Columns.Count - 2;
            dataGridView1.Columns["DeleteColumn"].DisplayIndex = dataGridView1.Columns.Count - 1;
        }
        public void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Đặt màu cho header
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 128);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;

            // Đặt màu cho cell
            e.CellStyle.BackColor = Color.White;
            e.CellStyle.ForeColor = Color.Black; // Màu chữ cho cell
        }

        private void HandleDetele(String MaLHP)
        {
            DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa dòng này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Xóa thành công");
            }
        }

        private void UC_QLLHP_Load(object sender, EventArgs e)
        {
            // LoadData();
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
            if (e.ColumnIndex == dataGridView1.Columns["deleteColumn"].Index && e.RowIndex >= 0)
            {
                string maLHP = dataGridView1.Rows[e.RowIndex].Cells["MaLHP"].Value?.ToString();

                if (!string.IsNullOrEmpty(maLHP))
                {
                    HandleDetele(maLHP);
                }
                else
                {
                    MessageBox.Show("Không thể xác định Mã LHP để xóa.");
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["DSSV"].Index && e.RowIndex >= 0)
            {
                string maLHP = dataGridView1.Rows[e.RowIndex].Cells["MaLHP"].Value?.ToString();
                frmSinhVienLHP frmSinhVienLHP = new frmSinhVienLHP(maLHP);
                frmSinhVienLHP.ShowDialog();

            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            {
                // Tạo một instance của form FormThemLHP
                QTV.Usercontrol.Form_thêm_LHP formThemLHP = new QTV.Usercontrol.Form_thêm_LHP();

                // Hiển thị form
                formThemLHP.ShowDialog();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Tạo một instance của form FormThemLHP
            QTV.Usercontrol.Form_thêm_LHP formThemLHP = new QTV.Usercontrol.Form_thêm_LHP();

            // Hiển thị form
            formThemLHP.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // View specific methods
        private void LoadData()
        {
            ClassController classController = new ClassController();
            var data = classController.LoadClass();
            // select only MaLHP, TenLHP, TenGV, TenMon
            var table = data.DefaultView.ToTable(false, "MaLHP", "TenLHP", "TenGV", "TenMon");
            dataGridView1.DataSource = table;
            dataGridView1.Columns["MaLHP"].HeaderText = "Mã Lớp Học phần";
            dataGridView1.Columns["TenLHP"].HeaderText = "Tên Lớp Học Phần";
            dataGridView1.Columns["TenGV"].HeaderText = "Tên Giảng Viên";
            dataGridView1.Columns["TenMon"].HeaderText = "Tên Môn Học";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
