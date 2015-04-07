using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPTesting.Gui.WebPage
{
    class WebPageFactory
    {
        private static IWebDriver _webDriver;

        public static IWebDriver CurrentWebWebDriver
        {
            get { return _webDriver ?? (_webDriver = new ChromeDriver()); }
        }

        public static T CreatePage<T>() where T : WebPage, new()
        {
            var page = new T();
            page.Initialize(CurrentWebWebDriver);
            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(_webDriver, page);
            return page;
        }
    }
}
