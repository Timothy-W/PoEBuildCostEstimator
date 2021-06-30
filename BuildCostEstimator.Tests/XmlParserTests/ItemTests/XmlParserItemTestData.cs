using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using BuildCostEstimator.Models;
using BuildCostEstimator.Tests.XmlParser.ItemTests;

namespace BuildCostEstimator.Tests.XmlParserTests.ItemTests
{
    public class XmlParserItemTestData : IEnumerable<object[]>
    {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Do I really have to put all test cases here?

                #region Abyssus Ezomyte Burgonet

                yield return new object[]
                {
                    new ItemXmlHelper(
                        new Item
                        {
                            Id = 0,
                            Rarity = "Unique",
                            Name = "Abyssus",
                            BaseType = "Ezomyte Burgonet",
                            Influences = "",
                            PobItemId = 4,
                            CostInChaos = 0,
                            ItemLevel = 0,
                            LevelReq = 60,
                            Sockets = "R-R-R-R"
                        },
                        XElement.Parse(
                            "	\t\t<Item variant=\"3\" id=\"4\">\r\n\t\t\tRarity: UNIQUE\r\nAbyssus\r\nEzomyte Burgonet\r\nVariant: Pre 2.2.0\r\nVariant: Pre 3.0.0\r\nVariant: Current\r\nSelected Variant: 3\r\nQuality: 20\r\nSockets: R-R-R-R\r\nLevelReq: 60\r\nImplicits: 0\r\nAdds 40 to 60 Physical Damage to Attacks\r\n{range:0.5}+(20-25) to all Attributes\r\n{variant:1}{range:0.5}+(100-150)% to Melee Critical Strike Multiplier\r\n{variant:2}{range:0.5}+(150-225)% to Melee Critical Strike Multiplier\r\n{variant:3}{range:0.5}+(100-125)% to Melee Critical Strike Multiplier\r\n{range:0.5}(100-120)% increased Armour\r\n{range:0.5}(40-50)% increased Physical Damage taken\r\n\t\t\t<ModRange range=\"0.5\" id=\"2\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"3\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"4\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"5\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"6\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"7\"/>\r\n\t\t</Item>"))
                };

                #endregion

                #region Rare Staff

                yield return new object[]
                {
                    new ItemXmlHelper(
                        new Item
                        {
                            Id = 0,
                            Rarity = "Rare",
                            Name = "SUGGESTED STAFF",
                            BaseType = "Ezomyte Staff",
                            Influences = "Redeemer",
                            PobItemId = 8,
                            CostInChaos = 0,
                            ItemLevel = 0,
                            LevelReq = 62,
                            Sockets = "B-B-B-B-B-B"
                        },
                        XElement.Parse(
                            "	\t\t<Item id=\"8\">\r\n\t\t\tRarity: RARE\r\nSUGGESTED STAFF\r\nEzomyte Staff\r\nRedeemer Item\r\nCrafted: true\r\nPrefix: {range:0.803}LocalIncreasedPhysicalDamagePercent6\r\nPrefix: {range:0.401}LocalAddedPhysicalDamageTwoHand7\r\nPrefix: {range:1}LocalWeaponColdPenetrationInfluence3\r\nSuffix: {range:0.035}LocalCriticalStrikeChance5\r\nSuffix: None\r\nSuffix: None\r\nQuality: 20\r\nSockets: B-B-B-B-B-B\r\nLevelReq: 62\r\nImplicits: 1\r\n+18% Chance to Block Attack Damage while wielding a Staff\r\n50% of Physical Damage Converted to Cold Damage\r\n(This simulates Ice Crash until it is updated in PoB)\r\n150% increased Physical Damage\r\nAdds 25 to 50 Physical Damage\r\n30% increased Critical Strike Chance\r\nAttacks with this Weapon Penetrate 15% Cold Resistance\r\n\t\t</Item>"))
                };

                #endregion

                #region Lion's Roar Granite Flask

