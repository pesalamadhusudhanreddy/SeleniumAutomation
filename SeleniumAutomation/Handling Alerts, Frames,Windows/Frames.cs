using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumPractice
{
    [TestFixture]
    public class Frames
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Handle_iFrame_DemoQA()
        {
            // Step 1: Open page with frames
            driver.Navigate().GoToUrl("https://demoqa.com/frames");

            // Step 2: Wait for iframe and switch
            IWebElement iframe = wait.Until(d =>
                d.FindElement(By.Id("frame1")));

            driver.SwitchTo().Frame(iframe);

            // Step 3: Locate element inside iframe
            IWebElement frameText = wait.Until(d =>
                d.FindElement(By.Id("sampleHeading")));

            Console.WriteLine("Text inside iframe: " + frameText.Text);

            // Step 4: Assertion
            Assert.That(frameText.Text, Does.Contain("This is a sample page"));

            // Step 5: Switch back to main page
            driver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
