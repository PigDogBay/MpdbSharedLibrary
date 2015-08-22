using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MpdBaileyTechnology.Shared.Maths
{
    /// <summary>
    /// A fixed size list that allows you to add in new items and old items are pushed out
    /// </summary>
    public class RollingAverage
    {
        /// <summary>
        /// Default list size
        /// </summary>
        public const int DEFAULT_ROLLING_AVERAGE_ARRAY_SIZE = 10;

        /// <summary>
        /// The maximum capacity of the fixed sized list
        /// </summary>
        public int Capacity { get; private set; }
        private List<double> _RollingAverageArray;

        /// <summary>
        /// Initialize using the default capacity
        /// </summary>
        public RollingAverage() : this(DEFAULT_ROLLING_AVERAGE_ARRAY_SIZE) { }
        /// <summary>
        /// Initialize instance with specfied capacity
        /// </summary>
        /// <param name="capacity">Capacity of the list</param>
        /// <exception cref="ArgumentOutOfRangeException">Capacity must be greater than 0</exception>
        public RollingAverage(int capacity)
        {
            _RollingAverageArray = new List<double>(capacity);
            this.Capacity = capacity;
        }
        /// <summary>
        /// Add item to the list, if list is already full, old items are pushed out
        /// </summary>
        /// <param name="x">New value to add</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Add(double x)
        {
            _RollingAverageArray.Add(x);
            while (_RollingAverageArray.Count > Capacity)
            {
                _RollingAverageArray.RemoveAt(0);
            }
        }
        /// <summary>
        /// Clears the list
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Clear()
        {
            _RollingAverageArray.Clear();
        }

        /// <summary>
        /// Calculates the mean value, if no items have been added 0 is returned
        /// </summary>
        /// <returns>Mean value</returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public double GetAverage()
        {
            if (_RollingAverageArray.Count==0)
            {
                return 0D;
            }
            return _RollingAverageArray.Sum() / ((double)_RollingAverageArray.Count);
        }
    }
}
