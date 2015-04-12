using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExtension
{
    class WebPageNotDisplayedException : Exception
    {
        public WebPageNotDisplayedException(WebPage webPage) : base("Web browser did not display the expected web page: " + webPage.Url)
        {
        }
    }
}
