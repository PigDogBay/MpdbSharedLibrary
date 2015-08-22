using MpdBaileyTechnology.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace MpdBaileyTechnology.Shared.Threading
{
    /// <summary>
    /// Uses a underlying timer to call a work function which returns a value
    /// A data received event is fired delivering this value. If an error occurred
    /// during the work function call, an error event is fired and the stream is stopped.
    /// 
    /// The timer has re-entrance protection.
    /// </summary>
    public class DataStream<T> : Disposer
    {
        /// <summary>
        /// Default time period between ticks in milliseconds
        /// </summary>
        public const int DefaultTimePeriod = 1000;
        private Timer _Timer;
        private Func<T> _WorkFunction;
        /// <summary>
        /// Event is fired when new data is received
        /// </summary>
        public event EventHandler<EventArg<T>> DataReceived;
        /// <summary>
        /// Event is fired when an exception occurs exceuting the work function
        /// </summary>
        public event EventHandler<EventArg<Exception>> ErrorOccurred;
        /// <summary>
        /// Create data stream
        /// </summary>
        /// <param name="workFunction">Function to call when timer ticks</param>
        public DataStream(Func<T> workFunction)
            : this(workFunction, DefaultTimePeriod)
        {
        }
        /// <summary>
        /// Create data stream
        /// </summary>
        /// <param name="workFunction">function to call when timer ticks</param>
        /// <param name="timePeriod">time period in milliseconds between ticks</param>
        public DataStream(Func<T> workFunction, int timePeriod)
        {
            _Timer = new Timer(timePeriod);
            this._WorkFunction = workFunction;
            _Timer.Elapsed += new ElapsedEventHandler(_Timer_Elapsed);
        }
        /// <summary>
        /// Disposes of the underlying timer, but the work function is set to null
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            base.CleanUpManagedResources();
            _WorkFunction = null;
            _Timer.Stop();
            try { _Timer.Dispose(); }
            catch { }
        }

        void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //prevent re-entrance
            _Timer.Stop();
            try
            {
                OnDataReceived(_WorkFunction());
                //Ok Restart timer
                _Timer.Start();
            }
            catch (Exception ex)
            {
                OnErrorOccurred(ex);
            }
        }
        /// <summary>
        /// Start the data stream
        /// </summary>
        public void Start()
        {
            _Timer.Start();
        }
        /// <summary>
        /// Stop the data stream
        /// </summary>
        public void Stop()
        {
            _Timer.Stop();
        }

        private void OnDataReceived(T data)
        {
            if (null != DataReceived)
            {
                DataReceived(this, new EventArg<T>(data));
            }
        }

        private void OnErrorOccurred(Exception e)
        {
            if (null!=ErrorOccurred)
            {
                ErrorOccurred(this, new EventArg<Exception>(e));
            }
        }

    }
}
