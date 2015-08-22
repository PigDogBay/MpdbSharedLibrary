using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Utils
{
    /// <summary>
    /// Generic event args class, based on 
    /// http://msdn.microsoft.com/en-us/library/system.eventargs(v=vs.80).aspx
    /// </summary>
    /// <typeparam name="T">Type of the data</typeparam>
    public class EventArg<T> : EventArgs
    {
        private readonly T _EventData;

        /// <summary>
        /// Create new event arg with the data
        /// </summary>
        /// <param name="data">Event data</param>
        public EventArg(T data)
        {
            _EventData = data;
        }

        /// <summary>
        /// Gets the data
        /// </summary>
        public T Data
        {
            get { return _EventData; }
        }
    }
}
