using School.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL
{
    public class Student
    {
        DataAccess.Student student;
        public Student()
        {
            student = new DataAccess.Student();
        }
        public OperationResult InsertEF(StudentDto studentDto)
        {
            student.I();
          
            return new OperationResult();
        }
        public OperationResult Insert(StudentDto studentDto)
        {
            //var valid = IsValid(studentDto);
            //if (!valid.Success)
            //{
            //    return valid;
            //}
            if (!studentDto.IsValid)
            {
                return new OperationResult
                {
                    Message = studentDto.ErrorMessage
                };
            }
            var existsMobileResult = student.CheckMobileExists(studentDto.Mobile);
            if (!existsMobileResult.Success)
            {
                return existsMobileResult;
            }
            if (existsMobileResult.Data)
            {
                existsMobileResult.Message = "شماره موبایل تکراری است";
                existsMobileResult.Success = false;
                return existsMobileResult;
            }
            return student.Insert(studentDto);

        }

        //private OperationResult IsValid(StudentDto studentDto)
        //{
        //    if (string.IsNullOrEmpty(studentDto.FirstName))
        //    {
        //        return new OperationResult
        //        {
        //            Message = "نام اجباری است"
        //        };
        //    }
        //    if (string.IsNullOrEmpty(studentDto.LastName))
        //    {
        //        return new OperationResult
        //        {
        //            Message = "نام خانوادگی اجباری است"
        //        };
        //    }
        //    if (string.IsNullOrEmpty(studentDto.Mobile))
        //    {
        //        return new OperationResult
        //        {
        //            Message = "شماره موبایل اجباری است"
        //        };
        //    }
        //    if (studentDto.Mobile.Length != 11 || !studentDto.Mobile.StartsWith("09"))
        //    {
        //        return new OperationResult
        //        {
        //            Message = "شماره موبایل نامعتبر است"
        //        };
        //    }
        //    return new OperationResult
        //    {
        //        Success = true
        //    };
        //}
    }
}
