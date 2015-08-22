using Microsoft.VisualStudio.TestTools.UnitTesting;
using MpdBaileyTechnology.Shared.WPF.ValidationRules;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace MpdBaileyTechnology.Shared.UnitTests.WPF
{
    
    
    /// <summary>
    ///This is a test class for MaxMinValidationRuleTest and is intended
    ///to contain all MaxMinValidationRuleTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MaxMinValidationRuleTest
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
        ///A test for Validate
        ///</summary>
        [TestMethod()]
        public void ValidateTest()
        {
            MaxMinValidationRule target = new MaxMinValidationRule() { Min = 10, Max = 50 };
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            ValidationResult actual;
            //in range
            actual = target.Validate("42", cultureInfo);
            Assert.IsTrue(actual.IsValid);
            //outside range
            actual = target.Validate("5", cultureInfo);
            Assert.IsFalse(actual.IsValid);
            actual = target.Validate("55", cultureInfo);
            Assert.IsFalse(actual.IsValid);
            //boundary case
            actual = target.Validate("10", cultureInfo);
            Assert.IsTrue(actual.IsValid);
            actual = target.Validate("50", cultureInfo);
            Assert.IsTrue(actual.IsValid);
        }
    }
}
