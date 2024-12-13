using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using QTV.DataAccess;

namespace QTV.Controllers;

public class QuizController
{
    // CRUD for BaiThi
    //public DataTable LoadQuiz(string maMon = "")
    //{
    //    try
    //    {
    //        var ado = ADO.Instance;
    //        string MaGV = UserSession.Instance.UserId;
    //        string query = "SELECT * FROM BaiThi WHERE MaGV = @MaGV";
    //        var MaGV_param = ado.CreateParameter("@MaGV", MaGV);

    //        if (maMon != "")
    //        {
    //            var query_add = " AND MaMon = @MaMon";
    //            query += query_add;
    //            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
    //            return ado.ExecuteQuery(query, MaGV_param, MaMon_param);
    //        }
    //        else // If maMon is empty
    //        {
    //            return ado.ExecuteQuery(query, MaGV_param);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        // Ghi l?i l?i vào log
    //        Console.WriteLine($"Error in LoadQuiz: {ex.Message}");
    //        return null;
    //    }
    //}

    //public DataTable LoadQuiz(string maLopHP = "")
    //{
    //    try
    //    {
    //        var ado = ADO.Instance;
    //        string MaGV = UserSession.Instance.UserId;
    //        string query = "SELECT * FROM BaiThi WHERE GV = @MaGV";
    //        var MaGV_param = ado.CreateParameter("@MaGV", MaGV);

    //        if (maLopHP != "")
    //        {
    //            var query_add = " AND LopHP = @LopHP";
    //            query += query_add;
    //            var LopHP_param = ado.CreateParameter("@LopHP", maLopHP);
    //            return ado.ExecuteQuery(query, MaGV_param, LopHP_param);
    //        }
    //        else
    //        {
    //            return ado.ExecuteQuery(query, MaGV_param);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error in LoadQuiz: {ex.Message}");
    //        return null;
    //    }
    //}

    public DataTable LoadQuiz(string maLopHP = "")
    {
        try
        {
            var ado = ADO.Instance;
            string MaGV = UserSession.Instance.UserId;

            // Khởi tạo câu truy vấn cơ bản để lấy bài thi theo mã giáo viên
            string query = "SELECT * FROM BaiThi WHERE GV = @MaGV";
            var MaGV_param = ado.CreateParameter("@MaGV", MaGV);

            // Kiểm tra nếu có tham số lớp học phần (maLopHP)
            if (!string.IsNullOrEmpty(maLopHP))
            {
                // Nếu có lớp học phần, thêm điều kiện lọc theo lớp học phần vào câu truy vấn
                query += " AND LopHP = @LopHP";
                var LopHP_param = ado.CreateParameter("@LopHP", maLopHP);

                // Thực hiện truy vấn và trả về kết quả
                return ado.ExecuteQuery(query, MaGV_param, LopHP_param);
            }
            else
            {
                // Nếu không có lớp học phần, chỉ lọc theo mã giáo viên
                return ado.ExecuteQuery(query, MaGV_param);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in LoadQuiz: {ex.Message}");
            return null;
        }
    }

    public DataTable GetQuizByMaBaiThi(string maBaiThi)
    {
        try
        {
            var ado = ADO.Instance;

            // Truy vấn SQL để lấy thông tin bài thi theo mã bài thi
            string query = "SELECT [MaBaiThi], [TenBaiThi], [MoTa], [MaDeThi], [TGBatDau], [TGKetThuc], " +
                           "[ThoiLuong], [HienThiDiem], [XemBaiLam], [TronCauHoi], [GV], [LopHP] " +
                           "FROM [QTV3].[dbo].[BaiThi] WHERE [MaBaiThi] = @MaBaiThi";

            // Tạo tham số để tránh SQL Injection
            var MaBaiThi_param = ado.CreateParameter("@MaBaiThi", maBaiThi);

            // Thực thi truy vấn và trả về kết quả
            DataTable result = ado.ExecuteQuery(query, MaBaiThi_param);

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetQuizByMaBaiThi: {ex.Message}");
            return null;
        }
    }

    public DataTable LoadExamBySubject(string maMon)
    {
        try
        {
            var ado = ADO.Instance;

            // Câu lệnh SQL để lấy danh sách đề thi theo mã môn
            string query = "SELECT [MaDeThi], [TenDeThi], [MaGV], [MaMon], [MaChuong], [MaMucDo] " +
                           "FROM [QTV3].[dbo].[DeThi] WHERE MaMon = @MaMon";

            // Tạo tham số cho MaMon
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);

            // Thực thi câu lệnh SQL và trả về kết quả dưới dạng DataTable
            return ado.ExecuteQuery(query, MaMon_param);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in LoadExamBySubject: {ex.Message}");
            return null;
        }
    }

