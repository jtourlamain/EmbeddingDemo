using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework
{
    public class Logic
    {
        public string MyLogicValue { get; set; }

        public string DoSomething(string input)
        {
            return string.Format("I did something with {0}", input);
        }
    }
}
