using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.WPF.Model;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.WPF
{
    
    
    /// <summary>
    ///This is a test class for RollingSeriesTest and is intended
    ///to contain all RollingSeriesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RollingSeriesTest
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

        ChartSeries CreateSeries(int count)
        {
            ChartSeries series = new ChartSeries("Test");
            for (int i = 0; i < count; i++)
            {
                series.AddPoint(i, i);
            }
            return series;
        }

        /// <summary>
        ///A test for RollingSeries Constructor,
        ///initialized with exisiting data more than max
        ///</summary>
        [TestMethod()]
        public void RollingSeriesConstructorTest1()
        {
            ChartSeries source = CreateSeries(100);
            int max = 10;
            int step = 4;
            RollingSeries target = new RollingSeries(source, max, step);
            Assert.AreEqual(6, target.Rolled.Points.Count);
            Assert.AreEqual(100 - 6, target.Rolled.Points[0].Key);
        }
        /// <summary>
        ///A test for RollingSeries Constructor, initialized with 0 elements
        ///</summary>
        [TestMethod()]
        public void RollingSeriesConstructorTest2()
        {
            ChartSeries source = CreateSeries(0);
            int max = 10;
            int step = 4;
            RollingSeries target = new RollingSeries(source, max, step);
            Assert.AreEqual(0, target.Rolled.Points.Count);
        }
        /// <summary>
        ///A test for RollingSeries Constructor, initialized with less than max elements
        ///</summary>
        [TestMethod()]
        public void RollingSeriesConstructorTest3()
        {
            ChartSeries source = CreateSeries(5);
            int max = 10;
            int step = 4;
            RollingSeries target = new RollingSeries(source, max, step);
            Assert.AreEqual(5, target.Rolled.Points.Count);
            Assert.AreEqual(0, target.Rolled.Points[0].Key);
            Assert.AreEqual(4, target.Rolled.Points[4].Key);
        }

        /// <summary>
        /// Test that rolled gets updated when new data is added
        ///</summary>
        [TestMethod()]
        public void AddLiveDataTest1()
        {
            ChartSeries source = CreateSeries(0);
            int max = 10;
            int step = 4;
            RollingSeries target = new RollingSeries(source, max, step);
            source.AddPoint(42, 9);
            Assert.AreEqual(1, target.Rolled.Points.Count);
            Assert.AreEqual(42, target.Rolled.Points[0].Key);
        }
        /// <summary>
        /// Test that rolled gets updated when multiple new data is added
        ///</summary>
        [TestMethod()]
        public void AddLiveDataTest2()
        {
            ChartSeries source = CreateSeries(0);
            int max = 10;
            int step = 4;
            RollingSeries target = new RollingSeries(source, max, step);
            source.Points.SuspendCollectionChangeNotification();
            for (int i = 0; i < 5; i++)
            {
                source.AddPoint(i, i);
            }
            source.Points.NotifyChanges();
            Assert.AreEqual(5, target.Rolled.Points.Count);
            Assert.AreEqual(2, target.Rolled.Points[2].Key);
        }
        /// <summary>
        /// Test adding live data causes a roll
        ///</summary>
        [TestMethod()]
        public void AddLiveDataTest3()
        {
            ChartSeries source = CreateSeries(0);
            int max = 10;
            int step = 4;
            RollingSeries target = new RollingSeries(source, max, step);
            source.Points.SuspendCollectionChangeNotification();
            for (int i = 0; i < max; i++)
            {
                source.AddPoint(i, i);
            }
            source.Points.NotifyChanges();
            Assert.AreEqual(6, target.Rolled.Points.Count);
            Assert.AreEqual(4, target.Rolled.Points[0].Key);
        }
        /// <summary>
        ///A test for RollingSeries Constructor, initialized with less than max elements
        ///</summary>
        [TestMethod()]
        public void EventsTest1()
        {
            ChartSeries source = CreateSeries(0);
            int max = 10;
            int step = 4;
            RollingSeries target = new RollingSeries(source, max, step);
            bool _IsCalled = false;
            target.Rolled.Points.CollectionChanged+=new System.Collections.Specialized.NotifyCollectionChangedEventHandler((object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)=>_IsCalled=true);
            source.AddPoint(42, 9);
            Assert.IsTrue(_IsCalled);
        }


    }
}
