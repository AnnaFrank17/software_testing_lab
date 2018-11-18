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

        private MainPage _mainPage;

        public void InitBrowser()
        {
            _driver = DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            _driver = null;
            DriverInstance.CloseBrowser();
        }

        public void OpenMainPage()
        {
            _mainPage = new MainPage(_driver);

            _mainPage.OpenPage();
        }

        public IWebElement SelectFromCity(string cityName)
        {
            return _mainPage.SelectFromCity(cityName);
        }

        public IWebElement SelectToCity(string cityName)
        {
            return _mainPage.SelectToCity(cityName);
        }

        public IWebElement SelectOneWayType()
        {
            var maiPage = new MainPage(_driver);

            maiPage.OpenPage();
            maiPage.BtnOneWay.Click();

            return maiPage.ReturnDateContainer;
        }

        public IWebElement SelectDepartDate(DateTime date)
        {
            var day = date.Day;

            return _mainPage.SelectDepartDay(day);
        }
    }
}
