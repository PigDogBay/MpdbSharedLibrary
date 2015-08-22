using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.WPF.Service.Services
{
    public interface IErrorDialog
    {
        void Show(string caption, string description);
    }
}
