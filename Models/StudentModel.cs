using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models
{
    public class StudentModel : BaseModelVaidation<StudentModel>
    {
        public StudentModel() 
        {
            model = this;
        }
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "نام خانوادگی اجباری است")]
        [MaxLength(10, ErrorMessage = "طول نباید بیش از 10 باشد")]
        public string LastName { get; set; }
        [MobileValidation(IsRequired = false)]
        public string Mobile { get; set; }

    }
}
