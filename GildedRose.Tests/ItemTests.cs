using System.Linq;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class Tests
    {
        private Inventory _inventory;

        [SetUp]
        public void SetUp()
        {
            _inventory = new Inventory();
        }

        [Test]
        public void WhenADayPasses_QualityDecreases()
        {
            var vest = _inventory.Items.Single(x => x.Name.Equals("+5 Dexterity Vest"));
            var initialVestQuality = vest.Quality;

            _inventory.UpdateQuality();

            Assert.That(initialVestQuality > vest.Quality);
        }

        [Test]
        public void WhenADayPasses_SellInDecreases()
        {
            var vest = _inventory.Items.Single(x => x.Name.Equals("+5 Dexterity Vest"));
            var initialVestSellIn = vest.SellIn;

            _inventory.UpdateQuality();

            Assert.That(initialVestSellIn > vest.SellIn);
        }

        [Test]
        public void OnceTheSellByDateHasPassedQualityDegradesTwiceAsFast()
        {
            var vest = _inventory.Items.Single(x => x.Name.Equals("+5 Dexterity Vest"));
            var initialVestQuality = vest.Quality;
            vest.SellIn = 1;

            _inventory.UpdateQuality();

            var intermediaryVestQuality = vest.Quality;

            _inventory.UpdateQuality();

            var initialDifference = initialVestQuality - intermediaryVestQuality;
            var newDifference = intermediaryVestQuality - vest.Quality;

            Assert.That(newDifference == initialDifference * 2);
        }

        [Test]
        public void TheQualityOfAnItemCannotBeNegative()
        {
            var manaCake = _inventory.Items.Single(x => x.Name.Equals("Conjured Mana Cake"));
            manaCake.Quality = 0;
           
            _inventory.UpdateQuality();

            Assert.That(manaCake.Quality == 0);
        }

        [Test]
        public void AgedBrieShouldIncreaseInQualityAsItAges()
        {
            var agedBrie = _inventory.Items.Single(x => x.Name.Equals("Aged Brie"));
            var initialQuality = agedBrie.Quality;

            _inventory.UpdateQuality();
            var newQuality = agedBrie.Quality;

            Assert.That(initialQuality < newQuality);
        }

        [Test]
        public void TheQualityOfAnItemCannotBeGreaterThan50()
        {
            var agedBrie = _inventory.Items.Single(x => x.Name.Equals("Aged Brie"));
            agedBrie.Quality = 50;

            _inventory.UpdateQuality();

            Assert.That(agedBrie.Quality == 50);
        }

        [Test]
        public void SulfurasShouldNotBeSoldOrDecreaseInQuality()
        {
            var sulfuras = _inventory.Items.Single(x => x.Name.Equals("Sulfuras, Hand of Ragnaros"));
            var initialQuality = sulfuras.Quality;
            var initialSellin = sulfuras.SellIn;

            _inventory.UpdateQuality();

            Assert.That(initialQuality, Is.EqualTo(sulfuras.Quality));
            Assert.That(initialSellin, Is.EqualTo(sulfuras.SellIn));
        }

        [Test]
        public void BackStagePassQualityIncreasesBy2WhenSellInIs10()
        {
            var backStagePass = _inventory.Items.Single(x => x.Name.Equals("Backstage passes to a TAFKAL80ETC concert"));
            var initialQuality = backStagePass.Quality;
            backStagePass.SellIn = 9;

            _inventory.UpdateQuality();

            Assert.That(initialQuality, Is.EqualTo(backStagePass.Quality - 2));
        }

        [Test]
        public void BackStagePassQualityIncreasesBy3WhenSellInIs5()
        {
            var backStagePass = _inventory.Items.Single(x => x.Name.Equals("Backstage passes to a TAFKAL80ETC concert"));
            var initialQuality = backStagePass.Quality;
            backStagePass.SellIn = 4;

            _inventory.UpdateQuality();

            Assert.That(initialQuality, Is.EqualTo(backStagePass.Quality - 3));
        }

        [Test]
        public void BackStagePassQualityDropsTo0WhenSellInIs0()
        {
            var backStagePass = _inventory.Items.Single(x => x.Name.Equals("Backstage passes to a TAFKAL80ETC concert"));
            backStagePass.SellIn = 0;
            _inventory.UpdateQuality();

            Assert.That(backStagePass.Quality, Is.EqualTo(0));
        }

        [Test]
        public void ConjuredItemsDegradeTwiceAsFast()
        {
            var conjuredItem = _inventory.Items.Single(x => x.Name.Equals("Conjured Mana Cake"));
            var initialQuality = conjuredItem.Quality;

            _inventory.UpdateQuality();
            var newQuality = conjuredItem.Quality;

            Assert.That(initialQuality, Is.EqualTo(newQuality + 2));
        }
    }
}
