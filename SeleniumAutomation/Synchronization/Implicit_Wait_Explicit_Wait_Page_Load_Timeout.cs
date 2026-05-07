using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
//Explicit Wait  → Specific element + condition
//Fluent Wait    → Custom polling + exceptions
//Page Load Wait → Full page load
//Implicit Wait  → Global wait for elements
namespace SeleniumPractice
{
    [TestFixture]
    public class Implicit_Wait_Explicit_Wait_Page_Load_Timeout
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // ✔ Implicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // ✔ Page Load Timeout
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        }

        [Test]
        public void DynamicControls_Waits_Test()
        {
            driver.FindElement(By.LinkText("Dynamic Controls")).Click();

            // ✔ Explicit Wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement enableBtn = wait.Until(drv =>
            {
                var element = drv.FindElement(By.XPath("//button[text()='Enable']"));
                return (element != null && element.Enabled && element.Displayed) ? element : null;
            });
            enableBtn.Click();

            IWebElement textBox = wait.Until(drv =>
            {
                var element = drv.FindElement(By.XPath("//input[@type='text']"));
                return (element != null && element.Displayed) ? element : null;
            });

            Assert.That(textBox.Enabled, Is.True);

            // ✔ Fluent Wait
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
            fluentWait.PollingInterval = TimeSpan.FromSeconds(2);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            
            IWebElement message = fluentWait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(By.Id("message"));
                    return element.Text.Contains("enabled") ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });

        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
