using School.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class ClassRepository
    {
        SchoolDataContext db = new SchoolDataContext();
        public void Insert(Class student)
        {
            db.Classes.Add(student);
            db.SaveChanges();
        }
    }
}
