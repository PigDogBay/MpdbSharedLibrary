﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MpdBaileyTechnology.Shared.WPF.Printing
{
    /// <summary>
    /// Interaction logic for PrintPreviewDialog.xaml
    /// </summary>
    public partial class PrintPreviewDialog : Window
    {
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register(
            "CurrentPage", typeof(int), typeof(PrintPreviewDialog));
        private readonly FlowDocumentPrintManager _manager;
        private int _pageIndex;

        public PrintPreviewDialog(FlowDocumentPrintManager printManager)
        {
            InitializeComponent();
            _manager = printManager;
            DataContext = this;
            ChangePage(0);
        }
        public int CurrentPage
        {
            get
            {
                return (int)GetValue(CurrentPageProperty);
            }
            set
            {
                SetValue(CurrentPageProperty, value);
            }
        }

        private void PreviousClick(object sender, RoutedEventArgs e)
        {
            ChangePage(_pageIndex - 1);
        }
        private void NextClick(object sender, RoutedEventArgs e)
        {
            ChangePage(_pageIndex + 1);
        }
        private void ChangePage(int requestedPage)
        {
            pageViewer.DocumentPaginator = _manager.GetPaginator(8.5 * FlowDocumentPrintManager.DPI, 11 * FlowDocumentPrintManager.DPI);
            if (requestedPage < 0)
            {
                _pageIndex = 0;
            }
            else if (requestedPage >= pageViewer.DocumentPaginator.PageCount)
            {
                _pageIndex = pageViewer.DocumentPaginator.PageCount - 1;
            }
            else
            {
                _pageIndex = requestedPage;
            }
            pageViewer.PageNumber = _pageIndex;
            CurrentPage = _pageIndex + 1;
        }
    }
}
