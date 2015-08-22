using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
    /// <summary>
    /// Collection of checksum functions
    /// </summary>
    public static class Checksum
    {
        /// <summary>
        /// Adds up the ascii value of each char, the total is AND with 0xff and then subtracted from 0x100
        /// Used by TC Plus messaging
        /// </summary>
        /// <param name="data">String to work on</param>
        /// <returns></returns>
        public static int ByteAddition(string data)
        {
            return ByteAddition(data.ToCharArray(), 0, data.Length);
        }
        /// <summary>
        /// Adds up the ascii value of each char, the total is AND with 0xff and then subtracted from 0x100
        /// </summary>
        /// <param name="data">Array of chars to work on</param>
        /// <param name="offset">Offset into the array</param>
        /// <param name="len">Number of bytes to work on</param>
        /// <returns></returns>
        public static int ByteAddition(char[] data,int offset, int len)
        {
            int total = 0;
            for (int i = offset; i < (offset+len); i++)
            {
                total += data[i];
            }
            total = total & 0xff;
            total = 0x100 - total;
            total = total & 0xff;
            return total;

        }

        /// <summary>
        /// Adds up the ascii value of each char
        /// Used by TC-5000 messaging and block tags
        /// </summary>
        /// <param name="data">String to work on</param>
        /// <returns>Checksum value 0-255</returns>
        public static int SimpleChecksum(string data)
        {
            return SimpleChecksum(data.ToCharArray(), 0, data.Length);
        }
        /// <summary>
        /// Uses byte addition to add the ascii value of each character
        /// </summary>
        /// <param name="data">Array of chars to work on</param>
        /// <param name="offset">Offset into the array</param>
        /// <param name="len">Number of bytes to work on</param>
        /// <returns>Checksum value 0-255</returns>
        public static int SimpleChecksum(char[] data, int offset, int len)
        {
            byte checksum = 0;
            for (int i = offset; i < (offset+len); i++)
            {
                checksum += ((byte)data[i]);
            }
            return checksum;
        }
    }
}
