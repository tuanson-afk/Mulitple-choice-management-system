using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace QTV.DataAccess
{
    public class ADO
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        public ADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static ADO Instance
        {
            get
            {
                string connectionString = "Server=127.0.0.1,1434; DataBase=QTV3; Integrated Security=true";
                return new ADO(connectionString);
            }
        }

        public SqlConnection GetConnection()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed.", ex);
            }
        }

        public void BeginTransaction()
        {
            try
            {
                _transaction = GetConnection().BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to begin transaction.", ex);
            }
        }

        public void CommitTransaction()
        {
            try
            {
                _transaction?.Commit();
                _transaction = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to commit transaction.", ex);
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _transaction?.Rollback();
                _transaction = null;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to rollback transaction.", ex);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (_connection != null && _connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to close connection.", ex);
            }
        }

        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(query, GetConnection()))
                {
                    if (_transaction != null)
                    {
                        command.Transaction = _transaction;
                    }

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Query execution failed.", ex);
            }
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(query, GetConnection()))
                {
                    if (_transaction != null)
                    {
                        command.Transaction = _transaction;
                    }

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    // print query
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception(ex.Message.ToString());
            }
        }

        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(query, GetConnection()))
                {
                    if (_transaction != null)
                    {
                        command.Transaction = _transaction;
                    }

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    return command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Scalar execution failed.", ex);
            }
        }

        public SqlParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        public void TestConnection()
        {
            try
            {
                GetConnection();
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed.", ex);
            }
        }
    }
}
