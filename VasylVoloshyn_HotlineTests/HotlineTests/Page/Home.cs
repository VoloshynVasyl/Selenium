using OpenQA.Selenium;
using HotlineTests.Helper;

namespace HotlineTests.Page
{
    public class Home
    {
        private const string SEARCH_FIELD = ".//*[@id='searchbox']";
        private By _searchField = By.XPath(SEARCH_FIELD);

        private const string SEARCH_BUTTON = ".//*[@id='doSearch']";
        private By _searchButton = By.XPath(SEARCH_BUTTON);

        private IWebDriver _driver;

        public Home(IWebDriver driver)
        {
            _driver = driver;
        }

        public void TypeSearchWord(string userInput)
        {
            Wait.ForElementToBeClickable(_driver, _searchField);
            _driver.FindElement(_searchField).SendKeys(userInput);
        }

        public void ClickSearchButton()
        {
            Wait.ForElementToBeClickable(_driver, _searchButton);
            _driver.FindElement(_searchButton).Click();
        }

        public void DoSearchByWord(string word)
        {
            TypeSearchWord(word);
            ClickSearchButton();
        }
    }
}
