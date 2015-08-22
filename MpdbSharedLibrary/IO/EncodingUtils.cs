using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.Utils;

namespace MpdBaileyTechnology.Shared.IO
{
    /// <summary>
    /// Functions for encoding strings and other data for use in communications messages
    /// </summary>
    public static class EncodingUtils
    {
        /// <summary>
        /// ASCII encoding id for the OEM USA
        /// </summary>
        public const int OEM_UNITED_STATES_ENCODING = 437;
        /// <summary>
        /// Converts a string, eg ROBOCOP, into binary representation: 524F424F434F50
        /// This is used by TC-5000 messaging and block tags
        /// </summary>
        /// <param name="name">Normal text string</param>
        /// <exception cref="NullReferenceException">If name is null</exception>
        /// <returns>String with each character converted in to its ASCII hex representation</returns>
        public static string FromStringNameIntoByteRepresentation(String name)
        {
            Encoding encoder = ASCIIEncoding.GetEncoding(OEM_UNITED_STATES_ENCODING);
            StringBuilder buffer = new StringBuilder();
            foreach (byte item in encoder.GetBytes(name.ToCharArray()))
            {
                buffer.Append(((int)item).ToString("X2", CultureInfo.InvariantCulture.NumberFormat));
            }
            return buffer.ToString();
        }
        /// <summary>
        /// Performs the inverse operation to FromStringNameIntoByteRepresentation
        /// </summary>
        /// <param name="name">String representation of the ASCII hex bytes</param>
        /// <exception cref="NullReferenceException">If name is null</exception>
        /// <returns>Actual string</returns>
        public static string FromByteRepresentationIntoStringName(String name)
        {
            Encoding encoder = ASCIIEncoding.GetEncoding(OEM_UNITED_STATES_ENCODING);
            return encoder.GetString(name.ToCharArray()
                                         .Chunk(2)
                                         .Select(s => new string(s.ToArray()))
                                         .Select(t => byte.Parse(t, NumberStyles.HexNumber))
                                         .ToArray());
        }

    }
}
