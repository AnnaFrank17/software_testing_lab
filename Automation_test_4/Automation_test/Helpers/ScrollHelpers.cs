using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Automation_test.Helpers
{
    class ScrollHelpers
    {
        public static void ScrollTo(IWebDriver driver, int position)
        {
            driver.ExecuteJavaScript($"window.scrollBy(0,{position})");
        }
    }
}
