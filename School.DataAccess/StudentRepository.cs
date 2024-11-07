using School.Model.DTO;
using School.Model.Entities;
using School.Model.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class StudentRepository
    {
        SchoolDataContext db = new SchoolDataContext();
        public void Insert(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }

        public bool CheckMobileExists(string mobile)
        {
            return db.Students.Where(x => x.Deleted == false && x.Mobile == mobile).Any();
        }

        public List<StudentVM> GetData()
        {
            return db.Students.Where(x => x.Deleted == false).Select(x => new StudentVM
            {
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                Mobile = x.Mobile
            }).ToList();
        }

        public void Delete(int id)
        {
            var student = db.Students.Where(x => x.Id == id).Single();
            student.Deleted = true;
            student.DeleteTime = DateTime.Now;
            db.SaveChanges();
        }
    }
}
