using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTesting.Gui.WebPage
{
    [AttributeUsage(AttributeTargets.Class)]
    class Url : System.Attribute
    {
        public const string ServerUrl = "http://localhost:8080";

        private readonly string _url;

        public string FullUrl
        {
            get { return ServerUrl + _url; }
        }

        public Url(string url)
        {
            _url = url;
        }
    }
}
