using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation_test
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver { get; set; }

        [TestInitialize]
        public void Before()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.flypgs.com/ru");
        }

        [TestMethod]
        public void OneWayRadioButtonTest()
        {
            var oneWayButton = _driver.FindElement(By.XPath("//label[@for='one_way']"));
            oneWayButton.Click();

            var returnDate = _driver.FindElement(By.XPath("//*[contains(@class, 'returnDateContainer')]"));

            Assert.AreEqual(returnDate.Displayed, false, "Return date should hide after button click");
        }

        [TestCleanup]
        public void After()
        {
            _driver.Quit();
        }
    }
}
