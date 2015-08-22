using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.IO;
using MpdBaileyTechnology.Shared.Threading;
using MpdBaileyTechnology.Shared.Utils;

namespace MpdBaileyTechnology.Shared.UnitTests.Threading
{
    
    
    /// <summary>
    ///This is a test class for DataStreamTest and is intended
    ///to contain all DataStreamTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataStreamTest
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

        private int _DataReceivedValue=0;

        [TestMethod()]
        public void ReceiveTest1()
        {
            DataStream<int> dataStream = new DataStream<int>(()=>42,100);
            dataStream.DataReceived += new EventHandler<EventArg<int>>(dataStream_DataReceived);
            dataStream.Start();
            int count = 0;
            while (_DataReceivedValue==0 && count++<10)
            {
                Thread.Sleep(100);
            }
            Assert.AreEqual(42, _DataReceivedValue);
        }

        void dataStream_DataReceived(object sender, EventArg<int> e)
        {
            _DataReceivedValue = e.Data;
        }

        Exception _ExceptionReceived = null;
        [TestMethod()]
        public void ErrorOccurredTest1()
        {
            DataStream<int> dataStream = new DataStream<int>(() => { throw new IOException(); }, 100);
            dataStream.ErrorOccurred += new EventHandler<EventArg<Exception>>(dataStream_ErrorOccurred);
            dataStream.Start();
            int count = 0;
            while (_ExceptionReceived == null && count++ < 10)
            {
                Thread.Sleep(100);
            }
            Assert.AreEqual(typeof(IOException), _ExceptionReceived.GetType());
        }

        void dataStream_ErrorOccurred(object sender, EventArg<Exception> e)
        {
            _ExceptionReceived = e.Data;
        }


    }
}
