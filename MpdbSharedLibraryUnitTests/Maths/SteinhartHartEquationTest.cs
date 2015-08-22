using MpdBaileyTechnology.Shared.Maths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MpdBaileyTechnology.Shared.UnitTests.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for SteinhartHartEquationTest and is intended
    ///to contain all SteinhartHartEquationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SteinhartHartEquationTest
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
        ///A test for CalculateTemperature
        ///</summary>
        [TestMethod()]
        public void CalculateTemperatureTest()
        {
            //Typical thermistor values, figures taken from http://en.wikipedia.org/wiki/Thermistor
            double a = 1.4e-3;
            double b = 2.37e-4;
            double c = 9.90e-8;
            SteinhartHartEquation target = new SteinhartHartEquation(a, b, c);
            double resistance = 3000;
            //Temperature calculated using Excel
            double expected = 25.507;
            double actual;
            actual = target.CalculateTemperature(resistance);
            Assert.AreEqual(expected.ToString("G5"), actual.ToString("G5"));
        }

        /// <summary>
        ///A test for CalculateResistance
        ///</summary>
        [TestMethod()]
        public void CalculateResistanceTest()
        {
            //Typical thermistor values, figures taken from http://en.wikipedia.org/wiki/Thermistor
            double a = 1.4e-3;
            double b = 2.37e-4;
            double c = 9.90e-8;
            SteinhartHartEquation target = new SteinhartHartEquation(a, b, c);
            double temperature = 25.507;
            double expected = 3000;
            double actual;
            actual = target.CalculateResistance(temperature);
            Assert.AreEqual(expected.ToString("G4"), actual.ToString("G4"));
        }

        /// <summary>
        ///A test for CalculateCoefficients
        ///</summary>
        [TestMethod()]
        public void CalculateCoefficientsTest()
        {
            SteinhartHartEquation target = new SteinhartHartEquation(0,0,0);
            double r1 = 8196.2083430224284D;
            double t1 = 4D;
            double r2 = 914.68076906345277D;
            double t2 = 55D;
            double r3 = 241.05129129281565D;
            double t3 = 95D;
            target.CalculateCoefficients(r1, t1, r2, t2, r3, t3);
            Assert.AreEqual("1.40E-003", target.A.ToString("E2"));
            Assert.AreEqual("2.37E-004", target.B.ToString("E2"));
            Assert.AreEqual("9.90E-008", target.C.ToString("E2"));
        }
    }
}
