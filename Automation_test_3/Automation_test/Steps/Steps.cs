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

        public IWebElement SelectCity(string cityName)
        {
            var mainPage = new MainPage(_driver);

            mainPage.OpenPage();
            return mainPage.SelectCity(cityName);
        }

        public IWebElement SelectOneWayType()
        {
            var maiPage = new MainPage(_driver);

            maiPage.OpenPage();
            maiPage.BtnOneWay.Click();

            return maiPage.ReturnDateContainer;
        }
    }
}
