using School.Model.DTO;
using School.Model.Entities;
using School.Model.Student;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace School.DataAccess
{
    public class StudentRepository : IDisposable
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

        public async Task<List<StudentVM>> GetDataAsync(CancellationToken token)
        {
            try
            {
                var a = db.Students.Where(x => x.Deleted == false).Select(x => new StudentVM
                {
                    FirstName = x.FirstName,
                    Id = x.Id,
                    LastName = x.LastName,
                    Mobile = x.Mobile
                }).ToListAsync(token);
                return await a;
            }
            catch (OperationCanceledException ex)
            {
                return new List<StudentVM>();
            }
            catch (Exception ex)
            {
                return new List<StudentVM>();
            }
        }

        public void Delete(int id)
        {
            var student = db.Students.Where(x => x.Id == id).Single();
            student.Deleted = true;
            student.DeleteTime = DateTime.Now;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
