using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class SchoolDataContext : DbContext
    {
        public SchoolDataContext() : base("Data Source=.;Initial Catalog=SchoolDb2;Integrated Security=True")
        {
            var ensureDLLIsCopied =
               System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Tbl_Student> Tbl_Students { get; set; }
        public DbSet<Tbl_Lesson> Tbl_Lessons { get; set; }
    }
}