    //public bool AddQuiz(string maBaiThi,
    //                    string tenBaiThi,
    //                    string moTa,
    //                    string maDeThi,
    //                    string tgBatDau, // should be d-m-Y H:i:s
    //                    string tgKetThuc, // should be d-m-Y H:i:s
    //                    int hienThiDiem,
    //                    int xemBaiLam,
    //                    int tronCauHoi,
    //                    string lopHP)
    //{
    //    try
    //    {
    //        var ado = ADO.Instance;
    //        var MaGV = UserSession.Instance.UserId;
    //        string query = "INSERT INTO BaiThi (MaBaiThi, TenBaiThi, MoTa, MaDeThi, TGBatDau, TGKetThuc, ThoiLuong, HienThiDiem, XemBaiLam, TronCauHoi, GV, LopHP) VALUES (@MaBaiThi, @TenBaiThi, @MoTa, @MaDeThi, @TGBatDau, @TGKetThuc, @ThoiLuong, @HienThiDiem, @XemBaiLam, @TronCauHoi, @GV, @LopHP)";
    //        var MaBaiThi_param = ado.CreateParameter("@MaBaiThi", maBaiThi);
    //        var TenBaiThi_param = ado.CreateParameter("@TenBaiThi", tenBaiThi);
    //        var MoTa_param = ado.CreateParameter("@MoTa", moTa);
    //        var MaDeThi_param = ado.CreateParameter("@MaDeThi", maDeThi);
    //        var TGBatDau_param = ado.CreateParameter("@TGBatDau", tgBatDau);
    //        var TGKetThuc_param = ado.CreateParameter("@TGKetThuc", tgKetThuc);
    //        // diff between tgBatDau and tgKetThuc
    //        var ThoiLuong_param = ado.CreateParameter("@ThoiLuong", (DateTime.Parse(tgKetThuc) - DateTime.Parse(tgBatDau)).TotalMinutes);
    //        var HienThiDiem_param = ado.CreateParameter("@HienThiDiem", hienThiDiem);
    //        var XemBaiLam_param = ado.CreateParameter("@XemBaiLam", xemBaiLam);
    //        var TronCauHoi_param = ado.CreateParameter("@TronCauHoi", tronCauHoi);
    //        var GV_param = ado.CreateParameter("@GV", MaGV);
    //        var LopHP_param = ado.CreateParameter("@LopHP", lopHP);


    //        var result = ado.ExecuteNonQuery(query, MaBaiThi_param, TenBaiThi_param, MoTa_param, MaDeThi_param, TGBatDau_param, TGKetThuc_param, ThoiLuong_param, HienThiDiem_param, XemBaiLam_param, TronCauHoi_param, GV_param, LopHP_param);
    //        return result > 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        return false;
    //    }
    //}

    private string GenerateMaBaiThi()
    {
        try
        {
            // Định nghĩa prefix (phần cố định của mã)
            string prefix = "CNTT";
            string datePart = DateTime.Now.ToString("ddMM"); // Lấy ngày tháng hiện tại (ddMM)
            string basePrefix = $"{prefix}{datePart}_BT"; // Ví dụ: CNTT1811_BT

            // Truy vấn mã bài thi lớn nhất
            var ado = ADO.Instance;
            string query = "SELECT TOP 1 MaBaiThi FROM BaiThi WHERE MaBaiThi LIKE @BasePrefix ORDER BY MaBaiThi DESC";
            var BasePrefix_param = ado.CreateParameter("@BasePrefix", basePrefix + "%");
            var result = ado.ExecuteScalar(query, BasePrefix_param);

            int newSequence = 1; // Giá trị mặc định nếu chưa có bài thi nào

            if (result != null)
            {
                // Tách phần số thứ tự từ mã bài thi
                string latestMaBaiThi = result.ToString();
                string sequencePart = latestMaBaiThi.Replace(basePrefix, ""); // Loại bỏ prefix
                if (int.TryParse(sequencePart, out int currentSequence))
                {
                    newSequence = currentSequence + 1; // Tăng số thứ tự
                }
            }

            // Sinh mã bài thi mới
            return $"{basePrefix}{newSequence:D3}"; // Format thành CNTT1811_BT001
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GenerateMaBaiThi: {ex.Message}");
            return null; // Trả về null nếu có lỗi
        }
    }

