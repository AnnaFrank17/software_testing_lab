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

            var selectedItem = _steps.SelectCity(cityName);

            Assert.AreEqual(selectedItem.Text, "Совпадений не найдено");
        }

        [Test]
        public void OneWayRadioButtonTypeTest()
        {
            var returnDateContainer = _steps.SelectOneWayType();

            var isReturnDateDisplayed = returnDateContainer.Displayed;

            Assert.AreEqual(isReturnDateDisplayed, false, "Return date should hide after button click");
        }
    }
}
