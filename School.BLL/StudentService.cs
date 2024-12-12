using School.DataAccess;
using School.Model;
using School.Model.DTO;
using School.Model.Entities;
using School.Model.Student;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace School.BLL
{
    public class StudentService : IDisposable
    {
        StudentRepository studentRepository;
        public StudentService()
        {
            studentRepository = new StudentRepository();
        }
        public OperationResult Insert(CreateStudentModel studentDto)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            //if (!studentDto.IsValid)
            //{
            //    return new OperationResult
            //    {
            //        Message = studentDto.ErrorMessage
            //    };
            //}
            //var existsMobile = studentRepository.CheckMobileExists(studentDto.Mobile);
            //if (existsMobile)
            //{
            //    return new OperationResult
            //    {
            //        Message = "شماره موبایل تکراری است"
            //    };
            //}
            var student = new Student
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Mobile = studentDto.Mobile,
                RegisterDate = DateTime.Now
            };
            studentRepository.Insert(student);
            return new OperationResult { Success = true };
        }
        public List<StudentVM> GetData()
        {
            return studentRepository.GetData();
        }

        public OperationResult Delete(int id)
        {
            studentRepository.Delete(id);
            return new OperationResult { Success = true };
        }

        public void Dispose()
        {
            studentRepository.Dispose();
        }

        
    }
}
