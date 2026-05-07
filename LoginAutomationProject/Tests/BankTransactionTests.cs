using NUnit.Framework;
using BankingAutomation.Base;
using BankingAutomation.Pages;

namespace BankingAutomation.Tests
{
    public class BankTransactionTests : BankBaseTest
    {
        [Test]
        public void TransactionHistoryTest()
        {
            BankLoginPage login = new BankLoginPage(driver);
            BankDashboardPage dashboard = new BankDashboardPage(driver);
            BankTransactionPage txn = new BankTransactionPage(driver);

            login.LoginToBank("mngr34926", "amUpenu");

            dashboard.GoToTransaction();

            txn.ViewTransactions("12345");

            dashboard.Logout();
        }
    }
}