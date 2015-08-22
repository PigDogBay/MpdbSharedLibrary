using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Utils
{
    /// <summary>
    /// Extension methods for IEnumerable T
    /// </summary>
    public static class IEnumerableExtensionMethods
    {
        /// <summary>
        /// Finds a single item in a list, or uses the specified default value if no items are found or the list is empty
        /// </summary>
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="source">Collection to enumerate over</param>
        /// <param name="predicate">Function implementing the condition</param>
        /// <param name="defaultValue">Default value to be returned if no items are found</param>
        /// <returns>The item that matches the condition or the default value</returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        /// <exception cref="InvalidOperationException">The input sequence contains more than one element.</exception>
        public static T FindSingleItem<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
        {
            T value = source.SingleOrDefault(predicate);
            if (object.Equals(value, default(T)))
            {
                value = defaultValue;
            }
            return value;
        }
        /// <summary>
        /// Finds the first item in a list, or uses the specified default value if no items are found or the list is empty
        /// </summary>
        /// <typeparam name="T">The type of the elements of source</typeparam>
        /// <param name="source">Collection to enumerate over</param>
        /// <param name="predicate">Function implementing the condition</param>
        /// <param name="defaultValue">Default value to be returned if no items are found</param>
        /// <returns>The item that matches the condition or the default value</returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        public static T FindFirstItem<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
        {
            T value = source.FirstOrDefault(predicate);
            if (object.Equals(value, default(T)))
            {
                value = defaultValue;
            }
            return value;
        }
        /// <summary>
        /// Splits data up into chunks
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">data</param>
        /// <param name="chunkSize">Size of the chunk</param>
        /// <returns>Enumeration of the chunks</returns>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            while (source.Any())
            {
                yield return source.Take(chunkSize);
                source = source.Skip(chunkSize);
            }
        }

    }
}
