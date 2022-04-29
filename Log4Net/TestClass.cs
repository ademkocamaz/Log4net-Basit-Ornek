using KingAOP;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Log4Net
{
    public class TestClass : IDynamicMetaObjectProvider
    {
        [LoggingAspect]
        public void TestMethod()
        {
            Console.WriteLine("Test Method");
        }

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new AspectWeaver(parameter, this);
        }
    }
}
