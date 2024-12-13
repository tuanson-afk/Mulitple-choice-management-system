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
using static QL_Trac_Nghiem.frmThemCauHoi;

namespace QL_Trac_Nghiem
{
    public partial class frmThemBaiThi : Form
    {
        private bool _editMode;
        private string _maLopHPDangChon;
        private string _maMonHocHienTai;
        private BaiThi _baiThiDangDuocChon;

        private string _tenBaiThi;
        private string _moTa;
        private string _maDeThiDaChon;
        private List<DeThi> _danhSachDeThiHienTai;
        private string _TGLamBai;
        private DateTime _ngayBatDauDaChon;
        private DateTime _thoiGianBatDauDaChon;
        private DateTime _ngayKetThucDaChon;
        private DateTime _thoiGianKetThucDaChon;
        private int _hienDiem = 0;
        private int _xemLai = 0;
        private int _xaoTron = 0;

        public frmThemBaiThi(bool editMode, string maMon, string maLopHP, BaiThi baiThi = null)
        {
            InitializeComponent();
            this._editMode = editMode;
            this._maMonHocHienTai = maMon;
            this._maLopHPDangChon = maLopHP;
            this._baiThiDangDuocChon = baiThi;

            if (_editMode && _baiThiDangDuocChon != null)
            {
                this.Text = "Sửa bài thi";
                gbContainer.Text = "Sửa bài thi";
            }
            else
            {
                this.Text = "Thêm mới bài thi";
                gbContainer.Text = "Thêm bài thi";
            }
            LoadDataDeThi(_maMonHocHienTai);
        }

        public class ComboBoxItem
        {
            public string DisplayText { get; set; } // Tên hiển thị
            public object Value { get; set; }      // Lưu đối tượng

            public override string ToString()
            {
                return DisplayText; // Hiển thị tên trong ComboBox
            }
        }

        public void LoadDataDeThi(string maMon)
        {
            try
            {
                QuizController quizController = new QuizController();
                DataTable dt = quizController.LoadExamBySubject(maMon);

                cbChonDeThi.Items.Clear();

                // Khởi tạo danh sách chương
                _danhSachDeThiHienTai = new List<DeThi>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        DeThi deThi = new DeThi
                        {
                            MaDeThi = row["MaDeThi"].ToString(),
                            TenDeThi = row["TenDeThi"].ToString()
                        };
                        _danhSachDeThiHienTai.Add(deThi);

                        ComboBoxItem item = new ComboBoxItem
                        {
                            DisplayText = deThi.TenDeThi,
                            Value = deThi.MaDeThi
                        };

                        cbChonDeThi.Items.Add(item);
                    }

                    cbChonDeThi.DisplayMember = "DisplayText";

                    if (!string.IsNullOrEmpty(_maDeThiDaChon))
                    {
                        for (int i = 0; i < cbChonDeThi.Items.Count; i++)
                        {
                            ComboBoxItem item = (ComboBoxItem)cbChonDeThi.Items[i];

                            if (item.Value.ToString() == _maDeThiDaChon)
                            {
                                cbChonDeThi.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        cbChonDeThi.SelectedIndex = 0;
                    }
                }
                else
                {
                    cbChonDeThi.Items.Add("Không có đề thi nào");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Có lỗi xảy ra khi tải danh sách chương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbChonDeThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChonDeThi.SelectedItem is ComboBoxItem selectedItem)
            {
                _maDeThiDaChon = selectedItem.Value.ToString();
            }
        }

        private void frmThemBaiThi_Load(object sender, EventArgs e)
        {
            gbContainer.Left = (this.ClientSize.Width - gbContainer.Width) / 2;
            gbContainer.Top = (this.ClientSize.Height - gbContainer.Height) / 2;

            if (_editMode && _baiThiDangDuocChon != null)
            {
                tbTenBaiThi.Text = _baiThiDangDuocChon.TenBaiThi;
                tbMoTa.Text = _baiThiDangDuocChon.MoTa;
                _maDeThiDaChon = _baiThiDangDuocChon.MaDeThi;
                tbTGLamBai.Text = _baiThiDangDuocChon.ThoiLuong.ToString();

                Debug.WriteLine("Bắt đầu: ");
                Debug.WriteLine(_baiThiDangDuocChon.TGBatDau);

                // Cập nhật giá trị cho DateTimePicker (chỉ lấy giờ từ TGBatDau)
                DateTime timeOnly = _baiThiDangDuocChon.TGBatDau;  // Ví dụ: 11/20/2024 8:00:00 AM

                // Tạo DateTime mới chỉ chứa giờ, phút, giây, nhưng ngày hiện tại
                DateTime validTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeOnly.Hour, timeOnly.Minute, timeOnly.Second);

                // Gán vào dtpTGBatDau chỉ phần giờ
                dtpTGBatDau.Value = validTime;

                dtpNgayBatDau.Value = _baiThiDangDuocChon.TGBatDau.Date;

                DateTime timeOnlyKetThuc = _baiThiDangDuocChon.TGKetThuc;
                DateTime validTimeKetThuc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timeOnlyKetThuc.Hour, timeOnlyKetThuc.Minute, timeOnlyKetThuc.Second);
                dtpTGKetThuc.Value = validTimeKetThuc;
                dtpNgayKetThuc.Value = _baiThiDangDuocChon.TGKetThuc.Date;

                _hienDiem = _baiThiDangDuocChon.HienThi;
                _xemLai = _baiThiDangDuocChon.XemLai;
                _xaoTron = _baiThiDangDuocChon.XaoTron;
                UpdateSwitchState();
            }
        }

