using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HotlineTests.Helper
{
    static class Wait
    {
        public const int DEFAULT_TIMEOUT = 20;
        private static IWebElement _element;
        private static WebDriverWait _wait;

        public static void ForElementToBeClickable(IWebDriver driver, By locator)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DEFAULT_TIMEOUT));
            _element = _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
