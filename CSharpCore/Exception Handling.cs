//using NUnit.Framework;                       // NUnit framework
//using OpenQA.Selenium;                       // Selenium WebDriver
//using OpenQA.Selenium.Chrome;                // Chrome browser
//using OpenQA.Selenium.Support.UI;             // WebDriverWait
//using System;                                // Core C# classes

//namespace ExceptionHandlingPractice
//{
//    [TestFixture] // Marks this class as NUnit test class
//    public class ExceptionHandlingTest
//    {
//        ChromeDriver driver; // WebDriver reference (CA1859 fix)

//        // =====================================================
//        // 1️⃣ SETUP METHOD
//        // =====================================================
//        [SetUp]
//        public void SetupBrowser()
//        {
//            // Launch Chrome browser
//            driver = new ChromeDriver();

//            // Maximize browser window
//            driver.Manage().Window.Maximize();
//        }

//        // =====================================================
//        // 2️⃣ TEST METHOD WITH EXCEPTION HANDLING
//        // =====================================================
//        [Test]
//        public void ExceptionHandlingAutomationTest()
//        {
//            try
//            {
//                // Navigate to website
//                driver.Navigate().GoToUrl("https://example.com");

//                // TRYING TO FIND A NON-EXISTING ELEMENT (Intentional)
//                IWebElement fakeButton = driver.FindElement(By.Id("loginBtn"));

//                // Click action (will not execute if exception occurs)
//                fakeButton.Click();
//            }
//            catch (NoSuchElementException ex)
//            {
//                // Handles element not found issue
//                Console.WriteLine("Element not found: " + ex.Message);

//                // Mark test as failed with clear reason
//                Assert.Fail("Test failed because element was not found.");
//            }
//            catch (WebDriverTimeoutException ex)
//            {
//                // Handles wait timeout issues
//                Console.WriteLine("Timeout error: " + ex.Message);

//                Assert.Fail("Test failed due to timeout.");
//            }
//            catch (Exception ex)
//            {
//                // Handles any unexpected exception
//                Console.WriteLine("Unexpected error: " + ex.Message);

//                Assert.Fail("Unexpected exception occurred.");
//            }
//        }

//        // =====================================================
//        // 3️⃣ TEARDOWN METHOD FOR CLEANUP
//        // =====================================================
//        [TearDown]
//        public void CleanupBrowser()
//        {
//            if (driver != null)
//            {
//                driver.Dispose(); // Close browser safely
//                driver = null;
//            }
//        }
//    }
//}
