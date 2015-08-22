using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using MpdBaileyTechnology.Shared.Utils;

namespace MpdBaileyTechnology.Shared.UnitTests.Utils
{
    
    
    /// <summary>
    ///This is a test class for IEnumerableExtensionMethodsTest and is intended
    ///to contain all IEnumerableExtensionMethodsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IEnumerableExtensionMethodsTest
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
        /// FindSingleItem, basic test
        /// </summary>
        [TestMethod()]
        public void FindSingleItemTest1()
        {
            List<string> characters = new List<string>() { "Hank", "Walt", "Jesse", "Mike", "Saul", "Skyler" };
            string actual =
                characters
                .FindSingleItem(s => s.StartsWith("W"), "Pollos");
            Assert.AreEqual("Walt", actual);
        }
        /// <summary>
        /// FindSingleItem, default value
        /// </summary>
        [TestMethod()]
        public void FindSingleItemTest2()
        {
            List<string> characters = new List<string>() { "Hank", "Walt", "Jesse", "Mike", "Saul", "Skyler" };
            string actual =
                characters
                .FindSingleItem(s => s.StartsWith("Z"), "Pollos");
            Assert.AreEqual("Pollos", actual);
        }
        /// <summary>
        /// FindSingleItem, default value
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindSingleItemTest3()
        {
            List<string> characters = new List<string>() { "Hank", "Walt", "Jesse", "Mike", "Saul", "Skyler" };
            string actual =
                characters
                .FindSingleItem(s => s.StartsWith("S"), "Pollos");
        }
        /// <summary>
        /// FindSingleItem, null source
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindSingleItemTest4()
        {
            List<string> characters = null;
            string actual =
                characters
                .FindSingleItem(s => s.StartsWith("H"), "Pollos");
        }
        /// <summary>
        /// FindFirstItem, basic test
        /// </summary>
        [TestMethod()]
        public void FindFirstItemTest1()
        {
            List<string> characters = new List<string>() { "Hank", "Walt", "Jesse", "Mike", "Saul", "Skyler" };
            string actual =
                characters
                .FindFirstItem(s => s.StartsWith("S"), "Pollos");
            Assert.AreEqual("Saul", actual);
        }
        /// <summary>
        /// FindFirstItem, default value
        /// </summary>
        [TestMethod()]
        public void FindFirstItemTest2()
        {
            List<string> characters = new List<string>() { "Hank", "Walt", "Jesse", "Mike", "Saul", "Skyler" };
            string actual =
                characters
                .FindFirstItem(s => s.StartsWith("Z"), "Pollos");
            Assert.AreEqual("Pollos", actual);
        }
        /// <summary>
        /// FindFirstItem, null source
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindFirstItemTest3()
        {
            List<string> characters = null;
            string actual =
                characters
                .FindFirstItem(s => s.StartsWith("S"), "Pollos");
        }

        [TestMethod()]
        public void ChunkTest1()
        {
            string test = "STARBUCK";
            var chunks = test.ToCharArray()
                            .Chunk(2);
            Assert.AreEqual(4, chunks.Count());
            Assert.AreEqual("BU", new String(chunks.ElementAt(2).ToArray()));
        }
        /// <summary>
        /// Left overs
        /// </summary>
        [TestMethod()]
        public void ChunkTest2()
        {
            string test = "GALACTICA";
            var chunks = test.ToCharArray()
                            .Chunk(2);
            Assert.AreEqual(5, chunks.Count());
            Assert.AreEqual("A", new String(chunks.ElementAt(4).ToArray()));
        }
    }
}
