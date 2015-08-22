using MpdBaileyTechnology.Shared.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
    
    
    /// <summary>
    ///This is a test class for RollingAverageTest and is intended
    ///to contain all RollingAverageTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RollingAverageTest
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
        ///A test for GetAverage
        ///</summary>
        [TestMethod()]
        public void GetAverageTest1()
        {
            RollingAverage target = new RollingAverage(); 
            double expected = 2F;
            double actual;
            target.Add(1);
            target.Add(2);
            target.Add(3);
            actual = target.GetAverage();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for GetAverage, push out test
        ///</summary>
        [TestMethod()]
        public void GetAverageTest2()
        {
            RollingAverage target = new RollingAverage(3);
            double expected = 3F;
            double actual;
            target.Add(1);
            target.Add(2);
            target.Add(3);
            target.Add(4);
            actual = target.GetAverage();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for GetAverage, thrash test
        ///</summary>
        [TestMethod()]
        public void GetAverageTest3()
        {
            RollingAverage target = new RollingAverage(16);
            double expected = 100F;
            double actual;
            for (int i = 0; i < 10000; i++)
            {
                target.Add(100F);
            }
            actual = target.GetAverage();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        ///A test for GetAverage, no items expect 0
        ///</summary>
        [TestMethod()]
        public void GetAverageTest4()
        {
            RollingAverage target = new RollingAverage();
            double expected = 0F;
            double actual;
            actual = target.GetAverage();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RollingAverage Constructor, negative capacity
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void RollingAverageConstructorTest()
        {
            int capacity = -1; 
            RollingAverage target = new RollingAverage(capacity);
        }
    }
}
