using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpdBaileyTechnology.Shared.WPF.Service.Services;

namespace MpdBaileyTechnology.Shared.WPF.Service.Mock
{
    public class MockPrintFlowDocument : IPrintFlowDocument
    {
        public string Caption { get; set; }
        public string Xaml { get; set; }
        public void Print(string caption, string flowDocumentXaml)
        {
            this.Caption = caption;
            this.Xaml = flowDocumentXaml;
        }

        public void PrintPreview(string caption, string flowDocumentXaml)
        {
            this.Caption = caption;
            this.Xaml = flowDocumentXaml;
        }
    }
}
