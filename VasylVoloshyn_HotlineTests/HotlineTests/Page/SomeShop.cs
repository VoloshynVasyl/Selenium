using OpenQA.Selenium;

namespace HotlineTests.Page
{
    public class SomeShop
    {
        private IWebDriver _driver;

        public SomeShop(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool ThisPagesTitleNotContains(string subString)
        {
            string windowHandleHotline = _driver.WindowHandles[0];
            string windowHandleSomeShop = _driver.WindowHandles[1];
            _driver.SwitchTo().Window(windowHandleHotline).Close();
            _driver.SwitchTo().Window(windowHandleSomeShop);
            
            if (_driver.Title.Contains(subString))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
