using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Utils
{
    public static class EnumTools
    {
        /// <summary>
        /// Returns an enumeration of the enum's names and values
        /// </summary>
        /// <typeparam name="T">Enum name</typeparam>
        /// <returns>Enumeration of the enum's names and values</returns>
        public static IEnumerable<KeyValuePair<string,int>> GetNamesValues<T>()
        {
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                yield return new KeyValuePair<string, int>(name, (int)Enum.Parse(typeof(T), name));
            }

        }
    }
}
