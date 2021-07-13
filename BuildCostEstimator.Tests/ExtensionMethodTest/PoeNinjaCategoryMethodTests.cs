using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using BuildCostEstimator.BuildFileProcessor.Parsers;
using BuildCostEstimator.Models;
using BuildCostEstimator.Tests.XmlParser.ItemTests;
using BuildCostEstimator.Utilities;
using Xunit;

namespace BuildCostEstimator.Tests.ExtensionMethodTest

{
    public class PoeNinjaCategoryMethodTests
    {
        // Test
        [Theory]
        [ClassData(typeof(PoeNinjaCategoryMethodTestData))]
        public void Parse_ShouldReturnCorrectPoeNinjaCategory(PoeNinjaCategoryHelper testCase)
        {
            // Arrange

            string expected = testCase.Category;

            // Act
            string actual = testCase.Item.PoeNinjaCategory();

            // Assert
            Assert.Equal(expected, actual);

        }
    }
    //Helper class
    public class PoeNinjaCategoryHelper
    {
        public PoeNinjaCategoryHelper(Item item, string category)
        {
            Item = item;
            Category = category;
        }

        public Item Item;
        public string Category;
    }

    // Test Cases
    public class PoeNinjaCategoryMethodTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Do I really have to put all test cases here?

            #region Ezomyte Burgonet

            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ezomyte Burgonet" }, "Armour") };

            #endregion

