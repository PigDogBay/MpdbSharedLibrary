using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Utils
{
    public static class DateUtils
    {
        /// <summary>
        /// Unix Epoch
        /// </summary>
        public static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1);
        /// <summary>
        /// Network Time Protocol Epoch
        /// </summary>
        public static readonly DateTime NTP_EPOCH = new DateTime(1900, 1, 1);


        public static int DaysSinceEpoch(DateTime time, DateTime epoch)
        {
            TimeSpan since = time - epoch;
            return (int)since.TotalDays;
        }
        /// <summary>
        /// Used by TC-Plus block tags
        /// </summary>
        /// <returns>The number of days from the 1900 to now</returns>
        public static int DaysSinceNTPEpoch()
        {
            return DaysSinceEpoch(DateTime.Now, NTP_EPOCH);
        }
    }
}
