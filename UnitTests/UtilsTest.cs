using ENFORM.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for UtilsTest and is intended
    ///to contain all UtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UtilsTest
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
        ///A test for getImageWeights
        ///</summary>
        [TestMethod()]
        public void getImageWeightsTest()
        {
            Image image = Image.FromFile(@"C:\Users\Sean\Pictures\test.png"); // Initialize to an appropriate value
            InputGroup[] inputGroups = new InputGroup[] {new InputGroup(InputGroupType.Grid,2)}; // Initialize to an appropriate value
            double[] expected = { 
                                    0.0, 0.0, 0.0, 0.0, 0.0, 0.2, 0.2, 0.2, 0.2, 0.2,
                                    0.0, 0.0, 0.0, 0.0, 0.0, 0.2, 0.2, 0.2, 0.2, 0.2,
                                    0.0, 0.0, 0.0, 0.0, 0.0, 0.2, 0.2, 0.2, 0.2, 0.2,
                                    0.0, 0.0, 0.0, 0.0, 0.0, 0.2, 0.2, 0.2, 0.2, 0.2,
                                    0.0, 0.0, 0.0, 0.0, 0.0, 0.2, 0.2, 0.2, 0.2, 0.2,
                                    0.4, 0.4, 0.4, 0.4, 0.4, 1.0, 1.0, 1.0, 1.0, 1.0,
                                    0.4, 0.4, 0.4, 0.4, 0.4, 1.0, 1.0, 1.0, 1.0, 1.0,
                                    0.4, 0.4, 0.4, 0.4, 0.4, 1.0, 1.0, 1.0, 1.0, 1.0,
                                    0.4, 0.4, 0.4, 0.4, 0.4, 1.0, 1.0, 1.0, 1.0, 1.0,
                                    0.4, 0.4, 0.4, 0.4, 0.4, 1.0, 1.0, 1.0, 1.0, 1.0
                                }; // Initialize to an appropriate value
            double[] actual;
            actual = Utils.getImageWeights(image, inputGroups);

            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(actual[i], expected[i]);
            }          
           
        }
    }
}
