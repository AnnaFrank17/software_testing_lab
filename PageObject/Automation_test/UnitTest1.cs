using System;
using Automation_test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation_test
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver { get; set; }

        private MainPage _mainPage { get; set; }

        [TestInitialize]
        public void Before()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.flypgs.com/ru");

            _mainPage = new MainPage(_driver);
        }

        [TestMethod]
        public void OneWayRadioButtonTest()
        {
            _mainPage.BtnOneWay.Click();

            Assert.AreEqual(_mainPage.ReturnDateContainer.Displayed, false, "Return date should hide after button click");
        }

        [TestMethod]
        public void FromCityDidntExist()
        {
            _mainPage.ConfirmFormCityDidntExist();
        }

        [TestCleanup]
        public void After()
        {
            _driver.Quit();
        }
    }
}
