using QTV.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTV.Models;

namespace QTV.Controllers
{
    internal class ClassController
    {
        public DataTable LoadClass()
        {
            try
            {
                var ado = ADO.Instance;
                string query = "SELECT * FROM LopHP LEFT JOIN MonHoc ON LopHP.MaMon = MonHoc.MaMON LEFT JOIN GiangVien ON LopHP.MaGV = GiangVien.MaGV";
                var result = ado.ExecuteQuery(query);
                // print the result to the console
                Console.WriteLine(result);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GiangVien> LoadGiangVienList()
        {
            try
            {
                var ado = ADO.Instance;
                string query = "SELECT * FROM GiangVien";
                var result = ado.ExecuteQuery(query);
                var list = new List<GiangVien>();
                foreach (DataRow row in result.Rows)
                {
                    var giangVien = new GiangVien
                    {
                        MaGV = row["MaGV"].ToString(),
                        TenGV = row["TenGV"].ToString()
                    };
                    list.Add(giangVien);
                }
                return list;
            } catch (Exception ex)
            {
                return null;
            }
        }

        public List<MonHoc> LoadMonHocList()
        {
            try
            {
                var ado = ADO.Instance;
                string query = "SELECT * FROM MonHoc";
                var result = ado.ExecuteQuery(query);
                var list = new List<MonHoc>();
                foreach (DataRow row in result.Rows)
                {
                    var monHoc = new MonHoc
                    {
                        MaMon = row["MaMon"].ToString(),
                        TenMon = row["TenMon"].ToString()
                    };
                    list.Add(monHoc);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        
        public bool AddClass(string maLHP, string tenLHP, string maGV, string maMon)
        {
            try
            {
                Debug.WriteLine("MaLHP: " + maLHP + " TenLHP: " + tenLHP + " MaGV: " + maGV + " MaMon: " + maMon);
                var ado = ADO.Instance;
                string query = "INSERT INTO LopHP(MaLHP, TenLHP, MaGV, MaMon) VALUES(@MaLHP, @TenLHP, @MaGV, @MaMon)";
                var parameter = ado.CreateParameter("@MaLHP", maLHP);
                var parameter1 = ado.CreateParameter("@TenLHP", tenLHP);
                var parameter2 = ado.CreateParameter("@MaGV", maGV);
                var parameter3 = ado.CreateParameter("@MaMon", maMon);
                var result = ado.ExecuteNonQuery(query, parameter, parameter1, parameter2, parameter3);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public bool UpdateClass(string maLHP, string tenLHP, string maGV, string maMon)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "UPDATE LopHP SET TenLHP = @TenLHP, MaGV = @MaGV, MaMon = @MaMon WHERE MaLHP = @MaLHP";
                var parameter = ado.CreateParameter("@MaLHP", maLHP);
                var parameter1 = ado.CreateParameter("@TenLHP", tenLHP);
                var parameter2 = ado.CreateParameter("@MaGV", maGV);
                var parameter3 = ado.CreateParameter("@MaMon", maMon);
                var result = ado.ExecuteNonQuery(query, parameter, parameter1, parameter2, parameter3);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public bool DeleteClass(string maLHP)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "DELETE FROM LopHP WHERE MaLHP = @MaLHP";
                var parameter = ado.CreateParameter("@MaLHP", maLHP);
                var result = ado.ExecuteNonQuery(query, parameter);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable loadSinhVienInClass(string LopHP)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "SELECT * FROM SV_LopHP LEFT JOIN SinhVien ON SV_LopHP.MaSV = SinhVien.MaSV WHERE SV_LopHP.MaLHP = @LopHP";
                var parameter = ado.CreateParameter("@LopHP", LopHP);
                return ado.ExecuteQuery(query, parameter);
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        
        public DataTable loadSinhVienNotInClass(string LopHP)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "SELECT * FROM SinhVien WHERE MaSV NOT IN (SELECT MaSV FROM SV_LopHP WHERE SV_LopHP.MaLHP = @LopHP)";
                var parameter = ado.CreateParameter("@LopHP", LopHP);
                return ado.ExecuteQuery(query, parameter);
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        
        public bool addSinhVienToClass(string MaSV, string MaLHP)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "INSERT INTO SV_LopHP(MaSV, MaLHP) VALUES(@MaSV, @MaLHP)";
                var parameter = ado.CreateParameter("@MaSV", MaSV);
                var parameter1 = ado.CreateParameter("@MaLHP", MaLHP);
                var result = ado.ExecuteNonQuery(query, parameter, parameter1);
                return result > 0;
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
        
        public bool removeSinhVienFromClass(string MaSV, string MaLHP)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "DELETE FROM SV_LopHP WHERE MaSV = @MaSV AND MaLHP = @MaLHP";
                var parameter = ado.CreateParameter("@MaSV", MaSV);
                var parameter1 = ado.CreateParameter("@MaLHP", MaLHP);
                var result = ado.ExecuteNonQuery(query, parameter, parameter1);
                return result > 0;
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
