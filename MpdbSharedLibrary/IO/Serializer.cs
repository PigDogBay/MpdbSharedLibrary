using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace MpdBaileyTechnology.Shared.IO
{
    /// <summary>
    /// Reads/Writes objects to an XML file using XmlSerializer
    /// 
    /// Notes:
    /// If you have class contains an List/Collection/Array you will usually allow access via Property that returns an IEnumerable
    /// In this case use a helper class that exposes the collection as such:
    ///     public List{string}{get;}
    ///
    /// 
    /// This class uses the optimized versions of XmlSerializer constructor, 
    /// which cache the generated assemblies.
    /// 
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Create an object from the XML file
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="filename">Filename of the XML</param>
        /// <returns>Object</returns>
        public static T Read<T>(String filename)
        {
            if (null == filename) { throw new ArgumentNullException("Filename is null"); }
            using (TextReader txtRdr = new StreamReader(filename))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                return (T)xmlSer.Deserialize(txtRdr);
            }
        }
        /// <summary>
        /// Wrie object to a XML file
        /// </summary>
        /// <param name="filename">Filename of the XML</param>
        /// <param name="serObj">Object to be serialized</param>
        public static void Write(String filename, object serObj)
        {
            if (null == filename) { throw new ArgumentNullException("Filename is null"); }
            if (null == serObj) { throw new ArgumentNullException("Serialize object is null"); }
            using (TextWriter txtWrt = new StreamWriter(filename))
            {
                XmlSerializer xmlSer = new XmlSerializer(serObj.GetType());
                xmlSer.Serialize(txtWrt, serObj);
            }
        }

    }
}
