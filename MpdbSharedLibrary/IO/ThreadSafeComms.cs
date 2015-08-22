using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MpdBaileyTechnology.Shared.IO
{
    /// <summary>
    /// Use this class if you have multiple threads attempting to communicate to an instrument.
    /// This class will only allow one thread at a time to send and receive to the instrument
    /// </summary>
    public class ThreadSafeComms
    {
        IInstrument _Instrument;
        private object _LockObject = new object();

        /// <summary>
        /// Gets/Sets Number of attempts to send/receive
        /// </summary>
        public int Retries { get; set; }

        public ThreadSafeComms(IInstrument instrument)
        {
            _Instrument = instrument;
            Retries = 2;
        }

        /// <summary>
        /// If send/receive fails this will retry to send and receive again.
        /// </summary>
        /// <exception cref="TimeoutException">If every retry fails</exception>
        /// <param name="msg">Message to send</param>
        /// <returns>Response</returns>
        public string RetrySendReceive(string msg)
        {
            lock (_LockObject)
            {
                int retries = this.Retries;
                do
                {
                    try
                    {
                        _Instrument.Send(msg);
                        return _Instrument.Receive();
                    }
                    catch { }
                } while (--retries > 0);
            }
            throw new TimeoutException(String.Format("Unable to send/receive {0}", msg));
        }
        /// <summary>
        /// Use this if you need to wait a short period before trying to receive comms
        /// </summary>
        /// <param name="msg">Message to send</param>
        /// <param name="period">Time in milliseconds</param>
        /// <returns>Response</returns>
        public String SendWaitReceive(string msg, int period)
        {
            lock (_LockObject)
            {
                _Instrument.Send(msg);
                Thread.Sleep(period);
                return _Instrument.Receive();
            }
        }
    }
}
