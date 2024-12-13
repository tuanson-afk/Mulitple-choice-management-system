using DocumentFormat.OpenXml.Bibliography;
using QTV.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QTV.Controllers
{
    internal class AuthController
    {
        public bool Authenticate(string username, string password, string role)
        {
            switch (role)
            {
                case "QTV":
                    return AuthenticateQTV(username, password);
                case "GiangVien":
                    return AuthenticateGV(username, password);
                case "SinhVien":
                    return AuthenticateSV(username, password);
                default:
                    return false;
            }
        }
        public bool AuthenticateQTV(string username, string password)
        {
            try
            {
                var ado = ADO.Instance;
                var hashPassword = HashMd5(password);
                string query = "SELECT * FROM QTV WHERE MaQTV = @UserId and MkQTV=@password";
                var parameter = ado.CreateParameter("@UserId", username);
                var parameter1 = ado.CreateParameter("@password", hashPassword);
                var result = ado.ExecuteQuery(query, parameter, parameter1);
                var status = result.Rows.Count > 0;
                if(status == true)
                {
                    UserSession.Instance.UserId = result.Rows[0]["MaQTV"]?.ToString();
                    UserSession.Instance.UserName = result.Rows[0]["TenQTV"]?.ToString();
                    UserSession.Instance.UserRole = "QTV";
                }
                return status;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // This method is used to authenticate the user who is a teacher
        public bool AuthenticateGV(string username, string password)
        {
            try
            {
                var ado = ADO.Instance;
                var hashPassword = HashMd5(password);
                string query = "SELECT * FROM GiangVien WHERE MaGV = @UserId and MkGV=@password";
                var parameter = ado.CreateParameter("@UserId", username);
                var parameter1 = ado.CreateParameter("@password", hashPassword);
                var result = ado.ExecuteQuery(query, parameter, parameter1);
                var status = result.Rows.Count > 0;
                if (status == true)
                {
                    UserSession.Instance.UserId = result.Rows[0]["MaGV"]?.ToString();
                    UserSession.Instance.UserName = result.Rows[0]["TenGV"]?.ToString();
                    UserSession.Instance.UserRole = "GiangVien";
                }
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to authenticate user.", ex);
            }
        }

        // This method is used to authenticate the user who is a student
        public bool AuthenticateSV(string username, string password)
        {
            try
            {
                var ado = ADO.Instance;
                var hashPassword = HashMd5(password);
                string query = "SELECT * FROM SinhVien WHERE MaSV = @UserId and MkSV=@password";
                var parameter = ado.CreateParameter("@UserId", username);
                var parameter1 = ado.CreateParameter("@password", hashPassword);
                var result = ado.ExecuteQuery(query, parameter, parameter1);
                var status = result.Rows.Count > 0;
                if (status == true)
                {
                    UserSession.Instance.UserId = result.Rows[0]["MaSV"]?.ToString();
                    UserSession.Instance.UserName = result.Rows[0]["TenSV"]?.ToString();
                    UserSession.Instance.UserRole = "SinhVien";
                }
                return status;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to authenticate user.", ex);
            }
        }

        private static string HashMd5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
}
