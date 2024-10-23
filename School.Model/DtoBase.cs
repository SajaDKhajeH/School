using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace School.BLL
{
    public class DtoBase
    {
        List<ValidationResult> validationResult;
        public bool IsValid(object instance, bool checkAll = true)
        {
            var context = new ValidationContext(instance);
            validationResult = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(instance, context, validationResult, true);
            return isValid;
        }
        public string ErrorMessages
        {
            get
            {
                string errors = "";
                foreach (var item in validationResult)
                {
                    errors += item.ErrorMessage;
                    errors += Environment.NewLine;
                }
                return errors;
            }
        }
    }
}