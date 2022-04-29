using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingManager
    {

        public VendingManager()
        {
            _coinList = new List<int>();
            InitializeCoins(_coinList);
            AvailableItems = new List<Product>();
            InitializeProductList(AvailableItems);
            SelectedItems = new List<Product>();
        }

        internal List<int> _coinList { get; set; }
        internal List<Product> AvailableItems { get; set; }
        internal List<Product> SelectedItems { get; set; }
        private int _insertedAmount { get; set; }

        public void InitializeCoins(List<int> myList)
        {
            myList.Add(1);
            myList.Add(5);
            myList.Add(10);
            myList.Add(20);
            myList.Add(50);
            myList.Add(100);
            myList.Add(500);
            myList.Add(1000);
        }

        private void InitializeProductList(List<Product> myList)
        {
            //Create 3 beverages
            var obj = new Product("Pepsi-Cola", 25, ProductTypes.Beverage);
            myList.Add(obj);
            obj = new Product("Fanta", 20, ProductTypes.Beverage);
            myList.Add(obj);
            obj = new Product("Magnum icecream", 28, ProductTypes.Beverage);
            myList.Add(obj);

            //Create 3 foods
            obj = new Product("Tuna sandwich", 28, ProductTypes.Food);
            myList.Add(obj);
            obj = new Product("Ham sandwichh", 35, ProductTypes.Food);
            myList.Add(obj);
            obj = new Product("Cheese sandwich", 25, ProductTypes.Food);
            myList.Add(obj);

            //Create 3 snacks
            obj = new Product("Chips (onion)", 30, ProductTypes.Snacks);
            myList.Add(obj);
            obj = new Product("Popcorn", 30, ProductTypes.Snacks);
            myList.Add(obj);
            obj = new Product("Kitkat choko bar", 30, ProductTypes.Snacks);
            myList.Add(obj);
        }

        public void DisplayAvailableItems()
        {
            string newName;
            Console.WriteLine("Item no.\t  Name  \t\tPrice");
            foreach (var item in AvailableItems)
            {
                //Make all strings 16 characters long, by adding spaces to the end or cutting them in case they are too long
                newName = MakeToSameSize(item.Name);
                Console.WriteLine("   {0}   \t\t  {1}  \t  {2}", AvailableItems.IndexOf(item) + 1, newName, item.Price);
            }
        }

        internal string MakeToSameSize(string str)
        {
            if (str.Length > 16)
            {
                //Chop it off 
                str = str.Substring(0, 16);
            }
            if (str.Length < 16)
            {
                //Add spaces
                str = str.PadRight(16, ' ');
            }
            return str;
        }

        public int ShowBalance()
        {
            return _insertedAmount;
        }
        public string GetAllCoinTypes()
        {
            string str = "";
            foreach (var item in _coinList)
            {
                str += item.ToString() + ", ";
            }
            //Remove the last comma and space
            str = str.Substring(0, str.Length - 2);

            return str;
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

        public void UpdateSelectedArticles(int articleNo)
        {
            //Add selected item to the list
            Product article = AvailableItems[articleNo - 1];
            if (_insertedAmount >= article.Price)
            {
                SelectedItems.Add(article);
                _insertedAmount -= article.Price;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe item you are trying to buy is too expensive!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void DisplaySelectedArticles()
        {
            Console.Write("\nYour items so far: ");
            foreach (var item in SelectedItems)
            {
                Console.Write("{0}, ", item.Name);
            }
        }

        public void AskForCoins()
        {
            int insertedCoin;
            Console.Write("\nEnter coin (End with 0): ");
            string coinString = Console.ReadLine();

            while (coinString != "0")
            {
                try
                {
                    insertedCoin = int.Parse(coinString);
                    if (_coinList.Contains(insertedCoin))
                    {
                        UpdateInsertedAmount(insertedCoin);
                        DisplayCurrentBalance();
                    }
                    else
                    {
                        Console.WriteLine("Unrecognized coin type! Try again!");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Write a VALID integer number: ");
                }
                Console.Write("Enter coin (End with 0): ");
                coinString = Console.ReadLine();
            }

        }
        public void EndTransaction()
        {
            //If we are to return the change in correct monetary values, we could use modulo operations to detect
            //what kind of change we should return, starting with the biggest values first
            // _coinValues is a list so we better make it into an array first
            int[] coinValuesArr = _coinList.ToArray();

            //We also need to store away how many of each value. We use an array for this.
            int howManyOfThis = 0;

            //We also need an amount to process.
            //The starting value will be the remaining funds to be returned to the user
            //But as we proceed, we will have less and less to convert into valid currencies
            int currentAmountToDistribute = _insertedAmount;

            Console.WriteLine();
            Console.WriteLine("Enjoy your purchase(s), said the vending machine returning {0} kr to you like this:", _insertedAmount);
            //The most significant monetary value is at the end of the array. That's why we pick the array elements in reverse order
            for (int i = coinValuesArr.Length - 1; i >= 0; i--)
            {
                if (currentAmountToDistribute >= coinValuesArr[i])
                {
                    howManyOfThis = currentAmountToDistribute / coinValuesArr[i];
                    Console.WriteLine($"{howManyOfThis} st x {coinValuesArr[i]} kr");
                    currentAmountToDistribute = currentAmountToDistribute % coinValuesArr[i];                   
                }
            }
        }
        public void BuyProducts()
        {
            int selectedArticle;

            Console.Write("\nSelect an article (End with 0): ");
            string articleString = Console.ReadLine();

            while (articleString != "0")
            {
                try
                {
                    selectedArticle = int.Parse(articleString);
                    //We are only goig to allow VALID integer numbers in a range defined by
                    //the total number of existing items inside the vending machine
                    //We are using the method "Count" on the list of items to get the maximum limit
                    //So we are basically saying that we only allow numbers from 1-9 (if the total of items in the list is 9)
                    if (selectedArticle > AvailableItems.Count || selectedArticle < 0)
                    {
                        Console.Write("\nWrite a VALID article number: ");
                    }
                    else
                    {
                        //We need to make a final check to see if the current credit is sufficient to
                        //allow the next purchase

                        UpdateSelectedArticles(selectedArticle);
                        DisplaySelectedArticles();
                        DisplayCurrentCredit();
                        DisplayAvailableItems();
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("\nWrite a VALID article number: ");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("\nArticle number too large: ");
                }
                Console.Write("Select an article (End with 0): ");
                articleString = Console.ReadLine();
            }
        }
    }
}
