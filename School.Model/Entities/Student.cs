using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace School.Model.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(128)]
        public string Mobile { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeleteTime { get; set; }
        public List<Register> Registers { get; set; }
    }
}
