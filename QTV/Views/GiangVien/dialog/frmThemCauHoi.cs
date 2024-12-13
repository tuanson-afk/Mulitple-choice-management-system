using DocumentFormat.OpenXml.Spreadsheet;
using QTV.Controllers;
using QTV.DataAccess;
using QTV.Models;
using QTV.Usercontrol.giangVien;
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
using static System.Net.Mime.MediaTypeNames;

namespace QL_Trac_Nghiem
{
    public partial class frmThemCauHoi : Form
    {
        private string maMonHocHienTai;
        private string maNHCauHoiHienTai;
        private string selectedMaChuong; // Biến để lưu mã chương
        private string selectedMaMucDo; // Biến để lưu mã chương

        private string _maCauHoiHienTai = ""; // random

        private string _noiDung;
        private string _maChuong;
        private string _maMucDo;
        private List<PhuongAn> _phuongAns = new List<PhuongAn>();

        private List<Chuong> _listChuongHienTai;
        private List<MucDo> _listMucDoHienTai;


        public frmThemCauHoi(string maNHCauHoiHienTai, string maMonHocHienTai, string noiDung = "", string maChuong = "", string maMucDo = "", string maCauHoiHienTai = "", List<PhuongAn> phuongAns = null)
        {
            InitializeComponent();
            this.maMonHocHienTai = maMonHocHienTai;
            this.maNHCauHoiHienTai = maNHCauHoiHienTai;

            this._noiDung = noiDung;
            this._maChuong = maChuong;
            this._maMucDo = maMucDo;
            this._maCauHoiHienTai = maCauHoiHienTai;
            this._phuongAns = phuongAns;

            if (!string.IsNullOrEmpty(_maCauHoiHienTai) && (_phuongAns.Count != 0))
            {
                title.Text = "Sửa thông tin câu hỏi";
                txtNoiDung.Text = _noiDung;
                txtA.Text = _phuongAns[0].NoiDung;
                txtB.Text = _phuongAns[1].NoiDung;
                txtC.Text = _phuongAns[2].NoiDung;
                txtD.Text = _phuongAns[3].NoiDung;
                if (_phuongAns[0].DungSai == 1)
                {
                    radioBtnA.Checked = true;
                }
                if (_phuongAns[1].DungSai == 1)
                {
                    radioBtnB.Checked = true;
                }
                if (_phuongAns[2].DungSai == 1)
                {
                    radioBtnC.Checked = true;
                }
                if (_phuongAns[3].DungSai == 1)
                {
                    radioBtnD.Checked = true;
                }

            }
            else
            {
                title.Text = "Thêm câu hỏi";
            }

            LoadData(maMonHocHienTai);
        }

