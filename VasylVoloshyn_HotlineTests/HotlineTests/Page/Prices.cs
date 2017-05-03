using System;
using OpenQA.Selenium;
using HotlineTests.Helper;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace HotlineTests.Page
{
    public class Prices : CurrentProduct
    {        
        private const string PATH_TO_ALL_PROPOSITIONS = ".//*[@id='gotoshop-price']";
        private By _pathToAllPropositions = By.XPath(PATH_TO_ALL_PROPOSITIONS);

        private const string PATH_TO_ALL_BUTTON_TO_SHOP = "(.//*[@id='gotoshop-price-button'])";
        private By _pathToAllButtonToShop = By.XPath(PATH_TO_ALL_BUTTON_TO_SHOP);

        private const string SORT_BY_PRICE_BUTTON = ".//span[@class=\"sort-by-price\"]/a";
        private By _pathToSortByPriceButton = By.XPath(SORT_BY_PRICE_BUTTON);

        private const string SORT_BY_PRICE_SWITCH = ".//span[@class=\"sort-by-price\"]/a/i";
        private By _pathToSortByPriceSwitch = By.XPath(SORT_BY_PRICE_SWITCH);

        private IWebDriver _driver;
        private const int  DEFAULT = 1;

        public Prices(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ClickSortByPriceButton()
        {
            Wait.ForElementToBeClickable(_driver, _pathToSortByPriceButton);

            Scroll.ToElement(_driver, _pathToSortByPriceButton);
            _driver.FindElement(_pathToSortByPriceButton).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Wait.DEFAULT_TIMEOUT));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(_pathToSortByPriceSwitch));
        }

        public void GoToTheShop(int buttonIndex = DEFAULT)
        {
            Wait.ForElementToBeClickable(_driver, _pathToAllButtonToShop);
            By pathToButton = By.XPath(PATH_TO_ALL_BUTTON_TO_SHOP + "[" + buttonIndex + "]");

            Scroll.ToElement(_driver, pathToButton);
            _driver.FindElement(pathToButton).Click();
        }

        public void GoToShopWithMinimalPrice()
        {
            Wait.ForElementToBeClickable(_driver, _pathToAllPropositions);
            int minimal = FindShopWithMinimalPrice();
            GoToTheShop(minimal);
        }

        private int FindShopWithMinimalPrice()
        {
            IReadOnlyCollection<IWebElement> listOfWebElements = _driver.FindElements(_pathToAllPropositions);
            List<string> listOfElemnts = new List<string>();
            List<string> sortedListOfElements = new List<string>();

            foreach (IWebElement element in listOfWebElements)
            {
                listOfElemnts.Add(element.Text);
                sortedListOfElements.Add(element.Text);
            }

            sortedListOfElements.Sort();
            string minimumValue = sortedListOfElements[0];

            int minimum = listOfElemnts.IndexOf(minimumValue);
            return minimum + 1;            
        }
    }
}
