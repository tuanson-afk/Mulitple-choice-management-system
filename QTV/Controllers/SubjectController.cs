using System.Data;
using System.Diagnostics;
using QTV.DataAccess;

namespace QTV.Controllers;

public class SubjectController
{
    public DataTable LoadAllSubjects()
    {
        try
        {
            var ado = ADO.Instance;
            string query = "SELECT * FROM MonHoc";
            var result = ado.ExecuteQuery(query);

            // S? d?ng Debug.WriteLine ?? ghi d? li?u ra b?ng Output trong Debug mode
            foreach (DataRow row in result.Rows)
            {
                Debug.WriteLine($"MaMon: {row["MaMon"]}, TenMon: {row["TenMon"]}");
                // Console.WriteLine($"MaMon: {row["MaMon"]}, TenMon: {row["TenMon"]}");
            }

            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool AddSubject(string maMon, string tenMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "INSERT INTO MonHoc (MaMon, TenMon) VALUES (@MaMon, @TenMon)";
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var TenMon_param = ado.CreateParameter("@TenMon", tenMon);
            ado.ExecuteNonQuery(query, MaMon_param, TenMon_param);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UpdateSubject(string maMon, string tenMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "UPDATE MonHoc SET TenMon = @TenMon WHERE MaMon = @MaMon";
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var TenMon_param = ado.CreateParameter("@TenMon", tenMon);
            ado.ExecuteNonQuery(query, TenMon_param, MaMon_param);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public bool DeleteSubject(string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "DELETE FROM MonHoc WHERE MaMon = @MaMon";
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            ado.ExecuteNonQuery(query, MaMon_param);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    // Load LopHP from MonHoc
    public DataTable LoadLopHPFromMonHoc(string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            var MaGV = UserSession.Instance.UserId;
            string query = "SELECT * FROM LopHP WHERE MaMon = @MaMon AND MaGV = @MaGV";
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var MaGV_param = ado.CreateParameter("@MaGV", MaGV);
            var result = ado.ExecuteQuery(query, MaMon_param, MaGV_param);

            foreach (DataRow row in result.Rows)
            {
                // Debug.WriteLine($"LopHP: {row["MaLHP"]}, TenLHP: {row["TenLHP"]}");
                // Console.WriteLine($"MaMon: {row["MaMon"]}, TenMon: {row["TenMon"]}");
            }

            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    // Load DeThi from MonHoc
    public DataTable LoadDeThiFromMonHoc(string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "SELECT * FROM DeThi WHERE MaMon = @MaMon AND MaGV = @MaGV";
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var MaGV_param = ado.CreateParameter("@MaGV", UserSession.Instance.UserId);
            var result = ado.ExecuteQuery(query, MaMon_param, MaGV_param);
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    // Load BaiThi from MonHoc
    public DataTable LoadCauHoiFromMonHoc(string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "SELECT * FROM CauHoi WHERE MaMon = @MaMon";
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var MaGV_param = ado.CreateParameter("@MaGV", UserSession.Instance.UserId);
            var result = ado.ExecuteQuery(query, MaMon_param, MaGV_param);
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    // CRUD for Chuong
    public DataTable LoadChuongList(string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "SELECT * FROM Chuong WHERE MaMon = @MaMon";
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var result = ado.ExecuteQuery(query, MaMon_param);
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool AddChuong(string maMon, string tenChuong)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "INSERT INTO Chuong (MaMon, TenChuong) VALUES (@MaMon, @TenChuong)";
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var TenChuong_param = ado.CreateParameter("@TenChuong", tenChuong);
            ado.ExecuteNonQuery(query, MaMon_param, TenChuong_param);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UpdateChuong(string maChuong, string tenChuong)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "UPDATE Chuong SET TenChuong = @TenChuong WHERE MaChuong = @MaChuong";
            var MaChuong_param = ado.CreateParameter("@MaChuong", maChuong);
            var TenChuong_param = ado.CreateParameter("@TenChuong", tenChuong);
            ado.ExecuteNonQuery(query, TenChuong_param, MaChuong_param);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    
    public bool DeleteChuong(string maChuong)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "DELETE FROM Chuong WHERE MaChuong = @MaChuong";
            var MaChuong_param = ado.CreateParameter("@MaChuong", maChuong);
            ado.ExecuteNonQuery(query, MaChuong_param);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}