using System.Data.SqlClient;

namespace School.DataAccess
{
    public sealed class Teacher : DbSqlCommands
    {
        public string Insert(string firstName, string lastName, string mobile)
        {
            return ExcuteProc("InsertTeacher", new SqlParameter[]
            {
                new SqlParameter("@FirstName",firstName),
                new SqlParameter("@LastName",lastName),
                new SqlParameter("@Mobile",mobile),
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
