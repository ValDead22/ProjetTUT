using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ApplicationJampay.Validation
{
    public class ValidateString : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value as string == "" || value is null)
            {
                return new ValidationResult(false, "Ce champ ne doit pas être vide");
            }

            return new ValidationResult(true, null);
        }
    }
}
