using System;

namespace SeleniumExtension
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Url : Attribute
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