    public bool AddQuiz(string tenBaiThi,
                        string moTa,
                        string maDeThi,
                        DateTime tgBatDau,
                        DateTime tgKetThuc,
                        int thoiLuong,
                        int hienThiDiem,
                        int xemBaiLam,
                        int tronCauHoi,
                        string lopHP)
    {
        try
        {
            var ado = ADO.Instance;
            var MaGV = UserSession.Instance.UserId;

            // Gọi hàm GenerateMaBaiThi để lấy mã bài thi
            string maBaiThi = GenerateMaBaiThi();
            if (string.IsNullOrEmpty(maBaiThi))
            {
                throw new Exception("Không thể tạo mã bài thi.");
            }

            // Truy vấn chèn dữ liệu
            string query = "INSERT INTO BaiThi (MaBaiThi, TenBaiThi, MoTa, MaDeThi, TGBatDau, TGKetThuc, ThoiLuong, HienThiDiem, XemBaiLam, TronCauHoi, GV, LopHP) " +
                           "VALUES (@MaBaiThi, @TenBaiThi, @MoTa, @MaDeThi, @TGBatDau, @TGKetThuc, @ThoiLuong, @HienThiDiem, @XemBaiLam, @TronCauHoi, @GV, @LopHP)";

            // Tạo các tham số SQL
            var parameters = new List<SqlParameter>
        {
            ado.CreateParameter("@MaBaiThi", maBaiThi),
            ado.CreateParameter("@TenBaiThi", tenBaiThi),
            ado.CreateParameter("@MoTa", moTa),
            ado.CreateParameter("@MaDeThi", maDeThi),
            ado.CreateParameter("@TGBatDau", tgBatDau.ToString("yyyy-MM-dd HH:mm:ss")), // Định dạng chuẩn SQL Server
            ado.CreateParameter("@TGKetThuc", tgKetThuc.ToString("yyyy-MM-dd HH:mm:ss")), // Định dạng chuẩn SQL Server
            ado.CreateParameter("@ThoiLuong", thoiLuong),
            ado.CreateParameter("@HienThiDiem", hienThiDiem),
            ado.CreateParameter("@XemBaiLam", xemBaiLam),
            ado.CreateParameter("@TronCauHoi", tronCauHoi),
            ado.CreateParameter("@GV", MaGV),
            ado.CreateParameter("@LopHP", lopHP)
        };

            // Thực thi câu lệnh SQL
            var result = ado.ExecuteNonQuery(query, parameters.ToArray());
            return result > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in AddQuiz: {ex.Message}");
            return false;
        }
    }


    public string GetExamCodeByQuizId(string maBaiThi)
    {
        try
        {
            // Khởi tạo ADO instance
            var ado = ADO.Instance;

            // Câu truy vấn SQL để lấy MaDeThi
            string query = "SELECT [MaDeThi] FROM [BaiThi] WHERE [MaBaiThi] = @MaBaiThi";

            // Tạo tham số cho câu truy vấn
            var param = ado.CreateParameter("@MaBaiThi", maBaiThi);

            // Thực thi câu truy vấn và lấy kết quả
            object result = ado.ExecuteScalar(query, param);

            // Nếu kết quả không null, trả về mã đề thi
            return result != null ? result.ToString() : null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetExamCodeByQuizId: {ex.Message}");
            return null;
        }
    }

