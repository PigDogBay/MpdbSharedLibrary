using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using MpdBaileyTechnology.Shared.WPF.Service.Services;

namespace MpdBaileyTechnology.Shared.WPF.Service.Implementation
{
    public class Win32SaveFileDialog : ISaveFileDialog
    {
        private SaveFileDialog _SaveFileDialog;
        public string InitialDirectory
        {
            get { return _SaveFileDialog.InitialDirectory; }
            set { _SaveFileDialog.InitialDirectory = value; }
        }
        public Win32SaveFileDialog()
        {
            _SaveFileDialog = new SaveFileDialog();
            _SaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public string Show(string filename, string filter)
        {
            return FileDialogHelper.Show(_SaveFileDialog, filename, filter);
        }


        public string Show(string filename, string filter, string initialDirectory)
        {
            InitialDirectory = initialDirectory;
            return FileDialogHelper.Show(_SaveFileDialog, filename, filter);
        }
    }
}
