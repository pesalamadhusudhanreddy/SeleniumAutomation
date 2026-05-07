using NUnit.Framework;                 // NUnit testing framework
using OpenQA.Selenium;                 // Selenium WebDriver
using OpenQA.Selenium.Chrome;          // Chrome browser
using System;                          // Core C# features

namespace StringPractice
{
    [TestFixture] // Marks this class as NUnit Test class
    public class StringMethodsTest
    {
        IWebDriver driver; // WebDriver reference

        [SetUp]
        public void Setup()
        {
            // Launch Chrome browser
            driver = new ChromeDriver();

            // Maximize browser window
            driver.Manage().Window.Maximize();

            // Navigate to test website
            driver.Navigate().GoToUrl("https://example.com");
        }

        [Test]
        public void StringMethodsAutomationTest()
        {
            // ===============================
            // 1️⃣ Get page title (String)
            // ===============================
            string pageTitle = driver.Title;
            // Example: "Example Domain"

            Console.WriteLine("Page Title: " + pageTitle);

            // ===============================
            // 2️⃣ String Length
            // ===============================
            int titleLength = pageTitle.Length;
            Console.WriteLine("Title Length: " + titleLength);

            // ===============================
            // 3️⃣ Convert to Upper & Lower case
            // ===============================
            string upperTitle = pageTitle.ToUpper();
            string lowerTitle = pageTitle.ToLower();

            Console.WriteLine("Upper Case: " + upperTitle);
            Console.WriteLine("Lower Case: " + lowerTitle);

            // ===============================
            // 4️⃣ String Contains
            // ===============================
            Assert.That(pageTitle.Contains("Example"), "Title does not contain expected word");

            // ===============================
            // 5️⃣ String Equals
            // ===============================
            string expectedTitle = "Example Domain";

            Assert.That(pageTitle.Equals(expectedTitle), "Title does not match exactly");

            // ===============================
            // 6️⃣ Trim (remove spaces)
            // ===============================
            string rawText = "  Selenium Automation  ";
            string trimmedText = rawText.Trim();

            Console.WriteLine("Trimmed Text: " + trimmedText);

            // ===============================
            // 7️⃣ Replace
            // ===============================
            string replacedText = trimmedText.Replace("Automation", "Testing");
            Console.WriteLine("Replaced Text: " + replacedText);

            // ===============================
            // 8️⃣ Substring
            // ===============================
            string subText = pageTitle.Substring(0, 7);
            // Takes characters from index 0 to 6

            Console.WriteLine("Substring: " + subText);

            // ===============================
            // 9️⃣ Split
            // ===============================
            string browserInfo = "Chrome-Firefox-Edge";

            string[] browsers = browserInfo.Split('-');
            // Splits string into array

            foreach (string browser in browsers)
            {
                Console.WriteLine("Browser: " + browser);
            }

            // ===============================
            // 🔟 String Interpolation
            // ===============================
            string message = $"Page title '{pageTitle}' has length {titleLength}";
            Console.WriteLine(message);
        }

        [TearDown]
        public void TearDown()
        {
            // Close browser
            driver.Dispose();
        }
    }
}
