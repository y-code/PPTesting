using System;

namespace SeleniumExtension
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WebPageName : Attribute
    {
        private readonly string _value;

        public WebPageName(string name)
        {
            _value = name;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
