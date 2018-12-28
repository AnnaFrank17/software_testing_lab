using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automation_test.Pages
{
    class ResultPage
    {

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'summary-inner')]//*[contains(@class, 'from')]")]
        public IWebElement FromElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'summary-inner')]//*[contains(@class, 'to')]")]
        public IWebElement ToElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='icon-filter']/../..")]
        public IWebElement FilterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name, 'MORNING')]")]
        public IWebElement FilterMorningButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Применить выбор')]")]
        public IWebElement BtnApplyFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'button submit-button')]")]
        public IWebElement BtnSubmit { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@name, 'EVENING')]")]
        public IWebElement FilterNightButton { get; set; }

        private IWebDriver _driver { get; set; }

        public ResultPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }
    }
}
