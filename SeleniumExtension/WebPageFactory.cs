using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumExtension
{
    public class WebPageFactory
    {
        private static IWebDriver _webDriver;

        public static IWebDriver CurrentWebWebDriver
        {
            get { return _webDriver ?? (_webDriver = new ChromeDriver()); }
        }

        public static T CreatePage<T>() where T : WebPage, new()
        {
            var webPage = new T();
            return InitializePage(webPage);
        }

        public static WebPage CreatePageNamed(string webPageName)
        {
            Type webPageType = null;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                webPageType = assembly.GetTypes()
                    .Where(type => type.GetCustomAttributes(typeof(WebPageName), true).Length > 0)
                    .FirstOrDefault(type => type.GetCustomAttributes(typeof(WebPageName), true).Any(name => name.ToString().Equals(webPageName)));
                if (webPageType != null)
                    break;
            }
            if (webPageType == null)
                throw new NoWebPageForName(webPageName);

            var webPage = (WebPage)Activator.CreateInstance(webPageType);
            return InitializePage(webPage);
        }

        private static T InitializePage<T>(T webPage) where T : WebPage
        {
            webPage.Initialize(CurrentWebWebDriver);
            PageFactory.InitElements(_webDriver, webPage);
            return webPage;
        }
    }
}
