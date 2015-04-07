using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PPTesting.Gui.WebPage
{
    [Url("/login")]
    class WebPageLogin : WebPage
    {
        [FindsBy(How = How.CssSelector, Using = "#login-box input[name=username]")]
        public IWebElement UserNameInput;

        [FindsBy(How = How.CssSelector, Using = "#login-box input[name=Password]")]
        public IWebElement PasswordInput;

        [FindsBy(How = How.CssSelector, Using = "#login-box input[name=submit]")]
        public IWebElement SubmitButton;

        public void Login(string userName, string password)
        {
            UserNameInput.SendKeys(userName);
            PasswordInput.SendKeys(password);
            SubmitButton.Click();
        }

        public void WaitForPageReady()
        {
            WaitForPageReady(By.Id("login-box"));
        }
    }
}
