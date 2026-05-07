using NUnit.Framework;  
using OpenQA.Selenium;
using LoginAutomationProject.Pages;
using LoginAutomationProject.Utilities;


namespace LoginAutomationProject.Tests
{
    public class AddToCartTest
    {
        IWebDriver driver;
        LoginPage login;
        ProductPage product;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.InitBrowser();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            login = new LoginPage(driver);
            product = new ProductPage(driver);

            login.Login("standard_user", "secret_sauce");
        }

        [Test]
        public void AddProductTest()
        {
            product.AddProductToCart();
            Assert.That(product.GetCartCount(), Is.EqualTo("1"));
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}