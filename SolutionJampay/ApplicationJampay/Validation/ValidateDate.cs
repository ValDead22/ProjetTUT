using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ApplicationJampay.Validation
{
    public class ValidateDate : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime date = new DateTime();

            try
            {
                date = DateTime.ParseExact(value as string, "dd/MM/yyyy", null);
            }
            catch
            {
                return new ValidationResult(false, "Ceci n'est pas une date !");
            }

            return new ValidationResult(true, null);
        }
    }
}
