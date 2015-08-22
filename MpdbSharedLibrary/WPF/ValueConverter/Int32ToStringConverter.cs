using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;
using System.Diagnostics;

namespace MpdBaileyTechnology.Shared.WPF.ValueConverter
{
    /// <summary>
    /// Converts an instance of <see cref="System.Int32"/> to an instance of <see cref="System.String"/> by returning
    /// a string representation of the passed value. 
    /// </summary>
    [ValueConversion(typeof(Int32), typeof(String))]
    public class Int32ToStringConverter : IValueConverter
    {
        /// <summary>
        /// Attempts to convert a specified object to an instance of <see cref="System.String"/>.
        /// </summary>
        /// <param name="value">The object being converted.</param>
        /// <param name="targetType">A <see cref="System.Type"/> that represents the type you wish to convert to.</param>
        /// <param name="parameter">A parameter to use in the conversion, unused for this converter.</param>
        /// <param name="culture">A culture to use during the conversion, unused for this converter.</param>
        /// <returns>An instance of <see cref="System.String"/> created from the conversion.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Assert(targetType.IsAssignableFrom(typeof(String)), "targetType should be System.String");

            return ((Int32)value).ToString();
        }

        /// <summary>
        /// Attempts to convert a specified object to an instance of <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="value">The object being converted.</param>
        /// <param name="targetType">A <see cref="System.Type"/> that represents the type you wish to convert to.</param>
        /// <param name="parameter">A parameter to use in the conversion, unused for this converter.</param>
        /// <param name="culture">A culture to use during the conversion, unused for this converter.</param>
        /// <returns>An instance of <see cref="System.Int32"/> created from the conversion.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.Assert(targetType.IsAssignableFrom(typeof(Int32)), "targetType should be System.Int32");

            return Int32.Parse(((String)value));
        }
    }
}
