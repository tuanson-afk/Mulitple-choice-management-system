using QTV.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Diagnostics;

namespace QTV.Controllers
{
    internal class UserManagerController
    {
        public DataTable loadStudentList()
        {
            try
            {
                var ado = ADO.Instance;
                string query = "SELECT * FROM SinhVien";
                var result = ado.ExecuteQuery(query);
                result.Columns.Remove("MkSV");
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool updateStudent(string MaSV, string TenSV, string MailSV)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "UPDATE SinhVien SET TenSV = @TenSV, MailSV = @MailSV WHERE MaSV = @MaSV";
                var MaSV_param = ado.CreateParameter("@MaSV", MaSV);
                var ten_param = ado.CreateParameter("@TenSV", TenSV);
                var mail_param = ado.CreateParameter("@MailSV", MailSV);
                var result = ado.ExecuteNonQuery(query, MaSV_param, ten_param, mail_param);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool addStudent(string MaSV, string TenSV, string MailSV)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "INSERT INTO SinhVien(MaSV, MkSV, TenSV, MailSV) VALUES(@MaSV, @MkSV, @TenSV, @MailSV)";
                var MaSV_param = ado.CreateParameter("@MaSV", MaSV);
                var ten_param = ado.CreateParameter("@TenSV", TenSV);
                var mail_param = ado.CreateParameter("@MailSV", MailSV);
                var pass_param = ado.CreateParameter("@MkSV", Helpers.HashMd5("123456"));
                var result = ado.ExecuteNonQuery(query, MaSV_param, ten_param, mail_param, pass_param);
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool deleteStudent(string MaSV)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                var MaSV_param = ado.CreateParameter("@MaSV", MaSV);
                var result = ado.ExecuteNonQuery(query, MaSV_param);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable LoadTeacherList()
        {
            try
            {
                var ado = ADO.Instance;
                string query = "SELECT * FROM GiangVien";
                var result = ado.ExecuteQuery(query);
                result.Columns.Remove("MkGV");
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool updateTeacher(string MaGV, string TenGV, string MailGV)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "UPDATE GiangVien SET TenGV = @TenGV, MailGV = @MailGV WHERE MaGV = @MaGV";
                var MaGV_param = ado.CreateParameter("@MaGV", MaGV);
                var ten_param = ado.CreateParameter("@TenGV", TenGV);
                var mail_param = ado.CreateParameter("@MailGV", MailGV);
                var result = ado.ExecuteNonQuery(query, MaGV_param, ten_param, mail_param);
                return result > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool addTeacher(string MaGV, string TenGV, string MailGV)
        {
            try
            {
                Debug.WriteLine("MaGV: " + MaGV + " TenGV: " + TenGV + " MailGV: " + MailGV);
                var ado = ADO.Instance;
                string query = "INSERT INTO GiangVien(MaGV, MkGV, TenGV, MailGV) VALUES(@MaGV, @MkGV, @TenGV, @MailGV)";
                var MaGV_param = ado.CreateParameter("@MaGV", MaGV);
                var ten_param = ado.CreateParameter("@TenGV", TenGV);
                var mail_param = ado.CreateParameter("@MailGV", MailGV);
                var pass_param = ado.CreateParameter("@MkGV", Helpers.HashMd5("123456"));
                var result = ado.ExecuteNonQuery(query, MaGV_param, ten_param, mail_param, pass_param);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool deleteTeacher(string MaGV)
        {
            try
            {
                var ado = ADO.Instance;
                string query = "DELETE FROM GiangVien WHERE MaGV = @MaGV";
                var MaGV_param = ado.CreateParameter("@MaGV", MaGV);
                var result = ado.ExecuteNonQuery(query, MaGV_param);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
