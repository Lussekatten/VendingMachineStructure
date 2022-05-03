﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    abstract class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; }
        public int Price { get; }
        public abstract void Examine();
        public abstract void Use();
    }
}
