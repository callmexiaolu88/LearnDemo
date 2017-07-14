using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using CustomBinding.Channels;

namespace CustomBinding.ChannelManagers
{
    class SimpleDatagramChannelListener<TChannel> : SimpleChannelListenerBase<TChannel> where TChannel:class,IChannel
    {
        public SimpleDatagramChannelListener(BindingContext context)
            : base(context)
        {
            this.Print("SimpleDatagramChannelListener()");
        }

        protected override TChannel OnAcceptChannel(TimeSpan timeout)
        {
            this.Print("OnAcceptChannel()");
            IReplyChannel channel = (IReplyChannel)this.InnerChannelListener.AcceptChannel(timeout);
            return new SimpleReplyChannel(this, channel) as TChannel;
        }

        protected override TChannel OnEndAcceptChannel(IAsyncResult result)
        {
            this.Print("OnEndAcceptChannel()");
            IReplyChannel channel = (IReplyChannel)this.InnerChannelListener.EndAcceptChannel(result);
            return new SimpleReplyChannel(this, channel) as TChannel;
        }
    }
}
