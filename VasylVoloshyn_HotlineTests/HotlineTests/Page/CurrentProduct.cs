using OpenQA.Selenium;
using HotlineTests.Helper;

namespace HotlineTests.Page
{
    public class CurrentProduct
    {
        private const string ALL_PROPOSITIONS_BUTTON = "(.//a[@class=\"tabs-link g_statistic\"]/b)[2]";
        private By _allPropositionsButton = By.XPath(ALL_PROPOSITIONS_BUTTON);

        private IWebDriver _driver;

        public CurrentProduct(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickButtonOfPropositions()
        {
            Wait.ForElementToBeClickable(_driver, _allPropositionsButton);
            Scroll.ToElement(_driver, _allPropositionsButton);
            _driver.FindElement(_allPropositionsButton).Click();
        }
    }
}
