# Welcome to the Guilded Rose kata

## Description

Your task is to add the new feature to our system so that we can begin selling a new category of items.

## Basic Existing Requirements

 - All items have a SellIn value which denotes the number of days we have to sell the item
 - All items have a Quality value which denotes how valuable the item is
 - At the end of each day our system lowers both values for every item

## Specific Existing Requirements

 - Once the sell by date has passed, Quality degrades twice as fast
 - The Quality of an item is never negative
 - "Aged Brie" actually increases in Quality the older it gets
 - The Quality of an item is never more than 50
 - "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
 - "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there    are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert

## New requirement

 - "Conjured" items degrade in Quality twice as fast as normal items

## Special notes
Feel free to make any changes to the UpdateQuality method and add any new code as long as everything still works correctly. However, do not alter the Item class or Items property.

Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
