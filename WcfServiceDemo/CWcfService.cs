using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;

namespace WcfServiceDemo
{
    public class CWcfService:IWcfService
    {
        private int _Result = 0;
        public CWcfService()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Service Start.....");
            Console.ResetColor();
        }

        #region IWcfService 成员

        public int GetData()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Get Data:{0}", _Result);
            Console.ResetColor();
            return _Result;
        }

        public void SetData(int p1, int p2)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            _Result = p1 + p2;
            Console.WriteLine("Set Data:{0}+{1}={2}", p1, p2, _Result);
            Console.ResetColor();            
        }

        #endregion
    }
}
