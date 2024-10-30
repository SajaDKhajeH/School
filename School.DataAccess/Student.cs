using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.BLL;

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


        public OperationResult Insert(StudentDto studentDto)
        {
            return ExcuteProc("InsertStudent", new SqlParameter[]
            {
                new SqlParameter("@FirstName",studentDto.FirstName),
                new SqlParameter("@LastName",studentDto.LastName),
                new SqlParameter("@Mobile",studentDto.Mobile),
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
