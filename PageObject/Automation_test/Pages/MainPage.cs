using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_test.Pages
{
    class MainPage
    {
        [FindsBy(How = How.XPath, Using = "//label[@for='one_way']")]
        public IWebElement BtnOneWay { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'returnDateContainer')]")]
        public IWebElement ReturnDateContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@placeholder='ОТКУДА']/following-sibling::span[1]//*[contains(@class, 'select2-selection')]")]
        public IWebElement SelectFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='select2-search__field']")]
        public IWebElement InpSelectFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='select2-results']//li")]
        public IWebElement SelectFormResultItem { get; set; }


        private IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(driver, this);
        }

        public void SelectCity(string cityName)
        {
            SelectFrom.Click();

            InpSelectFrom.SendKeys(cityName);

            Assert.AreEqual(SelectFormResultItem.Text, cityName);

            SelectFormResultItem.Click();
        }

        public void ConfirmFormCityDidntExist()
        {
            SelectFrom.Click();

            InpSelectFrom.SendKeys(Guid.NewGuid().ToString());

            Assert.AreEqual(SelectFormResultItem.Text, "Совпадений не найдено");
        }
    }
}
