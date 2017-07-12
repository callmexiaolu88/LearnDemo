using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        int GetData();

        [OperationContract]
        void SetData(int p1, int p2);
    }
}