            #region UniqueJewel

            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Small Cluster Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crimson Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Medium Cluster Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Cobalt Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Timeless Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Hypnotic Eye Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Large Cluster Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Murderous Eye Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Prismatic Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Searching Eye Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ghastly Eye Jewel" }, "Jewel") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Viridian Jewel" }, "Jewel") };
            #endregion

            #region UniqueFlask

            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sulphur Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Grand Mana Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bismuth Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ruby Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Amethyst Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Granite Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Diamond Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Topaz Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Quartz Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Stibnite Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Large Hybrid Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Quicksilver Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Greater Mana Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sanctified Mana Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Hallowed Hybrid Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Silver Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sanctified Life Flask" }, "Flask") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sapphire Flask" }, "Flask") };
            #endregion

            #region UniqueWeapon

            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Imperial Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Awl" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Blade" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Meatgrinder" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Karui Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Siege Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Eternal Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Boot Blade" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Driftwood Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Highborn Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sage Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ezomyte Dagger" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Headsman Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Skinning Knife" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Hatchet" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Reaver Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Nightmare Mace" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Harbinger Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vile Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Citadel Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Legion Sword Piece" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Dream Mace" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Void Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Assassin Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Claw" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Dusk Blade" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Serpentine Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Quartz Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Spine Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Prophecy Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Infernal Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Demon's Horn" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Recurve Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Royal Skean" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Infernal Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Goat's Horn" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Corsair Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Elder Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Nailed Fist" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bastard Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Throat Stabber" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Imbued Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Despot Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Blood Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Tyrant's Sekhem" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Opal Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Jade Hatchet" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Jewelled Foil" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Etched Greatsword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Primordial Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ezomyte Blade" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Great Mallet" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Terror Maul" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Lathi" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Tiger Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Midnight Blade" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Rock Breaker" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Labrys" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Shadow Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Grinning Fetish" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Gut Ripper" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Void Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Cutlass" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Elegant Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Hellion's Paw" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Stiletto" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Carved Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Imperial Staff Piece" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Steelhead" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Demon Dagger" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Lion Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sledgehammer" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Shadow Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ezomyte Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ornate Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sabre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Coiled Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Terror Claw" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Rapier" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Opal Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Antique Rapier" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Royal Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Imperial Skean" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Tomahawk" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Maelström Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Woodsplitter" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Timeworn Claw" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Tornado Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Royal Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Legion Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "War Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Military Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Royal Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Slaughter Knife" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Platinum Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Jasper Chopper" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Brass Maul" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Butcher Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Engraved Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crude Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Whalebone Rapier" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ornate Mace" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Poleaxe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ezomyte Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crystal Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Flaying Knife" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Elegant Foil" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Carnal Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ritual Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Blinder" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Gavel" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Steelwood Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Platinum Kris" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Jagged Maul" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crystal Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ranger Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Iron Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Auric Mace" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Fright Claw" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Thresher Claw" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Karui Maul" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Jagged Foil" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bone Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Boot Knife" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Imperial Maul" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Short Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Decimation Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Fiend Dagger" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Long Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Gemstone Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Spiraled Wand" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Death Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Gnarled Branch" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Royal Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ambusher" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Rusted Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Twilight Blade" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Charan's Sword" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Decorative Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Abyssal Axe" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bronze Sceptre" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "War Hammer" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Karui Chopper" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Basket Rapier" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Judgement Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Imperial Claw" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Estoc" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Imperial Bow" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Spiked Club" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Highland Blade" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Iron Staff" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Dread Maul" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Gladius" }, "Weapon") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Cleaver" }, "Weapon") };
            #endregion

            #region UniqueArmour

            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crusader Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ancient Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Iron Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Praetor Crown" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Tricorne" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Wool Shoes" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Rotted Round Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Strapped Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Plank Kite Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Clasped Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Exquisite Leather" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crusader Chainmail" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Serpentscale Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Samnite Helmet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ornate Quiver" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Harlequin Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Eelskin Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Lion Pelt" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Lacquered Buckler" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sacrificial Garb" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Painted Tower Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Branded Kite Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Conjurer Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sharkskin Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Archon Kite Shield Piece" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Compound Spiked Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Wyrmscale Doublet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Archon Kite Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crusader Plate" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Zealot Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Two-Point Arrow Quiver" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Brass Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Clasped Mitts" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Penetrating Arrow Quiver" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Reinforced Greaves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Assassin's Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ironscale Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Serpentscale Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Silk Slippers" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bone Armour" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Murder Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Tarnished Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Triumphant Lamellar" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Titan Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ironscale Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Goliath Greaves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sage's Robe" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Nightmare Bascinet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Soldier Helmet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Shagreen Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Chiming Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Blood Raiment" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Nubuck Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Wrapped Mitts" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Steel Circlet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Golden Plate" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bone Circlet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crimson Round Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Siege Helmet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Plate Vest" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Iron Circlet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Desert Brigandine" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Steel Kite Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Loricated Ringmail" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Gilded Sallet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Baroque Round Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Cutthroat's Garb" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bronze Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Stealth Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Royal Burgonet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ancient Greaves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Legion Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Leather Cap" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sharkskin Tunic" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ebony Tower Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Mesh Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Champion Kite Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "War Buckler" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Studded Round Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Supreme Spiked Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crusader Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Blunt Arrow Quiver Piece" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ursine Pelt" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Close Helmet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sharktooth Arrow Quiver" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Zealot Helmet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Jingling Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ezomyte Burgonet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Destroyer Regalia" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Conquest Chainmail" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Regicide Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sadist Garb" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Mesh Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Plague Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Lacquered Helmet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Regalia" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Iron Hat" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Soldier Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Mind Cage" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Aventail Helmet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Visored Sallet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Burnished Spiked Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Golden Mantle" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Assassin's Mitts" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Leather Hood" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Elegant Ringmail" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Full Dragonscale" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Golden Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Callous Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Steel Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Chain Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Blunt Arrow Quiver" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Rawhide Tower Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Secutor Helm" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Wild Leather" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Teak Round Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Assassin's Garb" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Holy Chainmail" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vine Circlet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Nubuck Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Wool Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Pine Buckler" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Trapper Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Rawhide Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Goliath Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Hydrascale Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Latticed Ringmail" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sentinel Jacket" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Harmonic Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Thorium Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Colossal Tower Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Deerskin Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Coronal Leather" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Spidersilk Robe" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Carnal Armour" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Great Crown" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Destiny Leather" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sinner Tricorne" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Simple Robe" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Cardinal Round Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Deerskin Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Carnal Mitts" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Magistrate Crown" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Spike-Point Arrow Quiver" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Polished Spiked Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Steelscale Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Corrugated Buckler" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Dragonscale Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Wyrmscale Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Titan Greaves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Golden Buckler" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Satin Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Enameled Buckler" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Conjurer Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Fossilised Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Glorious Plate" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Scholar Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ornate Ringmail" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Arcanist Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Murder Mitts" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Astral Plate" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Mirrored Spiked Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ivory Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Solaris Circlet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Titanium Spirit Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Saint's Hauberk" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Savant's Robe" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Raven Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Necromancer Silks" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Cedar Tower Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Strapped Mitts" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Laminated Kite Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bronzescale Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Prophet Crown" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Goathide Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Painted Buckler" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Silken Hood" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Embroidered Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Pinnacle Tower Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bone Helmet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Fire Arrow Quiver" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Riveted Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Strapped Leather" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Deicide Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Iron Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Wyrmscale Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sovereign Spiked Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Buckler" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Scholar's Robe" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sorcerer Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Great Helmet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Shagreen Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Velvet Slippers" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Dragonscale Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Saintly Chainmail" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Lunaris Circlet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sorcerer Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Broadhead Arrow Quiver" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Silk Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ezomyte Tower Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Legion Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Velvet Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Reinforced Tower Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Mosaic Kite Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Hydrascale Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Full Wyrmscale" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Golden Flame" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Buckskin Tunic" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Gladiator Plate" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Goathide Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Fluted Bascinet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Samite Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Bronzescale Gauntlets" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Callous Mask Piece" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Serrated Arrow Quiver" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Antique Greaves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Widowsilk Robe" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Zodiac Leather" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Varnished Coat" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Slink Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Festival Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Carnal Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Tribal Circlet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Riveted Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vaal Mask" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Hubris Circlet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Copper Plate" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Two-Toned Boots" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Slink Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Necromancer Circlet" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Occultist's Vestment" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ezomyte Spiked Shield" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Arcanist Slippers" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Plated Greaves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Full Scale Armour" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Soldier Gloves" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ambush Mitts" }, "Armour") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Lacquered Garb" }, "Armour") };
            #endregion

            #region UniqueAccessory

            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Black Maw Talisman" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Lapis Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Opal Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Greatwolf Talisman" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Jade Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Gold Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Paua Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Gold Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Marble Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Agate Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Heavy Belt" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Steel Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Coral Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Diamond Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Topaz Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Unset Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Citrine Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Two-Stone Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Leather Belt" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Turquoise Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Vanguard Belt" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Ruby Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Studded Belt" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Cloth Belt" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Stygian Vise" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Sapphire Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Amber Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Paua Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Wereclaw Talisman" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Amethyst Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Clutching Talisman" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Rotfeather Talisman" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Cloth Belt Piece" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Rustic Sash" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Moonstone Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Chain Belt" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Prismatic Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Blue Pearl Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Crystal Belt" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Coral Ring" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Onyx Amulet" }, "Accessory") };
            yield return new object[] { new PoeNinjaCategoryHelper(new Item { BaseType = "Iron Ring" }, "Accessory") };
            #endregion
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
