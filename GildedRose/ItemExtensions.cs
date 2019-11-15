using System.Net;
using System.Runtime.CompilerServices;

namespace GildedRose
{
    public static class ItemExtensions
    {
        private static bool IsLegendary(this Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private static bool DecreasesWithAge(this Item item)
        {
            return !item.IsAgedBrie() && !item.IsBackstagePass();
        }
        
        public static bool IncreasesWithAge(this Item item)
        {
            return item.IsAgedBrie() || item.IsBackstagePass();
        }

        public static bool IsAgedBrie(this Item item)
        {
            return item.Name == "Aged Brie";
        }

        public static void IncreaseAgedBrie(this Item item)
        {
            if (item.SellinIsLessThan(0) && item.IsAgedBrie())
            {
                item.IncreaseQuality();
            }
        }
        private static bool IsBackstagePass(this Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public static void DecreaseQuality(this Item item)
        {
            if (item.CanDecreaseQuality())
            {
                item.Quality -= 1;
            }
        }
        
        public static void DecreaseConjuredQuality(this Item item)
        {
            if (item.CanDecreaseQuality() && item.IsConjured())
            {
                item.Quality -= 1;
            }
        }

        public static bool CanDecreaseQuality(this Item item)
        {
            return item.DecreasesWithAge() && item.QualityIsGreaterThan(0) && !item.IsLegendary();
        }

        public static void IncreaseQuality(this Item item)
        {
            if (item.QualityIsLessThan(50))
            {
                item.Quality += 1;
            }
        }

        private static bool QualityIsGreaterThan(this Item item, int value)
        {
            return item.Quality > value;
        }

        private static bool QualityIsLessThan(this Item item, int value)
        {
            return item.Quality < value;
        }

        public static bool SellinIsLessThan(this Item item, int value)
        {
            return item.SellIn < value;
        }

        public static void DecreaseSellIn(this Item item)
        {
            if (!item.IsLegendary())
            {
                item.SellIn -= 1;
            }
        }

        public static void IncreaseBackstagePassQuality(this Item item)
        {
            if (item.IsBackstagePass() && item.QualityIsLessThan(50))
            {
                if (item.SellinIsLessThan(11))
                {
                    item.IncreaseQuality();
                }

                if (item.SellinIsLessThan(6))
                {
                    item.IncreaseQuality();
                }
            }
        }
        
        public static void ExpireBackstagePass(this Item item)
        {
            if (item.IsBackstagePass())
            {
                item.Quality = 0;
            }
        }

        private static bool IsConjured(this Item item)
        {
            return item.Name.Contains("Conjured");
        }

        public static bool HasExpired(this Item item)
        {
            return item.SellinIsLessThan(0);
        }
    }
}