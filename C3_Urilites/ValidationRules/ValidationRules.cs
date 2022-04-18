using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace C3_Urilites.ValidationRules
{
    class EmailValidationRules : ValidationRule
    {
        private Regex _emailRegex = new Regex(@"^([A-Za-z0-9_-]+\.)*[A-Za-z0-9_-]+@[A-Za-z0-9_-]+(\.[A-Za-z0-9_-]+)*\.[A-Za-z]{2,6}$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value.ToString();
            if (_emailRegex.IsMatch(email)) return new ValidationResult(true, null);
            else return new ValidationResult(false, "Не верный ввод адреса!");
        }
    }
}
