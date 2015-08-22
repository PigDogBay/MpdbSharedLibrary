using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.WPF.Windows.Resources;
using System;
using System.Diagnostics;

namespace MpdBaileyTechnology.Shared.UnitTests.WPF
{
    
    
    /// <summary>
    ///This is a test class for ResourceReaderTest and is intended
    ///to contain all ResourceReaderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ResourceReaderTest
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


        /// <summary>
        ///A test for ReadString
        ///</summary>
        [TestMethod()]
        public void ReadStringTest()
        {
            ResourceReader target = new ResourceReader();
            string path = "/MpdbSharedLibraryUnitTests;component/Resources/BlockOfText.txt";
            string actual = target.ReadString(path).Trim();
            Debug.WriteLine(actual);
            Assert.IsTrue(actual.StartsWith("It was a bright cold day in April"));
            Assert.IsTrue(actual.EndsWith("BIG BROTHER IS WATCHING YOU, the caption beneath it ran."));
        }
    }
}
