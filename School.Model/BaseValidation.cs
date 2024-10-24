using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class BaseValidation
    {
        List<ValidationResult> results;
        public bool IsValid
        {
            get
            {
                var context = new ValidationContext(this);
                results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(this, context, results, true);
                return isValid;
            }
        }
        public string ErrorMessage
        {
            get
            {
                //string errors = "";
                StringBuilder sb = new StringBuilder(); 
                foreach (var item in results)
                {
                    //errors += item.ErrorMessage;
                    //errors += Environment.NewLine;
                    sb.AppendLine(item.ErrorMessage);
                    //string b = $"{txt1.text} {txt2.text}";
                }
                return sb.ToString();
            }
        }
    }
}
