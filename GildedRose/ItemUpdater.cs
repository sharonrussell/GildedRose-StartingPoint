using System.Collections.Generic;

namespace GildedRose
{
    public class ItemUpdater
    {
        public void Update(List<Item> items)
        {
            foreach (var item in items)
            {
                item.DoQualityDecreases();
                item.DoQualityIncreases();
                item.DecreaseSellIn();
                item.ExpireItems();
            }
        }
    }
}