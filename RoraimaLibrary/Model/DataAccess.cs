using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;

namespace RoraimaLibrary
{
    public static class DataAccess
    {
        public static readonly HttpClient httpClient = new HttpClient();

        public static string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        public static SqlConnection CreateConnection()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.ConnectionString = ConnectionString;
            var connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            return connection;
        }

        public static SqlTransaction CreateTransaction(SqlConnection connection)
        {
            return connection.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public static DataSet GetDataSet(string spName, IDictionary parameters, int? timeout = null)
        {
            using (var con = CreateConnection())
                return GetDataSet(spName, parameters, con, timeout);
        }

        private static DataSet GetDataSet(string spName, IDictionary parameters, SqlConnection connection, int? timeout = null)
        {
            var res = new DataSet();
            using (var cmd = new SqlCommand(spName, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    if (timeout != null)
                        cmd.CommandTimeout = (int)timeout;
                    foreach (string key in parameters.Keys)
                        cmd.Parameters.Add(new SqlParameter(key, parameters[key]));
                }
                using (var da = new SqlDataAdapter(cmd))
                    da.Fill(res);
            }
 
            return res;
        }

        public static DataTable GetDataTable(string spName, IDictionary parameters, bool noTimeout = false)
        {
            using (var con = CreateConnection())
                return GetDataTable(spName, parameters, con, noTimeout);
        }

        public static DataTable GetDataTable(string spName, IDictionary parameters, SqlTransaction transaction) {
            DataTable res = null;
            //
            if (transaction != null)
                res = GetDataTable(spName, parameters, transaction.Connection, transaction, false);
            else
                res = GetDataTable(spName, parameters, false);
            //
            return res;
        }

        private static DataTable GetDataTable(string spName, IDictionary parameters, SqlConnection connection, bool noTimeout) => GetDataTable(spName, parameters, connection, null, noTimeout);

        private static DataTable GetDataTable(string spName, IDictionary parameters, SqlConnection connection, SqlTransaction transaction, bool noTimeout)
        {
            var res = new DataTable();
            using (var cmd = transaction == null ? new SqlCommand(spName, connection) : new SqlCommand(spName, connection, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (noTimeout)
                    cmd.CommandTimeout = 0;
                if (parameters != null)
                {
                    foreach (string key in parameters.Keys)
                        cmd.Parameters.Add(new SqlParameter(key, parameters[key] ?? DBNull.Value));
                }
                using (var da = new SqlDataAdapter(cmd))
                    da.Fill(res);
            }

            return res;
        }

        public static object GetScalar(string spName, IDictionary parameters)
        {
            using (var con = CreateConnection())
                return GetScalar(spName, parameters, con);
        }

        private static object GetScalar(string spName, IDictionary parameters, SqlConnection connection) => GetScalar(spName, parameters, connection, null);

        public static object GetScalar(string spName, IDictionary parameters, SqlTransaction trans) => GetScalar(spName, parameters, trans.Connection, trans);

        private static object GetScalar(string spName, IDictionary parameters, SqlConnection con, SqlTransaction trans)
        {
            object res;
            using (var cmd = (trans != null ? new SqlCommand(spName, con, trans) : new SqlCommand(spName, con)))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (string key in parameters.Keys)
                        cmd.Parameters.Add(new SqlParameter(key, parameters[key] ?? DBNull.Value));
                }
                if (con.State == ConnectionState.Closed)
                    con.Open();
                res = cmd.ExecuteScalar();
            }

            return res;
        }

        public static void ExecuteNonQuery(string spName, IDictionary parameters)
        {
            using (var con = CreateConnection())
                ExecuteNonQuery(spName, parameters, con);
        }

        private static void ExecuteNonQuery(string spName, IDictionary parameters, SqlConnection connection) => ExecuteNonQuery(spName, parameters, connection, null);

        public static void ExecuteNonQuery(string spName, IDictionary parameters, SqlTransaction transaction)
        {
            if (transaction != null)
                ExecuteNonQuery(spName, parameters, transaction.Connection, transaction);
            else
                ExecuteNonQuery(spName, parameters);
        }

        private static void ExecuteNonQuery(string spName, IDictionary parameters, SqlConnection connection, SqlTransaction transaction)
        {
            var startTime = DateTime.Now;
            using (var cmd = transaction != null ? new SqlCommand(spName, connection, transaction) : new SqlCommand(spName, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    foreach (string key in parameters.Keys)
                        cmd.Parameters.Add(new SqlParameter(key, parameters[key] ?? DBNull.Value));
                }
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
            }

        } 
    } 
}
