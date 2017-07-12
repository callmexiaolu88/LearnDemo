using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfHttpRefCall
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference.WcfServiceClient obj = new ServiceReference.WcfServiceClient();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(obj.GetData());
            obj.SetData(12, 18);
            Console.WriteLine(obj.GetData());
            Console.ResetColor();
            Console.Read();
        }
    }
}
