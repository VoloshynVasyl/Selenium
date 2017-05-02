using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace HotlineTests.Test
{
    public class Base
    {
        public static IWebDriver Driver;
        public const string BASE_URL = "http://hotline.ua";

        [TestFixtureSetUp]
        public void BeforeClass()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void BeforeTest()
        {
            Driver.Navigate().GoToUrl(BASE_URL);
        }

        [TestFixtureTearDown]
        public void AfterClass()
        {
            Driver.Close();
        }
    }
}
