using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Utils
{
    /// <summary>
    /// Collection of functions performing binary operations
    /// </summary>
    public static class BinaryUtils
    {
        /// <summary>
        /// Reverses the byte order
        /// </summary>
        /// <param name="x">integer</param>
        /// <returns>reverse integer</returns>
        public static uint ReverseBytes(uint x)
        {
            return (x << 24 | (x & 0x0000ff00) << 8 | (x & 0x00ff0000) >> 8 | x >> 24);
        }
        /// <summary>
        /// Reverses the byte order
        /// </summary>
        /// <param name="x">integer</param>
        /// <returns>reverse integer</returns>
        public static int ReverseBytes(int x)
        {
            return (int)ReverseBytes((uint)x);
        }
    }
}
