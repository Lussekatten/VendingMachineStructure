using System;
using System.Collections.Generic;
using Xunit;

namespace VendingMachine.Test
{
    public class VendingManagerShould
    {
        [Fact]
        public void CheckingExistenceOfListOfCoins()
        {
            //Checks that the list of coins is indeed created
            VendingManager vm = new VendingManager();

            //Assert that the list is not null
            Assert.NotNull(vm._coinList);
        }

        [Fact]
        public void CheckingExistenceOfListOfProducts()
        {
            //Checks that the list of products is indeed created
            VendingManager vm = new VendingManager();

            //Assert that the list is not null
            Assert.NotNull(vm.AvailableItems);
        }

        [Fact]
        public void CheckInitialDataOnCreation_ValidCoins()
        {
            //Checks that the list of coins contains all needed values upon initialization
            //Valid values are: 1,5,10,20,50,100,200,500,1000
            VendingManager vm = new VendingManager();
            
            Assert.Contains(1, vm._coinList);
            Assert.Contains(5, vm._coinList);
            Assert.Contains(10, vm._coinList);
            Assert.Contains(20, vm._coinList);
            Assert.Contains(50, vm._coinList);
            Assert.Contains(100, vm._coinList);
            Assert.Contains(500, vm._coinList);
            Assert.Contains(1000, vm._coinList);
        }

        [Fact]
        public void CheckInitialDataOnCreation_MaxAllowedArticles()
        {
            //Checks if the total number of articles is between 1 and 9
            VendingManager vm = new VendingManager();
            
            //Assert that the list of available items in the machine is between 1 and a maximum of 9
            Assert.InRange(vm.AvailableItems.Count,1,9);

        }

        //Some random condition could also be checked using Assert.True
        [Fact]
        public void CheckInitialDataOnCreation_BooleanCheck01()
        {
            //Checks if the total number of articles is between 1 and 9
            VendingManager vm = new VendingManager();

            //Assert that the list of available items in the machine is between 1 and a maximum of 9
            Assert.True(vm.AvailableItems.Count >0 && vm.AvailableItems.Count < 10);

        }

        [Fact]
        public void CheckingInheritance()
        {
            //Checks if some item in the vending machine is indeed inherited from the Product class
            VendingManager vm = new VendingManager();
            Random rnd = new Random();

            //Pick a number between 1 and 9, since we only have 9 items in the machine
            int myRnd = rnd.Next(0, 9); //since the 9:th element in the list is at index 8

            //Assert that the item that myRnd index points to is of correct type
            Assert.IsAssignableFrom<Product>(vm.AvailableItems[myRnd]);

        }
    }
}
