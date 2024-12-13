using QTV.DataAccess;
using QTV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTV.Views.GiangVien.dialog
{
    public partial class frmXemTruocDeThi : Form
    {
        private string _tenDeThi;
        private string _maChuong;
        private string _maMucDo;
        private List<string> _danhSachMaCauHoi = new List<string>();
        public frmXemTruocDeThi(string tenDeThi = "", string maChuong = "", string maMucDo = "", List<string> danhSachMaCauHoi = null)
        {
            InitializeComponent();
            this._tenDeThi = tenDeThi;
            this._maChuong = maChuong;
            this._maMucDo = maMucDo;
            this._danhSachMaCauHoi = danhSachMaCauHoi;
        }

        private void frmXemTruocDeThi_Load(object sender, EventArgs e)
        {
            
            tbTenDeThi.Text = _tenDeThi;
            dataGridViewDanhSachCauHoi.DataSource = null;
            dataGridViewDanhSachCauHoi.Columns.Clear();

            var ado = ADO.Instance;
            string queryChuong = "SELECT [TenChuong] FROM [QTV3].[dbo].[Chuong] WHERE [MaChuong] = @MaChuong";
            var maChuong_param = ado.CreateParameter("@MaChuong", _maChuong);
            DataTable chuongResult = ado.ExecuteQuery(queryChuong, maChuong_param);
            string tenChuong = chuongResult.Rows[0]["TenChuong"].ToString();
            tbChuong.Text = tenChuong;

            string queryMucDo = "SELECT [TenMucDo] FROM [QTV3].[dbo].[MucDo] WHERE [MaMucDo] = @MaMucDo";
            var maMucDo_param = ado.CreateParameter("@MaMucDo", _maMucDo);
            DataTable mucDoResult = ado.ExecuteQuery(queryMucDo, maMucDo_param);
            string tenMucDo = mucDoResult.Rows[0]["TenMucDo"].ToString();
            tbMucDo.Text = tenMucDo;

            LoadCauHoi();
        }

        private void LoadCauHoi()
        {
            var ado = ADO.Instance;

            // Tạo chuỗi điều kiện cho SQL (IN) từ danh sách mã câu hỏi
            string maCauHoiList = string.Join(",", _danhSachMaCauHoi.Select(maCauHoi => $"'{maCauHoi}'"));

            // Truy vấn câu hỏi theo mã câu hỏi
            string queryCauHoi = $"SELECT [MaCauHoi], [NoiDung], [MaMon], [Chuong], [MucDo], [MaNHCauHoi] FROM [QTV3].[dbo].[CauHoi] WHERE [MaCauHoi] IN ({maCauHoiList})";

            // Lấy kết quả từ cơ sở dữ liệu
            DataTable cauHoiResult = ado.ExecuteQuery(queryCauHoi);

            // Kiểm tra nếu có kết quả và gán vào DataGridView
            if (cauHoiResult.Rows.Count > 0)
            {
                // Gán dữ liệu vào DataGridView
                dataGridViewDanhSachCauHoi.DataSource = cauHoiResult;
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
    }
}
