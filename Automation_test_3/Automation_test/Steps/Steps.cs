using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_test.Driver;
using Automation_test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Automation_test.Steps
{
    class Steps
    {
        private IWebDriver _driver;

        public void InitBrowser()
        {
            _driver = DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            _driver = null;
            DriverInstance.CloseBrowser();
        }

        public void ConfirmFormCityDidntExist()
        {
            var mainPage = new MainPage(_driver);

            var cityName = Guid.NewGuid().ToString();

            var selectedItem = mainPage.SelectCity(cityName);

            Assert.AreEqual(selectedItem.Text, "Совпадений не найдено");
        }

        public void CofirmFormCityHide()
        {
            var maiPage = new MainPage(_driver);

            maiPage.BtnOneWay.Click();
            var isReturnDateDisplayed = maiPage.ReturnDateContainer.Displayed;

            Assert.AreEqual(isReturnDateDisplayed, false, "Return date should hide after button click");
        }
    }
}
