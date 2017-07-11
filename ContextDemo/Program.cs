using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Channels.Tcp;

namespace ContextDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectClass ovj1 = new ObjectClass("ovj1");
            ObjectClassSyn objectSynTwo = new ObjectClassSyn("Syn Mark Object 2");
            ObjectClassSyn objectSynOne = new ObjectClassSyn("Syn Mark Object 1");

            ovj1.GetName();
            objectSynOne.SetName();
            objectSynTwo.GetName();
            ovj1.SetName();
            Console.ReadLine();  
        }

    }
}
