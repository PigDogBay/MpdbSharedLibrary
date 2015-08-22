using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Controls;
using System.IO;
using System.Windows;
using System.Printing;

namespace MpdBaileyTechnology.Shared.WPF.Printing
{
    public class FlowDocumentPrintManager
    {
        public static readonly int DPI = 96;
        private readonly FlowDocument _FlowDocument;

        public FlowDocumentPrintManager(FlowDocument flowDocument)
        {
            _FlowDocument = flowDocument;
        }

        public bool Print(string caption)
        {
            PrintDialog dlg = new PrintDialog();
            if (dlg.ShowDialog() == true)
            {
                PrintQueue printQueue = dlg.PrintQueue;
                DocumentPaginator paginator = GetPaginator(
                    printQueue.UserPrintTicket.PageMediaSize.Width.Value,
                    printQueue.UserPrintTicket.PageMediaSize.Height.Value);

                dlg.PrintDocument(paginator, caption);
                return true;
            }
            return false;
        }
        public DocumentPaginator GetPaginator(double pageWidth, double pageHeight)
        {
            TextRange originalRange = new TextRange(
                _FlowDocument.ContentStart,
                _FlowDocument.ContentEnd);
            MemoryStream memoryStream = new MemoryStream();
            originalRange.Save(memoryStream, DataFormats.Xaml);
            FlowDocument copy = new FlowDocument();
            TextRange copyRange = new TextRange(copy.ContentStart, copy.ContentEnd);
            copyRange.Load(memoryStream, DataFormats.Xaml);
            copy.PagePadding = _FlowDocument.PagePadding;
            copy.Background = _FlowDocument.Background;
            DocumentPaginator paginator = ((IDocumentPaginatorSource)copy).DocumentPaginator;
            return new PrintingPaginator(paginator, new Size(pageWidth, pageHeight), new Size(DPI, DPI));
        }
        public void PrintPreview()
        {
            PrintPreviewDialog dlg = new PrintPreviewDialog(this);
            dlg.ShowDialog();
        }
    }
}
