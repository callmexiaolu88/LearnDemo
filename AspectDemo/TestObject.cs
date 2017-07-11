using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace AspectDemo
{
    [Aspect("LOG")]
    class TestObject : ContextBoundObject
    {
        private string _Name;
        public TestObject(string name)
        {
            _Name = name;
        }

        public void PrintInfo()
        {
            Context context = Thread.CurrentContext;

            Console.WriteLine("{0} in context {1}", _Name, context.ContextID);
        }

        public void GetName()
        {
            CallContext.SetData("name", _Name);
        }

        public void SetName()
        {
            _Name = CallContext.GetData("name") as string;
        }
    }
}
