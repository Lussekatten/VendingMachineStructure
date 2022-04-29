using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingManager vm = new VendingManager();

            Console.Write("\nAvailable coin types are: {0}", vm.GetAllCoinTypes());
            vm.AskForCoins();

            Console.WriteLine("Your balance: {0}",vm.ShowBalance());
            vm.DisplayAvailableItems();

            vm.BuyProducts();

            Console.WriteLine("Enjoy your meal, said the vending machine returning {0} kr to you.", vm.ShowBalance());
            vm.EndTransaction();
            Console.Read();
        }
    }
}
