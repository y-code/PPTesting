using System;

namespace SeleniumExtension
{
    [AttributeUsage(AttributeTargets.Field)]
    public class WebElementName : Attribute
    {
        private readonly string _value;

        public WebElementName(string name)
        {
            _value = name;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
