using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
    /// <summary>
    /// http://en.wikipedia.org/wiki/Steinhart-Hart_equation
    /// 
    /// The Steinhart–Hart equation is a model of the resistance of a semiconductor at different temperatures. 
    /// The equation is:
    /// 
    /// 1/T = A + B.ln(R) + C.(ln(R))^3
    /// 
    ///  T is the temperature (in kelvins)
    ///  R is the resistance at T (in ohms)
    ///  A, B and C are the Steinhart-Hart coefficients which vary depending on 
    ///  the type and model of thermistor and the temperature range of interest.
    /// 
    /// </summary>
    public class SteinhartHartEquation
    {
        /// <summary>
        /// Add this value to Celsius temperatures to convert to Kelvin
        /// Subtract this value to Kelvin temperatures to convert to Celsius
        /// </summary>
        public const double KelvinToCelsius = 273.15D;
        /// <summary>
        /// Gets/ Sets Equation coefficent A
        /// </summary>
        public double A { get; set; }
        /// <summary>
        /// Gets/ Sets Equation coefficent B
        /// </summary>
        public double B { get; set; }
        /// <summary>
        /// Gets/ Sets Equation coefficent C
        /// </summary>
        public double C { get; set; }

        /// <summary>
        /// Initialize with coefficients set to 0
        /// </summary>
        public SteinhartHartEquation()
        {
            A = 0D;
            B = 0D;
            C = 0D;
        }

        /// <summary>
        /// Initialize with the 3 equation coefficients
        /// </summary>
        /// <param name="a">Coefficient A</param>
        /// <param name="b">Coefficient B</param>
        /// <param name="c">Coefficient C</param>
        public SteinhartHartEquation(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        /// <summary>
        /// Uses Steinhart-Hart equation to calculate temperature
        /// </summary>
        /// <param name="resistance">Resistance in Ohms</param>
        /// <returns>Temperature in °C</returns>
        public double CalculateTemperature(double resistance)
        {
            return (1D / (A + (B * Math.Log(resistance)) + (C * Math.Pow(Math.Log(resistance), 3)))) - KelvinToCelsius;
        }

        /// <summary>
        /// Inverse of the Steinhart-Hart equation
        /// </summary>
        /// <param name="temperature">Temperature in °C</param>
        /// <returns>Resistance in Ohms</returns>
        public double CalculateResistance(double temperature)
        {
            //convert to Kelvin
            temperature += KelvinToCelsius;

            double y = (A - 1D / temperature) / C;
            double x = Math.Sqrt(Math.Pow(B / (3D * C), 3D) + y * y / 4D);

            return Math.Exp(Math.Pow(x - y / 2, 1D / 3D) - Math.Pow(x + y / 2, 1D / 3D));
        }
        /// <summary>
        /// To find the coefficients of Steinhart-Hart, we need to know at-least three operating points. 
        /// For this, we use three values ​​of resistance data for three known temperatures.
        /// </summary>
        /// <param name="r1">Resistance in Ohms</param>
        /// <param name="t1">Temperature in °C</param>
        /// <param name="r2">Resistance in Ohms</param>
        /// <param name="t2">Temperature in °C</param>
        /// <param name="r3">Resistance in Ohms</param>
        /// <param name="t3">Temperature in °C</param>
        public void CalculateCoefficients(double r1, double t1,double r2, double t2,double r3, double t3)
        {
            double L1 = Math.Log(r1);
            double L2 = Math.Log(r2);
            double L3 = Math.Log(r3);
            double Y1 = 1D / (t1+KelvinToCelsius);
            double Y2 = 1D / (t2+KelvinToCelsius);
            double Y3 = 1D / (t3+KelvinToCelsius);
            double G2 = (Y2 - Y1) / (L2 - L1);
            double G3 = (Y3 - Y1) / (L3 - L1);

            this.C = (G3 - G2) / ((L3 - L2) * (L1 + L2 + L3));
            this.B = G2 - C * (L1 * L1 + L1 * L2 + L2 * L2);
            this.A = Y1 - (B + L1 * L1 * C) * L1;
        }
    }
}
