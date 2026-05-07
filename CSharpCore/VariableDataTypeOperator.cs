using NUnit.Framework;                 // Import NUnit framework
using OpenQA.Selenium;                 // Import Selenium WebDriver interfaces
using OpenQA.Selenium.Chrome;          // Import Chrome browser driver
using System;                          // Import System namespace

namespace SeleniumCSharpBasics         // Namespace to organize the code
{
    [TestFixture]                      // Marks this class as an NUnit test class
    public class VariableDataTypeOperatorExample
    {
        IWebDriver driver;             // Variable to store browser instance

        [SetUp]                        // Runs before each test method
        public void Setup()
        {
            driver = new ChromeDriver();      // Create Chrome browser object
            driver.Manage().Window.Maximize(); // Maximize browser window
        }

        [Test]                         // Marks this as a test case
        public void VerifyPageTitleUsingVariablesAndOperators()
        {
            // ---------- VARIABLES & DATA TYPES ----------

            string url = "https://www.google.com"; // string variable to store URL
            string expectedTitle = "Google";       // string variable for expected title

            int maxRetryCount = 3;     // int data type variable
            bool isTitleMatched;       // bool data type variable

            // ---------- SELENIUM ACTION ----------

            driver.Navigate().GoToUrl(url); // Open the web application

            // Get actual title from the browser
            string actualTitle = driver.Title;

            // ---------- OPERATORS ----------

            // == comparison operator compares expected and actual values
            isTitleMatched = (actualTitle == expectedTitle);

            // > relational operator
            bool isRetryAllowed = maxRetryCount > 0;

            // && logical operator
            if (isTitleMatched == true && isRetryAllowed == true)
            {
                Console.WriteLine("Page title matched and retry allowed");
            }
            else
            {
                Console.WriteLine("Page title mismatch or retry not allowed");
            }

            // ---------- NUNIT ASSERTION ----------

            // Assert validates the condition
            Assert.That(isTitleMatched, Is.True, "Page title validation failed");
        }

        [TearDown]                     // Runs after each test method
        public void TearDown()
        {
            driver.Dispose();             // Close browser and end session
        }
    }
}
