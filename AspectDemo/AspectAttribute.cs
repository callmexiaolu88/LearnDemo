using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AspectDemo
{
    [AttributeUsageAttribute(AttributeTargets.Class)]
    class AspectAttribute : Attribute, IContextAttribute
    {

        private string _Name;

        public AspectAttribute(string name)
        {
            this._Name = name;
        }

        #region IContextAttribute 成员

        public void GetPropertiesForNewContext(IConstructionCallMessage msg)
        {
            msg.ContextProperties.Add(new ContextProperty(_Name));
        }

        public bool IsContextOK(Context ctx, IConstructionCallMessage msg)
        {
            var result = false;
            if (ctx!=null)
            {
                var prop = ctx.GetProperty(_Name);
                if (prop!=null)
                {
                    result = true;
                }
            }
            
            return result;
        }

        #endregion
    }
}
