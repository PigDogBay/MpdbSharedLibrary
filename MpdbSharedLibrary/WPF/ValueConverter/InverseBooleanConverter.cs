using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Diagnostics;

namespace MpdBaileyTechnology.Shared.WPF.ValueConverter
{
    /// <summary>
    /// Converts an instance of <see cref="System.Boolean"/> to an instance of <see cref="System.Boolean"/> by returning
    /// the boolean opposite.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Attempts to convert a specified object to an instance of <see cref="System.Boolean"/>.
        /// </summary>
        /// <param name="value">The object being converted.</param>
        /// <param name="targetType">A <see cref="System.Type"/> that represents the type you wish to convert to.</param>
        /// <param name="parameter">A parameter to use in the conversion, unused for this converter.</param>
        /// <param name="culture">A culture to use during the conversion, unused for this converter.</param>
        /// <returns>An instance of <see cref="System.Boolean"/> created from the conversion.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Assert(targetType.IsAssignableFrom(typeof(Boolean)), "targetType should be System.Boolean");

            return !(bool)value;
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
            Debug.Assert(targetType.IsAssignableFrom(typeof(Boolean)), "targetType should be System.Boolean");

            return !(bool)value;
        }
    }
}
