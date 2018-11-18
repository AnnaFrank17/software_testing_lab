using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_test.Pages
{
    class MainPage
    {
        private const string BASE_URL = "https://www.flypgs.com/ru";

        [FindsBy(How = How.XPath, Using = "//label[@for='one_way']")]
        public IWebElement BtnOneWay { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'departDateContainer')]")]
        public IWebElement DepartDateContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'returnDateContainer')]")]
        public IWebElement ReturnDateContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@placeholder='ОТКУДА']/following-sibling::span[1]//*[contains(@class, 'select2-selection')]")]
        public IWebElement SelectFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@placeholder='КУДА']/following-sibling::span[1]//*[contains(@class, 'select2-selection')]")]
        public IWebElement SelectTo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='select2-search__field']")]
        public IWebElement InpSelectCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='select2-results']//li")]
        public IWebElement SelectFormResultItem { get; set; }

        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(BASE_URL);
        }

        public IWebElement SelectFromCity(string cityName)
        {
            SelectFrom.Click();

            InpSelectCity.SendKeys(cityName);

            return SelectFormResultItem;
        }

        public IWebElement SelectToCity(string cityName)
        {
            SelectTo.Click();

            InpSelectCity.SendKeys(cityName);

            return SelectFormResultItem;
        }

        public IWebElement SelectDepartDay(int day)
        {
            var xPath = $"//*[contains(@id, 'pgs-departure-datepicker')]//table//td/span[contains(text(), '{day}')]";
            var dayElement = _driver.FindElement(By.XPath(xPath));

            return dayElement;
        }
    }
}
