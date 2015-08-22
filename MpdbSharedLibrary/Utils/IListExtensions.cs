using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Utils
{
    /// <summary>
    /// Extension methods for the IList interface
    /// </summary>
    public static class IListExtensions
    {
        /// <summary>
        /// Randomly shuffles the IList elements
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                int swap = random.Next(list.Count);
                if (i != swap)
                {
                    T tmp = list[i];
                    list[i] = list[swap];
                    list[swap] = tmp;
                }
            }
        }
    }
}
