using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Utils
{
    /// <summary>
    /// Represents a collection of key/value pairs accessible using the key or the value as an retreiver. 
    /// <remarks>Note that uniqueness of both key and value is not guaranteed and duplicates of either may cause unexpected results.</remarks>
    /// </summary>
    /// <typeparam name="TFirst">The type of first index or key in the collection.</typeparam>
    /// <typeparam name="TSecond">The type of second index or value in the collection.</typeparam>
    public class DoubleIndexedDictionary<TFirst, TSecond>
    {
        List<TFirst> _firstIndexedList = new List<TFirst>();
        List<TSecond> _secondIndexList = new List<TSecond>();

        /// <summary>
        /// Initialises a new instance of the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/> class.
        /// </summary>
        public DoubleIndexedDictionary() { }

        /// <summary>
        /// Gets or sets a collection of type <typeparamref name="TFirst"/> containing the keys in the 
        /// <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>
        /// </summary>
        public List<TFirst> Keys
        {
            get { return _firstIndexedList; }
            set { _firstIndexedList = value; }
        }

        /// <summary>
        /// Gets or sets a collection of type <typeparamref name="TSecond"/> containing the values in the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>.
        /// </summary>
        public List<TSecond> Values
        {
            get { return _secondIndexList; }
            set { _secondIndexList = value; }
        }

        /// <summary>
        /// Retrieves a value using the index of a specified key to indicate the position of the value.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">index is less than 0.-or-index is equal to or greater than length of <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary.Values"/>.</exception>
        /// <param name="index">The index of a key to indicate the position of the value.</param>
        /// <returns>An instance of <typeparamref name="TSecond"/>.</returns>
        public TSecond UseKeyIndex(int index)
        {
            return _secondIndexList[index];
        }

        /// <summary>
        /// Retrieves a key using the index of a specified value to indicate the position of the key.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">index is less than 0.-or-index is equal to or greater than length of <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary.Keys"/>.</exception>
        /// <param name="index">The index of a value to indicate the position of the key.</param>
        /// <returns>An instance of <typeparamref name="TFirst"/>.</returns>
        public TFirst UseValueIndex(int index)
        {
            return _firstIndexedList[index];
        }

        /// <summary>
        /// Adds an element to the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary"/>.
        /// </summary>
        /// <param name="key">The object to be added to the end of <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary.Keys"/>.</param>
        /// <param name="value">The object to be added to the end of <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary.Values"/>.</param>
        public void Add(TFirst key, TSecond value)
        {
            _firstIndexedList.Add(key);
            _secondIndexList.Add(value);
        }

        /// <summary>
        /// Removes the element with the specified key from the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">key does not exist in <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary.Keys"/>.</exception>
        /// <exception cref="System.ArgumentNullException">key is null.</exception>
        /// <param name="key">The key of the element to remove.</param>
        public void RemoveWithKey(TFirst key)
        {
            int index = this.IndexOfKey(key);

            _firstIndexedList.RemoveAt(index);
            _secondIndexList.RemoveAt(index);
        }

        /// <summary>
        /// Removes the element with the specified value from the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">value does not exist in or <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary.Values"/>.</exception>
        /// <exception cref="System.ArgumentNullException">value is null.</exception>
        /// <param name="value">The value of the element to remove.</param>
        public void RemoveWithValue(TSecond value)
        {
            int index = this.IndexOfValue(value);

            _firstIndexedList.RemoveAt(index);
            _secondIndexList.RemoveAt(index);
        }

        /// <summary>
        /// Searches for the specified key and returns the zero-based index within the entire <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>.</param>
        /// <returns>The zero-based index of key within the entire <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>,
        /// if found; otherwise, -1.</returns>
        public int IndexOfKey(TFirst key)
        {
            for (int i = 0; i < _firstIndexedList.Count; i++)
            {
                if (_firstIndexedList[i].Equals(key))
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Searches for the specified value and returns the zero-based index within the entire <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>.
        /// </summary>
        /// <param name="value">The value to locate in the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>.</param>
        /// <returns>The zero-based index of value within the entire <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>,
        /// if found; otherwise, -1.</returns>
        public int IndexOfValue(TSecond value)
        {
            for (int i = 0; i < _secondIndexList.Count; i++)
            {
                if (_secondIndexList[i].Equals(value))
                    return i;
            }

            return -1;
        }
        
        /// <summary>
        /// Determines whether the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/> contains a specific key.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">key is null.</exception>
        /// <param name="key">The key to locate in the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>.</param>
        /// <returns>true if the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/> contains an element with the specified key; otherwise, false.</returns>
        public bool ContainsKey(TFirst key)
        {
            return _firstIndexedList.Contains(key);
        }

        /// <summary>
        /// Determines whether the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/> contains a specific value.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">value is null.</exception>
        /// <param name="value">The value to locate in the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/>.</param>
        /// <returns>true if the <see cref="MpdBaileyTechnology.Shared.WPF.Collections.Generic.DoubleIndexedDictionary&lt;TFirst, TSecond&gt;"/> contains an element with the specified value; otherwise, false.</returns>
        public bool ContainsValue(TSecond value)
        {
            return _secondIndexList.Contains(value);
        }
    }
}
