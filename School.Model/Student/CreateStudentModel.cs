using System.ComponentModel.DataAnnotations;

namespace School.Model.DTO
{
    public class CreateStudentModel : BaseValidation
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
