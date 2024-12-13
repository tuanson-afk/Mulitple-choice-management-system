using DocumentFormat.OpenXml.Spreadsheet;
using QTV.Controllers;
using QTV.Models;
using QTV.Views.General;
using QTV.Views.GiangVien.dialog;
using QuanLyTracNghiem;
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
using static QL_Trac_Nghiem.frmThemCauHoi;

namespace QL_Trac_Nghiem
{
    public partial class frmThemDeThi : Form
    {
        private bool _editMode;
        private MonHoc _monHocHienTai;

        private List<Chuong> _chuongList;
        private string _maChuongDaChon;
        private List<MucDo> _mucDoList;
        private string _maMucDoDaChon;

        private string _tenDeThi;
        private List<string> _danhSachMaCauHoiDaChon = new List<string>();

        private DeThi _deThiHienTai;

        public frmThemDeThi(bool editMode, MonHoc monHoc, DeThi deThi = null)
        {
            InitializeComponent();
            this._editMode = editMode;
            this._monHocHienTai = monHoc;
            this._deThiHienTai = deThi;

            if (_deThiHienTai != null)
            {
                _tenDeThi = _deThiHienTai.TenDeThi;
                _maChuongDaChon = _deThiHienTai.MaChuong;
                _maMucDoDaChon = _deThiHienTai.MaMucDo;
                _danhSachMaCauHoiDaChon = _deThiHienTai.DanhSachMaCauHoiDaChon;
            }
            LoadData(_monHocHienTai.MaMon);

        }

        private void frmThemDeThi_Load(object sender, EventArgs e)
        {
            if (_editMode && _deThiHienTai != null)
            {
                this.Text = "Sửa đề thi";
                tbTenDeThi.Text = _deThiHienTai.TenDeThi;
                LoadDataDanhSachCauHoi(_monHocHienTai.MaMon);
            }
            else
            {
                this.Text = "Thêm đề thi";
            }

            //LoadDataChuong(_monHocHienTai.MaMon);
            //LoadDataMucDo();
            //LoadDataDanhSachCauHoi(_monHocHienTai.MaMon);


        }

        private void LoadData(string maMon)
        {
            LoadingBox loadingBox = new LoadingBox();
            loadingBox.Show();
            LoadDataChuong(_monHocHienTai.MaMon);
            LoadDataMucDo();
            LoadDataDanhSachCauHoi(_monHocHienTai.MaMon);
            loadingBox.Close();
        }

