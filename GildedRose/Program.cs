using System;

namespace GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {            
            Inventory inventory = new Inventory();
            
            foreach (var item in inventory.Items)
            {
                Console.WriteLine(item.Name + "... \n");
                Console.WriteLine(item.Quality + "... \n");
                Console.WriteLine(item.SellIn + "... \n");
            }
            
            inventory.UpdateQuality();

            Console.WriteLine("...UPDATING... \n \n");
            
            foreach (var item in inventory.Items)
            {
                Console.WriteLine(item.Name + "... \n");
                Console.WriteLine(item.Quality + "... \n");
                Console.WriteLine(item.SellIn + "... \n");
            }

            Console.ReadKey();
        }
    }
}