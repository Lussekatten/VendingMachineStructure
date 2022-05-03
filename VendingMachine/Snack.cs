using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Snack : Product
    {
        public Snack(string name, int price) : base(name, price)
        {
        }

        public override void Examine()
        {
            Console.WriteLine($"Article name: {Name}, Price: {Price} kr");
        }
        public override void Use()
        {
            Console.WriteLine("Enjoy eating your " + Name);
        }
    }
}
