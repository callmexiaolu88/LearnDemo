using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AspectDemo
{
    class ContextProperty : IContextProperty,IContributeObjectSink
    {
        private string _AttributeName;

        public ContextProperty(string name)
        {
            this._AttributeName = name;
        }

        #region IContextProperty 成员

        public void Freeze(Context newContext)
        {
            return;
        }

        public bool IsNewContextOK(Context newCtx)
        {
            return true;
        }

        public string Name
        {
            get { return _AttributeName; }
        }

        #endregion

        #region IContributeObjectSink 成员

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            IMessageSink messageSink = null;
            Type type = Type.GetType(string.Format("AspectDemo.{0}MessageSink",_AttributeName), false, true);
            if (type != null)
            {
                Type interfaceType = type.GetInterface("System.Runtime.Remoting.Messaging.IMessageSink");
                if (interfaceType != null)
                {
                    messageSink = (IMessageSink)Activator.CreateInstance(type,nextSink);
                }
            }
            return messageSink;
        }

        #endregion
    }
}
