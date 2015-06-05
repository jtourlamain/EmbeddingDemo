using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFramework;

namespace EmbeddingDemo.Host
{
    public class DemoManager
    {
        private Logic _logic;

        public DemoManager()
        {
            _logic = new Logic();
        }

        public void Run()
        {
            Console.WriteLine(_logic.DoSomething("Demo"));            
        }
    }
}
