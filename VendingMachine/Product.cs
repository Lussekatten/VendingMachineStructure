using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    enum ProductTypes
    {
        Beverage,
        Food,
        Snacks
    }

    class Product
    {
        public Product(string name, int price, ProductTypes type)
        {
            Name = name;
            Type = type;
            Price = price;
        }
        public string Name { get; }
        public ProductTypes Type { get;}
        public int Price { get; }
    }
}
