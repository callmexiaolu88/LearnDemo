using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using CustomBinding.BindingElements;

namespace CustomBinding
{
    public class SimpleDatagramBinding : Binding
    {

        private TransportBindingElement _TransportElement;
        private BindingElementCollection _BindingElements;

        public SimpleDatagramBinding()
        {
            _TransportElement = new HttpTransportBindingElement();
            _BindingElements = new BindingElementCollection();
            BindingElement[] elements = new BindingElement[]{
                new SimpleDatagramBindingElement(),
                new BinaryMessageEncodingBindingElement(),
                _TransportElement,
            };
            _BindingElements = new BindingElementCollection(elements);
            this.Print("SimpleDatagramBinding()");
        }

        public override BindingElementCollection CreateBindingElements()
        {
            //Print("CreateBindingElements");
            //return _BindingElements.Clone();
            return _BindingElements;
        }

        public override string Scheme
        {
            get { return _TransportElement.Scheme; }
        }

        protected void Print(string methodName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0}.{1}", this.GetType().Name, methodName);
            Console.ResetColor();
        }
    }
}
