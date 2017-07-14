using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using CustomBinding.Channels;

namespace CustomBinding.ChannelManagers
{
    public class SimpleDatagramChannelFactory<TChannel> : SimpleChannelFactoryBase<TChannel>
    {
        public SimpleDatagramChannelFactory(BindingContext context)
            : base(context)
        {
            this.Print("SimpleDatagramChannelFactory()");
        }

        protected override TChannel OnCreateChannel(System.ServiceModel.EndpointAddress address, Uri via)
        {
            this.Print("OnCreateChannel()");
            IRequestChannel channel = this.InnerChannelFactory.CreateChannel(address, via) as IRequestChannel;
            return (TChannel)(object)new SimpleRequestChannel(this, channel);
        }
    }
}
