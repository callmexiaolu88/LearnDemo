using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using InterfaceLib;
using System.Runtime.Remoting.Activation;

namespace RemotingCall
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel tc = new TcpChannel();
            ChannelServices.RegisterChannel(tc, false);
            IMatch m = (IMatch)Activator.GetObject(typeof(IMatch), "tcp://localhost:60003/MatchManager");
            IMatch1 m1 = (IMatch1)Activator.GetObject(typeof(IMatch1), "tcp://localhost:60003/MatchManager1");

            IMatch2 m2 = (IMatch2)Activator.CreateInstance(typeof(MatchManager2), new object[] { 10, 15 },
                new object[] { new UrlAttribute("tcp://localhost:60003/MatchManager2") });

            MatchManager2 m3 = (MatchManager2)Activator.CreateInstance(typeof(MatchManager2), new object[] { 100, 150 },
                new object[] { new UrlAttribute("tcp://localhost:60003/MatchManager2") });

            var value = m.Add(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m.Sub(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m.Add(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m.Sub(randomValue(), randomValue());
            Console.WriteLine(value);

            value = m1.Add(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m1.Sub(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m1.Add(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m1.Sub(randomValue(), randomValue());
            Console.WriteLine(value);

            value = m2.Add(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m2.Sub(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m2.Add(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m2.Sub(randomValue(), randomValue());
            Console.WriteLine(value);

            value = m3.Add(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m3.Sub(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m3.Add(randomValue(), randomValue());
            Console.WriteLine(value);
            value = m3.Sub(randomValue(), randomValue());
            Console.WriteLine(value);

            Console.ReadLine();
        }

        static int randomValue()
        {
            var rm = new Random(DateTime.Now.Millisecond);
            return rm.Next(100);
        }
    }
}