        private void LoadData(string maMonHocHienTai)
        {
            LoadDataChuong(maMonHocHienTai);
            LoadDataMucDo();
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

        private void LoadDataChuong(string maMonHienTai)
        {
            try
            {
                // Gọi hàm LoadChuongByMaMon để lấy dữ liệu
                QuestionBankController questionBankController = new QuestionBankController();
                DataTable dt = questionBankController.LoadChuongByMaMon(maMonHienTai);

                // Xóa các mục cũ trong ComboBox
                cbChonChuong.Items.Clear();

                // Khởi tạo danh sách chương
                _listChuongHienTai = new List<Chuong>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Thêm các mục mới vào ComboBox
                    // List<Chuong> chuongList = new List<Chuong>();

                    // Thêm các mục mới vào ComboBox
                    foreach (DataRow row in dt.Rows)
                    {
                        Chuong chuong = new Chuong
                        {
                            MaChuong = row["MaChuong"].ToString(),
                            TenChuong = row["TenChuong"].ToString()
                        };
                        // Thêm đối tượng Chuong vào danh sách
                        _listChuongHienTai.Add(chuong);

                        // Tạo một ComboBoxItem và gắn Chuong làm Tag
                        ComboBoxItem item = new ComboBoxItem
                        {
                            DisplayText = chuong.TenChuong,
                            Value = chuong.MaChuong // Hoặc lưu toàn bộ chuong nếu cần
                        };

                        // Gắn item vào ComboBox
                        cbChonChuong.Items.Add(item);
                    }

                    // Thiết lập DisplayMember để hiển thị tên chương
                    cbChonChuong.DisplayMember = "DisplayText";

                    // Nếu có ít nhất một mục, chọn mục có giá trị = _maChuong
                    if (!string.IsNullOrEmpty(_maChuong))
                    {
                        // Duyệt qua các items trong ComboBox để tìm item có Value == _maChuong
                        for (int i = 0; i < cbChonChuong.Items.Count; i++)
                        {
                            ComboBoxItem item = (ComboBoxItem)cbChonChuong.Items[i];

                            if (item.Value.ToString() == _maChuong)
                            {
                                cbChonChuong.SelectedIndex = i; // Chọn index của item có giá trị Value == _maChuong
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Nếu không có _maChuong, chọn mục đầu tiên trong ComboBox
                        cbChonChuong.SelectedIndex = 0;
                    }
                }
                else
                {
                    // Nếu không có dữ liệu, thêm thông báo
                    cbChonChuong.Items.Add("Không có chương nào");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Có lỗi xảy ra khi tải danh sách chương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbChonChuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChonChuong.SelectedItem is ComboBoxItem selectedItem)
            {
                // Lấy đối tượng Chuong từ Value
                _maChuong = selectedItem.Value.ToString();
                selectedMaChuong = selectedItem.Value.ToString(); // Hoặc cast sang kiểu Chuong nếu lưu toàn bộ
                // MessageBox.Show($"Mã chương được chọn: {selectedMaChuong}");
            }
        }

        private void LoadDataMucDo()
        {
            try
            {
                QuestionBankController questionBankController = new QuestionBankController();
                DataTable dt = questionBankController.LoadAllMucDo();

                cbChonMucDo.Items.Clear();

                _listMucDoHienTai = new List<MucDo>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        MucDo mucDo = new MucDo
                        {
                            MaMucDo = row["MaMucDo"].ToString(),
                            TenMucDo = row["TenMucDo"].ToString()
                        };

                        _listMucDoHienTai.Add(mucDo);

                        ComboBoxItem item = new ComboBoxItem
                        {
                            DisplayText = mucDo.TenMucDo,
                            Value = mucDo.MaMucDo
                        };

                        cbChonMucDo.Items.Add(item);
                    }

                    cbChonMucDo.DisplayMember = "DisplayText";

                    if (!string.IsNullOrEmpty(_maMucDo))
                    {
                        for (int i = 0; i < cbChonMucDo.Items.Count; i++)
                        {
                            ComboBoxItem item = (ComboBoxItem)cbChonMucDo.Items[i];

                            if (item.Value.ToString() == _maMucDo)
                            {
                                cbChonMucDo.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        cbChonMucDo.SelectedIndex = 0;
                    }
                }
                else
                {
                    cbChonMucDo.Items.Add("Không có mức độ nào");
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Có lỗi xảy ra khi tải danh sách chương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void cbChonMucDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có item được chọn
            if (cbChonMucDo.SelectedItem != null)
            {
                try
                {
                    string tenMucDo = cbChonMucDo.SelectedItem.ToString();
                    var ado = ADO.Instance;
                    string query = "SELECT MaMucDo FROM [QTV3].[dbo].[MucDo] WHERE TenMucDo = @TenMucDo";
                    var tenMucDoParam = ado.CreateParameter("@TenMucDo", tenMucDo);
                    var result = ado.ExecuteQuery(query, tenMucDoParam);

                    if (result != null && result.Rows.Count > 0)
                    {
                        string maMucDo = result.Rows[0]["MaMucDo"].ToString();
                        selectedMaMucDo = maMucDo;
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy mã mức độ.");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }*/

        private void cbChonMucDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChonMucDo.SelectedItem is ComboBoxItem selectedItem)
            {
                _maMucDo = selectedItem.Value.ToString();
                selectedMaMucDo = selectedItem.Value.ToString();
            }
        }

        private void btnLuuCauHoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(txtNoiDung.Text.Trim()) ||
                    string.IsNullOrEmpty(txtA.Text.Trim()) ||
                    string.IsNullOrEmpty(txtB.Text.Trim()) ||
                    string.IsNullOrEmpty(txtC.Text.Trim()) ||
                    string.IsNullOrEmpty(txtD.Text.Trim()) ||
                    (!radioBtnA.Checked && !radioBtnB.Checked && !radioBtnC.Checked && !radioBtnD.Checked))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //_noiDung = txtNoiDung.Text;
                //_phuongAns = new List<PhuongAn>();

                //_phuongAns.Add(new PhuongAn { NoiDung = txtA.Text, DungSai = radioBtnA.Checked ? 1 : 0 });
                //_phuongAns.Add(new PhuongAn { NoiDung = txtB.Text, DungSai = radioBtnB.Checked ? 1 : 0 });
                //_phuongAns.Add(new PhuongAn { NoiDung = txtC.Text, DungSai = radioBtnC.Checked ? 1 : 0 });
                //_phuongAns.Add(new PhuongAn { NoiDung = txtD.Text, DungSai = radioBtnD.Checked ? 1 : 0 });

                // QuestionBankController questionBankController = new QuestionBankController();

                //if (!string.IsNullOrEmpty(_maCauHoiHienTai) && (_phuongAns.Count != 0))
                //{
                //    //bool isUpdated = questionBankController.UpdateQuestion(maCauHoi: _maCauHoiHienTai, NoiDung: _noiDung, MaMon: maMonHocHienTai, MaChuong: _maChuong, MaMucDo: _maMucDo, phuongAns: _phuongAns);
                //    //if (isUpdated)
                //    //{
                //    //    MessageBox.Show("Cập nhật thành công!");
                //    //    this.DialogResult = DialogResult.OK;
                //    //    this.Close();
                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("Cập nhật thất bại!");
                //    //}
                //}
                //else
                //{
                //    bool isAdded = questionBankController.AddQuestion(maCauHoi: _maCauHoiHienTai, NoiDung: _noiDung, MaMon: maMonHocHienTai, MaChuong: _maChuong, MaMucDo: _maMucDo, MaNHCauHoi: maNHCauHoiHienTai, _phuongAns);

                //    if (isAdded)
                //    {
                //        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        this.Close();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Thêm thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}

                _noiDung = txtNoiDung.Text;
                _phuongAns = new List<PhuongAn>();

                _phuongAns.Add(new PhuongAn { NoiDung = txtA.Text, DungSai = radioBtnA.Checked ? 1 : 0 });
                _phuongAns.Add(new PhuongAn { NoiDung = txtB.Text, DungSai = radioBtnB.Checked ? 1 : 0 });
                _phuongAns.Add(new PhuongAn { NoiDung = txtC.Text, DungSai = radioBtnC.Checked ? 1 : 0 });
                _phuongAns.Add(new PhuongAn { NoiDung = txtD.Text, DungSai = radioBtnD.Checked ? 1 : 0 });

                QuestionBankController questionBankController = new QuestionBankController();

                if (!string.IsNullOrEmpty(_maCauHoiHienTai) && (_phuongAns.Count != 0))
                {
                    bool isUpdated = questionBankController.UpdateQuestion(maCauHoi: _maCauHoiHienTai, NoiDung: _noiDung, MaMon: maMonHocHienTai, MaChuong: _maChuong, MaMucDo: _maMucDo, phuongAns: _phuongAns);
                    if (isUpdated)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool isAdded = questionBankController.AddQuestion(NoiDung: _noiDung, MaMon: maMonHocHienTai, MaChuong: _maChuong, MaMucDo: _maMucDo, MaNHCauHoi: maNHCauHoiHienTai, _phuongAns);

                    if (isAdded)
                    {
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Debug.WriteLine("Nội dung câu hỏi: " + _noiDung);
                Debug.WriteLine("Mã chương: " + _maChuong);
                Debug.WriteLine("Mã mức độ: " + _maMucDo);
                if (_phuongAns.Count > 0 && _phuongAns != null)
                {
                    foreach (var phuongAn in _phuongAns)
                    {
                        // Debug.WriteLine("Mã phương án: " + phuongAn.MaCauHoi);
                        Debug.WriteLine("Nội dung câu hỏi: " + phuongAn.NoiDung);
                        Debug.WriteLine("Đúng sai đã chọn: " + phuongAn.DungSai);
                    }
                } else
                {
                    Debug.WriteLine("Danh sách phương án rỗng hoặc null!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
