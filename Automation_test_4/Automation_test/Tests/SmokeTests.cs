using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