    //public bool UpdateQuiz(string maBaiThi,
    //    string tenBaiThi,
    //    string moTa,
    //    string maDeThi,
    //    string tgBatDau, // should be d-m-Y H:i:s
    //    string tgKetThuc, // should be d-m-Y H:i:s
    //    int hienThiDiem,
    //    int xemBaiLam,
    //    int tronCauHoi,
    //    string lopHP)
    //{
    //    try
    //    {
    //        var ado = ADO.Instance;
    //        var MaGV = UserSession.Instance.UserId;
    //        string query =
    //            "UPDATE BaiThi SET TenBaiThi = @TenBaiThi, MoTa = @MoTa, MaDeThi = @MaDeThi, TGBatDau = @TGBatDau, TGKetThuc = @TGKetThuc, ThoiLuong = @ThoiLuong, HienThiDiem = @HienThiDiem, XemBaiLam = @XemBaiLam, TronCauHoi = @TronCauHoi, GV = @GV, LopHP = @LopHP WHERE MaBaiThi = @MaBaiThi";
    //        var MaBaiThi_param = ado.CreateParameter("@MaBaiThi", maBaiThi);
    //        var TenBaiThi_param = ado.CreateParameter("@TenBaiThi", tenBaiThi);
    //        var MoTa_param = ado.CreateParameter("@MoTa", moTa);
    //        var MaDeThi_param = ado.CreateParameter("@MaDeThi", maDeThi);
    //        var TGBatDau_param = ado.CreateParameter("@TGBatDau", tgBatDau);
    //        var TGKetThuc_param = ado.CreateParameter("@TGKetThuc", tgKetThuc);
    //        // diff between tgBatDau and tgKetThuc
    //        var ThoiLuong_param = ado.CreateParameter("@ThoiLuong",
    //            (DateTime.Parse(tgKetThuc) - DateTime.Parse(tgBatDau)).TotalMinutes);
    //        var HienThiDiem_param = ado.CreateParameter("@HienThiDiem", hienThiDiem);
    //        var XemBaiLam_param = ado.CreateParameter("@XemBaiLam", xemBaiLam);
    //        var TronCauHoi_param = ado.CreateParameter("@TronCauHoi", tronCauHoi);
    //        var GV_param = ado.CreateParameter("@GV", MaGV);
    //        var LopHP_param = ado.CreateParameter("@LopHP", lopHP);

    //        var result = ado.ExecuteNonQuery(query, TenBaiThi_param, MoTa_param, MaDeThi_param, TGBatDau_param,
    //            TGKetThuc_param, ThoiLuong_param, HienThiDiem_param, XemBaiLam_param, TronCauHoi_param, GV_param,
    //            LopHP_param, MaBaiThi_param);
    //        return result > 0;
    //    } 
    //    catch (Exception ex)
    //    {
    //        return false;
    //    }

    //}

