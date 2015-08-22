using MpdBaileyTechnology.Shared.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
    
    
    /// <summary>
    ///This is a test class for ChecksumTest and is intended
    ///to contain all ChecksumTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ChecksumTest
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
        ///A test for ByteAddition
        ///</summary>
        [TestMethod()]
        public void ByteAdditionTest()
        {
            char[] data = { 'Z', 'X', ' ', 'S', 'p', 'e', 'c', 't', 'r', 'u', 'm' };
            int offset = 0;
            int len = data.Length;
            int expected = 0xDB;
            int actual;
            actual = Checksum.ByteAddition(data, offset, len);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for ByteAddition, one char
        ///</summary>
        [TestMethod()]
        public void ByteAdditionTest2()
        {
            char[] data = { 'Z', 'X', ' ', 'S', 'p', 'e', 'c', 't', 'r', 'u', 'm' };
            int offset = 1;
            int len = 1;
            int expected = 0xA8;
            int actual;
            actual = Checksum.ByteAddition(data, offset, len);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for ByteAddition, no chars
        ///</summary>
        [TestMethod()]
        public void ByteAdditionTest3()
        {
            char[] data = { 'Z', 'X', ' ', 'S', 'p', 'e', 'c', 't', 'r', 'u', 'm' };
            int offset = 1;
            int len = 0;
            int expected = 0;
            int actual;
            actual = Checksum.ByteAddition(data, offset, len);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for ByteAddition, bad array offset / length
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof (IndexOutOfRangeException))]
        public void ByteAdditionTest4()
        {
            char[] data = { 'Z', 'X', ' ', 'S', 'p', 'e', 'c', 't', 'r', 'u', 'm' };
            int offset = 1;
            int len = data.Length;
            Checksum.ByteAddition(data, offset, len);
        }

        /// <summary>
        ///A test for ByteAddition
        ///</summary>
        [TestMethod()]
        public void ByteAdditionTest1()
        {
            string data = "ZX Spectrum";
            int expected = 0xDB;
            int actual;
            actual = Checksum.ByteAddition(data);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for ByteAddition
        /// TC-5000 message, EB is the checksum
        /// *SEG09C400000E100000000000FFEB
        ///</summary>
        [TestMethod()]
        public void SimpleChecksumTest1()
        {
            string data = "*SEG09C400000E100000000000FF";
            int expected = 0xEB;
            int actual;
            actual = Checksum.SimpleChecksum(data);
            Assert.AreEqual(expected, actual);
        }
    }
}
