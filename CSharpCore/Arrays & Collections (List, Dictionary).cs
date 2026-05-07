using NUnit.Framework;                     // NUnit framework
using OpenQA.Selenium;                     // Selenium WebDriver
using OpenQA.Selenium.Chrome;              // Chrome browser
using System;                              // Basic C# classes
using System.Collections.Generic;          // List & Dictionary

namespace CollectionsPractice
{
    [TestFixture] // Marks class as NUnit test class
    public class ArraysCollectionsTest
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
        public void Arrays_List_Dictionary_Test()
        {
            // =====================================================
            // 1️⃣ ARRAYS – Fixed size collection
            // =====================================================

            // Declare and initialize array of expected page titles
            string[] expectedTitles = { "Example Domain", "Google", "Facebook" };

            // Loop through array using foreach
            foreach (string title in expectedTitles)
            {
                Console.WriteLine("Expected Title: " + title);
            }

            // Get actual title from browser
            string actualTitle = driver.Title;

            // Validate title exists in array
            Assert.That(Array.Exists(expectedTitles, t => t == actualTitle),
                "Actual title not found in expected titles array");

            // =====================================================
            // 2️⃣ LIST<T> – Dynamic collection
            // =====================================================

            // Create list to store visible links text
            List<string> linkTexts = new List<string>();

            // Find all anchor tags on page
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));

            // Store each link text into list
            foreach (IWebElement link in links)
            {
                linkTexts.Add(link.Text);
            }

            // Print count of links
            Console.WriteLine("Total Links: " + linkTexts.Count);

            // Validate list contains specific text
            Assert.That(linkTexts.Contains("More information..."),
                "Expected link text not found in list");

            // Remove an item from list
            linkTexts.Remove("More information...");

            // =====================================================
            // 3️⃣ DICTIONARY<TKey, TValue> – Key Value pair
            // =====================================================

            // Create dictionary to store environment URLs
            Dictionary<string, string> envUrls = new Dictionary<string, string>();

            // Add key-value pairs
            envUrls.Add("QA", "https://example.com");
            envUrls.Add("UAT", "https://uat.example.com");

            // Check if key exists
            if (envUrls.ContainsKey("QA"))
            {
                // Navigate using dictionary value
                driver.Navigate().GoToUrl(envUrls["QA"]);
            }

            // Loop through dictionary
            foreach (KeyValuePair<string, string> env in envUrls)
            {
                Console.WriteLine($"Environment: {env.Key}, URL: {env.Value}");
            }
        }

        [TearDown]  
        public void TearDown()
        {
            // Close browser
            driver.Dispose();
        }
    }
}
