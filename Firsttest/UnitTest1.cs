using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnitFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Suport.UI;

namespace Firsttest
{
    [TestFuxture]
    public class GroupCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]

        public void SetupTest()
        {
            driver = new firefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
        }

        [TearDown]

        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GroupCreationTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
            driver.FindElement(By.name("user")).Clear();
            driver.FindElement(By.name("user")).SendKeys("admin");
            driver.FindElement(By.name("pass")).Clear();
            driver.FindElement(By.name("pass")).SendKeys("secret");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
            driver.FindElement(By.Name("groupe_name")).Clear();
            driver.FindElement(By.Name("groupe_name")).SendKeys("q");
            driver.FindElement(By.Name("groupe_header")).Clear();
            driver.FindElement(By.Name("groupe_header")).SendKeys("qw");
            driver.FindElement(By.Name("groupe_footer")).Clear();
            driver.FindElement(By.Name("groupe_footer")).SendKeys("wq");
            driver.FindElement(By.Name("submit")).Click();
            driver.FindElement(By.LinkText("groupe page")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwichTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
