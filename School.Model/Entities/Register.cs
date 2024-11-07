using System;

namespace School.Model.Entities
{
    public class Register
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime RegisterDate { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}
