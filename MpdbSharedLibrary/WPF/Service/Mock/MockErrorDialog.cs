using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Service.Services;

namespace MpdBaileyTechnology.Shared.WPF.Service.Mock
{
    public class MockErrorDialog : IErrorDialog
    {
        public string Caption { get; set; }
        public string Description { get; set; }

        public void Show(string caption, string description)
        {
            this.Caption = caption;
            this.Description = description;
        }
    }
}
