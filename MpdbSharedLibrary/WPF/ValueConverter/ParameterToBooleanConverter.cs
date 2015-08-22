/*
    See
    http://stackoverflow.com/questions/397556/wpf-how-to-bind-radiobuttons-to-an-enum
    
    Usage
<RadioButton 
            IsChecked="{Binding Path=ProfileData.Direction, 
            Converter={StaticResource enumToBooleanConverter}, 
            ConverterParameter={x:Static wp:WellProfileDirection.XDirection}}"/>
<RadioButton 
            IsChecked="{Binding Path=ProfileData.Direction, 
            Converter={StaticResource enumToBooleanConverter}, 
            ConverterParameter={x:Static wp:WellProfileDirection.YDirection}}"/>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace MpdBaileyTechnology.Shared.WPF.ValueConverter
{
    /// <summary>
    /// Converts the value to a boolean by comparing the value to the parameter.
    /// </summary>
    public class ParameterToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Convert value to boolean
        /// </summary>
        /// <param name="value">Data value</param>
        /// <param name="parameter">Specified in the ConverterParameter setting</param>
        /// <param name="targetType">Unused</param>
        /// <param name="culture">Unused</param>
        /// <returns>Returns true if the value equals the parameter</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Equals(parameter);
        }
        /// <summary>
        /// Convert boolean to parameter
        /// </summary>
        /// <param name="value">Data value</param>
        /// <param name="parameter">Specified in the ConverterParameter setting</param>
        /// <param name="targetType">Unused</param>
        /// <param name="culture">Unused</param>
        /// <returns>Returns the parameter if true, otherwise UnsetValue</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.Equals(false))
                return DependencyProperty.UnsetValue;
            else
                return parameter;
        }
    }
}
