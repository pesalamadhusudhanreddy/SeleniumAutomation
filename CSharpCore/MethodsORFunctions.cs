using NUnit.Framework;                   // NUnit framework
using OpenQA.Selenium;                   // Selenium WebDriver
using OpenQA.Selenium.Chrome;            // Chrome browser
using System;                            // Core C# classes

namespace MethodsPractice
{
    [TestFixture] // Marks class as NUnit test class
    public class MethodsTest
    {
        IWebDriver driver; // WebDriver reference

        // =====================================================
        // 1️⃣ SETUP METHOD (Void method)
        // =====================================================
        [SetUp]
        public void SetupBrowser()
        {
            // Create Chrome browser instance
            driver = new ChromeDriver();

            // Maximize browser window
            driver.Manage().Window.Maximize();
        }

        // =====================================================
        // 2️⃣ VOID METHOD – No return value
        // =====================================================
        public void OpenUrl(string url)
        {
            // Navigate browser to given URL
            driver.Navigate().GoToUrl(url);
        }

        // =====================================================
        // 3️⃣ METHOD WITH RETURN TYPE
        // =====================================================
        public string GetPageTitle()
        {
            // Return page title from browser
            return driver.Title;
        }

        // =====================================================
        // 4️⃣ METHOD WITH PARAMETERS
        // =====================================================
        public void ValidateTitle(string expectedTitle)
        {
            // Compare expected title with actual title
            Assert.That(driver.Title, Is.EqualTo(expectedTitle),
                "Page title does not match");
        }

        // =====================================================
        // 5️⃣ METHOD OVERLOADING
        // =====================================================

        // Method 1 – Validate title only
        public void ValidatePage(string expectedTitle)
        {
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        // Method 2 – Validate title and URL
        public void ValidatePage(string expectedTitle, string expectedUrl)
        {
            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
            Assert.That(driver.Url, Is.EqualTo(expectedUrl));
        }

        // =====================================================
        // 6️⃣ STATIC METHOD
        // =====================================================
        public static void PrintLog(string message)
        {
            // Print message without object creation
            Console.WriteLine(message);
        }

        // =====================================================
        // 7️⃣ MAIN TEST METHOD
        // =====================================================
        [Test]
        public void MethodsAutomationTest()
        {
            // Call void method with parameter
            OpenUrl("https://example.com");

            // Call return type method
            string title = GetPageTitle();

            // Log output using static method
            PrintLog("Page Title is: " + title);

            // Call validation method
            ValidateTitle("Example Domain");

            // Call overloaded methods
            ValidatePage("Example Domain");
            ValidatePage("Example Domain", "https://example.com/");
        }

        // =====================================================
        // 8️⃣ TEARDOWN METHOD
        // =====================================================
        [TearDown]
        public void CloseBrowser()
        {
            // Close browser after test execution
            driver.Dispose();
        }
    }
}
