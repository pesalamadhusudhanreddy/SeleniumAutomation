using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumPractice
{
    public class Locators
    {
        ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            // Maximizes the browser window to full screen
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LaunchBrowserTest()
        {

            // ------------------ ID (Best & Fastest) ------------------
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");

            // ------------------ Name (When ID not available) ----------
            driver.FindElement(By.Name("password")).SendKeys("secret_sauce");

            // ------------------ ClassName (Single class only) ---------
            driver.FindElement(By.ClassName("submit-button")).Click();

            // Assertion after login
            Assert.That(driver.Url, Does.Contain("inventory.html"));

            // ------------------ TagName (Multiple elements) -----------
            var links = driver.FindElements(By.TagName("a"));
            Assert.That(links.Count, Is.GreaterThan(0));

            // ------------------ CSS Selector (Fast & Flexible) --------
            driver.FindElement(By.CssSelector(".inventory_item_name")).Click();

            // ------------------ XPath (Complex & Dynamic) -------------
            string productName = driver.FindElement(
                By.XPath("//div[@class='inventory_details_name large_size']")
            ).Text;

            Assert.That(productName, Is.Not.Empty);

            // ------------------ LinkText ------------------------------
            driver.Navigate().GoToUrl("https://example.com");
            driver.FindElement(By.LinkText("Learn more")).Click();

            // ------------------ PartialLinkText -----------------------
            driver.FindElement(By.PartialLinkText("IANA")).Click();

        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