        private void btnLuuDeThi_Click(object sender, EventArgs e)
        {
            _tenDeThi = tbTenDeThi.Text;

            if (string.IsNullOrWhiteSpace(_tenDeThi))
            {
                MessageBox.Show("Vui lòng nhập tên đề thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_danhSachMaCauHoiDaChon == null || _danhSachMaCauHoiDaChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một câu hỏi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuizController quizController = new QuizController();

            if (!_editMode)
            {
                var result = quizController.AddExamWithQuestions(_tenDeThi, _monHocHienTai.MaMon, _maChuongDaChon, _maMucDoDaChon, _danhSachMaCauHoiDaChon);

                if (result)
                {
                    MessageBox.Show("Đã lưu đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xóa dữ liệu trong form
                    tbTenDeThi.Clear();
                    _danhSachMaCauHoiDaChon.Clear();
                    _maChuongDaChon = null;
                    _maMucDoDaChon = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu đề thi thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var result = quizController.EditExamWithQuestions(_deThiHienTai.MaDeThi, _tenDeThi, _monHocHienTai.MaMon, _maChuongDaChon, _maMucDoDaChon, _danhSachMaCauHoiDaChon);

                if (result)
                {
                    MessageBox.Show("Đã lưu đề thi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbTenDeThi.Clear();
                    _danhSachMaCauHoiDaChon.Clear();
                    _maChuongDaChon = null;
                    _maMucDoDaChon = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu đề thi thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Debug.WriteLine("Tên đề thi: " + _tenDeThi);
            Debug.WriteLine("Mã chương: " + _maChuongDaChon);
            Debug.WriteLine("Mã mức độ: " + _maMucDoDaChon);
            foreach (var maCauHoi in _danhSachMaCauHoiDaChon)
            {
                Debug.WriteLine("Mã câu hỏi đã chọn: " + maCauHoi);
            }
        }

        private void LoadDataDanhSachCauHoi(string maMon)
        {
            dataGridViewDanhSachCauHoi.DataSource = null;
            dataGridViewDanhSachCauHoi.Columns.Clear();

            dataGridViewDanhSachCauHoi.CellValueChanged -= DataGridViewDanhSachCauHoi_CellValueChanged;
            dataGridViewDanhSachCauHoi.CurrentCellDirtyStateChanged -= DataGridViewDanhSachCauHoi_CurrentCellDirtyStateChanged;

            QuestionBankController questionBankController = new QuestionBankController();
            DataTable dt = questionBankController.LoadQuestionsList(maMon);

            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridViewDanhSachCauHoi.DataSource = dt;

                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "SelectColumn",
                    HeaderText = "Chon",
                    Width = 50,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle { NullValue = false }
                };
                dataGridViewDanhSachCauHoi.Columns.Insert(0, checkBoxColumn);

                // Đăng ký sự kiện khi giá trị checkbox thay đổi
                dataGridViewDanhSachCauHoi.CellValueChanged += DataGridViewDanhSachCauHoi_CellValueChanged;
                dataGridViewDanhSachCauHoi.CurrentCellDirtyStateChanged += DataGridViewDanhSachCauHoi_CurrentCellDirtyStateChanged;

                // Kiểm tra và tự động tích checkbox cho những câu hỏi có mã trong _danhSachMaCauHoiDaChon
                if (_danhSachMaCauHoiDaChon != null && _danhSachMaCauHoiDaChon.Count > 0)
                {
                    //foreach (var maCauHoi in _danhSachMaCauHoiDaChon)
                    //{
                    //    Debug.WriteLine("Mã câu hỏi đã chọn: " + maCauHoi);
                    //}
                    foreach (DataGridViewRow row in dataGridViewDanhSachCauHoi.Rows)
                    {
                        if (row.IsNewRow) continue; // Bỏ qua hàng trống (nếu có)

                        // Lấy mã câu hỏi từ cột "MaCauHoi"
                        if (row.Cells["MaCauHoi"].Value != null)
                        {
                            string maCauHoi = row.Cells["MaCauHoi"].Value.ToString();

                            // Kiểm tra nếu mã câu hỏi có trong danh sách đã chọn
                            bool isChecked = _danhSachMaCauHoiDaChon.Contains(maCauHoi);
                            // Debug.WriteLine("Mã câu hỏi: " + maCauHoi);
                            // Debug.WriteLine("Mã câu hỏi đã chọn: " + _danhSachMaCauHoiDaChon[1]);
                            Debug.WriteLine("Mã số 2 " + isChecked);
                            // row.Cells["SelectColumn"].Value = isChecked; // Cập nhật trạng thái checkbox
                            row.Cells["SelectColumn"].Value = Convert.ToBoolean(isChecked);
                            Debug.WriteLine("Đáp án: " + row.Cells["SelectColumn"].Value);

                            // Làm mới giao diện
                            dataGridViewDanhSachCauHoi.InvalidateRow(row.Index);
                        }
                    }
                    // dataGridViewDanhSachCauHoi.Refresh();
                }

            }
            else
            {
                dataGridViewDanhSachCauHoi.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ThongBao",
                    HeaderText = "Không có dữ liệu",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            }
        }

        private void LoadDataChuong(string maMon)
        {
            try
            {
                QuestionBankController questionBankController = new QuestionBankController();
                DataTable dt = questionBankController.LoadChuongByMaMon(maMon);
                cbChuong.Items.Clear();
                _chuongList = new List<Chuong>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Chuong chuong = new Chuong
                        {
                            MaChuong = row["MaChuong"].ToString(),
                            TenChuong = row["TenChuong"].ToString()
                        };
                        _chuongList.Add(chuong);

                        ComboBoxItem item = new ComboBoxItem
                        {
                            DisplayText = chuong.TenChuong,
                            Value = chuong.MaChuong
                        };

                        cbChuong.Items.Add(item);
                    }
                    cbChuong.DisplayMember = "DisplayText";

                    // Nếu có ít nhất một mục, chọn mục có giá trị = _maChuong
                    if (!string.IsNullOrEmpty(_maChuongDaChon))
                    {
                        // Duyệt qua các items trong ComboBox để tìm item có Value == _maChuong
                        for (int i = 0; i < cbChuong.Items.Count; i++)
                        {
                            ComboBoxItem item = (ComboBoxItem)cbChuong.Items[i];

                            if (item.Value.ToString() == _maChuongDaChon)
                            {
                                cbChuong.SelectedIndex = i; // Chọn index của item có giá trị Value == _maChuong
                                break;
                            }
                        }
                    }
                    else
                    {
                        cbChuong.SelectedIndex = 0;
                    }
                }
                else
                {
                    cbChuong.Items.Add("Không có chương nào");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Có lỗi xảy ra khi tải danh sách chương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbChuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChuong.SelectedItem is ComboBoxItem selectedItem)
            {
                // Lấy đối tượng Chuong từ Value
                _maChuongDaChon = selectedItem.Value.ToString();
            }
        }

        private void LoadDataMucDo()
        {
            try
            {
                QuestionBankController questionBankController = new QuestionBankController();
                DataTable dt = questionBankController.LoadAllMucDo();
                cbMucDo.Items.Clear();
                _mucDoList = new List<MucDo>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        MucDo mucDo = new MucDo
                        {
                            MaMucDo = row["MaMucDo"].ToString(),
                            TenMucDo = row["TenMucDo"].ToString()
                        };
                        _mucDoList.Add(mucDo);
                        ComboBoxItem item = new ComboBoxItem
                        {
                            DisplayText = mucDo.TenMucDo,
                            Value = mucDo.MaMucDo
                        };
                        cbMucDo.Items.Add(item);
                    }
                    cbMucDo.DisplayMember = "DisplayText";

                    if (!string.IsNullOrEmpty(_maMucDoDaChon))
                    {
                        for (int i = 0; i < cbMucDo.Items.Count; i++)
                        {
                            ComboBoxItem item = (ComboBoxItem)cbMucDo.Items[i];

                            if (item.Value.ToString() == _maMucDoDaChon)
                            {
                                cbMucDo.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        cbMucDo.SelectedIndex = 0;
                    }
                }
                else
                {
                    cbMucDo.Items.Add("Không có mức độ nào");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Có lỗi xảy ra khi tải danh sách chương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMucDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMucDo.SelectedItem is ComboBoxItem selectedItem)
            {
                _maMucDoDaChon = selectedItem.Value.ToString();
            }
        }

        private void DataGridViewDanhSachCauHoi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột hiện tại là cột checkbox
            if (e.ColumnIndex == dataGridViewDanhSachCauHoi.Columns["SelectColumn"].Index)
            {
                DataGridViewRow row = dataGridViewDanhSachCauHoi.Rows[e.RowIndex];

                // Lấy mã câu hỏi từ cột "MaCauHoi" (đảm bảo cột này tồn tại trong DataTable)
                // string maCauHoi = row.Cells["MaCauHoi"].Value.ToString();
                string maCauHoi = dataGridViewDanhSachCauHoi.Rows[e.RowIndex].Cells["MaCauHoi"].Value.ToString();
                // Kiểm tra trạng thái checkbox
                // bool isChecked = Convert.ToBoolean(row.Cells["SelectColumn"].Value);
                bool isChecked = (bool)dataGridViewDanhSachCauHoi.Rows[e.RowIndex].Cells["SelectColumn"].Value;
                if (isChecked)
                {
                    // Thêm mã câu hỏi vào danh sách
                    if (!_danhSachMaCauHoiDaChon.Contains(maCauHoi))
                    {
                        _danhSachMaCauHoiDaChon.Add(maCauHoi);
                    }
                }
                else
                {
                    // Xóa mã câu hỏi khỏi danh sách
                    _danhSachMaCauHoiDaChon.Remove(maCauHoi);
                }
            }
        }
        //private void DataGridViewDanhSachCauHoi_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    if (dataGridViewDanhSachCauHoi.IsCurrentCellDirty)
        //    {
        //        dataGridViewDanhSachCauHoi.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //    }
        //}

        private void DataGridViewDanhSachCauHoi_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewDanhSachCauHoi.IsCurrentCellDirty)
            {
                dataGridViewDanhSachCauHoi.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Kiểm tra nếu ô hiện tại thuộc cột SelectColumn
                //if (dataGridViewDanhSachCauHoi.CurrentCell.OwningColumn.Name == "SelectColumn")
                //{
                //    bool isChecked = (bool)dataGridViewDanhSachCauHoi.CurrentCell.Value;
                //    Debug.WriteLine("Checkbox trạng thái mới: " + isChecked);
                //}
            }
        }

        private void btnXemTruocCauHoi_Click(object sender, EventArgs e)
        {
            _tenDeThi = tbTenDeThi.Text;
            if (_tenDeThi.Length > 0 && _danhSachMaCauHoiDaChon.Count != 0)
            {
                frmXemTruocDeThi frmXemTruocDeThi = new frmXemTruocDeThi(_tenDeThi, _maChuongDaChon, _maMucDoDaChon, _danhSachMaCauHoiDaChon);
                frmXemTruocDeThi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
        }

        private void dataGridViewDanhSachCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}