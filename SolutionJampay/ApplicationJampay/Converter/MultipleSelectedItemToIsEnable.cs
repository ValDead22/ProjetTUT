using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace ApplicationJampay.Converter
{
    class MultipleSelectedItemToIsEnable : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var cpt = 0;

            foreach(object o in values)
            {
                if (o != null)
                {
                    cpt++;
                }
            }
            
            if (cpt == values.Length)
            {
                return true;
            }

            return false;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
