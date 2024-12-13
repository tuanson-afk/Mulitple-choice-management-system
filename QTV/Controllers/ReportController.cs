using System.Data;
using OfficeOpenXml;
using QTV.DataAccess;
using QTV.Models;

namespace QTV.Controllers;

public class ReportController
{
    public DataTable LoadMonHoc(string searchString = "")
    {
        ADO ado = ADO.Instance;
        string query = "SELECT * FROM MonHoc";
        if (!string.IsNullOrEmpty(searchString))
        {
            query += $" WHERE TenMon LIKE '%{searchString}%'";
        }
        return ado.ExecuteQuery(query);
    }
    
    public List<MonHoc> TransformMonHoc () {
        DataTable dt = LoadMonHoc();
        List<MonHoc> monHocs = new List<MonHoc>();
        foreach (DataRow row in dt.Rows)
        {
            MonHoc monHoc = new MonHoc();
            monHoc.MaMon = row["MaMon"].ToString();
            monHoc.TenMon = row["TenMon"].ToString();
            monHocs.Add(monHoc);
        }
        return monHocs;
    }

    public DataTable LoadLHP(string MaMon)
    {
        ADO ado = ADO.Instance;
        string query = $"SELECT * FROM LopHP WHERE MaMon = '{MaMon}'";
        return ado.ExecuteQuery(query);
    }
    
    public List<LopHP> TransformLHP(string MaMon) {
        DataTable dt = LoadLHP(MaMon);
        List<LopHP> lopHocPhans = new List<LopHP>();
        foreach (DataRow row in dt.Rows)
        {
            LopHP lopHocPhan = new LopHP();
            lopHocPhan.MaLHP = row["MaLHP"].ToString();
            lopHocPhan.MaMon = row["MaMon"].ToString();
            lopHocPhan.MaGV = row["MaGV"].ToString();
            lopHocPhan.TenLHP = row["TenLHP"].ToString();
            lopHocPhans.Add(lopHocPhan);
        }
        return lopHocPhans;
    }

    public DataTable LoadBaiThi(string LopHP)
    {
        ADO ado = ADO.Instance;
        string query = $"SELECT * FROM BaiThi WHERE LopHP = '{LopHP}'";
        return ado.ExecuteQuery(query);
    }
    
    public List<BaiThi> TransformBaiThi(string LopHP) {
        DataTable dt = LoadBaiThi(LopHP);
        List<BaiThi> baiThis = new List<BaiThi>();
        foreach (DataRow row in dt.Rows)
        {
            BaiThi baiThi = new BaiThi();
            baiThi.MaBaiThi = row["MaBaiThi"].ToString();
            baiThi.TenBaiThi = row["TenBaiThi"].ToString();
            baiThi.XaoTron = row["TronCauHoi"].ToString() == "True" ? 1 : 0;
            baiThis.Add(baiThi);
        }
        return baiThis;
    }
    
    public DataTable LoadBaiLam(string MaBaiThi)
    {
        ADO ado = ADO.Instance;
        string query = $"SELECT * FROM BaiLam LEFT JOIN SinhVien on BaiLam.MaSV = SinhVien.MaSV LEFT JOIN TrangThai on BaiLam.TrangThai = TrangThai.MaTrangThai WHERE MaBaiThi = '{MaBaiThi}'";
        return ado.ExecuteQuery(query);
    }
    
    public void ExportToExcel(DataGridView dgv, string filePath)
    {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        using (ExcelPackage package = new ExcelPackage())
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("BaiLamData");

            for (int col = 0; col < dgv.Columns.Count; col++)
            {
                worksheet.Cells[1, col + 1].Value = dgv.Columns[col].HeaderText;
            }

            for (int row = 0; row < dgv.Rows.Count; row++)
            {
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    if (dgv.Rows[row].Cells[col].Value != null)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = dgv.Rows[row].Cells[col].Value.ToString();
                    }
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            FileInfo fi = new FileInfo(filePath);
            package.SaveAs(fi);
        }
    }

    
    
}