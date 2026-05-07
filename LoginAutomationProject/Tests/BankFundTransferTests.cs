using NUnit.Framework;
using BankingAutomation.Base;
using BankingAutomation.Pages;

namespace BankingAutomation.Tests
{
    public class BankFundTransferTests : BankBaseTest
    {
        [Test]
        public void FundTransferTest()
        {
            BankLoginPage login = new BankLoginPage(driver);
            BankDashboardPage dashboard = new BankDashboardPage(driver);
            BankTransferPage transfer = new BankTransferPage(driver);

            login.LoginToBank("mngr34926", "amUpenu");

            dashboard.GoToTransfer();

            transfer.TransferMoney("12345", "54321", "500");

            dashboard.Logout();
        }
    }
}