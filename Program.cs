using System;
using System.Collections.Generic;

namespace SydneyCoffee
{
    class CoffeeOrder
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Reseller { get; set; }
        public double Charge { get; set; }

        public CoffeeOrder(string name, int quantity, string reseller)
        {
            Name = name;
            Quantity = quantity;
            Reseller = reseller;
            CalculateCharge();
        }

        private void CalculateCharge()
        {
            double price;
            if (Quantity <= 5)
            {
                price = 36 * Quantity;
            }
            else if (Quantity <= 15)
            {
                price = 34.5 * Quantity;
            }
            else
            {
                price = 32.7 * Quantity;
            }

            Charge = (Reseller.ToLower() == "yes") ? price * 0.8 : price;
        }
        public void printData() {
            Console.Write("Data");
        }
    }

    class CoffeeShop
    {
        private List<CoffeeOrder> orders;

        public CoffeeShop()
        {
            orders = new List<CoffeeOrder>();
        }

        public void ProcessOrders()
        {
            int n = 2; // Number of orders (you can change this)

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter customer name: ");
                string name = Console.ReadLine();

                int quantity;
                do
                {
                    Console.Write("Enter the number of coffee bags (1kg): ");
                    quantity = Convert.ToInt32(Console.ReadLine());

                    if (quantity < 1 || quantity > 200)
                    {
                        Console.WriteLine("Invalid Input! Please enter a quantity between 1 and 200.");
                    }
                } while (quantity < 1 || quantity > 200);

                Console.Write("Are you a reseller? (yes/no): ");
                string reseller = Console.ReadLine();

                orders.Add(new CoffeeOrder(name, quantity, reseller));
                Console.WriteLine(String.Format("The total sales value from {0} is ${1}", name[i], charge[i]));
                Console.WriteLine("-----------------------------------------------------------------------------");

            }

            DisplaySummary();
        }

        private void DisplaySummary()
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            string minName = "";
            string maxName = "";

            Console.WriteLine("\n\t\t\t\tSummary of Sales\n");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("{0, -15}{1, -10}{2, -10}{3, -10}", "Name", "Quantity", "Reseller", "Charge");
            Console.WriteLine("------------------------------------------------------------");

            foreach (CoffeeOrder order in orders)
            {
                Console.WriteLine("{0, -15}{1, -10}{2, -10}{3, -10}", order.Name, order.Quantity, order.Reseller, order.Charge);
                
                if (order.Charge < min)
                {
                    min = order.Charge;
                    minName = order.Name;
                }

                if (order.Charge > max)
                {
                    max = order.Charge;
                    maxName = order.Name;
                }
            }

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("The customer spending most is {0} (${1})", maxName, max);
            Console.WriteLine("The customer spending least is {0} (${1})", minName, min);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CoffeeShop shop = new CoffeeShop();
            Console.WriteLine("\t\t\tWelcome to Sydney Coffee Program\n");

            shop.ProcessOrders();

            Console.WriteLine("\nPress any key to continue...");
            Console.Read();
        }
    }
}