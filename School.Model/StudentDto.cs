using School.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class StudentDto : BaseValidation
    {
        [Required(ErrorMessage = "نام اجباری است")]
        [MinLength(1, ErrorMessage = "حداقل یک کارکتر")]
        [MaxLength(128, ErrorMessage = "حداکثر 128 کارکتر")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "نام خانوادگی اجباری است")]
        [MinLength(1, ErrorMessage = "حداقل یک کارکتر")]
        [MaxLength(128, ErrorMessage = "حداکثر 128 کارکتر")]
        public string LastName { get; set; }
        [MobileValidation]
        public string Mobile { get; set; }
    }
}
