using OpenQA.Selenium;

namespace BankingAutomation.Pages
{
    public class BankTransactionPage
    {
        private IWebDriver driver;

        public BankTransactionPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement AccountNo => driver.FindElement(By.Name("accountno"));
        private IWebElement SubmitBtn => driver.FindElement(By.Name("AccSubmit"));

        public void ViewTransactions(string accNo)
        {
            AccountNo.SendKeys(accNo);
            SubmitBtn.Click();
        }
    }
}