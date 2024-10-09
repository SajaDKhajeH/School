using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public sealed class Student : DbSqlCommands
    {
        public DataTable GetData(ref string msg)
        {
            SqlConnection con = new SqlConnection(Connections.SchoolCS);
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SelectStudents";
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Search", txtSearch.Text);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            try
            {
                con.Open();
                sqlDataAdapter.Fill(dataTable);
                con.Close();
            }
            catch (Exception ex)
            {
                ex.AddLog();
                msg = "خطا در دریافت اطلاعات از سرور";
            }
            return dataTable;
        }

        public string Insert()
        {
            return ExcuteProc("InsertStudent");
        }
        public string Update()
        {
            return ExcuteProc("UpdateStudent");
        }
        public string Delete()
        {
            return ExcuteProc("DeleteStudent");
        }
    }
}
