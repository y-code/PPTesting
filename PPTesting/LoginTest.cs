using fit;
using OpenQA.Selenium.Support.PageObjects;
using PPTesting.Gui.WebPage;

namespace PPTesting
{
    class LoginTest : ColumnFixture
    {
        public string UserName;
        public string Password;

        public bool IsLogInSuccessful()
        {
            var wpLogin = WebPageFactory.CreatePage<WebPageLogin>();
            wpLogin.WaitForPageReady();
            wpLogin.Open();
            return true;
        }
    }
}
