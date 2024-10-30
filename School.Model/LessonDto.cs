using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class LessonDto : BaseValidation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "عنوان درس اجباری است")]
        [MinLength(1, ErrorMessage = "حداقل یک کارکتر")]
        [MaxLength(128, ErrorMessage = "حداکثر 128 کارکتر")]
        public string Title { get; set; }

    }
}
