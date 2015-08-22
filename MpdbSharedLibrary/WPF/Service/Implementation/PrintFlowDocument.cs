using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using MpdBaileyTechnology.Shared.WPF.Service.Services;
using System.Windows.Markup;
using MpdBaileyTechnology.Shared.WPF.Printing;

namespace MpdBaileyTechnology.Shared.WPF.Service.Implementation
{
    public class PrintFlowDocument : IPrintFlowDocument
    {
        public void Print(string caption, string flowDocumentXaml)
        {
            FlowDocument flowDocument = XamlReader.Parse(flowDocumentXaml) as FlowDocument;
            FlowDocumentPrintManager manager = new FlowDocumentPrintManager(flowDocument);
            manager.Print(caption);
        }
        public void PrintPreview(string caption, string flowDocumentXaml)
        {
            FlowDocument flowDocument = XamlReader.Parse(flowDocumentXaml) as FlowDocument;
            FlowDocumentPrintManager manager = new FlowDocumentPrintManager(flowDocument);
            manager.PrintPreview();
        }
    }
}
