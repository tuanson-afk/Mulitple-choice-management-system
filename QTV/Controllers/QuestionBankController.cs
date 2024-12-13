using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using QTV.DataAccess;
using QTV.Models;

namespace QTV.Controllers;

public class QuestionBankController
{
    // CRUD for NHCauHoi
    public DataTable LoadQuestionBank(string maMon = "")
    {
        try
        {
            var ado = ADO.Instance;
            string MaGV = UserSession.Instance.UserId;
            string query = "SELECT * FROM NHCauHoi WHERE MaGV = @MaGV";
            var MaGV_param = ado.CreateParameter("@MaGV", MaGV);
        
            if (maMon != "") // If maMon has a value
            {
                var query_add = " AND MaMon = @MaMon";
                query += query_add;
                var MaMon_param = ado.CreateParameter("@MaMon", maMon);
                return ado.ExecuteQuery(query, MaGV_param, MaMon_param);
            }
            else // If maMon is empty
            {
                return ado.ExecuteQuery(query, MaGV_param);
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    
    public bool AddQuestionBank(string maNHCauHoi, string tenNHCauHoi, string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "INSERT INTO NHCauHoi (MaNHCauHoi, TenNHCauHoi, MaMon, MaGV) VALUES (@MaNHCauHoi, @TenNHCauHoi, @MaMon, @MaGV)";
            var MaNHCauHoi_param = ado.CreateParameter("@MaNHCauHoi", maNHCauHoi);
            var TenNHCauHoi_param = ado.CreateParameter("@TenNHCauHoi", tenNHCauHoi);
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var MaGV_param = ado.CreateParameter("@MaGV", UserSession.Instance.UserId);
            var result = ado.ExecuteNonQuery(query, MaNHCauHoi_param, TenNHCauHoi_param, MaMon_param, MaGV_param);
            return result > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    
    public bool UpdateQuestionBank(string maNHCauHoi, string tenNHCauHoi, string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "UPDATE NHCauHoi SET TenNHCauHoi = @TenNHCauHoi, MaMon = @MaMon WHERE MaNHCauHoi = @MaNHCauHoi";
            var MaNHCauHoi_param = ado.CreateParameter("@MaNHCauHoi", maNHCauHoi);
            var TenNHCauHoi_param = ado.CreateParameter("@TenNHCauHoi", tenNHCauHoi);
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var result = ado.ExecuteNonQuery(query, TenNHCauHoi_param, MaMon_param, MaNHCauHoi_param);
            return result > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    
    public bool DeleteQuestionBank(string maNHCauHoi)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "DELETE FROM NHCauHoi WHERE MaNHCauHoi = @MaNHCauHoi";
            var MaNHCauHoi_param = ado.CreateParameter("@MaNHCauHoi", maNHCauHoi);
            var result = ado.ExecuteNonQuery(query, MaNHCauHoi_param);
            return result > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    // CRUD for CauHoi

    //public DataTable LoadQuestionsList(string maMon, string SearchString = "")
    //{
    //    try
    //    {
    //        var ado = ADO.Instance;
    //        string MaGV = UserSession.Instance.UserId;
    //        string query = "SELECT * FROM CauHoi WHERE MaGV = @MaGV";
    //        var MaGV_param = ado.CreateParameter("@MaGV", MaGV);
    //        var MaMon_param = ado.CreateParameter("@MaMon", maMon);
    //        if (SearchString != "")
    //        {
    //            var query_add = " AND NoiDung LIKE @SearchString";
    //            query += query_add;
    //            var SearchString_param = ado.CreateParameter("@SearchString", "%" + SearchString + "%");
    //            return ado.ExecuteQuery(query, MaGV_param, SearchString_param, MaMon_param);
    //        }
    //        else
    //        {
    //            return ado.ExecuteQuery(query, MaGV_param, MaMon_param);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        return null;
    //    }
    //}

    public DataTable LoadQuestionsList(string maMon, string searchString = "")
    {
        try
        {
            var ado = ADO.Instance;
            string maGV = UserSession.Instance.UserId;

            // Xây dựng câu truy vấn
            string query = "SELECT * FROM CauHoi WHERE MaMon = @MaMon";

            // Tạo tham số cơ bản
            var parameters = new List<SqlParameter>
        {
            ado.CreateParameter("@MaGV", maGV),
            ado.CreateParameter("@MaMon", maMon)
        };

            // Nếu có SearchString, thêm điều kiện vào câu truy vấn
            if (!string.IsNullOrEmpty(searchString))
            {
                query += " AND NoiDung LIKE @SearchString";
                parameters.Add(ado.CreateParameter("@SearchString", "%" + searchString + "%"));
            }

            var result = ado.ExecuteQuery(query, parameters.ToArray());

            // Thực thi câu lệnh truy vấn
            return result;
        }
        catch (Exception ex)
        {
            // Ghi log lỗi (nếu có hệ thống log)
            Console.WriteLine($"Error: {ex.Message}");

            // Hoặc ném ngoại lệ nếu muốn
            // throw;

            // Trả về null nếu có lỗi
            return null;
        }
    }

    public DataTable LoadQuestionAnswers(string maCauHoi)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "SELECT * FROM CauTraLoi WHERE MaCauHoi = @MaCauHoi";
            var MaCauHoi_param = ado.CreateParameter("@MaCauHoi", maCauHoi);
            return ado.ExecuteQuery(query, MaCauHoi_param);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public string GetNewMaCauHoi()
    {
        var ado = ADO.Instance;
        string query = "SELECT TOP 1 MaCauHoi FROM CauHoi ORDER BY MaCauHoi DESC";
        var lastId = ado.ExecuteScalar(query)?.ToString();

        // Nếu chưa có mã, bắt đầu từ CH001
        if (string.IsNullOrEmpty(lastId))
            return "CH0001";

        // Tách tiền tố và số thứ tự từ mã đề thi cuối cùng
        string prefix = "CH";
        int number = int.Parse(lastId.Substring(prefix.Length)); // Lấy phần số và chuyển thành số nguyên

        // Tăng số thứ tự và định dạng lại
        return $"{prefix}{(number + 1):D4}";
    }

    public bool AddQuestion(string NoiDung, string MaMon, string MaChuong, string MaMucDo, string MaNHCauHoi, List<PhuongAn> phuongAns)
    {
        var ado = ADO.Instance;
        var MaGV = UserSession.Instance.UserId;

        // Tự động sinh mã
        // string maCauHoi = GetNewMaCauHoi(); // Hoặc Guid.NewGuid().ToString("N").Substring(0, 8);
        string maCauHoi = Guid.NewGuid().ToString("N").Substring(0, 8);

        string query = "INSERT INTO CauHoi (MaCauHoi, NoiDung, MaMon, Chuong, MucDo, MaNHCauHoi) VALUES (@MaCauHoi, @NoiDung, @MaMon, @Chuong, @MucDo, @MaNHCauHoi)";
        var MaCauHoi_param = ado.CreateParameter("@MaCauHoi", maCauHoi);
        var NoiDung_param = ado.CreateParameter("@NoiDung", NoiDung);
        var MaMon_param = ado.CreateParameter("@MaMon", MaMon);
        var MaChuong_param = ado.CreateParameter("@Chuong", MaChuong);
        var MaMucDo_param = ado.CreateParameter("@MucDo", MaMucDo);
        var MaNHCauHoi_param = ado.CreateParameter("@MaNHCauHoi", MaNHCauHoi);

        try
        {
            var result = ado.ExecuteNonQuery(query, MaCauHoi_param, NoiDung_param, MaMon_param, MaChuong_param, MaMucDo_param, MaNHCauHoi_param);
            if (result > 0)
            {
                ado.BeginTransaction();
                try
                {
                    foreach (var phuongAn in phuongAns)
                    {
                        string maPhuongAn = "PA" + Guid.NewGuid().ToString("N").Substring(0, 6);

                        string query1 = "INSERT INTO QTV3.dbo.PhuongAn (MaPhuongAn, NoiDung, MaCauHoi, DungSai) VALUES (@MaPhuongAn, @NoiDung, @MaCauHoi, @DungSai)";
                        var MaPhuongAn_param = ado.CreateParameter("@MaPhuongAn", maPhuongAn);
                        var NoiDung_param1 = ado.CreateParameter("@NoiDung", phuongAn.NoiDung);
                        var MaCauHoi_param1 = ado.CreateParameter("@MaCauHoi", maCauHoi);
                        var DungSai_param = ado.CreateParameter("@DungSai", phuongAn.DungSai);
                        ado.ExecuteNonQuery(query1, MaPhuongAn_param, NoiDung_param1, MaCauHoi_param1, DungSai_param);
                    }
                    ado.CommitTransaction();
                    return true;
                }
                catch (Exception ex)
                {
                    ado.RollbackTransaction();
                    MessageBox.Show($"Lỗi khi thêm phương án: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi thêm câu hỏi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    public bool UpdateQuestion(string maCauHoi, string NoiDung, string MaMon, string MaChuong, string MaMucDo, List<PhuongAn> phuongAns)
    {
        try
        {
            var ado = ADO.Instance;

            // Cập nhật thông tin câu hỏi
            string updateQuestionQuery = "UPDATE CauHoi SET NoiDung = @NoiDung, MaMon = @MaMon, Chuong = @Chuong, MucDo = @MucDo WHERE MaCauHoi = @MaCauHoi";
            var result = ado.ExecuteNonQuery(updateQuestionQuery,
                ado.CreateParameter("@MaCauHoi", maCauHoi),
                ado.CreateParameter("@NoiDung", NoiDung),
                ado.CreateParameter("@MaMon", MaMon),
                ado.CreateParameter("@Chuong", MaChuong),
                ado.CreateParameter("@MucDo", MaMucDo)
            );

            if (result > 0)
            {
                ado.BeginTransaction();
                try
                {
                    // Xóa tất cả các phương án cũ của câu hỏi
                    string deleteOptionsQuery = "DELETE FROM PhuongAn WHERE MaCauHoi = @MaCauHoi";
                    ado.ExecuteNonQuery(deleteOptionsQuery, ado.CreateParameter("@MaCauHoi", maCauHoi));

                    // Thêm các phương án mới
                    foreach (var phuongAn in phuongAns)
                    {
                        string maPhuongAn = "PA" + Guid.NewGuid().ToString("N").Substring(0, 6); // Tạo mã phương án mới
                        string insertOptionQuery = "INSERT INTO PhuongAn (MaPhuongAn, NoiDung, MaCauHoi, DungSai) VALUES (@MaPhuongAn, @NoiDung, @MaCauHoi, @DungSai)";

                        // Tạo tham số mới cho mỗi lần chèn
                        ado.ExecuteNonQuery(insertOptionQuery,
                            ado.CreateParameter("@MaPhuongAn", maPhuongAn),
                            ado.CreateParameter("@NoiDung", phuongAn.NoiDung),
                            ado.CreateParameter("@MaCauHoi", maCauHoi),
                            ado.CreateParameter("@DungSai", phuongAn.DungSai)
                        );
                    }

                    ado.CommitTransaction();
                    return true;
                }
                catch (Exception ex)
                {
                    ado.RollbackTransaction();
                    throw new Exception($"Lỗi khi cập nhật phương án: {ex.Message}");
                }
            }

            return false;
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi cập nhật câu hỏi: {ex.Message}");
        }
    }

    public bool DeleteQuestion(string maCauHoi)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "DELETE FROM CauHoi WHERE MaCauHoi = @MaCauHoi";
            var MaCauHoi_param = ado.CreateParameter("@MaCauHoi", maCauHoi);
            var result = ado.ExecuteNonQuery(query, MaCauHoi_param);
            if (result > 0)
            {
                try
                {
                    var MaCauHoi_param2 = ado.CreateParameter("@MaCauHoi", maCauHoi);
                    string query1 = "DELETE FROM PhuongAn WHERE MaCauHoi = @MaCauHoi";
                    ado.ExecuteNonQuery(query1, MaCauHoi_param2);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;

        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error when delete question: " + ex.Message);
            return false;
        }
    }

    public DataTable LoadChuongByMaMon(string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "SELECT * FROM [QTV3].[dbo].[Chuong] WHERE [MaMon] = @MaMon";
            var maMon_param = ado.CreateParameter("@MaMon", maMon);
            var result = ado.ExecuteQuery(query, maMon_param);
            return result;
        }
        catch (Exception ex)
        {
            // Xử lý lỗi
            return null;
        }
    }

    public DataTable LoadAllMucDo()
    {
        try
        {
            var ado = ADO.Instance;
            string query = "SELECT [MaMucDo], [TenMucDo] FROM [QTV3].[dbo].[MucDo]";

            return ado.ExecuteQuery(query);
        }
        catch (Exception ex)
        {
            // Xử lý lỗi, có thể log hoặc thông báo lỗi
            // MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    public List<PhuongAn> LoadPhuongAnsByMaCauHoi(string maCauHoi)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "SELECT [MaPhuongAn], [MaCauHoi], [NoiDung], [DungSai] " +
                           "FROM [QTV3].[dbo].[PhuongAn] " +
                           "WHERE [MaCauHoi] = @MaCauHoi"; // Sử dụng tham số để tránh SQL Injection

            // Tạo tham số cho câu truy vấn
            var parameters = new SqlParameter[]
            {
            ado.CreateParameter("@MaCauHoi", maCauHoi)
            };

            // Thực thi truy vấn và lấy kết quả
            DataTable result = ado.ExecuteQuery(query, parameters);

            // Chuyển đổi DataTable thành List<PhuongAn>
            List<PhuongAn> phuongAns = new List<PhuongAn>();

            foreach (DataRow row in result.Rows)
            {
                phuongAns.Add(new PhuongAn
                {
                    MaPhuongAn = row["MaPhuongAn"].ToString(),
                    MaCauHoi = row["MaCauHoi"].ToString(),
                    NoiDung = row["NoiDung"].ToString(),
                    DungSai = Convert.ToInt32(row["DungSai"])
                });
            }

            return phuongAns;
        }
        catch (Exception ex)
        {
            // Xử lý lỗi, có thể log hoặc thông báo lỗi
            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
}