//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using System.Linq;

//namespace SeleniumPractice
//{
//    public class MultiSelectDropdownTests
//    {
//        IWebDriver driver;

//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
//        }

//        [Test]
//        public void HandleMultiSelectDropdown()
//        {
//            IWebElement multiDropdown = driver.FindElement(By.Id("cars"));
//            SelectElement select = new SelectElement(multiDropdown);

//            // Verify multi-select
//            Assert.IsTrue(select.IsMultiple, "Dropdown is not multi-select");

//            // Select multiple options
//            select.SelectByText("Volvo");
//            select.SelectByValue("saab");
//            select.SelectByIndex(2);

//            // Verify selected options
//            var selectedOptions = select.AllSelectedOptions;
//            Assert.That(selectedOptions, Has.Count.EqualTo(3));

//            // Deselect one option
//            select.DeselectByText("Saab");
//            Assert.AreEqual(2, select.AllSelectedOptions.Count);
//            // Deselect all
//            select.DeselectAll();
//            Assert.AreEqual(0, select.AllSelectedOptions.Count);
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            driver.Dispose();
//        }
//    }
//}
