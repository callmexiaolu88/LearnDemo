﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CustomBinding.ChannelManagers
{
    public abstract class SimpleChannelListenerBase<TChannel> : ChannelListenerBase<TChannel> where TChannel : class,IChannel
    {

        public IChannelListener<TChannel> InnerChannelListener { get; private set; }

        public SimpleChannelListenerBase(BindingContext context)
        {
            this.Print("SimpleChannelListenerBase()");
            InnerChannelListener = context.BuildInnerChannelListener<TChannel>();
        }

        public override Uri Uri
        {
            get { return this.InnerChannelListener.Uri; }
        }

        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("OnBeginAcceptChannel()");
            return this.InnerChannelListener.BeginAcceptChannel(timeout, callback, state);
        }

        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("OnBeginWaitForChannel()");
            return this.InnerChannelListener.BeginWaitForChannel(timeout, callback, state);
        }

        protected override bool OnEndWaitForChannel(IAsyncResult result)
        {
            this.Print("OnEndWaitForChannel()");
            return this.InnerChannelListener.EndWaitForChannel(result);
        }

        protected override bool OnWaitForChannel(TimeSpan timeout)
        {
            this.Print("OnWaitForChannel()");
            return this.InnerChannelListener.WaitForChannel(timeout);
        }

        protected override void OnAbort()
        {
            this.Print("OnAbort()");
            this.InnerChannelListener.Abort();
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("OnBeginClose()");
            return this.InnerChannelListener.BeginClose(timeout, callback, state);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("OnBeginOpen()");
            return this.InnerChannelListener.BeginOpen(timeout, callback, state);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            this.Print("OnClose()");
            this.InnerChannelListener.Close(timeout);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            this.Print("OnEndClose()");
            this.InnerChannelListener.EndClose(result);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            this.Print("OnEndOpen()");
            this.InnerChannelListener.EndOpen(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.Print("OnOpen()");
            this.InnerChannelListener.Open(timeout);
        }

        protected void Print(string methodName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0}.{1}", this.GetType().Name, methodName);
            Console.ResetColor();
        }

        public override T GetProperty<T>()
        {
            return this.InnerChannelListener.GetProperty<T>();
        }
    }
}
