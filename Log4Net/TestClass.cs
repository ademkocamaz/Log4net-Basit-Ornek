using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net
{
    public class TestClass
    {
        [LogAspect(typeof(FileLogger))]
        public void TestMethod()
        {
            Console.WriteLine("Test Method");
        }
    }
}
