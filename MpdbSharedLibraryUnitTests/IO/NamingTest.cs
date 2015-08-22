
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.IO;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.IO
{


    /// <summary>
    ///This is a test class for NamingTest and is intended
    ///to contain all NamingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NamingTest
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
        ///A test for GenerateTimeStampedName
        ///</summary>
        [TestMethod()]
        public void GenerateTimeStampedNameTest()
        {
            string directory = @"C:\test";
            string prefix = "abc";
            string extension = ".csv";
            string actual = Naming.GenerateTimeStampedName(directory, prefix, extension);
            Assert.IsTrue(actual.StartsWith(@"C:\test\abc"));
            Assert.IsTrue(actual.EndsWith(".csv"));
        }
    }
}
