using OfficeOpenXml;
using QTV.Controllers;
using QTV.Models;
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
using System.Windows.Forms.DataVisualization.Charting;


namespace QL_Trac_Nghiem.UserControls
{
    public partial class UC_BaoCao : UserControl
    {
        private ReportController reportController = new ReportController();
        public UC_BaoCao()
        {
            InitializeComponent();
            LoadMonHoc();
            guna2Button2.Hide();
            guna2Button4.Hide();

        }

        public void LoadMonHoc()
        {
            List<MonHoc> mh = reportController.TransformMonHoc();
            // update ComboBox1
            comboBox1.DataSource = mh;
            comboBox1.DisplayMember = "TenMon";
            comboBox1.ValueMember = "MaMon";
            comboBox1.SelectedIndex = 0;
            // add event on change
            comboBox1.SelectedIndexChanged += new EventHandler(LoadLHP);


        }

        private void LoadLHP(object sender, EventArgs e)
        {
            List<LopHP> lhp = reportController.TransformLHP(comboBox1.SelectedValue.ToString());
            // update ComboBox2
            comboBox2.DataSource = lhp;
            comboBox2.DisplayMember = "TenLHP";
            comboBox2.ValueMember = "MaLHP";
            comboBox2.SelectedIndexChanged += new EventHandler(LoadBaiThi);

        }

        private void LoadBaiThi(object sender, EventArgs e)
        {
            List<BaiThi> bt = reportController.TransformBaiThi(comboBox2.SelectedValue.ToString());
            comboBox3.DataSource = bt;
            comboBox3.DisplayMember = "TenBaiThi";
            comboBox3.ValueMember = "MaBaiThi";

            guna2Button2.Show();
            guna2Button4.Show();

            comboBox3.SelectedIndexChanged += new EventHandler(LoadBaiLam);



        }

        private void LoadBaiLam(object sender, EventArgs e)
        {
            guna2Button2.Click += new EventHandler(guna2Button2_Click);
            guna2Button4.Click += new EventHandler(guna2Button4_Click);


            DataTable bl = reportController.LoadBaiLam(comboBox3.SelectedValue.ToString());

            dataGridView1.DataSource = bl;

            dataGridView1.Columns.Clear();

            dataGridView1.AutoGenerateColumns = false; 


            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Bài Làm",
                DataPropertyName = "MaBaiLam",
                Name = "MaBaiLam"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Sinh Viên",
                DataPropertyName = "MaSV"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Sinh Viên",
                DataPropertyName = "TenSV"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Bài Thi",
                DataPropertyName = "MaBaiThi"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Bắt đầu",
                DataPropertyName = "BatDau"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Kết thúc",
                DataPropertyName = "KetThuc"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Trạng Thái",
                DataPropertyName = "TenTrangThai"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số câu đúng",
                DataPropertyName = "SoCauDung"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Điểm",
                DataPropertyName = "Diem"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Xem Phiếu Điểm",
                DataPropertyName = "Phieu Diem",
                Name = "PhieuDiem",
                ReadOnly = true,
                // add click event
            });

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);


            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure the click is not on the header row
            if (e.RowIndex >= 0)
            {
                string maBaiLamValue = dataGridView1.Rows[e.RowIndex].Cells["MaBaiLam"].Value.ToString();

                
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xuất file excel");
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "Xuất File Excel"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                reportController.ExportToExcel(dataGridView1, saveFileDialog.FileName);
                MessageBox.Show("Xuất thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ShowScoreSpectrumPopup(dataGridView1 as DataGridView);
        }

        public void ShowScoreSpectrumPopup(DataGridView dgv)
        {
            var diemColumn = dgv.Columns
                                .Cast<DataGridViewColumn>()
                                .FirstOrDefault(col => col.DataPropertyName == "Diem");

            if (diemColumn == null)
            {
                MessageBox.Show("The 'Diem' column was not found in the DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int diemColumnIndex = diemColumn.Index;

            var scores = dgv.Rows
                            .Cast<DataGridViewRow>()
                            .Where(row => row.Cells[diemColumnIndex].Value != null)
                            .Select(row => Convert.ToDouble(row.Cells[diemColumnIndex].Value))
                            .ToList();

            int rangeStart = 0;
            int rangeEnd = 10;
            double rangeSize = 1.0;

            Dictionary<string, int> scoreFrequency = new Dictionary<string, int>();

            for (double i = rangeStart; i < rangeEnd; i += rangeSize)
            {
                string rangeKey = $"{i}-{i + rangeSize}";
                scoreFrequency[rangeKey] = 0;
            }

            foreach (var score in scores)
            {
                foreach (var key in scoreFrequency.Keys.ToList())
                {
                    var parts = key.Split('-');
                    double lowerBound = Convert.ToDouble(parts[0]);
                    double upperBound = Convert.ToDouble(parts[1]);

                    if (score >= lowerBound && score < upperBound)
                    {
                        scoreFrequency[key]++;
                        break;
                    }
                }
            }

            Form chartForm = new Form
            {
                Text = "Phân bố điểm",
                Width = 800,
                Height = 600
            };

            Chart chart = new Chart
            {
                Dock = DockStyle.Fill
            };
            ChartArea chartArea = new ChartArea
            {
                Name = "Khoảng điểm"
            };
            chart.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                Name = "Phân bố điểm",
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String
            };

            foreach (var range in scoreFrequency)
            {
                series.Points.AddXY(range.Key, range.Value);
            }

            chart.Series.Add(series);

            chartArea.AxisX.Title = "Khoảng điểm";
            chartArea.AxisY.Title = "Số Sinh Viên";
            chartArea.AxisX.Interval = 1;

            chartForm.Controls.Add(chart);
            chartForm.ShowDialog();
        }


    }
}
