//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SeleniumPractice
//{
//    public class Alerts
//    {
//        IWebDriver driver;
//        WebDriverWait wait;

//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        }

//        [Test]
//        public void Handle_JavaScript_Alerts()
//        {
//            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

//            // ---------- Simple Alert ----------
//            driver.FindElement(By.XPath("//button[text()='Click for JS Alert']")).Click();

//            IAlert alert = wait.Until(CustomExpectedConditions.AlertIsPresent());
//            Console.WriteLine("Simple Alert Text: " + alert.Text);
//            alert.Accept();

//            // ---------- Confirmation Alert ----------
//            driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']")).Click();

//            alert = wait.Until(CustomExpectedConditions.AlertIsPresent());
//            Console.WriteLine("Confirmation Alert Text: " + alert.Text);
//            alert.Dismiss();

//            // ---------- Prompt Alert ----------
//            driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']")).Click();

//            alert = wait.Until(CustomExpectedConditions.AlertIsPresent());
//            alert.SendKeys("Selenium C#");
//            alert.Accept();

//            // ---------- Assertion ----------
//            IWebElement resultText = driver.FindElement(By.Id("result"));
//            Assert.IsTrue(resultText.Text.Contains("Selenium C#"));

//            Console.WriteLine("Final Result Text: " + resultText.Text);
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            driver.Dispose();
//        }
//    }

//    // Add this helper class to replace the missing ExpectedConditions
//    public static class CustomExpectedConditions
//    {
//        public static Func<IWebDriver, IAlert?> AlertIsPresent()
//        {
//            return driver =>
//            {
//                try
//                {
//                    return driver.SwitchTo().Alert();
//                }
//                catch (NoAlertPresentException)
//                {
//                    return null;
//                }
//            };
//        }
//    }
//}