        private void btnThemDeThi_Click(object sender, EventArgs e)
        {
            string maGV = UserSession.Instance.UserId;
            bool editMode = true;

            //frmThemDeThi frmThemDeThi = new frmThemDeThi(editMode);
            //frmThemDeThi.ShowDialog();
        }

        private void btnLuuBaiThi_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tbTenBaiThi.Text.Trim()) ||
                string.IsNullOrEmpty(tbMoTa.Text.Trim()) ||
                string.IsNullOrEmpty(tbTGLamBai.Text.Trim())
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _tenBaiThi = tbTenBaiThi.Text;
            _moTa = tbMoTa.Text;
            // _TGLamBai = tbTGLamBai.Text;
            int thoiLuong;

            // Kiểm tra và chuyển đổi thời lượng (phải là số nguyên)
            if (!int.TryParse(tbTGLamBai.Text.Trim(), out thoiLuong) || thoiLuong <= 0)
            {
                MessageBox.Show("Thời lượng làm bài phải là một số nguyên dương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ngayBatDauDaChon = dtpNgayBatDau.Value.Date;
            _ngayKetThucDaChon = dtpNgayKetThuc.Value.Date;

            _thoiGianBatDauDaChon = dtpNgayBatDau.Value.Date.Add(dtpTGBatDau.Value.TimeOfDay);
            _thoiGianKetThucDaChon = dtpNgayKetThuc.Value.Date.Add(dtpTGKetThuc.Value.TimeOfDay);
            
            Debug.WriteLine("Tên bài thi: " + _tenBaiThi);
            Debug.WriteLine("Mô tả: " + _moTa);
            Debug.WriteLine("Thời gian làm bài: " + _TGLamBai);
            Debug.WriteLine("Thời gian bắt đầu: " + _thoiGianBatDauDaChon);
            Debug.WriteLine("Thời gian bắt đầu: " + _thoiGianBatDauDaChon.ToString("HH:mm:ss"));
            Debug.WriteLine("Ngày bắt đầu: " + _ngayBatDauDaChon);
            Debug.WriteLine("Thời gian kết thúc: " + _thoiGianKetThucDaChon);
            Debug.WriteLine("Thời gian kết thúc: " + _thoiGianKetThucDaChon.ToString("HH:mm:ss"));
            Debug.WriteLine("Ngày kết thúc: " + _ngayKetThucDaChon);
            Debug.WriteLine("");

            // Gọi hàm lưu bài thi vào database
            QuizController quizController = new QuizController();

            if (!_editMode)
            {
                bool isAdded = quizController.AddQuiz(
                _tenBaiThi,
                _moTa,
                _maDeThiDaChon,
                _thoiGianBatDauDaChon,
                _thoiGianKetThucDaChon,
                thoiLuong,
                _hienDiem, 
                _xemLai,
                _xaoTron,
                _maLopHPDangChon
            );

                if (isAdded)
                {
                    MessageBox.Show("Lưu bài thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xóa dữ liệu trong form
                    //tbTenDeThi.Clear();
                    //_danhSachMaCauHoiDaChon.Clear();
                    //_maChuongDaChon = null;
                    //_maMucDoDaChon = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu bài thi thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                bool isEdited = quizController.UpdateQuiz(
                    _baiThiDangDuocChon.MaBaiThi, 
                    _tenBaiThi, 
                    _moTa, 
                    _maDeThiDaChon, 
                    _thoiGianBatDauDaChon, 
                    _thoiGianKetThucDaChon, 
                    thoiLuong, 
                    _hienDiem, 
                    _xemLai, 
                    _xaoTron, 
                    _maLopHPDangChon);

                if (isEdited)
                {
                    MessageBox.Show("Lưu bài thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _baiThiDangDuocChon = null;
                    this.Close();
                } else
                {
                    MessageBox.Show("Lưu bài thi thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbTGLamBai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu không phải số và không phải phím điều khiển
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Hủy sự kiện (không cho phép nhập)
                e.Handled = true;
            }
        }

        private void switchHienDiem_CheckedChanged(object sender, EventArgs e)
        {
            _hienDiem = switchHienDiem.Checked ? 1 : 0;
            UpdateSwitchState();
        }

        private void switchXemLaiBai_CheckedChanged(object sender, EventArgs e)
        {
            _xemLai = switchXemLaiBai.Checked ? 1 : 0;
            UpdateSwitchState();
        }

        private void swithTronCH_CheckedChanged(object sender, EventArgs e)
        {
            _xaoTron = swithTronCH.Checked ? 1 : 0;
            UpdateSwitchState();
        }

        private void UpdateSwitchState()
        {
            // Cập nhật giá trị cho các switch

            // Đảm bảo rằng khi cập nhật, trạng thái của các switch không gây vòng lặp vô hạn
            switchHienDiem.CheckedChanged -= switchHienDiem_CheckedChanged;
            switchXemLaiBai.CheckedChanged -= switchXemLaiBai_CheckedChanged;
            swithTronCH.CheckedChanged -= swithTronCH_CheckedChanged;

            // Cập nhật lại trạng thái của các switch từ biến
            switchHienDiem.Checked = _hienDiem == 1;
            switchXemLaiBai.Checked = _xemLai == 1;
            swithTronCH.Checked = _xaoTron == 1;

            // Đăng ký lại sự kiện CheckedChanged sau khi cập nhật
            switchHienDiem.CheckedChanged += switchHienDiem_CheckedChanged;
            switchXemLaiBai.CheckedChanged += switchXemLaiBai_CheckedChanged;
            swithTronCH.CheckedChanged += swithTronCH_CheckedChanged;

            //switchHienDiem.Checked = _hienDiem;
            //switchXemLaiBai.Checked = _xemLai;
            //swithTronCH.Checked = _xaoTron;
        }
    }
}
