using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.Utils;
using System;
using System.Collections.Generic;

namespace MpdBaileyTechnology.Shared.UnitTests.Utils
{


    /// <summary>
    ///This is a test class for IListExtensionsTest and is intended
    ///to contain all IListExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IListExtensionsTest
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
        ///A test for Shuffle
        ///</summary>
        public void ShuffleTestHelper<T>()
        {
            IList<T> list = null; // TODO: Initialize to an appropriate value
            IListExtensions.Shuffle<T>(list);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void ShuffleTest()
        {
            string[] alphabet = { "a", "b", "c", "d", "e", "f" };
            alphabet.Shuffle();
            Assert.AreEqual(6, alphabet.Length);
            Assert.IsFalse(
                alphabet[0].Equals("a") &&
                alphabet[1].Equals("b") &&
                alphabet[2].Equals("c") &&
                alphabet[3].Equals("d") &&
                alphabet[4].Equals("e") &&
                alphabet[5].Equals("f"));
        }
    }
}
