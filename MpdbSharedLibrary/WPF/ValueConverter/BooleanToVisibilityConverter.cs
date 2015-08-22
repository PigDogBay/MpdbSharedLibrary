using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Diagnostics;

namespace MpdBaileyTechnology.Shared.WPF.ValueConverter
{
    /// <summary>
    /// Converts an instance of <see cref="System.Boolean"/> to an instance of <see cref="System.Windows.Visibility"/> by returning
    /// <see cref="System.Windows.Visibility.Visible"/> if the received instance is true and <see cref="System.Windows.Visibility.Hidden"/>
    /// if false.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Attempts to convert a specified object to an instance of <see cref="System.Windows.Visibility"/>.
        /// </summary>
        /// <param name="value">The object being converted.</param>
        /// <param name="targetType">A <see cref="System.Type"/> that represents the type you wish to convert to.</param>
        /// <param name="parameter">A parameter to use in the conversion, unused for this converter.</param>
        /// <param name="culture">A culture to use during the conversion, unused for this converter.</param>
        /// <returns>An instance of <see cref="System.Windows.Visibility"/> created from the conversion.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Assert(targetType.IsAssignableFrom(typeof(Visibility)), "targetType should be System.Boolean");

            if ((bool)value)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        /// <summary>
        /// Attempts to convert a specified object to an instance of <see cref="System.Boolean"/>.
        /// </summary>
        /// <param name="value">The object being converted.</param>
        /// <param name="targetType">A <see cref="System.Type"/> that represents the type you wish to convert to.</param>
        /// <param name="parameter">A parameter to use in the conversion, unused for this converter.</param>
        /// <param name="culture">A culture to use during the conversion, unused for this converter.</param>
        /// <returns>An instance of <see cref="System.Boolean"/> created from the conversion.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Assert(targetType.IsAssignableFrom(typeof(Visibility)), "targetType should be System.Windows.Visibility");
             
            if (((Visibility)value) == Visibility.Visible)
                return true;
            else
                return false;
        }
    }
}
