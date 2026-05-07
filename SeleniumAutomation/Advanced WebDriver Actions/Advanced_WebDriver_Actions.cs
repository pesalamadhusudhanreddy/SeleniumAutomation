using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumPractice
{
    [TestFixture]
    public class Advanced_WebDriver_Actions
    {
        IWebDriver driver;
        WebDriverWait wait;
        Actions actions;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions = new Actions(driver);
        }

        [Test]
        public void All_Advanced_WebDriver_Actions_Test()
        {
            // 1️ Mouse Hover
            driver.Navigate().GoToUrl("https://demoqa.com/menu");

            IWebElement menuItem = wait.Until(
                d => d.FindElement(By.XPath("//a[text()='Main Item 2']"))
            );

            actions.MoveToElement(menuItem).Perform();
            Assert.That(menuItem.Displayed, Is.True);

            // 2️ Right Click
            driver.Navigate().GoToUrl("https://demoqa.com/buttons");

            IWebElement rightClickBtn = wait.Until(
                d => d.FindElement(By.Id("rightClickBtn"))
            );

            actions.ContextClick(rightClickBtn).Perform();

            IWebElement rightClickMsg = driver.FindElement(By.Id("rightClickMessage"));
            Assert.That(rightClickMsg.Text, Does.Contain("right click"));

            // 3️ Double Click
            IWebElement doubleClickBtn = driver.FindElement(By.Id("doubleClickBtn"));
            actions.DoubleClick(doubleClickBtn).Perform();

            IWebElement doubleClickMsg = driver.FindElement(By.Id("doubleClickMessage"));
            Assert.That(doubleClickMsg.Text, Does.Contain("double click"));

            // 4️ Drag and Drop
            driver.Navigate().GoToUrl("https://demoqa.com/droppable");

            IWebElement source = wait.Until(
                d => d.FindElement(By.Id("draggable"))
            );

            IWebElement target = driver.FindElement(By.Id("droppable"));

            actions.DragAndDrop(source, target).Perform();
            Assert.That(target.Text, Does.Contain("Dropped"));

            // 5️ Keyboard SendKeys
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");

            IWebElement fullName = wait.Until(
                d => d.FindElement(By.Id("userName"))
            );

            actions.SendKeys(fullName, "Selenium").Perform();
            Assert.That(fullName.GetAttribute("value"), Is.EqualTo("Selenium"));

            // 6️ Keyboard Press & Release (CTRL + A)
            IWebElement address = driver.FindElement(By.Id("currentAddress"));
            address.SendKeys("Hyderabad Telangana");

            actions.KeyDown(Keys.Control)
                   .SendKeys("a")
                   .KeyUp(Keys.Control)
                   .Perform();

            // 7️ Keyboard Press & Release (SHIFT + text)
            IWebElement email = driver.FindElement(By.Id("userEmail"));

            actions.KeyDown(Keys.Shift)
                   .SendKeys(email, "selenium@test.com")
                   .KeyUp(Keys.Shift)
                   .Perform();

            Assert.Pass("All Advanced WebDriver Actions executed successfully");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
