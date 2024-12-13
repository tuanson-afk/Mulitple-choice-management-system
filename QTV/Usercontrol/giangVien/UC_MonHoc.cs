using Guna.UI2.WinForms;
using QTV.Controllers;
using QTV.Models;
using QTV.Usercontrol.giangVien;
using QTV.Usercontrol.sinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Trac_Nghiem.UserControls
{
    public partial class UC_MonHoc : UserControl
    {
        private Guna2HtmlLabel lblNoData;

        public UC_MonHoc()
        {
            InitializeComponent();
            CreateNoDataLabel();
            loadListMonHoc();
        }

        private void CreateNoDataLabel()
        {
            lblNoData = new Guna2HtmlLabel
            {
                Text = "Không có dữ liệu",
                TextAlignment = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                Visible = false
            };
            flpMonHoc.Controls.Add(lblNoData);
        }

        /* private void loadListMonHoc()
        {
            var list = new List<MonHoc>
        {
            new MonHoc{ MaMon = "MM1010", TenMon = "Toán", },
            new MonHoc{ MaMon = "MM1011", TenMon = "Văn", },
            new MonHoc{ MaMon = "MM1012", TenMon = "Anh", },
            new MonHoc{ MaMon = "MM1013", TenMon = "Lý", },
            new MonHoc{ MaMon = "MM1014", TenMon = "Hóa", },
            new MonHoc{ MaMon = "MM1015", TenMon = "Sử", },
            new MonHoc{ MaMon = "MM1016", TenMon = "Địa", },
            new MonHoc{ MaMon = "MM1017", TenMon = "CNTT", },
        };

            if (list.Count == 0)
            {
                lblNoData.Visible = true;
            } else
            {
                lblNoData.Visible = false;
                foreach (var monHoc in list)
                {
                    UcMonHocItem ucItem = new UcMonHocItem();
                    ucItem.MonHoc = monHoc;
                    ucItem.TenMon = monHoc.TenMon;
                    ucItem.MaMon = monHoc.MaMon;

                    ucItem.ItemClicked += (s, monHoc) =>
                    {
                        MessageBox.Show("Chi tiết Môn học: " + monHoc.TenMon);
                    };

                    flpMonHoc.Controls.Add(ucItem);
                }
            }
        } */

        private void loadListMonHoc()
        {
            SubjectController subjectController = new SubjectController();
            DataTable dataTable = subjectController.LoadAllSubjects();

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                lblNoData.Visible = true; // Hiển thị nhãn "Không có dữ liệu" nếu không có kết quả
            }
            else
            {
                lblNoData.Visible = false; // Ẩn nhãn nếu có dữ liệu
                flpMonHoc.Controls.Clear(); // Xóa các phần tử trước khi tải mới
                foreach (DataRow row in dataTable.Rows)
                {
                    var monHoc = new MonHoc
                    {
                        MaMon = row["MaMon"].ToString(),
                        TenMon = row["TenMon"].ToString()
                    };

                    UcMonHocItem ucItem = new UcMonHocItem
                    {
                        MonHoc = monHoc,
                        TenMon = monHoc.TenMon,
                        MaMon = monHoc.MaMon
                    };

                    ucItem.ItemClicked += (s, monHoc) =>
                    {
                        // Mở DetailForm khi nhấp vào phần tử
                        frmMonCuThe frmMonCuThe = new frmMonCuThe(monHoc);

                        // Xử lý sự kiện MonHocFormClosed để quay lại danh sách
                        frmMonCuThe.MonHocFormClosed += () =>
                        {
                            // Hiển thị lại danh sách khi frmMonCuThe đóng
                            this.Visible = true;
                        };

                        // Ẩn danh sách khi mở DetailForm
                        // this.Visible = false;
                        frmMonCuThe.Show(); // Hiển thị form chi tiết
                    };

                    flpMonHoc.Controls.Add(ucItem);
                }
            }
        }
    }
}
