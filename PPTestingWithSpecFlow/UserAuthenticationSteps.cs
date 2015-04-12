using System;
using System.Reflection;
using NUnit.Framework;
using SeleniumExtension;
using TechTalk.SpecFlow;

namespace PPTestingWithSpecFlow
{
    [Binding]
    public class UserAuthenticationSteps
    {
        private WebPage _inputWebPage;
        private WebPage _resultWebPage;

        [BeforeTestRun]
        public static void TestSetUp()
        {
            Assembly.Load("PPTesting");
        }

        [Given(@"(.*) is displayed on the browser")]
        public void GivenWebPageIsDisplayedOnTheBrowser(string pageName)
        {
            _inputWebPage = WebPageFactory.CreatePageNamed(pageName);
            _inputWebPage.Open();
            _inputWebPage.WaitForPageReady();
        }

        [When(@"you enter the following inputs")]
        public void WhenYouEnterTheFollowingInputs(Table table)
        {
            foreach (var row in table.Rows)
                foreach (var key in row.Keys)
                _inputWebPage.EnterValueToInputNamed(key, row[key]);
        }

        [When(@"you click (.*)")]
        public void WhenYouClick(string webElementName)
        {
            _inputWebPage.ClickWebElementNamed(webElementName);
        }

        [Then(@"(.*) is displayed on the browser")]
        public void ThenWebPageIsDisplayedOnTheBrowser(string pageName)
        {
            var expectedWebPage = WebPageFactory.CreatePageNamed(pageName);
            Assert.IsTrue(expectedWebPage.IsDisplay());
            if (expectedWebPage.IsDisplay())
                _resultWebPage = WebPageFactory.CreatePageNamed(pageName);
        }

        [Then(@"(.*) says ""(.*)"" on the web page")]
        public void ThenTheMessageIsDisplayed(string webElementName, string message)
        {
            Assert.AreEqual(message, _resultWebPage.GetValueFromWebElementNamed(webElementName));
        }
    }
}
