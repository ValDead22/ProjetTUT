using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ApplicationJampay.Validation
{
    public class ValidateFloat : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                float.Parse(value as string, CultureInfo.InvariantCulture);
            }
            catch (System.FormatException)
            {
                return new ValidationResult(false, "Vous devez rentrez un prix valide !");
            }

            return new ValidationResult(true, null);
        }
    }
}
