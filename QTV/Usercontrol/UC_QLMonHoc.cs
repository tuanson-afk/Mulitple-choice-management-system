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

namespace QTV.Usercontrol
{
    public partial class UC_QLMonHoc : UserControl
    {
        public SubjectManagerController subjectManagerController = new SubjectManagerController();
        public UC_QLMonHoc()
        {
            InitializeComponent();
            InitializeFluentDesign();
            LoadData();
        }

        private void InitializeFluentDesign()
        {
            // Set up Fluent Design aesthetic for DataGridView
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

            // Add Edit and Delete button columns with icons
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

            // Move the Edit and Delete columns to the right
            dataGridView1.Columns["EditColumn"].DisplayIndex = dataGridView1.Columns.Count - 2;
            dataGridView1.Columns["DeleteColumn"].DisplayIndex = dataGridView1.Columns.Count - 1;
        }

        private void LoadData()
        {
            var data = subjectManagerController.loadMonHocList();
            dataGridView1.DataSource = data;
            dataGridView1.Columns["MaMon"].HeaderText = "Mã Môn";
            dataGridView1.Columns["TenMon"].HeaderText = "Tên Môn";
            dataGridView1.Columns["EditColumn"].DisplayIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns["DeleteColumn"].DisplayIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns["MaMon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["TenMon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the row index is valid
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dataGridView1.Columns["EditColumn"].Index)
            {
                // Load data into the form
                var id = dataGridView1.Rows[e.RowIndex].Cells["MaMon"].Value.ToString();
                var tenMH = dataGridView1.Rows[e.RowIndex].Cells["TenMon"].Value.ToString();
                txtmasv.Text = id;
                txthotensv.Text = tenMH;

            }
            else if (e.ColumnIndex == dataGridView1.Columns["DeleteColumn"].Index)
            {
                // Yes/No confirmation dialog
                var dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // Handle Delete action
                    var id = dataGridView1.Rows[e.RowIndex].Cells["MaMon"].Value.ToString();
                    var result = subjectManagerController.deleteMonHoc(id);
                    if (result)
                    {
                        MessageBox.Show("Xóa môn học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa môn học thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Do nothing
                }

            }
        }

        private void txtmasv_TextChanged(object sender, EventArgs e)
        {

        }

        private void txthotensv_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (subjectManagerController.updateOrCreateMonHoc(txtmasv.Text, txthotensv.Text))
            {
                MessageBox.Show("Cập nhật môn học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật môn học thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
