using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using MpdBaileyTechnology.Shared.Utils;

namespace MpdBaileyTechnology.Shared.UnitTests.Utils
{
    public class NotifierImpl : Notifier
    {
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _BadProperty;
        public string BadProperty
        {
            get
            {
                return _BadProperty;
            }
            set
            {
                _BadProperty = value;
                OnPropertyChanged("Wrong Property Name");
            }
        }
        protected override bool ThrowOnInvalidPropertyName
        {
            get
            {
                return true;
            }
        }
    }
    /// <summary>
    /// Summary description for NotifierTest
    /// </summary>
    [TestClass]
    public class NotifierTest
    {
        private string _PropertyName;
        public NotifierTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Check that PropertyChangedEvents are raised correctly
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            NotifierImpl notifier = new NotifierImpl();
            notifier.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(notifier_PropertyChanged);
            _PropertyName = string.Empty;
            notifier.Name = "Holden Caulfield";
            Assert.AreEqual("Name", _PropertyName);
        }
#if DEBUG
        /// <summary>
        /// Check that illegal property names are dealt with
        /// This test will fail if running as a Release build
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (Exception),"Ignore this fail if running as Release build")]
        public void TestMethod2()
        {
            NotifierImpl notifier = new NotifierImpl();
            notifier.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(notifier_PropertyChanged);
            notifier.BadProperty = "bad";
        }
#endif
        void notifier_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _PropertyName = e.PropertyName;
        }
    }
}
