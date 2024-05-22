using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PulsTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\Webdrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new EdgeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestSearch()
        {
            _driver.Navigate().GoToUrl("http://127.0.0.1:5500/Pages/restpulse.html");

            IWebElement inputElement0 = _driver.FindElement(By.Id("NameInput"));
            inputElement0.SendKeys("thor");

            IWebElement buttonElement0 = _driver.FindElement(By.Id("getbyNameButton"));
            buttonElement0.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement measurement = wait.Until(t => t.FindElement(By.Id("table")));
            IReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.TagName("th"));
            Assert.AreEqual(4, listElements.Count); //AreEqual 4 because of the 3 measurements + the header saying Navn

        }
    }
}