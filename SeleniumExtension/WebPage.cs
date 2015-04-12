using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExtension
{
    public abstract class WebPage
    {
        public IWebDriver WebDriver { get; private set; }

        private Dictionary<string, IWebElement> _webElements;

        public Dictionary<string, IWebElement> WebElements
        {
            get { return _webElements ?? (_webElements = InitializeFieldInfos()); }
        }

        public string Url
        {
            get
            {
                Url url = (Url) GetType().GetCustomAttribute(typeof(Url), true);
                return (url != null ? url.FullUrl : SeleniumExtension.Url.ServerUrl);
            }
        }

        public void Initialize(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        private Dictionary<string, IWebElement> InitializeFieldInfos()
        {
            var webElements = new Dictionary<string, IWebElement>(StringComparer.OrdinalIgnoreCase);
            foreach (var field in GetType().GetFields()
                .Where(field => typeof(IWebElement).IsAssignableFrom(field.FieldType) && field.GetCustomAttributes().Any(attribute => attribute is WebElementName)))
                webElements.Add(field.GetCustomAttribute(typeof(WebElementName)).ToString(), field.GetValue(this) as IWebElement);
            return webElements;
        }

        public void EnterValueToInputNamed(string inputName, string value)
        {
            WebElements[inputName].SendKeys(value);
        }

        public void ClickWebElementNamed(string buttonName)
        {
            WebElements[buttonName].Click();
        }

        public string GetValueFromWebElementNamed(string webElementName)
        {
            var webelement = WebElements[webElementName];
            if (webelement.TagName.Equals("input"))
                return webelement.GetAttribute("value");
            return webelement.Text;
        }

        protected IWebElement GetParent(IWebElement element)
        {
            return element.FindElement(By.XPath(".."));
        }

        public void WaitForPageReady(int waitTimeInSeconds = 10)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(waitTimeInSeconds));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState;").Equals("complete"));
            if (!IsDisplay())
                throw new WebPageNotDisplayedException(this);
        }

        public bool IsDisplay()
        {
            var url = WebDriver.ExecuteJavaScript<string>("return document.location.href;");
            // ReSharper disable once LoopCanBePartlyConvertedToQuery because it will break the logic.
            foreach (var separator in new[] { '?', '#' })
            {
                var index = url.IndexOf(separator);
                if (index >= 0)
                    url = url.Substring(0, index);
            }
            return Url == url;
        }

        public void Open()
        {
            WebDriver.Navigate().GoToUrl(Url);
        }
    }
}
