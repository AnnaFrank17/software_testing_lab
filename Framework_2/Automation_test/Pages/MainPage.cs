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

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'passenger-select')]")]
        public IWebElement SelectPassengerContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'passenger-select')]//label[contains(text(), 'взрослый')]/following-sibling::div//*[contains(@class, 'minus')]")]
        public IWebElement BtnAdultMinus { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'nxm-guestAdult')]")]
        public IWebElement AdultValue { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='fligth-searh']//*[@type='submit' and contains(@class, 'nxm2_btn nxm2_btn-big nxm2_btn-full nxm2_btn-dark_orange')]")]
        public IWebElement BtnFind { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'nxm2_language-btn')]")]
        public IWebElement SelectLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'English')]")]
        public IWebElement ChangeToEnglishElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'divBolBolPoint')]//input")]
        public IWebElement BtnBolPoints { get; set; }

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
            var xPath = $"//*[contains(@id, 'pgs-departure-datepicker')]//table//*[contains(text(), '{day}')]/..";
            var dayElement = _driver.FindElement(By.XPath(xPath));

            return dayElement;
        }

        public IWebElement SelectReturnDay(int day)
        {
            var xPath = $"//*[contains(@id, 'pgs-departure-datepicker')]//table//*[contains(text(), '{day}')]";
            var dayElement = _driver.FindElements(By.XPath(xPath))[0];

            return dayElement;
        }
    }
}
