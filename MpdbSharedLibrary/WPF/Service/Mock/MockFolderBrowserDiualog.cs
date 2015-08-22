using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Service.Services;

namespace MpdBaileyTechnology.Shared.WPF.Service.Mock
{
    public class MockFolderBrowserDiualog : IFolderBrowserDialog
    {
        public bool ReturnValue { get; set; }
        public string Path { get; set; }

        public bool Show(ref string path)
        {
            path = Path;
            return ReturnValue;
        }
    }
}