    public bool UpdateQuiz(string maBaiThi,
    string tenBaiThi,
    string moTa,
    string maDeThi,
    DateTime tgBatDau, // Định dạng d-m-Y H:i:s
    DateTime tgKetThuc, // Định dạng d-m-Y H:i:s
    int thoiLuong,
    int hienThiDiem,
    int xemBaiLam,
    int tronCauHoi,
    string lopHP)
    {
        try
        {
            var ado = ADO.Instance;
            var MaGV = UserSession.Instance.UserId;

            string query = "UPDATE BaiThi SET TenBaiThi = @TenBaiThi, MoTa = @MoTa, MaDeThi = @MaDeThi, " +
                "TGBatDau = @TGBatDau, TGKetThuc = @TGKetThuc, ThoiLuong = @ThoiLuong, HienThiDiem = @HienThiDiem, " +
                "XemBaiLam = @XemBaiLam, TronCauHoi = @TronCauHoi, GV = @GV, LopHP = @LopHP WHERE MaBaiThi = @MaBaiThi";

            var MaBaiThi_param = ado.CreateParameter("@MaBaiThi", maBaiThi);
            var TenBaiThi_param = ado.CreateParameter("@TenBaiThi", tenBaiThi);
            var MoTa_param = ado.CreateParameter("@MoTa", moTa);
            var MaDeThi_param = ado.CreateParameter("@MaDeThi", maDeThi);
            var TGBatDau_param = ado.CreateParameter("@TGBatDau", tgBatDau.ToString("yyyy-MM-dd HH:mm:ss"));
            var TGKetThuc_param = ado.CreateParameter("@TGKetThuc", tgKetThuc.ToString("yyyy-MM-dd HH:mm:ss"));
            var ThoiLuong_param = ado.CreateParameter("@ThoiLuong", thoiLuong);
            var HienThiDiem_param = ado.CreateParameter("@HienThiDiem", hienThiDiem);
            var XemBaiLam_param = ado.CreateParameter("@XemBaiLam", xemBaiLam);
            var TronCauHoi_param = ado.CreateParameter("@TronCauHoi", tronCauHoi);
            var GV_param = ado.CreateParameter("@GV", MaGV);
            var LopHP_param = ado.CreateParameter("@LopHP", lopHP);

            var result = ado.ExecuteNonQuery(query, TenBaiThi_param, MoTa_param, MaDeThi_param, TGBatDau_param,
                TGKetThuc_param, ThoiLuong_param, HienThiDiem_param, XemBaiLam_param, TronCauHoi_param, GV_param,
                LopHP_param, MaBaiThi_param);

            return result > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool DeleteQuiz(string maBaiThi)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "DELETE FROM BaiThi WHERE MaBaiThi = @MaBaiThi";
            var MaBaiThi_param = ado.CreateParameter("@MaBaiThi", maBaiThi);
            var result = ado.ExecuteNonQuery(query, MaBaiThi_param);
            return result > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    
    // CRUD for DeThi
    public DataTable LoadExam(string maMon = "")
    {
        try
        {
            var ado = ADO.Instance;
            var MaGV = UserSession.Instance.UserId;
            string query = "SELECT * FROM DeThi WHERE MaGV = @MaGV";
            if (maMon != "")
            {
                query += " AND MaMon = @MaMon";
                var MaMon_param = ado.CreateParameter("@MaMon", maMon);
                return ado.ExecuteQuery(query, MaMon_param);
            }
            else
            {
                return ado.ExecuteQuery(query);
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    
    public bool AddExam(string maDeThi, string tenDeThi, string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            var MaGV = UserSession.Instance.UserId;
            string query = "INSERT INTO DeThi (MaDeThi, TenDeThi, MaGV, MaMon) VALUES (@MaDeThi, @TenDeThi, @MaMon, @GV)";
            var MaDeThi_param = ado.CreateParameter("@MaDeThi", maDeThi);
            var TenDeThi_param = ado.CreateParameter("@TenDeThi", tenDeThi);
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var GV_param = ado.CreateParameter("@GV", MaGV);
            var result = ado.ExecuteNonQuery(query, MaDeThi_param, TenDeThi_param, MaMon_param, GV_param);
            return result > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    //public DataTable GetQuestionsByExamId(string maDeThi)
    //{
    //    try
    //    {
    //        var ado = ADO.Instance;
    //        string query = "SELECT MaCauHoi FROM ChiTietDeThi WHERE MaDeThi = @MaDeThi";
    //        var MaDeThi_param = ado.CreateParameter("@MaDeThi", maDeThi);
    //        return ado.ExecuteQuery(query, MaDeThi_param);
    //    }
    //    catch (Exception ex)
    //    {
    //        return null; // Trả về null nếu có lỗi
    //    }
    //}

    public List<string> GetQuestionsByExamId(string maDeThi)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "SELECT [MaCauHoi] " +
                           "FROM [QTV3].[dbo].[ChiTietDeThi] " +
                           "WHERE [MaDeThi] = @MaDeThi"; // Sử dụng tham số để tránh SQL Injection

            // Tạo tham số cho câu truy vấn
            var parameters = new SqlParameter[]
            {
            ado.CreateParameter("@MaDeThi", maDeThi)
            };

            // Thực thi truy vấn và lấy kết quả
            DataTable result = ado.ExecuteQuery(query, parameters);

            // Chuyển đổi DataTable thành List<string>
            List<string> maCauHoiList = new List<string>();

            foreach (DataRow row in result.Rows)
            {
                maCauHoiList.Add(row["MaCauHoi"].ToString());
            }

            return maCauHoiList;
        }
        catch (Exception ex)
        {
            // Xử lý lỗi, có thể log hoặc thông báo lỗi
            MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    public bool UpdateExam(string maDeThi, string tenDeThi, string maMon)
    {
        try
        {
            var ado = ADO.Instance;
            string query = "UPDATE DeThi SET TenDeThi = @TenDeThi, MaMon = @MaMon WHERE MaDeThi = @MaDeThi";
            var MaDeThi_param = ado.CreateParameter("@MaDeThi", maDeThi);
            var TenDeThi_param = ado.CreateParameter("@TenDeThi", tenDeThi);
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var result = ado.ExecuteNonQuery(query, TenDeThi_param, MaMon_param, MaDeThi_param);
            return result > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool DeleteExam(string maDeThi)
    {
        try
        {
            var ado = ADO.Instance;

            string queryDeleteQuestions = "DELETE FROM ChiTietDeThi WHERE MaDeThi = @MaDeThi";
            var MaDeThi_param = ado.CreateParameter("@MaDeThi", maDeThi);
            ado.ExecuteNonQuery(queryDeleteQuestions, MaDeThi_param);

            string queryDeleteExam = "DELETE FROM DeThi WHERE MaDeThi = @MaDeThi";
            var MaDeThi_param1 = ado.CreateParameter("@MaDeThi", maDeThi);
            var result = ado.ExecuteNonQuery(queryDeleteExam, MaDeThi_param1);

            return result > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }

    // Assign Questions to Exam
    public bool AddQuestionToExam(string maDeThi, List<String> MaCauHoi)
    {
        try
        {
            var ado = ADO.Instance;
            foreach (var maCauHoi in MaCauHoi)
            {
                try
                {
                    string query = "INSERT INTO ChiTietDeThi (MaDeThi, MaCauHoi) VALUES (@MaDeThi, @MaCauHoi)";
                    var MaDeThi_param = ado.CreateParameter("@MaDeThi", maDeThi);
                    var MaCauHoi_param = ado.CreateParameter("@MaCauHoi", maCauHoi);
                    ado.ExecuteNonQuery(query, MaDeThi_param, MaCauHoi_param);
                } catch (Exception ex)
                {
                    continue;
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }







    private string GenerateMaDeThi()
    {
        // Truy vấn để lấy mã đề thi lớn nhất hiện có
        var ado = ADO.Instance;
        string query = "SELECT TOP 1 MaDeThi FROM DeThi ORDER BY MaDeThi DESC";
        var result = ado.ExecuteScalar(query)?.ToString();

        // Nếu không có mã nào trong cơ sở dữ liệu, bắt đầu từ DT0001
        if (string.IsNullOrEmpty(result))
        {
            return "DT0001";
        }

        // Tách tiền tố và số thứ tự từ mã đề thi cuối cùng
        string prefix = "DT";
        int number = int.Parse(result.Substring(prefix.Length)); // Lấy phần số và chuyển thành số nguyên

        // Tăng số thứ tự và định dạng lại
        return $"{prefix}{(number + 1):D4}";
    }

    public bool AddExamWithQuestions(string tenDeThi, string maMon, string maChuong, string maMucDo, List<string> danhSachMaCauHoi)
    {
        var ado = ADO.Instance;
        try
        {
            ado.BeginTransaction(); // Bắt đầu transaction

            // Gọi phương thức để sinh mã đề thi tự động
            string maDeThi = GenerateMaDeThi();

            // Thêm đề thi vào bảng DeThi
            string queryExam = "INSERT INTO DeThi (MaDeThi, TenDeThi, MaGV, MaMon, MaChuong, MaMucDo) VALUES (@MaDeThi, @TenDeThi, @GV, @MaMon, @MaChuong, @MaMucDo)";
            var MaDeThi_param = ado.CreateParameter("@MaDeThi", maDeThi);
            var TenDeThi_param = ado.CreateParameter("@TenDeThi", tenDeThi);
            var MaMon_param = ado.CreateParameter("@MaMon", maMon);
            var MaChuong_param = ado.CreateParameter("@MaChuong", maChuong);
            var MaMucDo_param = ado.CreateParameter("@MaMucDo", maMucDo);
            var MaGV_param = ado.CreateParameter("@GV", UserSession.Instance.UserId);

            ado.ExecuteNonQuery(queryExam, MaDeThi_param, TenDeThi_param, MaMon_param, MaChuong_param, MaMucDo_param, MaGV_param);

            // Thêm câu hỏi vào bảng ChiTietDeThi
            foreach (var maCauHoi in danhSachMaCauHoi)
            {
                string queryQuestion = "INSERT INTO ChiTietDeThi (MaDeThi, MaCauHoi) VALUES (@MaDeThi, @MaCauHoi)";

                // Tạo mới tham số với tên biến khác
                var maDeThiParam = ado.CreateParameter("@MaDeThi", maDeThi); // Sử dụng tên biến khác
                var maCauHoiParam = ado.CreateParameter("@MaCauHoi", maCauHoi);

                ado.ExecuteNonQuery(queryQuestion, maDeThiParam, maCauHoiParam);
            }

            ado.CommitTransaction(); // Commit transaction nếu thành công
            return true;
        }
        catch (Exception ex)
        {
            ado.RollbackTransaction(); // Rollback nếu có lỗi
            Debug.WriteLine($"Error: {ex.Message}");
            return false;
        }
        finally
        {
            ado.CloseConnection(); // Đảm bảo đóng kết nối
        }
    }

    public string GetMaChuongByMaDeThi(string maDeThi)
    {
        var ado = ADO.Instance; // Sử dụng lớp ADO của bạn
        try
        {
            string query = "SELECT MaChuong FROM DeThi WHERE MaDeThi = @MaDeThi";
            var maDeThiParam = ado.CreateParameter("@MaDeThi", maDeThi);

            var result = ado.ExecuteScalar(query, maDeThiParam);
            return result?.ToString(); // Trả về giá trị nếu tồn tại, null nếu không có
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in GetMaChuongByMaDeThi: {ex.Message}");
            return null;
        }
    }

    public string GetMaMucDoByMaDeThi(string maDeThi)
    {
        var ado = ADO.Instance; // Sử dụng lớp ADO của bạn
        try
        {
            string query = "SELECT MaMucDo FROM DeThi WHERE MaDeThi = @MaDeThi";
            var maDeThiParam = ado.CreateParameter("@MaDeThi", maDeThi);

            var result = ado.ExecuteScalar(query, maDeThiParam);
            return result?.ToString(); // Trả về giá trị nếu tồn tại, null nếu không có
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetMaMucDoByMaDeThi: {ex.Message}");
            return null;
        }
    }

    public bool EditExamWithQuestions(string maDeThi, string tenDeThi, string maMon, string maChuong, string maMucDo, List<string> danhSachMaCauHoi)
    {
        var ado = ADO.Instance;
        try
        {
            ado.BeginTransaction(); // Bắt đầu transaction

            // Cập nhật thông tin đề thi trong bảng DeThi
            string queryUpdateExam = "UPDATE DeThi SET TenDeThi = @TenDeThi, MaMon = @MaMon, MaChuong = @MaChuong, MaMucDo = @MaMucDo WHERE MaDeThi = @MaDeThi";

            // Tạo tham số cho câu lệnh UPDATE
            var parametersUpdateExam = new SqlParameter[]
            {
            ado.CreateParameter("@MaDeThi", maDeThi),
            ado.CreateParameter("@TenDeThi", tenDeThi),
            ado.CreateParameter("@MaMon", maMon),
            ado.CreateParameter("@MaChuong", maChuong),
            ado.CreateParameter("@MaMucDo", maMucDo)
            };

            ado.ExecuteNonQuery(queryUpdateExam, parametersUpdateExam); // Thực thi câu lệnh cập nhật

            // Xóa các câu hỏi cũ trong bảng ChiTietDeThi
            string queryDeleteQuestions = "DELETE FROM ChiTietDeThi WHERE MaDeThi = @MaDeThi";
            var parametersDeleteQuestions = new SqlParameter[]
            {
            ado.CreateParameter("@MaDeThi", maDeThi)
            };

            ado.ExecuteNonQuery(queryDeleteQuestions, parametersDeleteQuestions); // Thực thi câu lệnh xóa

            // Thêm danh sách câu hỏi mới vào bảng ChiTietDeThi
            foreach (var maCauHoi in danhSachMaCauHoi)
            {
                string queryInsertQuestion = "INSERT INTO ChiTietDeThi (MaDeThi, MaCauHoi) VALUES (@MaDeThi, @MaCauHoi)";
                var parametersInsertQuestion = new SqlParameter[]
                {
                ado.CreateParameter("@MaDeThi", maDeThi),
                ado.CreateParameter("@MaCauHoi", maCauHoi)
                };

                ado.ExecuteNonQuery(queryInsertQuestion, parametersInsertQuestion); // Thực thi câu lệnh chèn
            }

            ado.CommitTransaction(); // Commit transaction nếu thành công
            return true;
        }
        catch (Exception ex)
        {
            ado.RollbackTransaction(); // Rollback nếu có lỗi
            Console.WriteLine($"Error: {ex.Message}"); // Ghi lại thông tin lỗi
            return false;
        }
        finally
        {
            ado.CloseConnection(); // Đảm bảo đóng kết nối
        }
    }


}
