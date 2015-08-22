using MpdBaileyTechnology.Shared.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
    
    
    /// <summary>
    ///This is a test class for Crc16CcittTest and is intended
    ///to contain all Crc16CcittTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Crc16CcittTest
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
        ///A test for ComputeChecksum
        ///</summary>
        [TestMethod()]
        public void ComputeChecksumTest1()
        {
            Crc16Ccitt target = new Crc16Ccitt(InitialCrcValue.Zeros);
            byte[] bytes = new byte[] { 0, 0, 0, 0 };
            ushort expected = 0;
            ushort actual;
            actual = target.ComputeChecksum(bytes);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ComputeChecksumTest2()
        {
            Crc16Ccitt target = new Crc16Ccitt(InitialCrcValue.Zeros);
            byte[] bytes = new byte[] { 0xff, 0xff, 0xff, 0xff };
            ushort expected = 0x99CF;
            ushort actual;
            actual = target.ComputeChecksum(bytes);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ComputeChecksumTest3()
        {
            Crc16Ccitt target = new Crc16Ccitt(InitialCrcValue.Zeros);
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x42 };
            ushort expected = 0x6886;
            ushort actual;
            actual = target.ComputeChecksum(bytes);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ComputeChecksumTest4()
        {
            Crc16Ccitt target = new Crc16Ccitt(InitialCrcValue.Zeros);
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x01 };
            ushort expected = 0x1021;
            ushort actual;
            actual = target.ComputeChecksum(bytes);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ComputeChecksumTest5()
        {
            Crc16Ccitt target = new Crc16Ccitt(InitialCrcValue.Zeros);
            byte[] bytes = new byte[] { 0xCA, 0xFE, 0xBA, 0xBE };
            ushort expected = 0x948F;
            ushort actual;
            actual = target.ComputeChecksum(bytes);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Check data + CRC gives 0
        /// </summary>
        [TestMethod()]
        public void ComputeChecksumTest6()
        {
            Crc16Ccitt target = new Crc16Ccitt(InitialCrcValue.Zeros);
            byte[] bytes = new byte[] { 0xCA, 0xFE, 0xBA, 0xBE, 0x94, 0x8F };
            ushort expected = 0;
            ushort actual;
            actual = target.ComputeChecksum(bytes);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Large array
        /// </summary>
        [TestMethod()]
        public void ComputeChecksumTest7()
        {
            Crc16Ccitt target = new Crc16Ccitt(InitialCrcValue.Zeros);
            byte[] bytes = new byte[10000];
            for (int i = 0; i < 10000; i++)
            {
                bytes[i] = (byte)i;
            }
            ushort expected = 0x5885;
            ushort actual;
            actual = target.ComputeChecksum(bytes);
            Assert.AreEqual(expected, actual);
        }
    }
}