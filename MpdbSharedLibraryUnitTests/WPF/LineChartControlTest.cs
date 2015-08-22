using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.WPF.Model;
using MpdBaileyTechnology.Shared.WPF.UserControls;
using System;
using System.Collections.ObjectModel;

namespace MpdBaileyTechnology.Shared.UnitTests.WPF
{
    
    
    /// <summary>
    ///This is a test class for LineChartControlTest and is intended
    ///to contain all LineChartControlTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LineChartControlTest
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
        ///A test for LineChartControl Constructor
        ///</summary>
        [TestMethod()]
        public void LineChartControlConstructorTest()
        {
            LineChartControl target = new LineChartControl();
            Assert.AreEqual(0, target.Chart.Series.Count);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Series
        ///Empty collection
        ///</summary>
        [TestMethod()]
        public void LineChartControlSeriesTest1()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            target.Series = coll;
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Series
        ///null
        ///</summary>
        [TestMethod()]
        public void LineChartControlSeriesTest2()
        {
            LineChartControl target = new LineChartControl();
            target.Series = null;
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Series
        ///Check collections are added
        ///</summary>
        [TestMethod()]
        public void LineChartControlSeriesTest3()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            coll.Add(new ChartSeries("Gran Canaria"));
            coll.Add(new ChartSeries("Tenerife"));
            coll.Add(new ChartSeries("Lanzarote"));
            target.Series = coll;
            Assert.AreEqual(3, target.Chart.Series.Count);
            Assert.IsNotNull(target.Chart.Series["Gran Canaria"]);
            Assert.IsNotNull(target.Chart.Series["Tenerife"]);
            Assert.IsNotNull(target.Chart.Series["Lanzarote"]);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Series
        ///Check points are added
        ///</summary>
        [TestMethod()]
        public void LineChartControlSeriesTest4()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            ChartSeries cs = new ChartSeries("La Palma");
            coll.Add(cs);
            cs.AddPoint(0.644, 2);
            cs.AddPoint(2, 4);
            cs.AddPoint(5, 10);
            cs.AddPoint(20, 42);
            target.Series = coll;
            Assert.AreEqual(4, target.Chart.Series["La Palma"].Points.Count);
            Assert.AreEqual(0.644, target.Chart.Series["La Palma"].Points[0].XValue);
            Assert.AreEqual(42, target.Chart.Series["La Palma"].Points[3].YValues[0]);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Series
        ///Check points are not mixed
        ///</summary>
        [TestMethod()]
        public void LineChartControlSeriesTest5()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            ChartSeries cs = new ChartSeries("La Palma");
            cs.AddPoint(555, 888);
            coll.Add(cs);
            cs = new ChartSeries("Lanzarote");
            cs.AddPoint(18, 4);
            cs.AddPoint(19, 3);
            coll.Add(cs);
            target.Series = coll;
            Assert.AreEqual(1, target.Chart.Series["La Palma"].Points.Count);
            Assert.AreEqual(2, target.Chart.Series["Lanzarote"].Points.Count);
            Assert.AreEqual(555, target.Chart.Series["La Palma"].Points[0].XValue);
            Assert.AreEqual(18, target.Chart.Series["Lanzarote"].Points[0].XValue);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Binding
        ///Adding series
        ///</summary>
        [TestMethod()]
        public void LineChartControlBindingTest1()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            target.Series = coll;
            coll.Add(new ChartSeries("Gran Canaria"));
            Assert.AreEqual(1, target.Chart.Series.Count);
            Assert.IsNotNull(target.Chart.Series["Gran Canaria"]);
            coll.Add(new ChartSeries("Tenerife"));
            Assert.AreEqual(2, target.Chart.Series.Count);
            Assert.IsNotNull(target.Chart.Series["Tenerife"]);
            coll.Add(new ChartSeries("Lanzarote"));
            Assert.AreEqual(3, target.Chart.Series.Count);
            Assert.IsNotNull(target.Chart.Series["Lanzarote"]);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Binding
        ///Removing series
        ///</summary>
        [TestMethod()]
        public void LineChartControlBindingTest2()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            target.Series = coll;
            coll.Add(new ChartSeries("Gran Canaria"));
            coll.Add(new ChartSeries("Tenerife"));
            coll.Add(new ChartSeries("Lanzarote"));
            coll.RemoveAt(1);
            Assert.AreEqual(2, target.Chart.Series.Count);
            Assert.IsNotNull(target.Chart.Series["Gran Canaria"]);
            Assert.IsNotNull(target.Chart.Series["Lanzarote"]);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Binding
        ///Adding / Removing many series
        ///</summary>
        [TestMethod()]
        public void LineChartControlBindingTest3()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            target.Series = coll;
            for (int i = 0; i < 100; i++)
            {
                coll.Add(new ChartSeries(i.ToString()));
            }
            Assert.AreEqual(100, target.Chart.Series.Count);
            coll.Clear();
            Assert.AreEqual(0, target.Chart.Series.Count);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Binding
        ///Adding / Removing many series, this time remove only half
        ///</summary>
        [TestMethod()]
        public void LineChartControlBindingTest4()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            target.Series = coll;
            for (int i = 0; i < 100; i++)
            {
                coll.Add(new ChartSeries(i.ToString()));
            }
            Assert.AreEqual(100, target.Chart.Series.Count);
            for (int i = 0; i < 50; i++)
            {
                coll.RemoveAt(i);
            }
            Assert.AreEqual(50, target.Chart.Series.Count);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Binding
        ///Adding points
        ///</summary>
        [TestMethod()]
        public void LineChartControlBindingTest5()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            target.Series = coll;
            coll.Add(new ChartSeries("Gran Canaria"));
            coll.Add(new ChartSeries("Lanzarote"));
            coll.Add(new ChartSeries("Tenerife"));
            coll[1].AddPoint(5, 8);
            Assert.AreEqual(1, target.Chart.Series["Lanzarote"].Points.Count);
            coll[1].AddPoint(14, 19);
            Assert.AreEqual(2, target.Chart.Series["Lanzarote"].Points.Count);
            Assert.AreEqual(0, target.Chart.Series["Gran Canaria"].Points.Count);
            Assert.AreEqual(0, target.Chart.Series["Tenerife"].Points.Count);
            Assert.AreEqual(5, target.Chart.Series["Lanzarote"].Points[0].XValue);
            Assert.AreEqual(8, target.Chart.Series["Lanzarote"].Points[0].YValues[0]);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Binding
        ///Removing points
        ///</summary>
        [TestMethod()]
        public void LineChartControlBindingTest6()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            target.Series = coll;
            coll.Add(new ChartSeries("Gran Canaria"));
            coll.Add(new ChartSeries("Lanzarote"));
            coll.Add(new ChartSeries("Tenerife"));
            coll[1].AddPoint(5, 8);
            coll[1].AddPoint(14, 19);
            coll[1].AddPoint(25, 37);
            coll[1].Points.RemoveAt(0);
            Assert.AreEqual(2, target.Chart.Series["Lanzarote"].Points.Count);
            coll[1].Points.RemoveAt(0);
            Assert.AreEqual(1, target.Chart.Series["Lanzarote"].Points.Count);
            Assert.AreEqual(25, target.Chart.Series["Lanzarote"].Points[0].XValue);
            Assert.AreEqual(37, target.Chart.Series["Lanzarote"].Points[0].YValues[0]);
            target.Dispose();
        }
        /// <summary>
        ///A test for LineChartControl Binding
        ///Adding / Removing many points
        ///</summary>
        [TestMethod()]
        public void LineChartControlBindingTest7()
        {
            LineChartControl target = new LineChartControl();
            ObservableCollection<ChartSeries> coll = new ObservableCollection<ChartSeries>();
            target.Series = coll;
            ChartSeries cs = new ChartSeries("Benidorm");
            coll.Add(cs);
            for (int i = 0; i < 100; i++)
            {
                cs.AddPoint(i, i * 2);
            }
            Assert.AreEqual(100, target.Chart.Series["Benidorm"].Points.Count);
            cs.Points.Clear();
            Assert.AreEqual(0, target.Chart.Series["Benidorm"].Points.Count);
            target.Dispose();
        }
    }
}
