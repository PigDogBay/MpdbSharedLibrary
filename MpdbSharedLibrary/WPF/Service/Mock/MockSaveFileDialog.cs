using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Service.Services;

namespace MpdBaileyTechnology.Shared.WPF.Service.Mock
{
    public class MockSaveFileDialog : ISaveFileDialog
    {
        public string InitialDirectory { get; set; }
        public string Filename { get; private set; }
        public string Filter { get; private set; }
        public string ReturnValue { get; set; }
        public string Show(string filename, string filter)
        {
            return Show(filename,filter,Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        }


        public string Show(string filename, string filter, string initialDirectory)
        {
            this.Filename = filename;
            this.Filter = filter;
            this.InitialDirectory = initialDirectory;
            return ReturnValue;
        }
    }
}
