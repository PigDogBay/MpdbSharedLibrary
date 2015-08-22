using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MpdBaileyTechnology.Shared.WPF.Printing
{
    /// <summary>
    /// Helper class for creating FlowDocument Xaml
    /// </summary>
    public static class FlowDocumentXamlFactory
    {
        public const string Paragraph = "Paragraph";
        public const string Section = "Section";
        public const string BlockUIContainer = "BlockUIContainer";
        public const string List = "List";
        public const string Table = "Table";
        public const string Table_Columns = "Table.Columns";
        public const string TableColumn = "TableColumn";
        public const string TableRow = "TableRow";
        public const string TableRowGroup = "TableRowGroup";
        public const string TableCell = "TableCell";
        public const string ListItem = "ListItem";

        public const string Inline = "Inline";
        public const string Run = "Run";
        public const string Span = "Span";
        public const string Hyperlink = "Hyperlink";
        public const string Bold = "Bold";
        public const string Italic = "Italic";
        public const string Underline = "Underline";
        public const string InlineUIContainer = "InlineUIContainer";
        public const string AnchoredBlock = "AnchoredBlock";
        public const string Floater = "Floater";
        public const string Figure = "Figure";
        public const string LineBreak = "LineBreak";


        private static XNamespace _Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
        /// <summary>
        /// Gets the default XAML namespace
        /// </summary>
        public static XNamespace Namespace { get { return _Namespace; } }

        /// <summary>
        /// Creates the root node of the flow document
        /// </summary>
        /// <param name="content">Flow documents contents</param>
        /// <returns>Flow document containing contents</returns>
        public static XElement CreateFlowDocument(params object[] content)
        {
            return new XElement(Namespace + "FlowDocument",
                        new XAttribute(XNamespace.Xmlns + "x", "http://schemas.microsoft.com/winfx/2006/xaml"),
                        content);
        }
        public static object[] CreateParagraphAttributes(String alignment="left")
        {
            return new object[] { new XAttribute("TextAlignment", alignment) };
        }        /// <summary>
        /// Create a paragraph block
        /// </summary>
        public static XElement CreateParagraph(params object[] content)
        {
            return new XElement(Namespace + Paragraph, content);
        }
        /// <summary>
        /// Create a section block
        /// </summary>
        public static XElement CreateSection(params object[] content)
        {
            return new XElement(Namespace + Section, content);
        }
        /// <summary>
        /// Create a bold element
        /// </summary>
        public static XElement CreateBold(params object[] content)
        {
            return new XElement(Namespace + Bold, content);
        }
        /// <summary>
        /// Create an underline element
        /// </summary>
        public static XElement CreateUnderline(params object[] content)
        {
            return new XElement(Namespace + Underline, content);
        }
        /// <summary>
        /// Create a bold, font size 18 title
        /// </summary>
        /// <param name="title"></param>
        public static XElement CreateTitle(string title)
        {
            return new XElement(Namespace + Paragraph, new XAttribute("FontSize", 18), new XAttribute("TextAlignment", "Center"),
                    new XElement(Namespace + Bold, title),
                    new XElement(Namespace + LineBreak),
                    new XElement(Namespace + LineBreak));
        }
        /// <summary>
        /// Converts end of lines (\r\n) in the text to LineBreaks
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <returns>XElement containing lins of test and LineBreak elements</returns>
        public static XElement CreateLineBreakText(this string text)
        {
            XElement paragraph = new XElement(Namespace + Paragraph);
            foreach (string s in text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                paragraph.Add(s, new XElement(Namespace + LineBreak));
            }
            return paragraph;
        }
        public static XElement CreateLineBreak()
        {
            return new XElement(Namespace + LineBreak);
        }
        public static object[] CreateTableAttributes(String cellSpacing, String borderThickness, String borderColor)
        {
            return new object[] { new XAttribute("CellSpacing", cellSpacing), new XAttribute("BorderBrush", borderColor), new XAttribute("BorderThickness", borderThickness) };
        }
        public static XElement CreateTable(params object[] content)
        {
            return new XElement(Namespace + Table, content);
        }
        public static XElement CreateTable_Columns(params object[] content)
        {
            return new XElement(Namespace + Table_Columns, content);
        }
        public static XElement CreateTableColumn(params object[] content)
        {
            return new XElement(Namespace + TableColumn, content);
        }
        public static XElement CreateTableColumn(String width)
        {
            return new XElement(Namespace + TableColumn, new XAttribute("Width",width));
        }
        public static XElement CreateTableRowGroup(params object[] content)
        {
            return new XElement(Namespace + TableRowGroup, content);
        }
        public static XElement CreateTableRow(params object[] content)
        {
            return new XElement(Namespace + TableRow, content);
        }
        public static object[] CreateCellAttributes(String padding, 
            String borderThickness, String borderColor, String colSpan="1", String rowSpan="1",
            String textAlignment = "Center", String background="White")
        {
            return new object[] { 
                new XAttribute("Padding", padding), 
                new XAttribute("BorderBrush", borderColor), 
                new XAttribute("BorderThickness", borderThickness), 
                new XAttribute("ColumnSpan", colSpan), 
                new XAttribute("RowSpan", rowSpan), 
                new XAttribute("TextAlignment", textAlignment), 
                new XAttribute("Background",background) };
        }
        public static XElement CreateTableCell(params object[] content)
        {
            return new XElement(Namespace + TableCell,  content);
        }

    }
}
