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
        public OperationResult<DataTable> GetData()
        {
            return SelectDataTable("SelectStudents");
        }

        public OperationResult<bool> CheckMobileExists(string mobile)
        {
            return SelectFunc("dbo.CheckExistsMobileNumber", new SqlParameter[]
                {
                    new SqlParameter("@MobileNumber", mobile)
                });
        }


        public OperationResult Insert(string firstName, string lastName, string mobile)
        {
            var existsMobileResult = CheckMobileExists(mobile);
            if (!existsMobileResult.Success)
            {
                return existsMobileResult;
            }
            if (existsMobileResult.Data)
            {
                return existsMobileResult;
            }
            return ExcuteProc("InsertStudent", new SqlParameter[]
            {
                new SqlParameter("@FirstName",firstName),
                new SqlParameter("@LastName",lastName),
                new SqlParameter("@Mobile",mobile),
            });
        }
        public OperationResult Update()
        {
            return ExcuteProc("UpdateStudent");
        }
        public OperationResult Delete()
        {
            return ExcuteProc("DeleteStudent");
        }
    }
}
