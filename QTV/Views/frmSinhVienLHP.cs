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

namespace QTV.Views
{
    public partial class frmSinhVienLHP : Form
    {
        public string maLHP;
        public frmSinhVienLHP(string maLHP)
        {
            InitializeComponent();
            this.maLHP = maLHP;
            InitializeFluentDesign();
            LoadData();
        }

        private void InitializeFluentDesign()
        {
            dgvSinhVien.BorderStyle = BorderStyle.None;
            dgvSinhVien.EnableHeadersVisualStyles = false;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvSinhVien.DefaultCellStyle.BackColor = Color.White;
            dgvSinhVien.DefaultCellStyle.ForeColor = Color.Black;
            dgvSinhVien.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvSinhVien.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSinhVien.GridColor = Color.Gainsboro;

            DataGridViewImageColumn studentColumn = new DataGridViewImageColumn();
            studentColumn.Name = "DSSV";
            studentColumn.HeaderText = "Xóa";
            studentColumn.Image = Properties.Resources.cross_circle__3_;
            studentColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            studentColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSinhVien.Columns.Add(studentColumn);

            dgvSinhVien.Columns["DSSV"].DisplayIndex = dgvSinhVien.Columns.Count - 1;

            dgvSinhVienNot.BorderStyle = BorderStyle.None;
            dgvSinhVienNot.EnableHeadersVisualStyles = false;
            dgvSinhVienNot.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            dgvSinhVienNot.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSinhVienNot.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvSinhVienNot.DefaultCellStyle.BackColor = Color.White;
            dgvSinhVienNot.DefaultCellStyle.ForeColor = Color.Black;
            dgvSinhVienNot.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvSinhVienNot.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSinhVienNot.GridColor = Color.Gainsboro;

            DataGridViewImageColumn studentColumn2 = new DataGridViewImageColumn();
            studentColumn2.Name = "DSSV";
            studentColumn2.HeaderText = "Thêm";
            studentColumn2.Image = Properties.Resources.cross_circle__3_;
            studentColumn2.ImageLayout = DataGridViewImageCellLayout.Zoom;
            studentColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSinhVienNot.Columns.Add(studentColumn2);

            dgvSinhVienNot.Columns["DSSV"].DisplayIndex = dgvSinhVienNot.Columns.Count - 1;

            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            dgvSinhVienNot.CellClick += dgvSinhVienNot_CellClick;
        }

        public void LoadData()
        {
            ClassController classController = new ClassController();
            DataTable inClass = classController.loadSinhVienInClass(maLHP);

            DataTable filteredTable = new DataTable();

            filteredTable.Columns.Add("Họ Và Tên", typeof(string));
            filteredTable.Columns.Add("Mã Sinh Viên", typeof(string));

            foreach (DataRow row in inClass.Rows)
            {
                filteredTable.Rows.Add(row["TenSV"], row["MaSV"]);
            }

            dgvSinhVien.DataSource = filteredTable;

            DataTable notInClass = classController.loadSinhVienNotInClass(maLHP);

            DataTable filteredTable2 = new DataTable();

            filteredTable2.Columns.Add("Họ Và Tên", typeof(string));
            filteredTable2.Columns.Add("Mã Sinh Viên", typeof(string));

            foreach (DataRow row in notInClass.Rows)
            {
                filteredTable2.Rows.Add(row["TenSV"], row["MaSV"]);
            }
            dgvSinhVienNot.DataSource = filteredTable2;



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSinhVien.Columns[e.ColumnIndex].Name == "DSSV")
            {
                string maSV = dgvSinhVien.Rows[e.RowIndex].Cells["Mã Sinh Viên"].Value.ToString();
                removeSVFromClass(maSV, maLHP);
            }
        }

        private void dgvSinhVienNot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSinhVienNot.Columns[e.ColumnIndex].Name == "DSSV")
            {
                string maSV = dgvSinhVienNot.Rows[e.RowIndex].Cells["Mã Sinh Viên"].Value.ToString();
                addSVToClass(maSV, maLHP);
            }
        }

        private void addSVToClass(string MaSV, string LopHP)
        {
            ClassController classController = new ClassController();
            classController.addSinhVienToClass(MaSV, LopHP);
            LoadData();
        }

        private void removeSVFromClass(string MaSV, string LopHP)
        {
            ClassController classController = new ClassController();
            classController.removeSinhVienFromClass(MaSV, LopHP);
            LoadData();

        }
    }
}
