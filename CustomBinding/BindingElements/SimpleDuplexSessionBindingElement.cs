using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using CustomBinding.ChannelManagers;

namespace CustomBinding.BindingElements
{
    public class SimpleDuplexSessionBindingElement:BindingElement
    {

        public SimpleDuplexSessionBindingElement()
        {
            this.Print("SimpleDuplexSessionBindingElement()");
        }
        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            this.Print("BuildChannelFactory()");
            return new SimpleDuplexSessionChannelFactory<TChannel>(context);
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            this.Print("BuildChannelListener()");
            return new SimpleDuplexSessionChannelListener<TChannel>(context);
        }

        public override BindingElement Clone()
        {
            this.Print("Clone()");
            return new SimpleDuplexSessionBindingElement();
        }

        public override T GetProperty<T>(BindingContext context)
        {
            this.Print("GetProperty()");
            return context.GetInnerProperty<T>();
        }

        protected void Print(string methodName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0}.{1}", this.GetType().Name, methodName);
            Console.ResetColor();
        }
    }
}
