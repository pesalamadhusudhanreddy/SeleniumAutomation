using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace NUnitSeleniumPractice
{
    [TestFixture]
    public class Attributes
    {
        IWebDriver driver;

        // Runs ONCE before all tests
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        // Runs BEFORE EACH test
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        // Test Case 1
        [Test]
        public void GoogleTitleTest()
        {
            string title = driver.Title;
            Assert.That(title, Is.EqualTo("Google"));
        }

        // Test Case 2
        [Test]
        public void GoogleSearchBoxDisplayedTest()
        {
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            Assert.That(searchBox.Displayed, Is.True);
        }

        // Runs AFTER EACH test
        [TearDown]
        public void TearDown()
        {
            // Example: Screenshot or cleanup (not closing browser here)
            Console.WriteLine("Test completed");
        }

        // Runs ONCE after all tests
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Dispose();
        }
    }
}
