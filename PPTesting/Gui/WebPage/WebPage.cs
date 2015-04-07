using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PPTesting.Gui.WebPage
{
    abstract class WebPage
    {
        public IWebDriver WebDriver { get; private set; }

        public string Url
        {
            get
            {
                MemberInfo info = this.GetType();
                Url url = (Url) info.GetCustomAttributes(true).FirstOrDefault(att => att is Url);
                if (url == null)
                    return Gui.WebPage.Url.ServerUrl;
                return url.FullUrl;
            }
        }

        public void Initialize(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        protected IWebElement getParent(IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }

        public void WaitForPageReady(By by, int waitTimeInSeconds = 10)
        {
            var wait = new WebDriverWait(WebDriver, new TimeSpan(0, 0, waitTimeInSeconds));
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public void Open()
        {
            WebDriver.Navigate().GoToUrl(Url);
        }
    }
}
