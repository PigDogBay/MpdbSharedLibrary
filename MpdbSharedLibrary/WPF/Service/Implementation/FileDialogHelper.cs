using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using MpdBaileyTechnology.Shared.WPF.Service.Services;

namespace MpdBaileyTechnology.Shared.WPF.Service.Implementation
{
    public static class FileDialogHelper 
    {
        public static string Show(FileDialog fileDialog, string filename, string filter)
        {
            try
            {
                if (!String.IsNullOrEmpty(filename))
                {
                    fileDialog.FileName = filename;
                }
                if (!String.IsNullOrEmpty(filter))
                {
                    fileDialog.Filter = filter;
                }
                bool? result = fileDialog.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    if (!string.IsNullOrEmpty(fileDialog.FileName)) return fileDialog.FileName;
                }
            }
            catch { }
            return string.Empty;
        }
    }
}