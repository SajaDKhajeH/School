using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class ChatModel
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public ApiStudentResponse From { get; set; }
        public ApiStudentResponse To { get; set; }
    }
}
