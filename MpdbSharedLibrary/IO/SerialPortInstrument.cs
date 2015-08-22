using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using MpdBaileyTechnology.Shared.Utils;

namespace MpdBaileyTechnology.Shared.IO
{
    /// <summary>
    /// Implements the IInstrument inteface using a SerialPort
    /// If a TimeOut exception is thrown whilst receiving data, this class will attempt
    /// to retry the operation until the max number of retries has been attempted.
    /// </summary>
    public class SerialPortInstrument : Disposer, IInstrument
    {
        /// <summary>
        /// Gets / sets the maximum number of read retries when getting time out exceptions 
        /// </summary>
        public int Retries { get; set; }

        private SerialPort _SerialPort;
        private Func<string, SerialPort> _CreatePort;

        /// <summary>
        /// The constructor takes a function that will create the port, 
        /// since there are many arguments needed to set up a port
        /// </summary>
        /// <param name="createPort">Function that takes the port name string and returns a SerialPort</param>
        public SerialPortInstrument(Func<string, SerialPort> createPort)
        {
            Retries = 3;
            _CreatePort = createPort;
        }
        /// <summary>
        /// Disconnects from the current port, creates a new port and opens it
        /// </summary>
        /// <param name="port">Name of the port, eg COM1</param>
        public void Connect(string port)
        {
            Disconnect();
            _SerialPort = _CreatePort(port);
            _SerialPort.Open();

        }
        /// <summary>
        /// Attempts to receive a line of data from the serial port
        /// If a TimeoutException is thrown, the operation is repeated 
        /// until the data is received or the max number of retries has been hit
        /// </summary>
        /// <exception cref="TimeoutException">No response from the port</exception>
        /// <exception cref="InvalidOperation">Port is closed</exception>
        /// <returns>Received string</returns>
        public string Receive()
        {
            int count = 0;
            while (true)
            {
                try
                {
                    return _SerialPort.ReadLine();
                }
                catch (TimeoutException)
                {
                    count++;
                    if (count > Retries)
                    {
                        //max number of retries have been made so re-throw the exception
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// Closes the underlying serial port
        /// </summary>
        public void Disconnect()
        {
            if (_SerialPort != null)
            {
                try
                {
                    _SerialPort.Close();
                    _SerialPort.Dispose();
                }
                catch { }
            }
            _SerialPort = null;
        }

        /// <summary>
        /// Clears the input buffer and then sends the command using WriteLine
        /// </summary>
        /// <param name="msg">Message to send</param>
        public void Send(string msg)
        {
            //Clear read/write buffers
            _SerialPort.DiscardInBuffer();
            _SerialPort.DiscardOutBuffer();
            _SerialPort.WriteLine(msg);
        }

        protected override void CleanUpManagedResources()
        {
            base.CleanUpManagedResources();
            Disconnect();
        }
    }
}
