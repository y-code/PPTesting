using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtension;

namespace PPTesting.WebPage
{
    [Url("/login")]
    [WebPageName("Login Page")]
    public class WebPageLogin : SeleniumExtension.WebPage
    {
        [FindsBy(How = How.CssSelector, Using = "#login-box input[name=username]")]
        [WebElementName("User Name")]
        public IWebElement UserNameInput;

        [FindsBy(How = How.CssSelector, Using = "#login-box input[name=password]")]
        [WebElementName("Password")]
        public IWebElement PasswordInput;

        [FindsBy(How = How.CssSelector, Using = "#login-box input[name=submit]")]
        [WebElementName("Login Button")]
        public IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#login-box div.msg")]
        [WebElementName("Login Result Message")]
        public IWebElement MessageDiv;

        [FindsBy(How = How.CssSelector, Using = "#login-box div.error")]
        [WebElementName("Login Error Message")]
        public IWebElement ErrorMessageDiv;

    }
}
