using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.IO
{
    /// <summary>
    /// Decorator to put logging around IInstrument calls
    /// </summary>
    public class LoggingInstrument : IInstrument
    {
        private static int _Counter = 0;
        private readonly int _ID;
        IInstrument _BaseInstrument;
        Action<string> _LoggingFunction;

        /// <summary>
        /// Uses Debug.WriteLine as the logging function
        /// </summary>
        /// <param name="baseInstrument">Base instrument to decorate</param>
        public LoggingInstrument(IInstrument baseInstrument)
            : this(baseInstrument, (msg) => Trace.WriteLine(msg))
        {
        }
        /// <summary>
        /// Uses specified logging function
        /// Please ensure your logging function appends new lines
        /// </summary>
        /// <param name="baseInstrument">Base instrument to decorate</param>
        /// <param name="loggingFunction">The logging function</param>
        public LoggingInstrument(IInstrument baseInstrument, Action<string> loggingFunction)
        {
            if (baseInstrument == null)
            {
                throw new ArgumentNullException("baseInstrument");
            }
            if (loggingFunction == null)
            {
                throw new ArgumentNullException("loggingFunction");
            }
            _BaseInstrument = baseInstrument;
            _LoggingFunction = loggingFunction;
            this._ID = _Counter;
            _Counter++;
        }
        private void Log(string msg)
        {
            string output = String.Format("DbgInst {0}: {1}", _ID.ToString(), msg);
            _LoggingFunction(output);
        }
        private void Log(string format, params object[] args)
        {
            Log(string.Format(format, args));
        }
        public void Connect(string connection)
        {
            Log("Connect {0}", connection);
            try
            {
                _BaseInstrument.Connect(connection);
            }
            catch (Exception e)
            {
                Log("Connect threw {0}", e.Message);
                throw;
            }
        }

        public void Disconnect()
        {
            Log("Disconnect");
            try
            {
                _BaseInstrument.Disconnect();
            }
            catch (Exception e)
            {
                Log("Disconnect threw {0}", e.Message);
                throw;
            }
        }

        public string Receive()
        {
            Log("Receive");
            try
            {
                string receive = _BaseInstrument.Receive();
                Log("Receive ret: {0}", receive);
                return receive;
            }
            catch (Exception e)
            {
                Log("Receive threw {0}", e.Message);
                throw;
            }
        }

        public void Send(string msg)
        {
            Log("Send {0}", msg);
            try
            {
                _BaseInstrument.Send(msg);
            }
            catch (Exception e)
            {
                Log("Send threw {0}", e.Message);
                throw;
            }
        }

        public void Dispose()
        {
            Log("Dispose");
            try
            {
                _BaseInstrument.Dispose();
            }
            catch (Exception e)
            {
                Log("Dispose threw {0}", e.Message);
                throw;
            }
        }
        public override string ToString()
        {
            return string.Format("DbgInst {0}: {1}", _ID.ToString(), base.ToString());
        }
    }
}
