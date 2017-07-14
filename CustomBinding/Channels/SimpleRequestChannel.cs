using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomBinding.Channels
{
    class SimpleRequestChannel : SimpleChannelBase, IRequestChannel
    {
        public IRequestChannel InnerRequestChannel { get { return (IRequestChannel)this.InnerChannel; } }

        public SimpleRequestChannel(ChannelManagerBase channelManager, IRequestChannel requestChannel)
            : base(channelManager, (ChannelBase)requestChannel)
        {
            this.Print("SimpleRequestChannel()");
        }

        #region IRequestChannel 成员

        public EndpointAddress RemoteAddress
        {
            get { return this.InnerRequestChannel.RemoteAddress; }
        }

        public Uri Via
        {
            get { return this.InnerRequestChannel.Via; }
        }

        public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("BeginRequest(timeout)");
            return this.InnerRequestChannel.BeginRequest(message, timeout, callback, state);
        }

        public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
        {
            this.Print("BeginRequest()");
            return this.InnerRequestChannel.BeginRequest(message, callback, state);
        }

        public Message EndRequest(IAsyncResult result)
        {
            this.Print("EndRequest()");
            return this.InnerRequestChannel.EndRequest(result);
        }

        public Message Request(Message message, TimeSpan timeout)
        {
            this.Print("Request(timeout)");
            return this.InnerRequestChannel.Request(message, timeout);
        }

        public Message Request(Message message)
        {
            this.Print("Request()");
            return this.InnerRequestChannel.Request(message);
        }

        #endregion
    }
}
