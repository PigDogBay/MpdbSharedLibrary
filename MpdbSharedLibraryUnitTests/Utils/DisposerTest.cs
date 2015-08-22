using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.Utils;
using System;
using System.Diagnostics;

namespace MpdBaileyTechnology.Shared.UnitTests.Utils
{

    public class MockDisposer : Disposer
    {
        public bool ManagedCleanUpFlag { get; set; }
        public bool UnmanagedCleanUpFlag { get; set; }

        ~MockDisposer()
        {
            Debug.WriteLine("~MockDisposer");
            Dispose(false);
        }

        protected override void CleanUpManagedResources()
        {
            base.CleanUpManagedResources();
            ManagedCleanUpFlag = true;
            Debug.WriteLine("Clean Up Managed");
        }
        protected override void CleanUpUnmanagedResources()
        {
            base.CleanUpUnmanagedResources();
            UnmanagedCleanUpFlag = true;
            Debug.WriteLine("Clean Up Unmanaged");
        }
    }
    
    /// <summary>
    ///This is a test class for DisposerTest and is intended
    ///to contain all DisposerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DisposerTest
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


        internal virtual Disposer CreateDisposer()
        {
            // TODO: Instantiate an appropriate concrete class.
            Disposer target = null;
            return target;
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            MockDisposer target = new MockDisposer();
            target.Dispose();
            Assert.IsTrue(target.ManagedCleanUpFlag);
            Assert.IsTrue(target.UnmanagedCleanUpFlag);
        }
    }
}
