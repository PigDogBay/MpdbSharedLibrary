/*
    Example usage:
    <TextBox>
        <TextBox.Text>
            <Binding Path="WellReaderData.NumberOfReadings">
                <Binding.ValidationRules>
                    <validators:MaxMinValidationRule Min="1" Max="1000"/>
                </Binding.ValidationRules>
            </Binding>
        </TextBox.Text>
    </TextBox>
  */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;

namespace MpdBaileyTechnology.Shared.WPF.ValidationRules
{
    /// <summary>
    /// Custom validation rule for checking the maximum and minimum allowed values
    /// </summary>
    public class MaxMinValidationRule : ValidationRule
    {
        /// <summary>
        /// Gets or sets the minimum allowed value
        /// </summary>
        public float Min { get; set; }
        /// <summary>
        /// Gets or sets the maximum allowed value
        /// </summary>
        public float Max { get; set; }

        /// <summary>
        /// Creates MaxMinValidationRule using float32 max and min values as defaults
        /// </summary>
        public MaxMinValidationRule()
        {
            Min = float.MinValue;
            Max = float.MaxValue;
        }
        /// <summary>
        /// Validate the value against the allowed maximum and minimum settings
        /// </summary>
        /// <param name="value">value to test</param>
        /// <param name="cultureInfo">Locale setting</param>
        /// <returns>True - value falls in the allowed range</returns>
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            float result = 0;
            if (((string)value).Length > 0)
            {
                if (!float.TryParse((string)value, NumberStyles.Any, cultureInfo, out result))
                {
                    return new ValidationResult(false, "Illegal characters.");
                }
            }
            if ((result < Min) || (result > Max))
            {
                return new ValidationResult(false, "Not in range " + Min + " to " + Max + ".");
            }
            return new ValidationResult(true, null);
        }
    }
}
