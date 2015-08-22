using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.Utils;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.Utils
{
    
    
    /// <summary>
    ///This is a test class for FormatterTest and is intended
    ///to contain all FormatterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FormatterTest
    {


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


        private const string _RawXml =
            "<Book><Author>George Orwell</Author><Title>1984</Title></Book>";
        private const string _IndentedXml =
            "<Book>\r\n\t<Author>George Orwell</Author>\r\n\t<Title>1984</Title>\r\n</Book>";

        /// <summary>
        ///A test for IndentXml, simple use case
        ///</summary>
        [TestMethod()]
        public void IndentXmlTest1()
        {
            XmlFormatter formatter = new XmlFormatter();
            string expected = _IndentedXml;
            string actual = formatter.IndentXml(_RawXml);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for IndentXml, null string
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndentXmlTest2()
        {
            XmlFormatter formatter = new XmlFormatter();
            string actual = formatter.IndentXml(null);
        }
        /// <summary>
        ///A test for IndentXml, empty string
        ///</summary>
        [TestMethod()]
        public void IndentXmlTest3()
        {
            XmlFormatter formatter = new XmlFormatter();
            string expected = string.Empty;
            string actual = formatter.IndentXml(string.Empty);
            Assert.AreEqual(expected, actual);
        }
    }
}
