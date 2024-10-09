using System;
using System.Data;
using System.Data.SqlClient;

namespace School.DataAccess
{
    public static class ExtentionMethods
    {
        public static void AddLog(this Exception ex)
        {
            SqlConnection c = new SqlConnection(Connections.SchoolCS);
            var cmd = new SqlCommand();
            cmd.Connection = c;
            cmd.CommandText = "AddError";
            cmd.Parameters.AddWithValue("@ErrorText", ex.ToString());
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                c.Open();
                cmd.ExecuteNonQuery();
                c.Close();
            }
            catch
            {
            }
        }
    }
}
