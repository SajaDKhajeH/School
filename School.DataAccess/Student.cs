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

        public void I()
        {
            SchoolDataContext db = new SchoolDataContext();

            var cc = db.Tbl_Students
                 .Select(x => new
                 {
                     x.FirstName,
                     x.LastName
                 }).Where(x => x.FirstName.Contains("ali")).FirstOrDefault();

            var dd = db.Tbl_Students
              .Select(x => new
              {
                  x.FirstName,
                  x.LastName,
                  x.Id
              }).Where(x => x.FirstName.Contains("ali"))
              .OrderByDescending(x => x.Id)
              .FirstOrDefault();

            var q1 = db.Tbl_Students
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                }).Where(x => x.FirstName.Contains("ali"))
                .ToString();

            var q2 = db.Tbl_Students
                .Where(x => x.FirstName.Contains("ali"))
               .Select(x => new
               {
                   x.FirstName,
                   x.LastName
               })
               .ToString();

            #region Insert
            db.Tbl_Students.Add(new Tbl_Student
            {
                FirstName = "",
                LastName = "",
                RegisterDate = DateTime.Now
            });

            db.SaveChanges();
            #endregion

            #region Update

            var student = db.Tbl_Students.Where(x => x.Id == 1).Single();
            student.FirstName = "";
            student.LastName = "";

            db.SaveChanges();

            #endregion

            #region Delete

            var dStudent = db.Tbl_Students.Where(x => x.Id == 1).Single();
            db.Tbl_Students.Remove(dStudent);
            db.SaveChanges();

            #endregion


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
