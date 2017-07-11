using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Web.Mvc;

namespace ProxyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Match mt = new Match();
            Match mt1 = new Match(12,18);
            //var realProxy = new MyRealProxy<IMatch>(mt);
            //var tp = (IMatch)realProxy.GetTransparentProxy();
            
            int p1 = 0;
            int p2 = 10;

            mt.Add(10, out p1);
            mt.Sub(p1, ref p2);

            mt1.Add(p1, out p2);
            mt1.Sub(p1, ref p2);
            Console.ReadLine();
        }
    }
}
