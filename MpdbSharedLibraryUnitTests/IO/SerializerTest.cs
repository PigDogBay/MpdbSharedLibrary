
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using MpdBaileyTechnology.Shared.IO;

namespace MpdBaileyTechnology.Shared.UnitTests.IO
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int FavouriteNumber { get; set; }
    }

    public class Customers
    {
        private List<Person> _People;
        public List<Person> People { get { return _People; } }
        public string Description { get; set; }
        public Customers()
        {
            _People = new List<Person>();

        }
    }
    
    /// <summary>
    ///This is a test class for SerializerTest and is intended
    ///to contain all SerializerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SerializerTest
    {

        const string _Filename = "SerializerTestFile.xml";

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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            if (File.Exists(_Filename))
            {
                File.Delete(_Filename);
            }
        }
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
        ///A test for Read and Write
        ///</summary>
        [TestMethod()]
        public void ReadWriteTest()
        {
            Customers customers = new Customers();
            customers.People.Add(new Person() { Name = "Joffrey", DOB = new DateTime(1977, 3, 17), FavouriteNumber = 9 });
            customers.People.Add(new Person() { Name = "Arya", DOB = new DateTime(1978, 7, 19), FavouriteNumber = 1 });
            customers.People.Add(new Person() { Name = "Hot Pie", DOB = new DateTime(1984, 2, 12), FavouriteNumber = 42 });
            customers.Description = "Thrones";
            Serializer.Write(_Filename, customers);

            Customers readback = Serializer.Read<Customers>(_Filename);
            Assert.AreEqual(3, readback.People.Count());
            Assert.AreEqual("Hot Pie", readback.People.Last().Name);
            Assert.AreEqual("Thrones", readback.Description);
        }
        /// <summary>
        /// Read, Null filename
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadTest1()
        {
            Serializer.Read<string>(null);
        }
        /// <summary>
        /// Read, bad filename
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadTest2()
        {
            Serializer.Read<string>("Gobblygook.yumyum");
        }

        /// <summary>
        ///Write, Null filename
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteTest1()
        {
            Serializer.Write(null, "Hello");
        }
        /// <summary>
        ///Write, Null object
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteTest2()
        {
            Serializer.Write(_Filename, null);
        }
    }
}
