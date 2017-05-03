using OpenQA.Selenium;
using System.Drawing;

namespace HotlineTests.Helper
{
    public static class Scroll
    {
        public static void ToElement(IWebDriver driver, By by)
        {
            Point coordsOfElem = driver.FindElement(by).Location;
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(" + coordsOfElem.X + ", " + coordsOfElem.Y + ");");
        }
    }
}
