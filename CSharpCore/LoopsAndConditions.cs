using NUnit.Framework;                 // NUnit framework
using OpenQA.Selenium;                 // Selenium WebDriver interfaces
using OpenQA.Selenium.Chrome;          // Chrome browser driver
using System;                          // System namespace

namespace SeleniumCSharpLoops
{
    [TestFixture]                      // Marks this class as an NUnit test class
    public class LoopsAndConditionsExample
    {
        IWebDriver driver;             // Variable to store browser instance

        [SetUp]                        // Runs before each test
        public void Setup()
        {
            driver = new ChromeDriver();          // Launch Chrome browser
            driver.Manage().Window.Maximize();    // Maximize browser
            driver.Navigate().GoToUrl(
                "https://the-internet.herokuapp.com/login"); // Open login page
        }

        [Test]                         // Marks this method as a test case
        public void LoginAttemptsUsingLoopAndConditions()
        {
            // ---------- VARIABLES ----------
            string[] usernames = { "invalidUser", "tomsmith" };   // Array for usernames
            string[] passwords = { "wrongPass", "SuperSecretPassword!" };

            int totalAttempts = usernames.Length; // Total number of attempts

            // ---------- FOR LOOP ----------
            for (int i = 0; i < totalAttempts; i++)
            {
                // Locate username input field
                IWebElement usernameField = driver.FindElement(By.Id("username"));

                // Locate password input field
                IWebElement passwordField = driver.FindElement(By.Id("password"));

                // Locate login button
                IWebElement loginButton = driver.FindElement(By.CssSelector("button"));

                // Clear existing values before entering new ones
                usernameField.Clear();
                passwordField.Clear();

                // Enter username and password from array using index
                usernameField.SendKeys(usernames[i]);
                passwordField.SendKeys(passwords[i]);

                // Click on login button
                loginButton.Click();

                // Capture login message text
                string message = driver.FindElement(By.Id("flash")).Text;

                // ---------- CONDITIONAL STATEMENTS ----------

                // Check if login is successful
                if (message.Contains("secure"))
                {
                    Console.WriteLine("Login successful on attempt: " + (i + 1));

                    // Assertion for successful login
                    Assert.That(message.Contains("secure"),
                        "Login should be successful");

                    break; // Exit loop once login succeeds
                }
                else if (message.Contains("invalid"))
                {
                    Console.WriteLine("Login failed on attempt: " + (i + 1));

                    // Assertion for failed login
                    Assert.That(message.Contains("invalid"),
                        "Invalid credentials message expected");
                }
                else
                {
                    Console.WriteLine("Unexpected login result");
                }
            }
        }

        [TearDown]                     // Runs after each test
        public void TearDown()
        {
            driver.Dispose();             // Close browser
        }
    }
}
