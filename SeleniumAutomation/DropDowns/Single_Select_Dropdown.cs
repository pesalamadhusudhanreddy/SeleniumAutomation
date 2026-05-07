using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPractice
{
    public class Single_Select_Dropdown
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
        }

        [Test]
        public void HandleSingleSelectDropdown()
        {
            IWebElement dropdown = driver.FindElement(By.Id("dropdown"));
            SelectElement select = new SelectElement(dropdown);

            // Select by Index
            select.SelectByIndex(1);
            Assert.That(select.SelectedOption.Text, Is.EqualTo("Option 1"));

            // Select by Value
            select.SelectByValue("2");
            Assert.That(select.SelectedOption.Text, Is.EqualTo("Option 2"));

            // Select by Visible Text
            select.SelectByText("Option 1");
            Assert.That(select.SelectedOption.Text, Is.EqualTo("Option 1"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
