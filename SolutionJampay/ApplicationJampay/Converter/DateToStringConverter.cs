using System;
using System.Globalization;
using System.Windows.Data;

namespace ApplicationJampay.Converter
{
    class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return String.Format("{0:dd/MM/yyyy}", value);
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return DateTime.ParseExact(value as string, "dd/MM/yyyy", null);
            }
            catch
            {
                return value;
            }
        }
    }
}
