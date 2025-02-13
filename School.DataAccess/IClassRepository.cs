using School.Model.Entities;
using School.Model.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public interface IClassRepository
    {
        void Insert(Student student);
        bool CheckMobileExists(string mobile);
        List<StudentVM> GetData();
    }
}
