using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAutomationProject.Pages
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement username => driver.FindElement(By.Id("user-name"));
        IWebElement password => driver.FindElement(By.Id("password"));
        IWebElement loginBtn => driver.FindElement(By.Id("login-button"));
        IWebElement errorMsg => driver.FindElement(By.ClassName("error-message-container"));
        public void Login(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            loginBtn.Click();

        }
        public string GetErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => errorMsg.Displayed);
            return errorMsg.Text;
        }
    }
}

