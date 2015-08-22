using MpdBaileyTechnology.Shared.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.Utils
{
    
    
    /// <summary>
    ///This is a test class for DateUtilsTest and is intended
    ///to contain all DateUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DateUtilsTest
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
        ///A test for DaysSinceEpoch
        ///NB Excel gives 41200 as the days since the epoch
        ///but excel has a leap year bug, as it treat 1900 as a leap year
        ///so gives an extra day
        ///</summary>
        [TestMethod()]
        public void DaysSinceEpochTest()
        {
            DateTime time = new DateTime(2012, 10, 19);
            DateTime epoch = DateUtils.NTP_EPOCH;
            int expected = 41199;
            int actual;
            actual = DateUtils.DaysSinceEpoch(time, epoch);
            Assert.AreEqual(expected, actual);
        }
    }
}
