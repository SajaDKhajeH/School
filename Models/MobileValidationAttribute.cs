using System.ComponentModel.DataAnnotations;

namespace Models
{
    internal class MobileValidationAttribute : ValidationAttribute
    {
        public bool IsRequired { get; set; }
        public override bool IsValid(object value)
        {
            string mobile = value as string;
            if (string.IsNullOrEmpty(mobile) && !IsRequired)
            {
                return true;
            }
            if (string.IsNullOrEmpty(mobile))
            {
                ErrorMessage = "شماره موبایل اجباری است";
                return false;
            }
            if (mobile.Length != 10)
            {
                ErrorMessage = "شماره موبایل نامعتبر است";
                return false;
            }
            return true;
        }
    }
}
