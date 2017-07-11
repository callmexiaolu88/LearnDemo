using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace ProxyDemo
{
    class MyAopAttribute : ProxyAttribute
    {
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            var obj = base.CreateInstance(serverType);
            var realProxy = new MyRealProxy(serverType, obj);
            return (MarshalByRefObject)realProxy.GetTransparentProxy();

        }
    }
}
