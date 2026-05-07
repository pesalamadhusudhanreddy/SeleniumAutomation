using OpenQA.Selenium;

namespace BankingAutomation.Pages
{
    public class BankDashboardPage
    {
        private IWebDriver driver;

        public BankDashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ManagerId => driver.FindElement(By.XPath("//td[contains(text(),'Manger Id')]"));
        private IWebElement BalanceMenu => driver.FindElement(By.LinkText("Balance Enquiry"));
        private IWebElement TransferMenu => driver.FindElement(By.LinkText("Fund Transfer"));
        private IWebElement TransactionMenu => driver.FindElement(By.LinkText("Mini Statement"));
        private IWebElement LogoutBtn => driver.FindElement(By.LinkText("Log out"));

        public bool IsLoginSuccessful()
        {
            return ManagerId.Displayed;
        }

        public void GoToBalance()
        {
            BalanceMenu.Click();
        }

        public void GoToTransfer()
        {
            TransferMenu.Click();
        }

        public void GoToTransaction()
        {
            TransactionMenu.Click();
        }

        public void Logout()
        {
            LogoutBtn.Click();
        }
    }
}