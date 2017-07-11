using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TestObject obj = new TestObject("Objetc1");
            obj.PrintInfo();
            obj.GetName();
            obj.PrintInfo();
            obj.SetName();
            Console.ReadLine();
        }
    }
}