                yield return new object[]
                {
                    new ItemXmlHelper(
                        new Item
                        {
                            Id = 0,
                            Rarity = "Unique",
                            Name = "Lion's Roar",
                            BaseType = "Granite Flask",
                            Influences = "",
                            PobItemId = 5,
                            CostInChaos = 0,
                            ItemLevel = 0,
                            LevelReq = 27,
                            Sockets = ""
                        },
                        XElement.Parse("	\t\t<Item variant=\"4\" id=\"5\">\r\n\t\t\tRarity: UNIQUE\r\nLion&apos;s Roar\r\nGranite Flask\r\nVariant: Pre 2.2.0\r\nVariant: Pre 3.0.0\r\nVariant: Pre 3.1.0\r\nVariant: Current\r\nSelected Variant: 4\r\nQuality: 20\r\nLevelReq: 27\r\nImplicits: 0\r\n{variant:1,2,3}Adds Knockback during Flask effect\r\n{variant:4}Adds Knockback to Melee Attacks during Flask effect\r\n{range:0.5}75% chance to cause Enemies to Flee on use\r\n{variant:1}{range:0.5}(70-100)% increased Charges used\r\n{variant:1}30% more Melee Physical Damage during effect\r\n{variant:2}{range:0.5}(30-35)% more Melee Physical Damage during effect\r\n{variant:4,3}{range:0.5}(20-25)% more Melee Physical Damage during effect\r\nKnocks Back Enemies in an Area on Flask use\r\n\t\t\t<ModRange range=\"0.5\" id=\"4\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"5\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"7\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"8\"/>\r\n\t\t</Item>"))
                };

                #endregion

                #region Magic Experimenter's Diamond Flask of Warding

                yield return new object[]
                {
                    new ItemXmlHelper(
                        new Item
                        {
                            PobItemId = 9,
                            Rarity = "Magic",
                            Name = "Experimenter's Diamond Flask of Warding",
                            BaseType = "Diamond Flask",
                            Influences = "",
                            LevelReq = 27,
                            ItemLevel = 0,
                            Sockets = "",
                        },
                        XElement.Parse("	\t\t<Item id=\"9\">\r\n\t\t\tRarity: MAGIC\r\nExperimenter&apos;s Diamond Flask of Warding\r\nCrafted: true\r\nPrefix: {range:1}FlaskIncreasedDuration2\r\nSuffix: {range:0.5}FlaskCurseImmunity1\r\nQuality: 20\r\nLevelReq: 27\r\nImplicits: 0\r\nImmune to Curses during Flask effect\r\nRemoves Curses on use\r\n40% increased Duration\r\n\t\t</Item>"))
                };

                #endregion

            
                #region ^2Crest of Desire

                yield return new object[]
                {
                    new ItemXmlHelper(
                        new Item
                        {
                            Rarity = "Unique",
                            Name = "Crest of Desire",
                            BaseType = "Fluted Bascinet",
                            Influences = "",
                            PobItemId = 1,
                            ItemLevel = 0,
                            LevelReq = 58,
                            Sockets = "G",
                            Id = 0,
                            CostInChaos = 0
                        },
                        XElement.Parse("	\t\t<Item id=\"1\">\r\n\t\t\tRarity: UNIQUE\r\n^2Crest of Desire\r\nFluted Bascinet\r\nLeague: Heist\r\nQuality: 20\r\nSockets: G\r\nLevelReq: 58\r\nImplicits: 0\r\nHas 1 Socket\r\n{range:1}+(5-8) to Level of Socketed Gems\r\n{range:0.5}+(30-50)% to Quality of Socketed Gems\r\nSocketed Skills deal Double Damage\r\n{range:0.5}(100-150)% increased Armour and Evasion\r\n\t\t\t<ModRange range=\"1\" id=\"2\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"3\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"5\"/>\r\n\t\t</Item>"))
                };

                #endregion

            


            }
            
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
   
}
