using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using LoginAutomationProject.Pages;
using LoginAutomationProject.Utilities;

namespace LoginAutomationProject.Tests
{
    [TestFixture]
    public class LoginTest
    {
         IWebDriver driver;
        LoginPage login;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.InitBrowser();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            login = new LoginPage(driver);
        }

        [Test]
        public void ValidLoginTest()
        {
            login.Login("standard_user", "secret_sauce");
            Assert.That(driver.PageSource.Contains("Products"));
        }

        [Test]
        public void InvalidLoginTest()
        {
            login.Login("standard_user", "sauce");
            Assert.That(login.GetErrorMessage().Contains("Epic sadface"));
        }

        [TearDown]
        public void Close()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
