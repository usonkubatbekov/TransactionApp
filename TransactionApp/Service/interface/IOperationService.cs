using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionApp.Service
{
    public interface IOperationService
    {
        void AddTransaction();

        void GetTransaction();
    }
    
}
