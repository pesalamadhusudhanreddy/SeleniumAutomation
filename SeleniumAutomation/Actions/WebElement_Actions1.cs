using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumPractice
{
    public class WebElement_Actions1
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
        public void WebElementActions_Login()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Username - SendKeys, Clear, GetAttribute
            IWebElement username = driver.FindElement(By.Id("user-name"));
            username.SendKeys("standard_user");
            username.Clear();
            username.SendKeys("standard_user");

            // Password - SendKeys
            IWebElement password = driver.FindElement(By.Name("password"));
            password.SendKeys("secret_sauce");

            // Validate entered value (Input field → GetAttribute)
            string enteredUser = username.GetAttribute("value")!;

            // Click Login
            driver.FindElement(By.ClassName("submit-button")).Click();

            // Assertion after login
            Assert.That(driver.Url, Does.Contain("inventory.html"),
                "Login failed: Inventory page not loaded");
        }

        // ---------------- TEAR DOWN ----------------
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();   // closes all browser windows
        }
    }
}











