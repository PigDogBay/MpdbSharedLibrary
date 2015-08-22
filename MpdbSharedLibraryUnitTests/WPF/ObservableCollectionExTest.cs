using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.WPF.Collections;
using System;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Controls;

namespace MpdBaileyTechnology.Shared.UnitTests.WPF
{
    /// <summary>
    ///This is a test class for ObservableCollectionExTest and is intended
    ///to contain all ObservableCollectionExTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ObservableCollectionExTest
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
        
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            _Args = null;
        }
        
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            _Args = null;
        }
        
        #endregion

        System.Collections.Specialized.NotifyCollectionChangedEventArgs _Args;
        void target_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _Args = e;
        }
        /// <summary>
        /// Basic Tests
        /// </summary>
        [TestMethod()]
        public void ObsCollExConstructorTest()
        {
            ObservableCollectionEx<string> target = new ObservableCollectionEx<string>();
            target.Add("Jesse Pinkman");
            Assert.AreEqual(1, target.Count);
            target.Clear();
            Assert.AreEqual(0, target.Count);
        }
        /// <summary>
        /// Basic event tests on the same thread
        /// </summary>
        [TestMethod()]
        public void ObsCollExCollectionChangedTest()
        {
            ObservableCollectionEx<string> target = new ObservableCollectionEx<string>();
            target.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(target_CollectionChanged);
            target.Add("Walter White");
            Assert.AreEqual(NotifyCollectionChangedAction.Add,_Args.Action);
            Assert.AreEqual(1, _Args.NewItems.Count);
            Assert.AreEqual("Walter White", _Args.NewItems[0]);
            _Args = null;
        }
        /// <summary>
        /// Event tests on a using a worker thread
        /// </summary>
        [TestMethod()]
        public void ObsCollExWorkerThreadTest()
        {
            ObservableCollectionEx<string> target = new ObservableCollectionEx<string>();
            target.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(target_CollectionChanged);
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(new WaitCallback((x) =>
                {
                    target.Add("Crystal Meth");
                    resetEvent.Set();
                }));
            resetEvent.WaitOne(1000);
            Assert.AreEqual(NotifyCollectionChangedAction.Add, _Args.Action);
            Assert.AreEqual(1, _Args.NewItems.Count);
            Assert.AreEqual("Crystal Meth", _Args.NewItems[0]);
        }
        /// <summary>
        /// Event tests on a using a worker thread and WPF Listbox
        /// </summary>
        [TestMethod()]
        public void ObsCollExWPFTest()
        {
            ObservableCollectionEx<string> target = new ObservableCollectionEx<string>();
            target.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(target_CollectionChanged);
            ListBox listBox = new ListBox();
            listBox.Name = "testListBox";
            listBox.ItemsSource = target;

            ManualResetEvent resetEvent = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(new WaitCallback((x) =>
            {
                target.Add("Hank Schrader");
                resetEvent.Set();
            }));
            resetEvent.WaitOne(1000);

            Assert.AreEqual(1, listBox.Items.Count);
            Assert.AreEqual("Hank Schrader", listBox.Items[0] as string);

            Assert.AreEqual(NotifyCollectionChangedAction.Add, _Args.Action);
            Assert.AreEqual(1, _Args.NewItems.Count);
            Assert.AreEqual("Hank Schrader", _Args.NewItems[0]);
        }

    }
}
