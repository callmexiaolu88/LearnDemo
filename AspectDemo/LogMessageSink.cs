using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AspectDemo
{
    class LogMessageSink:IMessageSink
    {

        private IMessageSink _NextSink;

        public LogMessageSink(IMessageSink nextSink)
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
            var callMessage = msg as IMethodCallMessage;
            IMessage returnMessage = null;
            if (callMessage!=null)
            {
                preProcess(callMessage);
            }
            returnMessage=_NextSink.SyncProcessMessage(msg);
            return returnMessage;
        }

        #endregion

        private void preProcess(IMethodCallMessage msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("CallMethod:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\t{0}", msg.MethodName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("(");
            Type[] paramNames = null;
            object[] param = null;
            if (msg.Properties.Contains("__MethodSignature") &&
                msg.Properties.Contains("__Args"))
            {
                paramNames = (Type[])msg.Properties["__MethodSignature"];
                param = (object[])msg.Properties["__Args"];
                if (paramNames.Length > 0 &&
                    paramNames.Length == param.Length)
                {
                    for (int i = 0; i < paramNames.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("{0}:", paramNames[i].Name);
                        Console.Write("{0}", param[i]);
                        if (i != paramNames.Length - 1)
                        {
                            Console.ResetColor();
                            Console.Write(", ");
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(")");
            Console.ResetColor();
        }
    }
}
