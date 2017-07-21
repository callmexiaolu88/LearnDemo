using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CustomBinding;

namespace BindingReplay
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:8888/BindingCreateChannel");
            Binding binding = new SimpleDatagramBinding();
            var localObject = binding.BuildChannelFactory<IRequestChannel>();
            localObject.Open();

            var channel = localObject.CreateChannel(new EndpointAddress(uri));
            channel.Open();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Message message = Message.CreateMessage(binding.MessageVersion, "SetData", "this is a request:" + DateTime.Now);
                Console.WriteLine("Send Data:\n{0}", message.ToString());
                var newMessage = channel.Request(message);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Recive Data:\n{0}", newMessage.ToString());
                Console.ResetColor();
                Thread.Sleep(5000);
            }
        }
    }
}
