using MpdBaileyTechnology.Shared.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.Maths
{
    
    
    /// <summary>
    ///This is a test class for RandomNumberTest and is intended
    ///to contain all RandomNumberTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RandomNumberTest
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
        ///A test for MakeRandomSeed, check it returns a non-zero value
        ///</summary>
        [TestMethod()]
        public void MakeRandomSeedTest()
        {
            int actual;
            actual = RandomNumber.MakeRandomSeed();
            Assert.IsTrue(actual != 0);
        }
        /// <summary>
        ///A test for MakeRandomSeed, check it returns different values
        ///</summary>
        [TestMethod()]
        public void MakeRandomSeedTest1()
        {
            int actual, previous = 0;
            for (int i = 0; i < 100; i++)
            {
                actual = RandomNumber.MakeRandomSeed();
                Assert.AreNotEqual(actual, previous);
                previous = actual;
            }
        }
    }
}
