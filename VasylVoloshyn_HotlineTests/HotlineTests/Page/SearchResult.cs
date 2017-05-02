using OpenQA.Selenium;
using HotlineTests.Helper;

namespace HotlineTests.Page
{
    public class SearchResult
    {
        private const string COMPARE = "(.//a[@class='cell but-box g_statistic m_t-10'])";
        private By _compare = By.XPath(COMPARE);

        private IWebDriver _driver;
        private const int DEFAULT = 1;

        public SearchResult(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickButtonToCompare(int buttonIndex = DEFAULT)
        {
            Wait.ForElementToBeClickable(_driver, _compare);
            _driver.FindElement(By.XPath(COMPARE+"["+buttonIndex+"]")).Click();
        }
    }
}
