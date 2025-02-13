using School.Model.Entities;
using School.Model.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class ClassRepository : IClassRepository
    {
        SchoolDataContext db = new SchoolDataContext();

        public bool CheckMobileExists(string mobile)
        {
            throw new NotImplementedException();
        }

        public List<StudentVM> GetData()
        {
            throw new NotImplementedException();
        }

        public void Insert(Class student)
        {
            db.Classes.Add(student);
            db.SaveChanges();
        }

        public void Insert(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
