using OpenQA.Selenium;

namespace LoginAutomationProject.Pages
{
    public class ProductPage
    {
        IWebDriver driver;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement addToCartBtn => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        IWebElement cartBadge => driver.FindElement(By.ClassName("shopping_cart_badge"));

        public void AddProductToCart()
        {
            addToCartBtn.Click();
        }

        public string GetCartCount()
        {
            return cartBadge.Text;
        }
    }
}