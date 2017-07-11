using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;

namespace RemotingService
{
    class MatchManager : MarshalByRefObject, IMatch
    {

        int _AddResult = 0;

        #region IMatch 成员

        public int Add(int p1, int p2)
        {
            _AddResult = p1 + p2;
            Console.WriteLine("M-----------{0}={1}+{2}", _AddResult, p1, p2);
            return _AddResult;
        }

        public int Sub(int p1, int p2)
        {
            var rs = p1 - p2;
            Console.WriteLine("M-----------{0}={1}-{2}| _AddResult={3}", rs, p1, p2, _AddResult);
            return rs;
        }

        #endregion
    }

    class MatchManager1 : MarshalByRefObject, IMatch1
    {

        int _AddResult = 0;

        #region IMatch 成员

        public int Add(int p1, int p2)
        {
            _AddResult = p1 + p2;
            Console.WriteLine("M----1------{0}={1}+{2}", _AddResult, p1, p2);
            return _AddResult;
        }

        public int Sub(int p1, int p2)
        {
            var rs = p1 - p2;
            Console.WriteLine("M----1------{0}={1}-{2}| _AddResult={3}", rs, p1, p2, _AddResult);
            return rs;
        }

        #endregion
    }
}
