using System;

namespace GildedRose
{
    public static class Program
    {
        public static void Main()
        {            
            var inventory = new Inventory();
            
            foreach (var item in inventory.Items)
            {
                Console.WriteLine("Item Name: " + item.Name + "\n");
                Console.WriteLine("Item Quality: " + item.Quality + "\n");
                Console.WriteLine("Item SellIn: " + item.SellIn + "\n");
            }
            
            inventory.UpdateQuality();

            Console.WriteLine("\n ...UPDATING... \n \n");
            
            foreach (var item in inventory.Items)
            {
                Console.WriteLine("Item Name: " + item.Name + "\n");
                Console.WriteLine("Item Quality: " + item.Quality + "\n");
                Console.WriteLine("Item SellIn: " + item.SellIn + "\n");
            }

            Console.ReadKey();
        }
    }
}