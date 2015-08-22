/*
 * Example usage:

   <StackPanel>
        <StackPanel.Resources>
            <converters:BooleanToStringConverter x:Key="boolConv" FalseText="Noh" TrueText="Hoo Yeah!"/>
        </StackPanel.Resources>
        <CheckBox 
            Content="Tick me"
            IsChecked="{Binding Flag}"/>
        <Label Content="{Binding Flag,Converter={StaticResource ResourceKey=boolConv}}"/>
    </StackPanel>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace MpdBaileyTechnology.Shared.WPF.ValueConverter
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class BooleanToStringConverter : IValueConverter
    {
        /// <summary>
        /// Gets / Sets the text to display if the value is false
        /// </summary>
        public string FalseText { get; set; }
        /// <summary>
        /// Gets / Sets the text to display if the value is true
        /// </summary>
        public string TrueText { get; set; }
        public BooleanToStringConverter()
        {
            FalseText = string.Empty;
            TrueText = string.Empty;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? result = value as bool?;
            if (result.HasValue && result.Value)
            {
                return TrueText;
            }
            return FalseText;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            String str = value as string;
            if (str != null)
            {
                if (str.Equals(TrueText))
                    return true;
                else if (str.Equals(FalseText))
                    return false;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
