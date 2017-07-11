using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Services;
using System.Threading;

namespace ProxyDemo
{
    class MyRealProxy:RealProxy
    {
        MarshalByRefObject _Target;
        public MyRealProxy(Type serviceType, MarshalByRefObject target)
            : base(serviceType)
        {
            _Target = target;
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage callMessage = (IMethodCallMessage)msg;
            IMethodReturnMessage returnMessage = null;
            preProcess(callMessage);
            if (msg is IConstructionCallMessage)
            {
                IConstructionCallMessage constructionMessage = (IConstructionCallMessage)msg;
                var realProxy = RemotingServices.GetRealProxy(_Target);
                realProxy.InitializeServerObject(constructionMessage);
                returnMessage = EnterpriseServicesHelper.CreateConstructionReturnMessage(constructionMessage,
                    (MarshalByRefObject)GetTransparentProxy());
            }
            else
            {
                try
                {
                    //returnMessage = RemotingServices.ExecuteMessage(_Target, callMessage);
                    var outArgsCount = callMessage.ArgCount - callMessage.InArgCount;
                    var outArgs = callMessage.Args;
                    object returnValue = callMessage.MethodBase.Invoke(this._Target, outArgs);
                    returnMessage = new ReturnMessage(returnValue, outArgs, outArgsCount,
                        callMessage.LogicalCallContext, callMessage);
                }
                catch (System.Exception ex)
                {
                    returnMessage = new ReturnMessage(ex, callMessage);
                }
            }
            postProcess(returnMessage);
            return returnMessage;
        }

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

        private void postProcess(IMethodReturnMessage msg)
        {
            if (!(msg is IConstructionReturnMessage))
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\tReturn:{0}", msg.ReturnValue);
                if (msg.Exception != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tException:");
                    Console.WriteLine("\t{0}", msg.Exception);
                }
                Console.ResetColor();
            }
        }
    }
}
