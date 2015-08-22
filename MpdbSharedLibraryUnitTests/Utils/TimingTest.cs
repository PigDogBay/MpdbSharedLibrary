using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.Utils;
using System;
using System.Threading;

namespace MpdBaileyTechnology.Shared.UnitTests.Utils
{
    
    
    /// <summary>
    ///This is a test class for TimingTest and is intended
    ///to contain all TimingTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TimingTest
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
        ///A test for FormattedTime
        ///</summary>
        [TestMethod()]
        public void FormattedTimeTest()
        {
            TimeSpan ts = new TimeSpan(0,1,2,3,44); 
            string expected = "01:02:03.044";
            string actual;
            actual = Timing.FormattedTime(ts);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DoCpuIntensiveOperation
        ///</summary>
        [TestMethod()]
        public void DoCpuIntensiveOperationTest()
        {
            double seconds = 0.5F;
            bool expected = true;
            bool actual;
            actual = Timing.DoCpuIntensiveOperation(seconds);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for DoCpuIntensiveOperation
        ///</summary>
        [TestMethod()]
        public void DoCpuIntensiveOperationTest1()
        {
            double seconds = 0.5F;
            CancellationToken token = new CancellationToken();
            bool throwOnCancel = false;
            bool expected = true;
            bool actual;
            actual = Timing.DoCpuIntensiveOperation(seconds, token, throwOnCancel);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for DoCpuIntensiveOperation, cancel the operation
        ///</summary>
        [TestMethod()]
        public void DoCpuIntensiveOperationTest2()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            double seconds = 0.5F;
            CancellationToken token = cts.Token;
            bool throwOnCancel = false;
            bool actual;
            bool expected = false;
            cts.Cancel();
            actual = Timing.DoCpuIntensiveOperation(seconds, token, throwOnCancel);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for DoCpuIntensiveOperation, cancel the operation
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(OperationCanceledException))]
        public void DoCpuIntensiveOperationTest3()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            double seconds = 0.5F;
            CancellationToken token = cts.Token;
            bool throwOnCancel = true;
            bool actual;
            cts.Cancel();
            actual = Timing.DoCpuIntensiveOperation(seconds, token, throwOnCancel);
        }

        /// <summary>
        ///A test for DoIoIntensiveOperation
        ///</summary>
        [TestMethod()]
        public void DoIoIntensiveOperationTest1()
        {
            double seconds = 1F;
            CancellationToken token = new CancellationToken();
            bool throwOnCancel = false;
            bool expected = true;
            bool actual;
            actual = Timing.DoIoIntensiveOperation(seconds, token, throwOnCancel);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for DoIoIntensiveOperation, cancel the operation
        ///</summary>
        [TestMethod()]
        public void DoIoIntensiveOperationTest2()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            double seconds = 0.5F;
            CancellationToken token = cts.Token;
            bool throwOnCancel = false;
            bool actual;
            bool expected = false;
            cts.Cancel();
            actual = Timing.DoIoIntensiveOperation(seconds, token, throwOnCancel);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for DoIoIntensiveOperation, cancel the operation
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(OperationCanceledException))]
        public void DoIoIntensiveOperationTest3()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            double seconds = 0.5F;
            CancellationToken token = cts.Token;
            bool throwOnCancel = true;
            bool actual;
            cts.Cancel();
            actual = Timing.DoIoIntensiveOperation(seconds, token, throwOnCancel);
        }

        /// <summary>
        ///A test for TimedAction
        ///</summary>
        [TestMethod()]
        public void TimedActionTest()
        {
            Action test = () =>
            {
                Thread.Sleep(300);
            };
            string label = "TimedActionTest";
            Timing.TimedAction(test, label);
        }

        /// <summary>
        ///A test for TimedRun
        ///</summary>
        [TestMethod()]
        public void TimedRunTest()
        {
            Func<bool> test = () =>
            {
                Thread.Sleep(300);
                return true;
            };
            string label = "TimedRunTest";
            Timing.TimedRun(test, label);
        }
    }
}
