using BankingAutomation.Base;
using BankingAutomation.Pages;
using LoginAutomationProject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BankingAutomation.Tests
{
    public class BankBalanceTests : BankBaseTest
    {
        private IWebDriver driver;

        [Test]
        public void CheckBalanceTest()
        {
            BankLoginPage login = new BankLoginPage(driver);
            BankDashboardPage dashboard = new BankDashboardPage(driver);

            login.LoginToBank("mngr34926", "amUpenu");

            Assert.That(dashboard.IsLoginSuccessful(), Is.True);

            dashboard.GoToBalance();
            dashboard.Logout();
        }
    }
}