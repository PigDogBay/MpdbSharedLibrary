using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.WPF.Service.Services
{
    public interface ISaveFileDialog
    {
        string InitialDirectory { get; set; }
        string Show(string filename, string filter);
        string Show(string filename, string filter, string initialDirectory);
    }
}
