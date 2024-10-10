using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public sealed class Teacher : DbSqlCommands
    {
        public OperationResult Insert(string firstName, string lastName, string mobile)
        {
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
