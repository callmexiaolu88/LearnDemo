using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using CustomBinding.Channels;

namespace CustomBinding.ChannelManagers
{
    public class SimpleDuplexSessionChannelFactory<TChannel> : SimpleChannelFactoryBase<TChannel>
    {
        public SimpleDuplexSessionChannelFactory(BindingContext context)
            : base(context)
        {
            this.Print("SimpleDuplexSessionChannelFactory()");
        }
        protected override TChannel OnCreateChannel(EndpointAddress address, Uri via)
        {
            this.Print("OnCreateChannel()");
            IDuplexSessionChannel channel = this.InnerChannelFactory.CreateChannel(address, via) as IDuplexSessionChannel;
            return (TChannel)(object)new SimpleDuplexSessionChannel(this, channel);
        }
    }
}
