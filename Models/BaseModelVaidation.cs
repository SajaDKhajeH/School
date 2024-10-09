using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models
{
    public class BaseModelVaidation<T>
    {
        protected T model { get; set; }
        public bool IsValid
        {
            get
            {
                var context = new ValidationContext(model);
                results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(model, context, results, true);
                return isValid;
            }
        }
        protected List<ValidationResult> results = new List<ValidationResult>();
        public string Errors
        {
            get
            {
                return string.Join(Environment.NewLine, results.Select(x => x.ErrorMessage));
            }
        }
    }
}
