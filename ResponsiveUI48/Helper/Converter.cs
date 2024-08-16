using System;
using System.Globalization;
using System.Windows.Data;

namespace ResponsiveUI48.Helper
{
    public class IsLessThanConverter : IValueConverter
    {
        public static readonly IValueConverter Instance = new IsLessThanConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dbValue = System.Convert.ToDouble(value);
            double dbCompareToValue = System.Convert.ToDouble(parameter);

            return dbValue < dbCompareToValue;
        }

        public object ConvertBack(object value, Type targetType, object paramter,  CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class IsGreaterThanConverter : IValueConverter
    {
        public static readonly IValueConverter Instance = new IsGreaterThanConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dbValue = System.Convert.ToDouble(value);
            double dbCompareToValue = System.Convert.ToDouble(parameter);

            return dbValue > dbCompareToValue;
        }

        public object ConvertBack(object value, Type targetType, object paramter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
