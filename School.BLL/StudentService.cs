using School.DataAccess;
using School.Model;
using School.Model.DTO;
using School.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL
{
    public class StudentService
    {
        StudentRepository studentRepository;
        public StudentService()
        {
            studentRepository = new StudentRepository();
        }
        public OperationResult Insert(StudentDto studentDto)
        {
            if (!studentDto.IsValid)
            {
                return new OperationResult
                {
                    Message = studentDto.ErrorMessage
                };
            }
            var existsMobile = studentRepository.CheckMobileExists(studentDto.Mobile);
            if (existsMobile)
            {
                return new OperationResult
                {
                    Message = "شماره موبایل تکراری است"
                };
            }
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
        public List<Student> GetData()
        {
            return studentRepository.GetData();
        }
    }
}
