using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingManager : IVending
    {

        public VendingManager() 
        {
            _coinList = new List<int>();
            InitializeCoins();
            AvailableItems = new List<Product>();
            InitializeProductList();
            SelectedItems = new List<Product>();
        }

        internal List<int> _coinList { get; set; }
        internal List<Product> AvailableItems { get; set; }
        internal List<Product> SelectedItems { get; set; }
        private int _insertedAmount { get; set; }

        public void InitializeCoins()
        {
            _coinList.Add(1);
            _coinList.Add(5);
        }

        private void InitializeProductList()
        {
            //Create snacks
            AvailableItems.Add(new Snack("Chips (onion)", 30));
            AvailableItems.Add(new Snack("Popcorn", 35));
            AvailableItems.Add(new Snack("Kitkat choko bar", 25));           
        }
            //Skapa dryck

            //Create foods


        public void ShowAll()
        {
            
        }
  
        public int ShowBalance()
        {
            return _insertedAmount;
        }
        public string GetAllCoinTypes()
        {
            return "1 kr, 10 kr, ...";
        }

        public void UpdateInsertedAmount(int amount)
        {
            _insertedAmount += amount;
        }

        public void DisplayCurrentBalance()
        {
            Console.WriteLine("You have inserted {0} kr", _insertedAmount);
        }

        public void DisplayCurrentCredit()
        {
            Console.WriteLine("You have {0} kr left", _insertedAmount);
        }   

        public void DisplaySelectedArticles()
        {
            
        }

        public void InsertMoney()
        {

        }
        public void EndTransaction()
        {
            
        }
        public void Purchase()
        {

        }
    }
}
