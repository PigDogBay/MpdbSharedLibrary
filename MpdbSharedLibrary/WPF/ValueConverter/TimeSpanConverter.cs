using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace MpdBaileyTechnology.Shared.WPF.ValueConverter
{
    [ValueConversion(typeof(TimeSpan), typeof(string))]
    public class TimeSpanConverter : IValueConverter
    {
        public const string DefaultFormat = "HH:mm:ss";
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is TimeSpan))
            {
                return DependencyProperty.UnsetValue;
            }
            TimeSpan timeSpan = (TimeSpan)value;
            int hours = (int)timeSpan.TotalHours;
            return string.Format("{0}:{1:00}:{2:00}", hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string timeSpanString = value as string;
            if (timeSpanString == null)
            {
                return DependencyProperty.UnsetValue;
            }
            return TimeSpan.Parse((string)value);
        }
    }
}
