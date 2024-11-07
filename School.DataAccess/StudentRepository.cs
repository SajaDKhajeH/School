using School.Model.DTO;
using School.Model.Entities;
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
            return db.Students.Any(x => x.Mobile == mobile);
        }

        public List<Student> GetData()
        {
            return db.Students.ToList();
        }
    }
}
