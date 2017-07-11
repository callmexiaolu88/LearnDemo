using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ContextDemo
{
    class CusContextAttribute : ContextAttribute
    {
        public CusContextAttribute()
            : base("CusContextAttribute")
        {
            Console.WriteLine("Init CusContext");
        }

        public override bool IsNewContextOK(Context newCtx)
        {
            //return base.IsNewContextOK(newCtx);
            Console.WriteLine("Call IsNewContextOK");
            return true;
        }

        public override void Freeze(Context newContext)
        {
            base.Freeze(newContext);
            Console.WriteLine("Call Freeze");
        }

        public override void GetPropertiesForNewContext(System.Runtime.Remoting.Activation.IConstructionCallMessage ctorMsg)
        {
            base.GetPropertiesForNewContext(ctorMsg);
            Console.WriteLine("Call GetPropertiesForNewContext");
        }

        public override bool IsContextOK(Context ctx, System.Runtime.Remoting.Activation.IConstructionCallMessage ctorMsg)
        {
            return base.IsContextOK(ctx, ctorMsg);
            //Console.WriteLine("Call IsContextOK");
            //return false;
        }

        #region IContributeObjectSink 成员

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new AopMessageSink(nextSink);
        }

        #endregion
    }

    public class AopMessageSink:IMessageSink
    {

        private IMessageSink _NextSink = null;

        public AopMessageSink(IMessageSink nextSink)
        {
            _NextSink = nextSink;
        }

        #region IMessageSink 成员 

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }

        public IMessageSink NextSink
        {
            get { return _NextSink; }
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            //TODO
            Console.WriteLine(msg.GetType());
            return _NextSink.SyncProcessMessage(msg);
        }

        #endregion
    }
}
