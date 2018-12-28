using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Automation_test.Tests
{
    [TestFixture]
    public class SmokeTests
    {
        private Steps.Steps _steps = new Steps.Steps();

        [SetUp]
        public void StartBrowser()
        {
            _steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            _steps.CloseBrowser();
        }

        [Test]
        public void CityDidntExistTest()
        {
            var cityName = Guid.NewGuid().ToString();

            _steps.OpenMainPage();
            var selectedItem = _steps.SelectFromCity(cityName);

            Assert.AreEqual(selectedItem.Text, "Совпадений не найдено");
        }

        [Test]
        public void OneWayRadioButtonTypeTest()
        {
            _steps.OpenMainPage();
            var returnDateContainer = _steps.SelectOneWayType();

            var isReturnDateDisplayed = returnDateContainer.Displayed;

            Assert.AreEqual(isReturnDateDisplayed, false, "Return date should hide after button click");
        }

        [Test]
        public void FromDateMoreThanToDateTest()
        {
            var fromCity = "Antalya";
            var toCity = "Barcelona";
            var departDay = DateTime.Now.AddDays(-2);

            _steps.OpenMainPage();
            _steps
                .SelectFromCity(fromCity)
                .Click();
            _steps
                .SelectToCity(toCity)
                .Click();

            var departDayElement = _steps.SelectDepartDate(departDay);
            var isDepartDayDisabled = departDayElement.Displayed;

            Assert.IsFalse(isDepartDayDisabled);
        }

        [Test]
        public void SelectOnlyChildTest()
        {
            _steps.OpenMainPage();
            _steps.OpenPassengerContainer();
            _steps.DecrementAdult();
            var adultValue = _steps.GetAdultValue();

            Assert.AreEqual(adultValue, 1);
        }

        [Test]
        public void ResultFlightsTest()
        {
            var fromCity = "Antalya";
            var toCity = "Barcelona";
            var departDay = DateTime.Now.AddDays(3);

            _steps.OpenMainPage();
            _steps
                .SelectFromCity(fromCity)
                .Click();
            _steps
                .SelectToCity(toCity)
                .Click();

            _steps.SelectOneWayType();

            ScrollHelpers.ScrollTo(_steps._driver, 300);

            _steps.OpenDepartContainer();
            _steps.SelectDepartDate(departDay).Click();

            _steps.FindResults();
            _steps.OpenResultPage();

            var fromCityResult = _steps.GetFromCity();
            var toCityResult = _steps.GetToCity();

            Assert.AreEqual(fromCity, fromCityResult);
        }

        [Test]
        public void FilterResultPage()
        {
            ResultFlightsTest();

            _steps.ApplyMorningFilter();
        }

        [Test]
        public void ChangeLanguageTest()
        {
            _steps.OpenMainPage();

            var findButton = _steps.ChangeLanguageToEnglish();

            Assert.AreEqual(findButton.Text, "SEARCH CHEAP FLIGHTS");
        }

        [Test]
        public void SubmitTicketTest()
        {
            ResultFlightsTest();

            var submitTicket = _steps.SubmitTicketButton();

            Assert.IsTrue(submitTicket.Displayed);
        }

        [Test]
        public void SelectBolPoints()
        {
            var fromCity = "Antalya";
            var toCity = "Barcelona";
            var departDay = DateTime.Now.AddDays(3);

            _steps.OpenMainPage();
            _steps
                .SelectFromCity(fromCity)
                .Click();
            _steps
                .SelectToCity(toCity)
                .Click();

            _steps.SelectOneWayType();
            _steps.ChooseBolPoints();

            ScrollHelpers.ScrollTo(_steps._driver, 300);

            _steps.OpenDepartContainer();
            _steps.SelectDepartDate(departDay).Click();

            _steps.FindResults();
            _steps.OpenResultPage();

            var fromCityResult = _steps.GetFromCity();
            var toCityResult = _steps.GetToCity();

            Assert.AreEqual(fromCity, fromCityResult);
        }

        [Test]
        public void FilterNightFlightsResultsTest()
        {
            var fromCity = "Antalya";
            var toCity = "Barcelona";
            var departDay = DateTime.Now.AddDays(3);

            _steps.OpenMainPage();
            _steps
                .SelectFromCity(fromCity)
                .Click();
            _steps
                .SelectToCity(toCity)
                .Click();

            _steps.SelectOneWayType();

            ScrollHelpers.ScrollTo(_steps._driver, 300);

            _steps.OpenDepartContainer();
            _steps.SelectDepartDate(departDay).Click();

            _steps.FindResults();
            _steps.OpenResultPage();

            var fromCityResult = _steps.GetFromCity();
            var toCityResult = _steps.GetToCity();

            Assert.AreEqual(fromCity, fromCityResult);

            _steps.ApplyNightFilter();
        }
    }
}
