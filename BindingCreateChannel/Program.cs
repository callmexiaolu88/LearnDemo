using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace BindingCreateChannel
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:8888/BindingCreateChannel");
            Binding binding = new BasicHttpBinding();
            var listener = binding.BuildChannelListener<IReplyChannel>(uri);
            listener.Open();

            var channel = listener.AcceptChannel();
            channel.Open();

            while (true)
            {
                var requestContext = channel.ReceiveRequest();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Recive Data:\n{0}", requestContext.RequestMessage.ToString());
                Console.ResetColor();
                Message message = Message.CreateMessage(binding.MessageVersion, "GetData", "this is a replay:"+DateTime.Now);
                requestContext.Reply(message);
                Console.WriteLine("Send Data:\n{0}", message.ToString());
                Console.WriteLine();
            }
        }
    }
}
