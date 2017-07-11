using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDemo
{
    [MyAopAttribute]
    class Match :ContextBoundObject, IMatch
    {
        public Match(int p1,int p2)
        {

        }

        public Match()
        {

        }

        public int Add(int p1, out int p2)
        {
            Console.WriteLine(Thread.CurrentContext.ContextID);
            p2 = 3;
            return p1 + p2;
        }

        public int Sub(int p1, ref int p2)
        {
            if (p2>0)
            {
                p2 = 100;
                //throw new Exception("This is a Test");
            }
            return p1 - p2;
        }
    }

    public interface IMatch
    {
        int Add(int p1, out int p2);
        int Sub(int p1, ref int p2);
    }
}
