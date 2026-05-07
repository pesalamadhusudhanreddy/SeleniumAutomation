using BankingAutomation.Base;
using BankingAutomation.Pages;
using NUnit.Framework;

namespace BankingAutomation.Tests
{
    public class BankLoginTests : BankBaseTest
    {
        [Test]
        public void ValidBankLoginTest()
        {
            BankLoginPage login = new BankLoginPage(driver);
            BankDashboardPage dashboard = new BankDashboardPage(driver);

          

            Assert.That(dashboard.IsLoginSuccessful(), Is.True);
        }
    }
}