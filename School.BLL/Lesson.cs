using School.DataAccess;
using School.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL
{
    public class Lesson
    {
        //DataAccess.Student student;
        public Lesson()
        {
            //student = new DataAccess.Student();
        }
        public OperationResult Insert(LessonDto lessonDto)
        {
            //var valid = IsValid(studentDto);
            //if (!valid.Success)
            //{
            //    return valid;
            //}
            if (!lessonDto.IsValid)
            {
                return new OperationResult
                {
                    Message = lessonDto.ErrorMessage
                };
            }
            return new OperationResult
            {
                Success = true,
                Message = "ok"
            };
            //var existsMobileResult = student.CheckMobileExists(studentDto.Mobile);
            //if (!existsMobileResult.Success)
            //{
            //    return existsMobileResult;
            //}
            //if (existsMobileResult.Data)
            //{
            //    existsMobileResult.Message = "شماره موبایل تکراری است";
            //    existsMobileResult.Success = false;
            //    return existsMobileResult;
            //}
            //return student.Insert(studentDto);

        }
    }
}
