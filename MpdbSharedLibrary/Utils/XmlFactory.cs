using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MpdBaileyTechnology.Shared.Utils
{
    /// <summary>
    /// Creates XElements from strings
    /// </summary>
    public static class XmlFactory
    {
        /// <summary>
        /// Creates XML representing the element path
        /// Each element will not contain any text
        /// </summary>
        /// <param name="path">Element path, eg InstrumentConstants/InstrumentName</param>
        /// <exception cref="System.ArgumentException">If path is empty</exception>
        /// <example cref="System.NullReferenceException">If path is null</example>
        /// <returns>XElement representing the path as XML</returns>
        public static XElement CreateFromElementPath(string path)
        {
            return CreateFromElementPath(path, null);
        }
        /// <summary>
        /// Creates XML representing the element path
        /// </summary>
        /// <param name="path">Element path, eg InstrumentConstants/InstrumentName</param>
        /// <param name="value">The inner most element's text, pass null for it to be empty</param>
        /// <exception cref="System.ArgumentException">If path is empty</exception>
        /// <example cref="System.NullReferenceException">If path is null</example>
        /// <returns>XElement representing the path as XML</returns>
        public static XElement CreateFromElementPath(string path, string value)
        {
            //The code is written using functional style programming
            //First unfold the string to create an IEnumerable<stirng>
            //Second transform the enumeration into type IEnumerable<Func<object,XElement>>
            //Third fold the enumeration into one function Func<object,XElement>, by nesting the functions in the enumeration
            //Finally call the aggregated function by passing in the value parameter
            //
            //For a string "one/two/three"
            //Effectively the following code will be created:
            //
            // return new XElement("one",
            //                    new XElement("two",
            //                        new XElement("three",value)));

            //The Unfold function will take a string s and return a new 'curried' function
            // Func(object inner){return new XElement(s,inner);}
            Func<string, Func<object, XElement>> Unfold = s => (inner) => new XElement(s, inner);
            return path.Split('/')
                           .Select(Unfold)
                           .Aggregate((agg, next) => inner => agg(next(inner)))
                            (value);
        }

    }
}
