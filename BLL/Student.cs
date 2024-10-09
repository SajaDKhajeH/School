using Models;

namespace BLL
{
    public class Student
    {
        School.DataAccess.Student student;
        public Student()
        {
            student = new School.DataAccess.Student();
        }
        public string Insert(StudentModel studentModel)
        {
            if (!studentModel.IsValid)
                return studentModel.Errors;
            if (student.IsDuplicateMobile(studentModel.Mobile, 0))
                return "شماره موبایل به کاربر دیگری اختصاص داده شده";

            return student.Insert(studentModel);

        }
    }
}
