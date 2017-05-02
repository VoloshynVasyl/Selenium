using NUnit.Framework;
using HotlineTests.Page;

namespace HotlineTests.Test
{
    [TestFixture]
    class Test : Base
    {
        [Test]
        public static void Hotline_SearchOfGoods_UsingSortbyPriceButton_ShouldOpenPageWithMinimalPrice()
        {
            Home home;
            SearchResult searchResult;
            CurrentProduct currentProduct;
            Prices prices;
            SomeShop someShop;
            bool condition = false;
            string searchWord = "MacBook";
            string homeTitleSubstring = "Hotline";

            home = new Home(Driver);
            home.DoSearchByWord(searchWord);
            searchResult = new SearchResult(Driver);
            searchResult.ClickButtonToCompare();
            currentProduct = new CurrentProduct(Driver);
            currentProduct.ClickButtonOfPropositions();
            prices = new Prices(Driver);
            prices.ClickSortByPriceButton();
            prices.GoToTheShop();
            someShop = new SomeShop(Driver);
            condition = someShop.ThisPagesTitleNotContains(homeTitleSubstring);

            Assert.True(condition);
        }

        [Test]
        public static void Hotline_SearchOfGoods_UsingAlgorithmOfSorting_ShouldOpenPageWithMinimalPrice()
        {
            Home home;
            SearchResult searchResult;
            CurrentProduct currentProduct;
            Prices prices;
            SomeShop someShop;
            bool condition = false;
            string searchWord = "Apple MacBook Air";
            string homeTitleSubstring = "Hotline";

            home = new Home(Driver);
            home.DoSearchByWord(searchWord);
            searchResult = new SearchResult(Driver);
            searchResult.ClickButtonToCompare();
            currentProduct = new CurrentProduct(Driver);
            currentProduct.ClickButtonOfPropositions();
            prices = new Prices(Driver);
            prices.GoToShopWithMinimalPrice();
            someShop = new SomeShop(Driver);
            condition = someShop.ThisPagesTitleNotContains(homeTitleSubstring);

            Assert.True(condition);
        }        
    }
}
