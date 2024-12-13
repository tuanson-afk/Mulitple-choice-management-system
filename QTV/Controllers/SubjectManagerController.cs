using System.Data;
using System.Data.SqlClient;
using QTV.DataAccess;

namespace QTV.Controllers;

public class SubjectManagerController
{
    public DataTable loadMonHocList()
    {
        ADO ado = ADO.Instance;
        string query = "SELECT * FROM MonHoc";
        return ado.ExecuteQuery(query);
    }
    
    public bool deleteMonHoc(string MaMon)
    {
        ADO ado = ADO.Instance;
        string query = $"DELETE FROM MonHoc WHERE MaMon = '{MaMon}'";
        return ado.ExecuteNonQuery(query) > 0;
    }

    public bool updateMonHoc(string MaMon, string TenMon)
    {
        ADO ado = ADO.Instance;
        string query = $"UPDATE MonHoc SET TenMon = '{TenMon}' WHERE MaMon = '{MaMon}'";
        return ado.ExecuteNonQuery(query) > 0;
    }
    
    public bool updateOrCreateMonHoc(string MaMon, string TenMon)
    {
        ADO ado = ADO.Instance;
        string query = "IF EXISTS (SELECT * FROM MonHoc WHERE MaMon = @MaMon) " +
                       "UPDATE MonHoc SET TenMon = @TenMon WHERE MaMon = @MaMon " +
                       "ELSE " +
                       "INSERT INTO MonHoc(MaMon, TenMon) VALUES(@MaMon, @TenMon)";
        var parameters = new List<SqlParameter>
        {
            ado.CreateParameter("@MaMon", MaMon),
            ado.CreateParameter("@TenMon", TenMon),
        };
        return ado.ExecuteNonQuery(query, parameters.ToArray()) > 0;
    }
}