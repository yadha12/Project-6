using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6
{
    class Calculating
    {
        double price;

        public double calculatePrice(int amount, Pizza pizzaType)
        {
            price = amount * pizzaType.price;
            return price;
        }

        public double calculatePrice(int amount, Burger burgerType)
        {
            price = amount * burgerType.price;
            return price;
        }

        public double calculatePrice(int amount, Dessert icecreamType)
        {
            price = amount * icecreamType.price;
            return price;
        }

        public void calculatePriceWithToppings()
        {

        }
    }
}
