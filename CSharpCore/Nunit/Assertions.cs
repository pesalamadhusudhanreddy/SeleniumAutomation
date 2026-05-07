using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace NUnitAssertionPractice
{
    [TestFixture]
    public class AssertionTests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }

        // Assert.AreEqual
        [Test]
        public void VerifyGoogleTitle()
        {
            Assert.That(driver.Title, Is.EqualTo("Google"));
        }

        // Assert.IsTrue
        [Test]
        public void VerifySearchBoxIsDisplayed()
        {
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            Assert.That(searchBox.Displayed, Is.True);
        }

        // Assert.IsFalse
        [Test]
        public void VerifyFakeErrorMessageIsNotDisplayed()
        {
            bool isDisplayed = driver.FindElements(By.Id("fakeError")).Count > 0;
            Assert.That(isDisplayed, Is.False);
        }

        // Assert.Throws
        [Test]
        public void VerifyExceptionForInvalidElement()
        {
            Assert.Throws<NoSuchElementException>(() =>
            {
                driver.FindElement(By.Id("invalidElement"));
            });
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Dispose();
        }
    }
}
