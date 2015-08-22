using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using MpdBaileyTechnology.Shared.WPF.Service.Services;

namespace MpdBaileyTechnology.Shared.WPF.Service.Implementation
{
    public class Win32OpenFileDialog : IOpenFileDialog
    {
        private OpenFileDialog _OpenFileDialog;
        public string InitialDirectory
        {
            get
            {
                return _OpenFileDialog.InitialDirectory;
            }
            set
            {
                _OpenFileDialog.InitialDirectory = value;
            }
        }

        public Win32OpenFileDialog()
        {
            _OpenFileDialog = new OpenFileDialog();
            _OpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _OpenFileDialog.CheckFileExists = true;
        }

        public string Show(string filename, string filter)
        {
            return FileDialogHelper.Show(_OpenFileDialog, filename, filter);
        }
        public string Show(string filename, string filter, string initialDirectory)
        {
            InitialDirectory = initialDirectory;
            return FileDialogHelper.Show(_OpenFileDialog, filename, filter);
        }

    }
}