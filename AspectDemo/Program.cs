using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfServiceDemo;
using InterfaceLib;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace AspectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CWcfService)))
            {
                var header=AddressHeader.CreateAddressHeader("Test","http://fitsco.com.cn","Luyulong");
                EndpointAddress address = new EndpointAddress(new Uri("net.pipe://localhost/Services/WcfService"), header);
                Binding bind = new NetNamedPipeBinding();
                ContractDescription contract=ContractDescription.GetContract(typeof(IWcfService));
                ServiceEndpoint endpoint=new ServiceEndpoint(contract,bind,address);
                endpoint.ListenUri = new Uri("net.pipe://localhost/Services/WcfService1");
                host.AddServiceEndpoint(endpoint);

                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = new Uri("http://localhost/Services/WcfService/Metadata");
                    host.Description.Behaviors.Add(behavior);
                }
                host.Opened += host_Opened;
                host.Opening += host_Opening;
                host.Faulted += host_Faulted;
                host.UnknownMessageReceived += host_UnknownMessageReceived;
                host.Closing += host_Closing;
                host.Closed += host_Closed;
                host.Open();
                Console.ReadLine();
            }            
        }

        static void host_Closed(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Service is closed......");
            Console.ResetColor();
        }

        static void host_Closing(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Service is closing......");
            Console.ResetColor();
        }

        static void host_UnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Service receive unknow data......");
            Console.ResetColor();
        }

        static void host_Faulted(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Comunication object convert error......");
            Console.ResetColor();
        }

        static void host_Opening(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Service is opening......");
            Console.ResetColor();
        }

        static void host_Opened(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Service is opened......");
            Console.ResetColor();
        }
    }
}
