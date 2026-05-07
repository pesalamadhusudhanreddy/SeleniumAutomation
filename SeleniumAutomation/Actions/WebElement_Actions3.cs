using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
namespace SeleniumPractice
{
    public class WebElement_Actions3
    {
        IWebDriver driver ;

        // ---------------- SETUP ----------------
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        // ---------------- TEST ----------------
        [Test]
        public void WebElementActions_CheckboxAndSubmit()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");

            // Locate first checkbox
            IWebElement checkbox = driver.FindElements(
                By.CssSelector("input[type='checkbox']"))[0];

            // IsSelected - before click
            Assert.That(checkbox.Selected, Is.False,
                "Checkbox should not be selected initially");

            // Click checkbox
            checkbox.Click();

            // IsSelected - after click
            Assert.That(checkbox.Selected, Is.True,
                "Checkbox should be selected after clicking");
        }

        // ---------------- TEAR DOWN ----------------
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

