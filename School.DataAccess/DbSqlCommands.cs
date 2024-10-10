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
        protected OperationResult ExcuteProc(string proc, SqlParameter[] ps = null)
        {
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
                return new OperationResult
                {
                    Message = "عملیات با موفقیت انجام شد",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return new OperationResult
                {
                    Message = "خطا در دریافت اطلاعات از سرور",
                    Success = false
                };
            }
        }
        protected OperationResult<DataTable> SelectDataTable(string procName, SqlParameter[] ps = null)
        {
            SqlConnection con = new SqlConnection(Connections.SchoolCS);
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Search", txtSearch.Text);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            try
            {
                con.Open();
                sqlDataAdapter.Fill(dataTable);
                con.Close();
                return new OperationResult<DataTable>
                {
                    Success = true,
                    Message = "عملیات با موفقیت انجام شده",
                    Data = dataTable
                };
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return new OperationResult<DataTable>
                {
                    Success = false,
                    Message = "خطا در دریافت اطلاعات از سرور"
                };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcName">must have schema</param>
        /// <param name="ps"></param>
        /// <returns></returns>
        protected OperationResult<bool> SelectFunc(string funcName, SqlParameter[] ps = null)
        {
            SqlConnection con = new SqlConnection(Connections.SchoolCS);
            SqlCommand cmd = new SqlCommand();
            string commandText = "select " + funcName + "(";
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
                var o = (bool)cmd.ExecuteScalar();
                con.Close();
                return new OperationResult<bool>
                {
                    Success = true,
                    Data = o
                };
            }
            catch (Exception ex)
            {
                ex.AddLog();
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = "خطا در عملیات"
                };
            }
        }
    }
}
