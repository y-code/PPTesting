using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExtension
{
    public class NoWebPageForName : Exception
    {
        public NoWebPageForName(string name) : base(string.Format("There was no web page that can be referred by \"{0}\"", name))
        {
        }
    }
}
