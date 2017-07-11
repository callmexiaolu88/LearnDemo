using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using InterfaceLib;

namespace RemotingService
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel tc = new TcpChannel(60003);
            ChannelServices.RegisterChannel(tc, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(MatchManager), "MatchManager", WellKnownObjectMode.SingleCall);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(MatchManager1), "MatchManager1", WellKnownObjectMode.Singleton);

            RemotingConfiguration.ApplicationName = "MatchManager2";
            RemotingConfiguration.RegisterActivatedServiceType(typeof(MatchManager2));

            Console.ReadLine();
        }
    }
}
