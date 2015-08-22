using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using MpdBaileyTechnology.Shared.WPF.Service.Services;
using System.Windows.Forms;

namespace MpdBaileyTechnology.Shared.WPF.Service.Implementation
{
    public class Win32FolderBrowserDialog : IFolderBrowserDialog
    {
        FolderBrowserDialog dialog;
        public Win32FolderBrowserDialog()
        {
            dialog = new FolderBrowserDialog();
        }

        public bool Show(ref string path)
        {
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.SelectedPath;
                return true;
            }
            return false;
        }
    }
}
