using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Service.Services;
using System.Windows;

namespace MpdBaileyTechnology.Shared.WPF.Service.Implementation
{
    public class Win32InformationDialog : IInformationDialog
    {
        public void Show(string caption, string description)
        {
            MessageBox.Show(description, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
