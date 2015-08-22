using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace MpdBaileyTechnology.Shared.WPF.Printing
{
    public class PrintingPaginator : DocumentPaginator
    {
        private readonly DocumentPaginator _originalPaginator;
        private readonly Size _pageSize;
        private readonly Size _pageMargin;

        public PrintingPaginator(DocumentPaginator originalPaginator, Size pageSize, Size pageMargin)
        {
            this._originalPaginator = originalPaginator;
            this._pageSize = pageSize;
            this._pageMargin = pageMargin;

            _originalPaginator.PageSize = new Size(
                _pageSize.Width - _pageMargin.Width * 2,
                _pageSize.Height - _pageMargin.Height * 2);
            _originalPaginator.ComputePageCount();

        }

        public override bool IsPageCountValid
        {
            get { return _originalPaginator.IsPageCountValid; }
        }
        public override int PageCount
        {
            get { return _originalPaginator.PageCount; }
        }
        public override Size PageSize
        {
            get
            {
                return _originalPaginator.PageSize;
            }
            set
            {
                _originalPaginator.PageSize = value;
            }
        }
        public override IDocumentPaginatorSource Source
        {
            get { return _originalPaginator.Source; }
        }
        public override DocumentPage GetPage(int pageNumber)
        {
            DocumentPage originalPage = _originalPaginator.GetPage(pageNumber);
            ContainerVisual fixedPage = new ContainerVisual();
            fixedPage.Children.Add(originalPage.Visual);
            fixedPage.Transform = new TranslateTransform(_pageMargin.Width, _pageMargin.Height);
            Rect bleedBox = AdjustForMargins(originalPage.BleedBox);
            Rect contentBox = AdjustForMargins(originalPage.ContentBox);
            return new DocumentPage(fixedPage, _pageSize, bleedBox, contentBox);
        }
        private Rect AdjustForMargins(Rect rect)
        {
            if (!rect.IsEmpty)
            {
                rect = new Rect(rect.Left + _pageMargin.Width,
                    rect.Top + _pageMargin.Height,
                    rect.Width,
                    rect.Height);
            }
            return rect;

        }
    }
}
