using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.Threading;
using System;
using System.Threading;

namespace MpdBaileyTechnology.Shared.UnitTests.Threading
{
    
    
    /// <summary>
    ///This is a test class for PlayControlTest and is intended
    ///to contain all PlayControlTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PlayControlTest
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


        int count = 0;
        Exception _FailedException = null;
        void target_Failed(object sender, PlayControlFailedEventArgs e)
        {
            _FailedException = e.Exception;
        }

        private void TestAction()
        {
            count++;
            Thread.Sleep(50);
        }
        /// <summary>
        /// simulates an error in the call back
        /// </summary>
        private void ErrorAction()
        {
            count++;
            if (count > 5)
            {
                throw new System.IO.IOException();
            }
        }
        /// <summary>
        /// Checks that the count is still not increasing
        /// </summary>
        private void CheckCountNotIncreasing()
        {
            int countCheck = count;
            Thread.Sleep(200);
            Assert.AreEqual<int>(countCheck, count);
        }
        /// <summary>
        ///A test for Start, null action
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void StartTest1()
        {
            PlayControl target = new PlayControl();
            target.Start(null);
        }
        /// <summary>
        ///A test for Start, simple case
        ///</summary>
        [TestMethod()]
        public void StartTest2()
        {
            PlayControl target = new PlayControl();
            count = 0;
            target.Start(() => TestAction());
            Thread.Sleep(200);
            Assert.AreEqual(PlayControl.States.Playing, target.State);
            Assert.IsTrue(count > 0);
            target.Stop();
        }
        /// <summary>
        ///A test for Start, set state to Stopped before starting
        ///expect state to be changed to Playing
        ///</summary>
        [TestMethod()]
        public void StartTest3()
        {
            PlayControl target = new PlayControl();
            count = 0;
            target.Stop();
            target.Start(() => TestAction());
            Thread.Sleep(200);
            Assert.AreEqual(PlayControl.States.Playing, target.State);
            target.Stop();
        }

        /// <summary>
        ///A test for Stop
        ///</summary>
        [TestMethod()]
        public void StopTest()
        {
            PlayControl target = new PlayControl();
            count = 0;
            target.Start(() => TestAction());
            Thread.Sleep(200);
            target.Stop();
            //allow some time for the thread to change state
            Thread.Sleep(200);
            Assert.IsTrue(count > 0);
            Assert.AreEqual(PlayControl.States.Stopped, target.State);
            CheckCountNotIncreasing();
        }

        /// <summary>
        ///A test for Pause
        ///</summary>
        [TestMethod()]
        public void PauseTest()
        {
#if DEBUG
            PlayControl target = new PlayControl();
            count = 0;
            target.Start(() => TestAction());
            Thread.Sleep(1000);
            target.Pause();
            //allow some time for the thread to change state
            Thread.Sleep(1000);
            Assert.IsTrue(count > 0);
            Assert.AreEqual(PlayControl.States.Paused, target.State);
            CheckCountNotIncreasing();
#endif
        }

        /// <summary>
        ///A test for Play
        ///</summary>
        [TestMethod()]
        public void PlayTest()
        {
#if DEBUG
            PlayControl target = new PlayControl();
            count = 0;
            target.Start(() => TestAction());
            Thread.Sleep(200);
            target.Pause();
            //allow some time for the thread to change state
            Thread.Sleep(200);
            int countCheck = count;
            target.Play();
            //allow some time for the thread to change state
            Thread.Sleep(300);
            Assert.AreEqual(PlayControl.States.Playing, target.State);
            //check that count is increasing
            Assert.IsTrue(count > countCheck);
            target.Stop();
#endif
        }
        /// <summary>
        ///A test for Error condition, the action will throw an IOException
        ///</summary>
        [TestMethod()]
        public void ErrorTest()
        {
            PlayControl target = new PlayControl();
            target.Failed += new EventHandler<PlayControlFailedEventArgs>(target_Failed);
            _FailedException = null;
            count = 0;
            target.Start(() => ErrorAction());
            Thread.Sleep(200);
            Assert.AreEqual(PlayControl.States.Error, target.State);
            Assert.IsTrue(_FailedException is System.IO.IOException);
        }
    }
}
