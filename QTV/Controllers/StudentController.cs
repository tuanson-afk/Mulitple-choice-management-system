using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using QTV.DataAccess;
using QTV.Models;

namespace QTV.Controllers;

public class StudentController
{
    public DataTable LoadComingExam(string searchString = "")
    {
        try
        {
            // get now in D-m-Y format
            var ado = ADO.Instance;

            // 1. Query for list of MaLHP
            var list_of_lop_hoc_phan = new List<string>();
            var MaSV = UserSession.Instance.UserId;
            string lhp_query = "SELECT MaLHP FROM SV_LopHP WHERE MaSV = @MaSV";
            var MaSV_param = ado.CreateParameter("@MaSV", MaSV);
            var lhp_result = ado.ExecuteQuery(lhp_query, MaSV_param);
            foreach (DataRow row in lhp_result.Rows)
            {
                list_of_lop_hoc_phan.Add(row["MaLHP"].ToString());
            }
            
            // Get taken BaiThi
            var taken_exam = LoadTakenExam(searchString);
            var exclude_string = "";
            if (taken_exam.Rows.Count > 0)
            {
                List<string> excludeParameters = new List<string>();
                for (int i = 0; i < taken_exam.Rows.Count; i++)
                {
                    excludeParameters.Add("@ExcludeMaBaiThi" + i);
                }
                if (excludeParameters.Count > 0)
                {
                    exclude_string = "AND BaiThi.MaBaiThi NOT IN (" + string.Join(",", excludeParameters) + ")";
                }

            }
            Debug.WriteLine(exclude_string);

            // 2. Get 30 minutes before and a week later
            var now = DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd");
            var a_week_later = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");

            // 3. Query BaiThi with JOIN
            if (list_of_lop_hoc_phan.Count == 0)
            {
                return new DataTable(); // Return empty result if no classes found
            }

            // Create base query
            string query = @"SELECT BaiThi.*, GiangVien.*, LopHP.* 
                 FROM BaiThi 
                 LEFT JOIN GiangVien ON BaiThi.GV = GiangVien.MaGV 
                 LEFT JOIN LopHP ON BaiThi.LopHP = LopHP.MaLHP
                 WHERE TGBatDau BETWEEN @now AND @a_week_later 
                 AND BaiThi.TenBaiThi LIKE @searchString
                 AND BaiThi.LopHP IN (" +
                           string.Join(",", list_of_lop_hoc_phan.Select((_, i) => "@MaLHP" + i)) + ") " + exclude_string;
            
            Debug.WriteLine(query);

            // Create parameter list
            var parameters = new List<SqlParameter>
            {
                ado.CreateParameter("@now", now),
                ado.CreateParameter("@a_week_later", a_week_later),
                ado.CreateParameter("@searchString", "%" + searchString + "%")
            };
            for (int i = 0; i < taken_exam.Rows.Count; i++)
            {
                parameters.Add(ado.CreateParameter("@ExcludeMaBaiThi" + i, taken_exam.Rows[i]["MaBaiThi"]));
            }

            // Add MaLHP parameters
            for (int i = 0; i < list_of_lop_hoc_phan.Count; i++)
            {
                parameters.Add(ado.CreateParameter("@MaLHP" + i, list_of_lop_hoc_phan[i]));
            }

            // Execute query with all parameters
            var result = ado.ExecuteQuery(query, parameters.ToArray());
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Co loi: " + ex);
            return null;
        }
    }

    public List<BaiThi> transformBaiThiSapDienRa(string searchString = "")
    {
        var dt = LoadComingExam(searchString);
        if (dt == null)
        {
            return null;
        }

        var result = new List<BaiThi>();
        foreach (DataRow row in dt.Rows)
        {
            var bai_thi = new BaiThi
            {
                MaBaiThi = row["MaBaiThi"].ToString(),
                TenBaiThi = row["TenBaiThi"].ToString(),
                // parse TGBatDau to DateTime
                TGBatDau = DateTime.Parse(row["TGBatDau"].ToString()),
                TGKetThuc = DateTime.Parse(row["TGKetThuc"].ToString()),
                GiangVien = new GiangVien
                {
                    MaGV = row["MaGV"].ToString(),
                    TenGV = row["TenGV"].ToString()
                },
                LopHP = row["LopHP"].ToString(),
                MoTa = row["MoTa"].ToString(),
                ThoiLuong = int.Parse(row["ThoiLuong"].ToString()),
                SoCauHoi = countCauHoi(row["MaDeThi"].ToString()),
                MaDeThi = row["MaDeThi"].ToString(),
                XaoTron = row["TronCauHoi"].ToString() == "True" ? 1 : 0
            };
            result.Add(bai_thi);
        }
        return result;
    }

    public DataTable LoadTakenExam(string searchString = "")
    {
        try
        {
            ADO ado = ADO.Instance;
            var MaSV = UserSession.Instance.UserId;
            var query = @"SELECT BaiLam.*, BaiThi.*, GiangVien.*, LopHP.* 
                 FROM BaiLam 
                 LEFT JOIN BaiThi ON BaiLam.MaBaiThi = BaiThi.MaBaiThi
                 LEFT JOIN GiangVien ON BaiThi.GV = GiangVien.MaGV 
                 LEFT JOIN LopHP ON BaiThi.LopHP = LopHP.MaLHP
                 WHERE BaiLam.MaSV = @MaSV AND BaiThi.TenBaiThi LIKE @searchString";
            
            var parameters = new SqlParameter[]
            {
                ado.CreateParameter("@MaSV", MaSV),
                ado.CreateParameter("@searchString", "%" + searchString + "%")
            };
            var result = ado.ExecuteQuery(query, parameters);
            return result;
        } catch (Exception ex)
        {
            Debug.WriteLine("Co loi: " + ex);
            return null;
        }
    }

    public List<BaiThi> transformBaiThiDaKetThuc(string searchString = "")
    {
        var dt = LoadTakenExam(searchString);
        if (dt == null)
        {
            return null;
        }

        var result = new List<BaiThi>();
        foreach (DataRow row in dt.Rows)
        {
            var bai_thi = new BaiThi
            {
                MaBaiThi = row["MaBaiThi"].ToString(),
                TenBaiThi = row["TenBaiThi"].ToString(),
                // parse TGBatDau to DateTime
                TGBatDau = DateTime.Parse(row["TGBatDau"].ToString()),
                TGKetThuc = DateTime.Parse(row["TGKetThuc"].ToString()),
                GiangVien = new GiangVien
                {
                    MaGV = row["MaGV"].ToString(),
                    TenGV = row["TenGV"].ToString()
                },
                LopHP = row["LopHP"].ToString(),
                MoTa = row["MoTa"].ToString(),
                ThoiLuong = int.Parse(row["ThoiLuong"].ToString()),
                SoCauHoi = countCauHoi(row["MaDeThi"].ToString()),
                MaDeThi = row["MaDeThi"].ToString(),
                HienThi = (row["HienThiDiem"].ToString() == "True") ? 1 : 0,
                XemLai = (row["XemBaiLam"].ToString() == "True") ? 1 : 0,
            };
            Debug.WriteLine(row["HienThiDiem"].ToString());
            result.Add(bai_thi);
        }
        return result;
    }
    
    public string NewBaiLam(string MaBaiThi)
    {
        var ado = ADO.Instance;
        var MaSV = UserSession.Instance.UserId;
        // generate a random code for MaBaiLam
        var MaBaiLam = Guid.NewGuid().ToString();
        var batdau = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var TrangThai = "TT02";
        var query = "INSERT INTO BaiLam(MaBaiLam, MaSV, MaBaiThi, BatDau, TrangThai) VALUES(@MaBaiLam, @MaSV, @MaBaiThi, @BatDau, @TrangThai)";
        var parameters = new SqlParameter[]
        {
            ado.CreateParameter("@MaBaiLam", MaBaiLam),
            ado.CreateParameter("@MaSV", MaSV),
            ado.CreateParameter("@MaBaiThi", MaBaiThi),
            ado.CreateParameter("@BatDau", batdau),
            ado.CreateParameter("@TrangThai", TrangThai)
        };
        var exec = ado.ExecuteNonQuery(query, parameters);
        if(exec > 0)
        {
            return MaBaiLam;
        }
        return null;
    }

    public int countCauHoi(string MaDeThi)
    {
        var ado = ADO.Instance;
        var query = "SELECT COUNT(*) FROM ChiTietDeThi WHERE MaDeThi = @MaDeThi";
        var parameters = new SqlParameter[]
        {
            ado.CreateParameter("@MaDeThi", MaDeThi)
        };
        
        var cnt = ado.ExecuteQuery(query, parameters);
        if (cnt != null)
        {
            return int.Parse(cnt.Rows[0][0].ToString());
        }
        else
        {
            return 0;
        }
    }

    public List<CauHoi> loadCauHoi(string MaDeThi)
    {
        var ado = ADO.Instance;
        var query = "SELECT * FROM ChiTietDeThi WHERE MaDeThi = @MaDeThi";
        var parameters = new SqlParameter[]
        {
            ado.CreateParameter("@MaDeThi", MaDeThi)
        };
        var result = ado.ExecuteQuery(query, parameters);
        var output = new List<CauHoi>();
        // for MaCauHoi from result
        foreach (DataRow row in result.Rows)
        {
            var MaCauHoi = row["MaCauHoi"].ToString();
            var cauhoi = new CauHoi();
            var query_cauhoi = "SELECT * FROM CauHoi WHERE MaCauHoi = @MaCauHoi";
            var parameters_cauhoi = new SqlParameter[]
            {
                ado.CreateParameter("@MaCauHoi", MaCauHoi)
            };
            var result_cauhoi = ado.ExecuteQuery(query_cauhoi, parameters_cauhoi);
            if (result_cauhoi != null)
            {
                cauhoi.MaCauHoi = result_cauhoi.Rows[0]["MaCauHoi"].ToString();
                cauhoi.NoiDung = result_cauhoi.Rows[0]["NoiDung"].ToString();
                cauhoi.PhuongAns = loadDapAn(MaCauHoi);
                output.Add(cauhoi);
            }
        }
        return output;
    }

    public List<PhuongAn> loadDapAn(string MaCauHoi)
    {
        var ado = ADO.Instance;
        var query = "SELECT * FROM PhuongAn WHERE MaCauHoi = @MaCauHoi";
        var parameters_phuongan = new SqlParameter[]
        {
            ado.CreateParameter("@MaCauHoi", MaCauHoi)
        };
        var result_phuongans = ado.ExecuteQuery(query, parameters_phuongan);
        var output = new List<PhuongAn>();
        foreach (DataRow row in result_phuongans.Rows)
        {
            var ds = 0;
            if (row["DungSai"].ToString() == "True")
            {
                ds = 1;
            }
            var phuongan = new PhuongAn
            {
                MaPhuongAn = row["MaPhuongAn"].ToString(),
                NoiDung = row["NoiDung"].ToString(),
                DungSai = ds
            };
            output.Add(phuongan);
        }
        return output;

    }

    public bool createOrUpdateChiTietBaiLam(string MaBaiLam, string MaCauHoi, string MaPhuongAn)
    {
        var ado = ADO.Instance;
        // search for mabailam and MaCauHoi
        var query = "SELECT * FROM ChiTietBaiLam WHERE MaBaiLam = @MaBaiLam AND MaCauHoi = @MaCauHoi";
        var parameters = new SqlParameter[]
        {
            ado.CreateParameter("@MaBaiLam", MaBaiLam),
            ado.CreateParameter("@MaCauHoi", MaCauHoi)
        };
        var result = ado.ExecuteQuery(query, parameters);
        if (result.Rows.Count > 0)
        {
            // update
            var query_update = "UPDATE ChiTietBaiLam SET MaPhuongAn = @MaPhuongAn, ThoiGianTraLoi = @Now WHERE MaBaiLam = @MaBaiLam AND MaCauHoi = @MaCauHoi";
            var parameters_update = new SqlParameter[]
            {
                ado.CreateParameter("@MaBaiLam", MaBaiLam),
                ado.CreateParameter("@MaCauHoi", MaCauHoi),
                ado.CreateParameter("@MaPhuongAn", MaPhuongAn),
                ado.CreateParameter("@Now", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            var exec = ado.ExecuteNonQuery(query_update, parameters_update);
            if (exec > 0)
            {
                return true;
            }
        }
        else
        {
            // insert
            var query_insert =
                "INSERT INTO ChiTietBaiLam(MaBaiLam, MaCauHoi, MaPhuongAn, ThoiGianTraLoi) VALUES(@MaBaiLam, @MaCauHoi, @MaPhuongAn, @Now)";
            var parameters_insert = new SqlParameter[]
            {
                ado.CreateParameter("@MaBaiLam", MaBaiLam),
                ado.CreateParameter("@MaCauHoi", MaCauHoi),
                ado.CreateParameter("@MaPhuongAn", MaPhuongAn),
                ado.CreateParameter("@Now", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                
            };
            var exec = ado.ExecuteNonQuery(query_insert, parameters_insert);
            if (exec > 0)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool submitBaiLam(string MaBaiLam)
    {
        var ado = ADO.Instance;
        // Query BaiThi
        var query_bailam = "SELECT * FROM BaiLam WHERE MaBaiLam = @MaBaiLam";
        var parameters_bailam = new SqlParameter[]
        {
            ado.CreateParameter("@MaBaiLam", MaBaiLam)
        };
        var bailam = ado.ExecuteQuery(query_bailam, parameters_bailam);
        if (bailam.Rows.Count == 0)
        {
            return false;
        }

        var query_baithi = "SELECT * FROM BaiThi WHERE MaBaiThi = @MaBaiThi";
        var parameters_baithi = new SqlParameter[]
        {
            ado.CreateParameter("@MaBaiThi", bailam.Rows[0]["MaBaiThi"].ToString())
        };
        var baithi = ado.ExecuteQuery(query_baithi, parameters_baithi);
        if (baithi.Rows.Count == 0)
        {
            return false;
        }


        var query_soCauHoi = "SELECT COUNT(*) FROM ChiTietDeThi WHERE MaDeThi = @MaDeThi";
        var parameters_soCauHoi = new SqlParameter[]
        {
            ado.CreateParameter("@MaDeThi", baithi.Rows[0]["MaDeThi"].ToString())
        };
        var soCauHoiResult = ado.ExecuteQuery(query_soCauHoi, parameters_soCauHoi);
        if (soCauHoiResult.Rows.Count == 0)
        {
            return false;
        }
        var soCauHoi = int.Parse(soCauHoiResult.Rows[0][0].ToString());
        
        // Tinh So Cau Nop
        var query_count = "SELECT COUNT(*) FROM ChiTietBaiLam WHERE MaBaiLam = @MaBaiLam";
        var parameters_count = new SqlParameter[]
        {
            ado.CreateParameter("@MaBaiLam", MaBaiLam)
        };
        var count = ado.ExecuteQuery(query_count, parameters_count);
        var SoCauNop = int.Parse(count.Rows[0][0].ToString());
        // Tinh So Cau Dung
        var query_dung = "SELECT * FROM  ChiTietBaiLam LEFT JOIN PhuongAn ON ChiTietBaiLam.MaPhuongAn = PhuongAn.MaPhuongAn WHERE DungSai = 1 AND MaBaiLam = @MaBaiLam";
        var parameters_dung = new SqlParameter[]
        {
            ado.CreateParameter("@MaBaiLam", MaBaiLam)
        };
        var dung = ado.ExecuteQuery(query_dung, parameters_dung);
        var SoCauDung = dung.Rows.Count;
        // Tinh So Cau Sai
        var SoCauSai = soCauHoi - SoCauDung;
        // Tinh Diem
        var DiemFloat = (float)SoCauDung / soCauHoi * 10;
        var Diem = Math.Round(DiemFloat, 2);
        
        var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var query_final = "UPDATE BaiLam SET TrangThai = 'TT03', KetThuc = @Now, SoCauNop = @SoCauNop, SoCauDung = @SoCauDung, SoCauSai = @SoCauSai, Diem = @Diem WHERE MaBaiLam = @MaBaiLam";
        var parameters = new SqlParameter[]
        {
            ado.CreateParameter("@MaBaiLam", MaBaiLam),
            ado.CreateParameter("@Now", now),
            ado.CreateParameter("@SoCauNop", SoCauNop),
            ado.CreateParameter("@SoCauDung", SoCauDung),
            ado.CreateParameter("@SoCauSai", SoCauSai),
            ado.CreateParameter("@Diem", Diem)
        };
        var exec = ado.ExecuteNonQuery(query_final, parameters);
        if (exec > 0)
        {
            return true;
        }
        return false;
    }

    public BaiLam LoadBaiLam(string MaBaiThi)
    {
        ADO ado = ADO.Instance;
        var MaSV = UserSession.Instance.UserId;
        var query = "SELECT * FROM BaiLam WHERE MaSV = @MaSV AND MaBaiThi = @MaBaiThi";
        var parameters = new SqlParameter[]
        {
            ado.CreateParameter("@MaSV", MaSV),
            ado.CreateParameter("@MaBaiThi", MaBaiThi)
        };
        var result = ado.ExecuteQuery(query, parameters);
        if (result.Rows.Count == 0)
        {
            return null;
        }
        var bailam = new BaiLam
        {
            MaBaiLam = result.Rows[0]["MaBaiLam"].ToString(),
            MaSV = result.Rows[0]["MaSV"].ToString(),
            MaBaiThi = result.Rows[0]["MaBaiThi"].ToString(),
            BatDau = DateTime.Parse(result.Rows[0]["BatDau"].ToString()),
            KetThuc = DateTime.Parse(result.Rows[0]["KetThuc"].ToString()),
            MaTrangThai = result.Rows[0]["TrangThai"].ToString(),
            SoCauNop = short.Parse(result.Rows[0]["SoCauNop"].ToString()),
            SoCauDung = short.Parse(result.Rows[0]["SoCauDung"].ToString()),
            SoCauSai = short.Parse(result.Rows[0]["SoCauSai"].ToString()),
            Diem = float.Parse(result.Rows[0]["Diem"].ToString())
        };
        return bailam;
    }
}