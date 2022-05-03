using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IVending
    {
        void Purchase();
        void ShowAll();
        void InsertMoney();
        void EndTransaction();

    }

}
