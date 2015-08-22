using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.IO
{
    public interface IInstrument : IDisposable
    {
        void Connect(string connection);
        void Disconnect();
        void Send(string msg);
        string Receive();
    }
}
