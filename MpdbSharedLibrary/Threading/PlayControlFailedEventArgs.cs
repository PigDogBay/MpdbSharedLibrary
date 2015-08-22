using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Threading
{
    /// <summary>
    /// Event arguments for the PlayControl Failed event
    /// </summary>
    public class PlayControlFailedEventArgs : EventArgs
    {
        /// <summary>
        /// The exception that was raised during the worker thread execution
        /// </summary>
        public Exception Exception { get; private set; }
        /// <summary>
        /// Creates a new PlayControlFailedEventArgs instance
        /// </summary>
        /// <param name="e">The exception raised during working thread execution</param>
        public PlayControlFailedEventArgs(Exception e)
        {
            this.Exception = e;
        }
    }
}
