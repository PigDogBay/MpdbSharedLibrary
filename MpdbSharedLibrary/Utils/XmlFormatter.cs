using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace MpdBaileyTechnology.Shared.Utils
{
    /// <summary>
    /// Formats XML from unformatted XML
    /// </summary>
    public class XmlFormatter
    {
        /// <summary>
        /// Gets or sets which character to use for indentation, default is tab
        /// </summary>
        public char IndentChar { get; set; }
        /// <summary>
        /// Gets or sets the number of indent characters to use for each indentation level,
        /// the default is 1.
        /// </summary>
        public int Indentation { get; set; }

        public XmlFormatter()
        {
            this.IndentChar = '\t';
            Indentation = 1;
        }
        /// <summary>
        /// Formats an XML string using indents and newlines
        /// 
        /// Based on code from:
        /// http://www.codeproject.com/KB/cpp/FormattingXML.aspx
        /// </summary>
        /// <exception cref="System.ArgumentNullException">unformattedXml is null</exception>
        /// <param name="unformattedXml">Unformatted xml string.</param>
        /// <returns>Formatted xml string</returns>
        public string IndentXml(string unformattedXml)
        {
            //return immediately if empty string
            if (string.Empty.Equals(unformattedXml))
            {
                return string.Empty;
            }
            //load unformatted xml into a dom
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(unformattedXml);

            //will hold formatted xml
            StringBuilder sb = new StringBuilder();

            //pumps the formatted xml into the StringBuilder above
            StringWriter sw = new StringWriter(sb);

            //does the formatting
            XmlTextWriter xtw = null;

            try
            {
                //point the xtw at the StringWriter
                xtw = new XmlTextWriter(sw);

                //we want the output formatted
                xtw.Formatting = Formatting.Indented;
                xtw.Indentation = this.Indentation;
                xtw.IndentChar = this.IndentChar;
                //get the dom to dump its contents into the xtw 
                xd.WriteTo(xtw);
            }
            finally
            {
                //clean up even if error
                if (xtw != null)
                    xtw.Close();
            }

            //return the formatted xml
            return sb.ToString();
        }

    }
}
