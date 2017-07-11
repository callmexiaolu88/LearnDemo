using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IMatch
    {
        int Add(int p1, int p2);
        int Sub(int p1, int p2);
    }

    public interface IMatch1
    {
        int Add(int p1, int p2);
        int Sub(int p1, int p2);
    }

    public interface IMatch2
    {
        int Add(int p1, int p2);
        int Sub(int p1, int p2);
    }

    public class MatchManager2 : MarshalByRefObject, IMatch2
    {

        public MatchManager2()
        {

        }

        int _AddResult = 0;

        public MatchManager2(int p1, int p2)
        {
            _AddResult = p1 + p2;
        }

        #region IMatch 成员

        public int Add(int p1, int p2)
        {
            var tmp = _AddResult;
            _AddResult = p1 + p2;
            Console.WriteLine("M----2------{0}={1}+{2}|{3}", _AddResult, p1, p2, tmp);
            return _AddResult;
        }

        public int Sub(int p1, int p2)
        {
            var rs = p1 - p2;
            Console.WriteLine("M----2------{0}={1}-{2}| _AddResult={3}", rs, p1, p2, _AddResult);
            return rs;
        }

        #endregion
    }
}
