using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using InterfaceLib;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace WcfCallDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressHeader header = AddressHeader.CreateAddressHeader("Test", "http://fitsco.com.cn", "Luyulong");
            EndpointAddress address = new EndpointAddress(new Uri("net.pipe://localhost/Services/WcfService"), header);
            Binding bind = new NetNamedPipeBinding();
            ContractDescription contract = ContractDescription.GetContract(typeof(IWcfService));
            ServiceEndpoint endpoint = new ServiceEndpoint(contract, bind, address);
            ClientViaBehavior clientBehavior = new ClientViaBehavior(new Uri("net.pipe://localhost/Services/WcfService1"));
            endpoint.EndpointBehaviors.Add(clientBehavior);
            ChannelFactory<IWcfService> factory = new ChannelFactory<IWcfService>(endpoint);

            var obj = factory.CreateChannel();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(obj.GetData());
            obj.SetData(12, 18);
            Console.WriteLine(obj.GetData());
            Console.ResetColor();
            Console.Read();
        }
    }
}
