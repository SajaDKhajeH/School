using Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace School.DataAccess
{
    public sealed class Student : DbSqlCommands
    {
        public DataTable GetData(string search, ref string msg)
        {
            SqlConnection con = new SqlConnection(Connections.SchoolCS);
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SelectStudents";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", search);
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

        public string Insert(StudentModel student)
        {
            return ExcuteProc("InsertTeacher", new SqlParameter[]
            {
                new SqlParameter("@FirstName",student.FirstName),
                new SqlParameter("@LastName",student.LastName),
                new SqlParameter("@Mobile",student.Mobile),
            });
        }
        public bool IsDuplicateMobile(string mobileNumber, int studentId)
        {
            return ExcuteFunc<bool>("dbo.IsDuplicateMobile", new SqlParameter[]
            {
                new SqlParameter("@Mobile",mobileNumber),
                new SqlParameter("@StudentId",studentId)
            });
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
