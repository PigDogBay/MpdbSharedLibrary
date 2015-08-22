/*
 * See Pack URIs in WPF
 * http://msdn.microsoft.com/en-us/library/aa970069.aspx
 * 
 * WPF Application Resource, Content, and Data Files
 * http://msdn.microsoft.com/en-us/library/aa970494.aspx
 * 
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Resources;
using System.Windows;
using System.IO;

namespace Bibby.WPF.Windows.Resources
{
    /// <summary>
    /// Reads application resources that use the 'Resource' build action
    /// </summary>
    public class ResourceReader
    {
        /// <summary>
        /// Reads a WPF resource as a string
        /// </summary>
        /// <param name="path">Relative Pack URI, eg: "/ReferencedAssembly;component/ResourceFile.xaml"</param>
        /// <returns>String resource</returns>
        public string ReadString(string path)
        {
            Uri uri = new Uri(path, UriKind.Relative);
            StreamResourceInfo sri = Application.GetResourceStream(uri);
            if (sri != null)
            {
                using (StreamReader reader = new StreamReader(sri.Stream))
                {
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }
}
