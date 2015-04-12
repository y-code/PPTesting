using System;

namespace SeleniumExtension
{
    public class NoInputFoundForNameOnWebPage : Exception
    {
        public NoInputFoundForNameOnWebPage(string name, WebPage webPage)
            : base(string.Format("There was no input that can be referred by \"{0}\", on the web page {1}", name, webPage.Url))
        {
        }
    }
}
