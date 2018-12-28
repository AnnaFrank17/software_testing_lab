using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation_test.Driver;
using Automation_test.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Automation_test.Steps
{
    class Steps
    {
        public IWebDriver _driver;

        private MainPage _mainPage;

        private ResultPage _resultPage;

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
            _mainPage.BtnOneWay.Click();

            return _mainPage.ReturnDateContainer;
        }

        public IWebElement SelectDepartDate(DateTime date)
        {
            var day = date.Day;

            return _mainPage.SelectDepartDay(day);
        }

        public void OpenPassengerContainer()
        {
            _mainPage.SelectPassengerContainer.Click();
        }

        public void DecrementAdult()
        {
            _mainPage.BtnAdultMinus.Click();
        }

        public int GetAdultValue()
        {
            var adultValue = _mainPage.AdultValue;

            return Convert.ToInt32(adultValue.GetAttribute("value"));
        }

        public IWebElement SelectReturnDate(DateTime date)
        {
            var day = date.Day;

            return _mainPage.SelectReturnDay(day);
        }

        public void OpenDepartContainer()
        {
            _mainPage.DepartDateContainer.Click();
        }

        public void OpenReturnContainer()
        {
            _mainPage.ReturnDateContainer.Click();
        }

        public void FindResults()
        {
            _mainPage.BtnFind.Click();
        }

        public void OpenResultPage()
        {
            _resultPage = new ResultPage(_driver);
        }

        public string GetFromCity()
        {
            return _resultPage.FromElement.Text;
        }

        public string GetToCity()
        {
            return _resultPage.ToElement.Text;
        }

        public void ApplyMorningFilter()
        {
            _resultPage.FilterButton.Click();
            _resultPage.FilterMorningButton.Click();
            _resultPage.BtnApplyFilter.Click();
        }

        public IWebElement ChangeLanguageToEnglish()
        {
            _mainPage.SelectLanguage.Click();
            _mainPage.ChangeToEnglishElement.Click();

            return _mainPage.BtnFind;
        }

        public IWebElement SubmitTicketButton()
        {
            return _resultPage.BtnSubmit;
        }

        public void ChooseBolPoints()
        {
            _mainPage.BtnBolPoints.Click();
        }

        public void ApplyNightFilter()
        {
            _resultPage.FilterButton.Click();
            _resultPage.FilterNightButton.Click();
            _resultPage.BtnApplyFilter.Click();
        }
    }
}
