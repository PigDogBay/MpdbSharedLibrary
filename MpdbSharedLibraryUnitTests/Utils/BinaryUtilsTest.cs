using MpdBaileyTechnology.Shared.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.Utils
{
    
    
    /// <summary>
    ///This is a test class for BinaryUtilsTest and is intended
    ///to contain all BinaryUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BinaryUtilsTest
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
        ///A test for ReverseBytes
        ///</summary>
        [TestMethod()]
        public void ReverseBytesTest()
        {
            uint x = 0xCAFEBABE;
            uint expected = 0xBEBAFECA;
            uint actual;
            actual = BinaryUtils.ReverseBytes(x);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ReverseBytes
        ///</summary>
        [TestMethod()]
        public void ReverseBytesTest1()
        {
            unchecked
            {
                int x = (int)0xCAFEBABE;
                int expected = (int)0xBEBAFECA;
                int actual;
                actual = BinaryUtils.ReverseBytes(x);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
