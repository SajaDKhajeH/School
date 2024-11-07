using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class RegisterRepository
    {
        SchoolDataContext db = new SchoolDataContext();
        public object GetRegisters()
        {
            return db.Registers
                .Select(x => new
                {
                    x.Student.FirstName,
                    x.Class.Title
                });
        }
    }
}
