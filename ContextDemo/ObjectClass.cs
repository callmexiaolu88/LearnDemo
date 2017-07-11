using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace ContextDemo
{
    [CusContext]
    class ObjectClass
    {
        public string _Name = string.Empty;
        public ObjectClass(string name)
        {
            _Name = name;
            Context context = Thread.CurrentContext;

            Console.WriteLine("{0} in context {1}", _Name, context.ContextID);
            //输出上下文的所有属性名称  
            foreach (IContextProperty property in context.ContextProperties)
            {
                Console.WriteLine("\tContext Propery: {0}", property.Name);
            }
            
            Console.WriteLine(); 
        }

        public void GetName()
        {
            CallContext.SetData("name", _Name);
            //return _Name;
        }

        public void SetName()
        {
            _Name = CallContext.GetData("name") as string;
            //_Name = name;
        }
    }
}
