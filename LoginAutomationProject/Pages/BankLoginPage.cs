using OpenQA.Selenium;

namespace BankingAutomation.Pages
{
    public class BankLoginPage
    {
        private IWebDriver driver;

        public BankLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Username => driver.FindElement(By.Name("uid"));
        private IWebElement Password => driver.FindElement(By.Name("password"));
        private IWebElement LoginBtn => driver.FindElement(By.Name("btnLogin"));

        public void LoginToBank(string user, string pass)
        {
            Username.SendKeys(user);
            Password.SendKeys(pass);
            LoginBtn.Click();
        }
    }
}