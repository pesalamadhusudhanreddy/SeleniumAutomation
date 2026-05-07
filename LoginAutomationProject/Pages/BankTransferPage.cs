using OpenQA.Selenium;

namespace BankingAutomation.Pages
{
    public class BankTransferPage
    {
        private IWebDriver driver;

        public BankTransferPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement PayerAccount => driver.FindElement(By.Name("payersaccount"));
        private IWebElement PayeeAccount => driver.FindElement(By.Name("payeeaccount"));
        private IWebElement Amount => driver.FindElement(By.Name("ammount"));
        private IWebElement TransferBtn => driver.FindElement(By.Name("AccSubmit"));

        public void TransferMoney(string fromAcc, string toAcc, string amount)
        {
            PayerAccount.SendKeys(fromAcc);
            PayeeAccount.SendKeys(toAcc);
            Amount.SendKeys(amount);
            TransferBtn.Click();
        }
    }
}