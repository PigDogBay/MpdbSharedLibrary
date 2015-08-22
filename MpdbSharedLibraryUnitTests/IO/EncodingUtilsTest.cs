using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.IO;

namespace MpdBaileyTechnology.Shared.UnitTests.IO
{
    [TestClass]
    public class EncodingUtilsTest
    {
        [TestMethod]
        public void FromStringNameIntoByteRepresentationTest1()
        {
            string input = "ROBOCOP";
            string expected = "524F424F434F50";
            Assert.AreEqual(expected, EncodingUtils.FromStringNameIntoByteRepresentation(input));
        }
        /// <summary>
        /// Empty string
        /// </summary>
        [TestMethod]
        public void FromStringNameIntoByteRepresentationTest2()
        {
            string input = "";
            string expected = "";
            Assert.AreEqual(expected, EncodingUtils.FromStringNameIntoByteRepresentation(input));
        }
        /// <summary>
        /// Null string
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FromStringNameIntoByteRepresentationTest3()
        {
            string input = null;
            string expected = "";
            Assert.AreEqual(expected, EncodingUtils.FromStringNameIntoByteRepresentation(input));
        }

        /// <summary>
        ///A test for FromByteRepresentationIntoStringName
        ///</summary>
        [TestMethod()]
        public void FromByteRepresentationIntoStringNameTest1()
        {
            string input = "524F424F434F50";
            string expected = "ROBOCOP";
            Assert.AreEqual(expected, EncodingUtils.FromByteRepresentationIntoStringName(input));
        }
        /// <summary>
        ///Empty string
        ///</summary>
        [TestMethod()]
        public void FromByteRepresentationIntoStringNameTest2()
        {
            string input = "";
            string expected = "";
            Assert.AreEqual(expected, EncodingUtils.FromByteRepresentationIntoStringName(input));
        }
        /// <summary>
        ///Null string
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void FromByteRepresentationIntoStringNameTest3()
        {
            string input = null;
            string expected = "";
            Assert.AreEqual(expected, EncodingUtils.FromByteRepresentationIntoStringName(input));
        }
    }
}
