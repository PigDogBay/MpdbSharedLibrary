using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;
using System.Diagnostics;
using MpdBaileyTechnology.Shared.Utils;

namespace MpdBaileyTechnology.Shared.UnitTests.Utils
{
    
    
    /// <summary>
    ///This is a test class for XmlFactoryTest and is intended
    ///to contain all XmlFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XmlFactoryTest
    {
        private const string ElementPath = "TemperatureConstants/CoverThermConstants/TemperatureCorrections/ReadingAt10";
        private const string Xml =
                    "<TemperatureConstants>" +
                        "<CoverThermConstants>" +
                            "<TemperatureCorrections>" +
                                "<ReadingAt10>{0}</ReadingAt10>" +
                            "</TemperatureCorrections>" +
                        "</CoverThermConstants>" +
                    "</TemperatureConstants>";


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for CreateXmlFromElementPath, normal case
        ///</summary>
        [TestMethod()]
        public void CreateFromElementPathTest1()
        {
            string path = ElementPath;
            XElement expected = new XElement("TemperatureConstants",
                                            new XElement("CoverThermConstants",
                                                new XElement("TemperatureCorrections",
                                                    new XElement("ReadingAt10"))));
            XElement actual = XmlFactory.CreateFromElementPath(path);
            Debug.WriteLine(actual.ToString());
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        /// <summary>
        ///A test for CreateXmlFromElementPath, one element case
        ///</summary>
        [TestMethod()]
        public void CreateFromElementPathTest2()
        {
            string path = "TemperatureConstants";
            XElement expected = new XElement("TemperatureConstants");
            XElement actual = XmlFactory.CreateFromElementPath(path);
            Debug.WriteLine(actual.ToString());
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        /// <summary>
        ///A test for CreateXmlFromElementPath, empty string
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void CreateFromElementPathTest3()
        {
            string path = "";
            XElement actual = XmlFactory.CreateFromElementPath(path);
        }
        /// <summary>
        ///A test for CreateXmlFromElementPath,null string
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void CreateFromElementPathTest4()
        {
            string path = null;
            XElement actual = XmlFactory.CreateFromElementPath(path);
        }
    }
}
