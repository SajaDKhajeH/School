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
        SqlConnection con;
        public DbSqlCommands()
        {
            con = new SqlConnection(Connections.SchoolCS);
        }
        protected string ExcuteProc(string proc, SqlParameter[] ps = null)
        {
            string msg = "";
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
        protected T ExcuteFunc<T>(string func, SqlParameter[] ps = null)
        {
            SqlCommand cmd = new SqlCommand();
            string commandText = "select " + func + "(";
            if (ps != null)
            {
                foreach (var p in ps)
                {
                    cmd.Parameters.Add(p);
                    commandText += p.ParameterName + ",";
                }
            }
            commandText = commandText.Remove(commandText.Length - 1, 1);
            commandText += ")";
            cmd.Connection = con;
            cmd.CommandText = commandText;
            try
            {
                con.Open();
                var o = (T)cmd.ExecuteScalar();
                con.Close();
                return o;
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return default(T);
            }
        }

    }
}
