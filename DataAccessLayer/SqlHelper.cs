using SharedClassess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    
    public class SqlHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DbConnecion"].ConnectionString;
        public static DataTable ExecuteQuery(string cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        con.Open();
                        cmd.CommandType = cmdType;

                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
            }
            return table;
        }

        public static bool ExecuteNonQuery(string cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            var value = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        con.Open();
                        cmd.CommandType = cmdType;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        value = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.WriteLog(ex.ToString());
                return false;
            }
            if (value < 0)
                return false;
            else
                return true;
        }
    }
}
