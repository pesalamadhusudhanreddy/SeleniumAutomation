using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoginAutomationProject.Utilities
{
    public class DriverFactory
    {
        public static IWebDriver driver;

        public static IWebDriver InitBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
