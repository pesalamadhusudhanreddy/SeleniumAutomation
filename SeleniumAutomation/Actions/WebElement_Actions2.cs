using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPractice
{
    public class WebElement_Actions2
    {
        IWebDriver driver;         
            // ---------------- SETUP ----------------
            [SetUp]
            public void Setup()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }

            // ---------------- TEST ----------------
            [Test]
            public void WebElementActions_UIValidation()
            {
                // Navigate & Login
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");
                driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
                driver.FindElement(By.Name("password")).SendKeys("secret_sauce");
                driver.FindElement(By.ClassName("submit-button")).Click();

                // GetText (for labels / headings)
                IWebElement title = driver.FindElement(By.ClassName("title"));
                string pageText = title.Text;

                Assert.That(pageText, Is.EqualTo("Products"),
                    "Page title text is incorrect");

                // IsDisplayed
                Assert.That(title.Displayed, Is.True,
                    "Products title is not displayed");

                // IsEnabled
                IWebElement cartButton = driver.FindElement(By.ClassName("shopping_cart_link"));
                Assert.That(cartButton.Enabled, Is.True,
                    "Cart button is not enabled");
            }

            // ---------------- TEAR DOWN ----------------
            [TearDown]
            public void TearDown()
            {
                driver.Dispose();
            }
        }
    }
