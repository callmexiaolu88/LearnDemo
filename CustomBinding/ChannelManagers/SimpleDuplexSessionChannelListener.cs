using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using CustomBinding.Channels;

namespace CustomBinding.ChannelManagers
{
    public class SimpleDuplexSessionChannelListener<TChannel> : SimpleChannelListenerBase<TChannel> where TChannel : class,IChannel
    {
        public SimpleDuplexSessionChannelListener(BindingContext context)
            : base(context)
        {
            this.Print("SimpleDuplexSessionChannelListener()");
        }

        protected override TChannel OnAcceptChannel(TimeSpan timeout)
        {
            this.Print("OnAcceptChannel()");
            IDuplexSessionChannel channel = (IDuplexSessionChannel)this.InnerChannelListener.AcceptChannel(timeout);
            return new SimpleDuplexSessionChannel(this, channel) as TChannel;
        }

        protected override TChannel OnEndAcceptChannel(IAsyncResult result)
        {
            this.Print("OnEndAcceptChannel()");
            IDuplexSessionChannel channel = (IDuplexSessionChannel)this.InnerChannelListener.EndAcceptChannel(result);
            return new SimpleDuplexSessionChannel(this, channel) as TChannel;
        }
    }
}
