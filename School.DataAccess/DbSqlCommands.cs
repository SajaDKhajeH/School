using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class DbSqlCommands
    {
        protected string ExcuteProc(string proc, SqlParameter[] ps = null)
        {
            string msg = "";
            SqlConnection con = new SqlConnection(Connections.SchoolCS);
            SqlCommand cmd = new SqlCommand();
            if (ps != null)
            {
                foreach (var p in ps)
                {
                    cmd.Parameters.Add(p);
                }
            }
            cmd.Connection = con;
            cmd.CommandText = proc;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Search", txtSearch.Text);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                ex.AddLog();
                msg = "خطا در دریافت اطلاعات از سرور";
            }
            return msg;
        }
    }
}
