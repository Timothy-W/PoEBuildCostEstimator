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
                            Sockets = "R-R-R-R",
                            ImplicitMods = "[]"
                            
                        },
                        XElement.Parse(
                            "	\t\t<Item variant=\"3\" id=\"4\">\r\n" +
                            "\t\t\tRarity: UNIQUE\r\n" +
                            "Abyssus\r\n" +
                            "Ezomyte Burgonet\r\n" +
                            "Variant: Pre 2.2.0\r\n" +
                            "Variant: Pre 3.0.0\r\n" +
                            "Variant: Current\r\n" +
                            "Selected Variant: 3\r\n" +
                            "Quality: 20\r\n" +
                            "Sockets: R-R-R-R\r\n" +
                            "LevelReq: 60\r\n" +
                            "Implicits: 0\r\nAdds 40 to 60 Physical Damage to Attacks\r\n{range:0.5}+(20-25) to all Attributes\r\n{variant:1}{range:0.5}+(100-150)% to Melee Critical Strike Multiplier\r\n{variant:2}{range:0.5}+(150-225)% to Melee Critical Strike Multiplier\r\n{variant:3}{range:0.5}+(100-125)% to Melee Critical Strike Multiplier\r\n{range:0.5}(100-120)% increased Armour\r\n{range:0.5}(40-50)% increased Physical Damage taken\r\n\t\t\t<ModRange range=\"0.5\" id=\"2\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"3\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"4\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"5\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"6\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"7\"/>\r\n\t\t</Item>"))
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
                            Sockets = "B-B-B-B-B-B",
                            ImplicitMods = "[\"+18% Chance to Block Attack Damage while wielding a Staff\"]"
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
                            Sockets = "",
                            ImplicitMods = "[]"
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
                            ImplicitMods = "[]",
                            Id = 0,
                            CostInChaos = 0,
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
                            CostInChaos = 0,
                            ImplicitMods = "[]"

                        },
                        XElement.Parse("	\t\t<Item id=\"1\">\r\n\t\t\tRarity: UNIQUE\r\n^2Crest of Desire\r\nFluted Bascinet\r\nLeague: Heist\r\nQuality: 20\r\nSockets: G\r\nLevelReq: 58\r\nImplicits: 0\r\nHas 1 Socket\r\n{range:1}+(5-8) to Level of Socketed Gems\r\n{range:0.5}+(30-50)% to Quality of Socketed Gems\r\nSocketed Skills deal Double Damage\r\n{range:0.5}(100-150)% increased Armour and Evasion\r\n\t\t\t<ModRange range=\"1\" id=\"2\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"3\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"5\"/>\r\n\t\t</Item>"))
                };

                #endregion

                #region Thief's Torment

                yield return new object[]
                {
                    new ItemXmlHelper(
                        new Item
                        {
                            Rarity = "Unique",
                            Name = "Thief's Torment",
                            BaseType = "Prismatic Ring",
                            Influences = "",
                            PobItemId = 48,
                            ItemLevel = 0,
                            LevelReq = 30,
                            Sockets = "",
                            Id = 0,
                            CostInChaos = 0,
                            ImplicitMods = "[\"+9% to all Elemental Resistances\",\"13% increased Quantity of Items found\"]"
                        },
                        XElement.Parse("	\t\t<Item variant=\"4\" id=\"48\">\r\n\t\t\tRarity: UNIQUE\r\nThief&apos;s Torment\r\nPrismatic Ring\r\nVariant: Pre 1.0.0\r\nVariant: Pre 1.1.0\r\nVariant: Pre 2.6.0\r\nVariant: Current\r\nSelected Variant: 4\r\nPrismatic Ring\r\nLevelReq: 30\r\nImplicits: 2\r\n{tags:jewellery_resistance}{variant:1}{range:0.5}+(8-12) to all Elemental Resistances\r\n{tags:jewellery_resistance}{variant:2,3,4}{range:0.5}+(8-10)% to all Elemental Resistances\r\n{variant:1,2}{range:0.5}(15-25)% increased Quantity of Items found\r\n{variant:4,3}{range:0.5}(10-16)% increased Quantity of Items found\r\nCan&apos;t use other Rings\r\n{tags:jewellery_resistance}{variant:1,2,3}{range:0.5}+(8-12)% to all Elemental Resistances\r\n{tags:jewellery_resistance}{variant:4}{range:0.5}+(16-24)% to all Elemental Resistances\r\n{tags:caster}50% reduced Effect of Curses on You\r\n{tags:attack,life}{variant:1,2,3}{range:0.5}+(20-30) Life gained for each Enemy hit by your Attacks\r\n{tags:attack,life}{variant:4}{range:0.5}+(40-60) Life gained for each Enemy hit by your Attacks\r\n{tags:attack,mana}{variant:1,2,3}+15 Mana gained for each Enemy hit by your Attacks\r\n{tags:attack,mana}{variant:4}+30 Mana gained for each Enemy hit by your Attacks\r\n\t\t\t<ModRange range=\"0.5\" id=\"1\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"2\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"3\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"4\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"6\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"7\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"9\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"10\"/>\r\n\t\t</Item>"))
                };

                #endregion

                #region Watcher's Eye

                yield return new object[]
                {
                    new ItemXmlHelper(
                        new Item
                        {
                            Rarity = "Unique",
                            Name = "Watcher's Eye",
                            BaseType = "Prismatic Jewel",
                            Influences = "",
                            PobItemId = 50,
                            ItemLevel = 0,
                            LevelReq = 0,
                            Sockets = "",
                            Id = 0,
                            CostInChaos = 0,
                            ImplicitMods = "[]"
                        },
                        XElement.Parse("\t\t<Item variant=\"83\" variantAlt2=\"0\" variantAlt=\"0\" id=\"50\">\r\n\t\t\tRarity: UNIQUE\r\nWatcher&apos;s Eye\r\nPrismatic Jewel\r\nVariant: Anger: Fire Damage Life Leech\r\nVariant: Anger: Fire Penetration\r\nVariant: Anger: Inc Crit Strike Mult\r\nVariant: Anger: Inc Fire Damage\r\nVariant: Anger: Phys Added As Fire\r\nVariant: Anger: Phys Converted To Fire\r\nVariant: Clarity: Damage Taken From Mana Before Life\r\nVariant: Clarity: Damage Taken Gained As Mana\r\nVariant: Clarity: Mana Added As ES (Pre 3.12.0)\r\nVariant: Clarity: Mana Added As ES\r\nVariant: Clarity: Mana Recovery Rate (Pre 3.12.0)\r\nVariant: Clarity: Mana Recovery Rate\r\nVariant: Clarity: Recover Mana On Skill Use\r\nVariant: Clarity: Red. Mana Cost (Pre 3.8.0)\r\nVariant: Clarity: Red. Mana Cost Non Channelled\r\nVariant: Determination: Additional Armour\r\nVariant: Determination: Additional Block\r\nVariant: Determination: Phys Damage Reduction\r\nVariant: Determination: Red. Extra Damage From Crits\r\nVariant: Determination: Red. Reflected Phys Damage\r\nVariant: Determination: Unaffected By Vulnerability\r\nVariant: Discipline: Additional Spell Block\r\nVariant: Discipline: ES Per Hit\r\nVariant: Discipline: ES Recovery Rate (Pre 3.12.0)\r\nVariant: Discipline: ES Recovery Rate\r\nVariant: Discipline: ES Regen\r\nVariant: Discipline: Faster Start Of Recharge\r\nVariant: Grace: Additional Chance To Evade\r\nVariant: Grace: Blind Enemies When Hit\r\nVariant: Grace: Chance To Dodge\r\nVariant: Grace: Inc Movement Speed\r\nVariant: Grace: Unaffected By Enfeeble\r\nVariant: Haste: Chance To Dodge Spells\r\nVariant: Haste: Cooldown Recovery For Movement Skills\r\nVariant: Haste: Debuffs Expire Faster\r\nVariant: Haste: Gain Onslaught On Kill\r\nVariant: Haste: Gain Phasing\r\nVariant: Haste: Unaffected By Temporal Chains\r\nVariant: Hatred: Added Cold Damage\r\nVariant: Hatred: Additional Crit Strike Chance\r\nVariant: Hatred: Cold Penetration\r\nVariant: Hatred: Inc Cold Damage\r\nVariant: Hatred: Phys Converted To Cold\r\nVariant: Malevolence: Damage Over Time Mult (Pre 3.8.0)\r\nVariant: Malevolence: Damage Over Time Mult\r\nVariant: Malevolence: Life And ES Recovery Rate (Pre 3.12.0)\r\nVariant: Malevolence: Life And ES Recovery Rate\r\nVariant: Malevolence: Unaffected By Bleeding\r\nVariant: Malevolence: Unaffected By Poison\r\nVariant: Malevolence: Your Ailments Deal Damage Faster\r\nVariant: Precision: Cannot Be Blinded\r\nVariant: Precision: Flask Charge On Crit\r\nVariant: Precision: Inc Attack Damage\r\nVariant: Precision: Inc Attack Speed\r\nVariant: Precision: Inc Crit Strike Mult (Pre 3.12.0)\r\nVariant: Precision: Inc Crit Strike Mult\r\nVariant: Pride: Chance For Double Damage\r\nVariant: Pride: Chance To Impale\r\nVariant: Pride: Impale Additional Hits\r\nVariant: Pride: Inc Phys Damage\r\nVariant: Pride: Intimidate On Hit\r\nVariant: Purity Of Elements: Chaos Resistance\r\nVariant: Purity Of Elements: Red. Reflected Ele Damage\r\nVariant: Purity Of Elements: Take Phys As Cold\r\nVariant: Purity Of Elements: Take Phys As Fire\r\nVariant: Purity Of Elements: Take Phys As Lightning\r\nVariant: Purity Of Elements: Unaffected By Ele Weakness\r\nVariant: Purity Of Fire: Immune To Ignite\r\nVariant: Purity Of Fire: Take Phys As Fire\r\nVariant: Purity Of Fire: Unaffected By Burning Ground\r\nVariant: Purity Of Fire: Unaffected By Flammability\r\nVariant: Purity Of Ice: Immune To Freeze\r\nVariant: Purity Of Ice: Take Phys As Ice\r\nVariant: Purity Of Ice: Unaffected By Chilled Ground\r\nVariant: Purity Of Ice: Unaffected By Frostbite\r\nVariant: Purity Of Lightning: Immune To Shock\r\nVariant: Purity Of Lightning: Take Phys As Lightning\r\nVariant: Purity Of Lightning: Unaffected By Conductivity\r\nVariant: Purity Of Lightning: Unaffected By Shocked Ground\r\nVariant: Vitality: Damage Life Leech (Pre 3.12.0)\r\nVariant: Vitality: Damage Life Leech\r\nVariant: Vitality: Flat Life Regen (Pre 3.12.0)\r\nVariant: Vitality: Life Gain Per Hit\r\nVariant: Vitality: Life Recovery From Flasks\r\nVariant: Vitality: Life Recovery Rate (Pre 3.12.0)\r\nVariant: Vitality: Life Recovery Rate\r\nVariant: Vitality: Percent Life Regen\r\nVariant: Wrath: Inc Crit Strike Chance\r\nVariant: Wrath: Inc Lightning Damage\r\nVariant: Wrath: Lightning Damage ES Leech\r\nVariant: Wrath: Lightning Damage Mana Leech (Pre 3.8.0)\r\nVariant: Wrath: Lightning Penetration\r\nVariant: Wrath: Phys Added As Lightning\r\nVariant: Wrath: Phys Converted To Lightning\r\nVariant: Zealotry: Cast Speed\r\nVariant: Zealotry: Consecrated Ground Effect Lingers For Ms After Leaving The Area\r\nVariant: Zealotry: Consecrated Ground Enemy Damage Taken\r\nVariant: Zealotry: Crit Strike Chance Against Enemies On Consecrated Ground\r\nVariant: Zealotry: Crit Strikes Penetrates Ele Resistances\r\nVariant: Zealotry: Gain Arcane Surge For 4 Seconds When You Create Consecrated Ground\r\nVariant: Zealotry: Maximum ES Per Second To Maximum ES Leech Rate\r\nSelected Variant: 83\r\nPrismatic Jewel\r\nHas Alt Variant: true\r\nSelected Alt Variant: 0\r\nHas Alt Variant Two: true\r\nSelected Alt Variant Two: 0\r\nLimited to: 1\r\nImplicits: 0\r\n{range:0.5}(4-6)% increased maximum Energy Shield\r\n{range:0.5}(4-6)% increased maximum Life\r\n{range:0.5}(4-6)% increased maximum Mana\r\n{variant:1}{range:0.5}(1-1.5)% of Fire Damage Leeched as Life while affected by Anger\r\n{variant:2}{range:0.5}Damage Penetrates (10-15)% Fire Resistance while affected by Anger\r\n{variant:3}{range:0.5}+(30-50)% to Critical Strike Multiplier while affected by Anger\r\n{variant:4}{range:0.5}(40-60)% increased Fire Damage while affected by Anger\r\n{variant:5}{range:0.5}Gain (15-25)% of Physical Damage as Extra Fire Damage while affected by Anger\r\n{variant:6}{range:0.5}(25-40)% of Physical Damage Converted to Fire Damage while affected by Anger\r\n{variant:7}{range:0.5}(6-10)% of Damage taken from Mana before Life while affected by Clarity\r\n{variant:8}{range:0.5}(15-20)% of Damage taken while affected by Clarity Recouped as Mana\r\n{variant:9}{range:0.5}Gain (12-18)% of Maximum Mana as Extra Maximum Energy Shield while affected by Clarity\r\n{variant:10}{range:0.5}Gain (6-10)% of Maximum Mana as Extra Maximum Energy Shield while affected by Clarity\r\n{variant:11}{range:0.5}(20-30)% increased Mana Recovery Rate while affected by Clarity\r\n{variant:12}{range:0.5}(10-15)% increased Mana Recovery Rate while affected by Clarity\r\n{variant:13}{range:0.5}(10-15)% chance to Recover 10% of Mana when you use a Skill while affected by Clarity\r\n{variant:14}{range:0.5}-(10-5) to Total Mana Cost of Skills while affected by Clarity\r\n{variant:15}{range:0.5}Non-Channelling Skills have -(10-5) to Total Mana Cost while affected by Clarity\r\n{variant:16}{range:0.5}+(600-1000) to Armour while affected by Determination\r\n{variant:17}{range:0.5}+(5-8)% Chance to Block Attack Damage while affected by Determination\r\n{variant:18}{range:0.5}(5-8)% additional Physical Damage Reduction while affected by Determination\r\n{variant:19}You take (40-60)% reduced Extra Damage from Critical Strikes while affected by Determination\r\n{variant:20}{range:0.5}(40-50)% reduced Reflected Physical Damage taken while affected by Determination\r\n{variant:21}Unaffected by Vulnerability while affected by Determination\r\n{variant:22}{range:0.5}+(5-8)% Chance to Block Spell Damage while affected by Discipline\r\n{variant:23}{range:0.5}+(20-30) Energy Shield gained for each Enemy Hit while affected by Discipline\r\n{variant:24}{range:0.5}(20-30)% increased Energy Shield Recovery Rate while affected by Discipline\r\n{variant:25}{range:0.5}(10-15)% increased Energy Shield Recovery Rate while affected by Discipline\r\n{variant:26}{range:0.5}Regenerate (1.5-2.5)% of Energy Shield per Second while affected by Discipline\r\n{variant:27}{range:0.5}(30-40)% faster start of Energy Shield Recharge while affected by Discipline\r\n{variant:28}{range:0.5}+(5-8)% chance to Evade Attack Hits while affected by Grace\r\n{variant:29}{range:0.5}(30-50)% chance to Blind Enemies which Hit you while affected by Grace\r\n{variant:30}{range:0.5}(6-10)% chance to Dodge Attack Hits while affected by Grace\r\n{variant:31}{range:0.5}(10-15)% increased Movement Speed while affected by Grace\r\n{variant:32}Unaffected by Enfeeble while affected by Grace\r\n{variant:33}{range:0.5}(5-8)% chance to Dodge Spell Hits while affected by Haste\r\n{variant:34}{range:0.5}(30-50)% increased Cooldown Recovery Rate of Movement Skills used while affected by Haste\r\n{variant:35}Debuffs on you expire (15-20)% faster while affected by Haste\r\n{variant:36}You gain Onslaught for 4 seconds on Kill while affected by Haste\r\n{variant:37}You have Phasing while affected by Haste\r\n{variant:38}{range:0.5}Unaffected by Temporal Chains while affected by Haste\r\n{variant:39}{range:0.5}Adds (58-70) to (88-104) Cold Damage while affected by Hatred\r\n{variant:40}{range:0.5}+(1.2-1.8)% to Critical Strike Chance while affected by Hatred\r\n{variant:41}{range:0.5}Damage Penetrates (10-15)% Cold Resistance while affected by Hatred\r\n{variant:42}{range:0.5}(40-60)% increased Cold Damage while affected by Hatred\r\n{variant:43}{range:0.5}(25-40)% of Physical Damage Converted to Cold Damage while affected by Hatred\r\n{variant:44}{range:0.5}+(36-44)% to Damage over Time Multiplier while affected by Malevolence\r\n{variant:45}{range:0.5}+(18-22)% to Damage over Time Multiplier while affected by Malevolence\r\n{variant:46}{range:0.5}(15-20)% increased Recovery rate of Life and Energy Shield while affected by Malevolence\r\n{variant:47}{range:0.5}(8-12)% increased Recovery rate of Life and Energy Shield while affected by Malevolence\r\n{variant:48}Unaffected by Bleeding while affected by Malevolence\r\n{variant:49}Unaffected by Poison while affected by Malevolence\r\n{variant:50}{range:0.5}Damaging Ailments you inflict deal Damage (10-15)% faster while affected by Malevolence\r\n{variant:51}Cannot be Blinded while affected by Precision\r\n{variant:52}Gain a Flask Charge when you deal a Critical Strike while affected by Precision\r\n{variant:53}{range:0.5}(40-60)% increased Attack Damage while affected by Precision\r\n{variant:54}{range:0.5}(10-15)% increased Attack Speed while affected by Precision\r\n{variant:55}{range:0.5}+(30-50)% to Critical Strike Multiplier while affected by Precision\r\n{variant:56}{range:0.5}+(20-30)% to Critical Strike Multiplier while affected by Precision\r\n{variant:57}{range:0.5}(8-12)% chance to deal Double Damage while using Pride\r\n{variant:58}25% chance to Impale Enemies on Hit with Attacks while using Pride\r\n{variant:59}Impales you inflict last 2 additional Hits while using Pride\r\n{variant:60}{range:0.5}(40-60)% increased Attack Physical Damage while using Pride\r\n{variant:61}Your Hits Intimidate Enemies for 4 seconds while you are using Pride\r\n{variant:62}{range:0.5}+(30-50)% to Chaos Resistance while affected by Purity of Elements\r\n{variant:63}{range:0.5}(40-50)% reduced Reflected Elemental Damage taken while affected by Purity of Elements\r\n{variant:64}{range:0.5}(8-12)% of Physical Damage from Hits taken as Cold Damage while affected by Purity of Elements\r\n{variant:65}{range:0.5}(8-12)% of Physical Damage from Hits taken as Fire Damage while affected by Purity of Elements\r\n{variant:66}{range:0.5}(8-12)% of Physical Damage from Hits taken as Lightning Damage while affected by Purity of Elements\r\n{variant:67}Unaffected by Elemental Weakness while affected by Purity of Elements\r\n{variant:68}Immune to Ignite while affected by Purity of Fire\r\n{variant:69}{range:0.5}(6-10)% of Physical Damage from Hits taken as Fire Damage while affected by Purity of Fire\r\n{variant:70}Unaffected by Burning Ground while affected by Purity of Fire\r\n{variant:71}Unaffected by Flammability while affected by Purity of Fire\r\n{variant:72}Immune to Freeze while affected by Purity of Ice\r\n{variant:73}{range:0.5}(6-10)% of Physical Damage from Hits taken as Cold Damage while affected by Purity of Ice\r\n{variant:74}Unaffected by Chilled Ground while affected by Purity of Ice\r\n{variant:75}Unaffected by Frostbite while affected by Purity of Ice\r\n{variant:76}Immune to Shock while affected by Purity of Lightning\r\n{variant:77}{range:0.5}(6-10)% of Physical Damage from Hits taken as Lightning Damage while affected by Purity of Lightning\r\n{variant:78}Unaffected by Conductivity while affected by Purity of Lightning\r\n{variant:79}Unaffected by Shocked Ground while affected by Purity of Lightning\r\n{variant:80}{range:0.5}(1-1.5)% of Damage leeched as Life while affected by Vitality\r\n{variant:81}{range:0.5}(0.8-1.2)% of Damage leeched as Life while affected by Vitality\r\n{variant:82}{range:0.5}Regenerate (100-140) Life per Second while affected by Vitality\r\n{variant:83}{range:1}+(20-30) Life gained for each Enemy Hit while affected by Vitality\r\n{variant:84}{range:0.5}(50-70)% increased Life Recovery from Flasks while affected by Vitality\r\n{variant:85}{range:0.5}(20-30)% increased Life Recovery Rate while affected by Vitality\r\n{variant:86}{range:0.5}(10-15)% increased Life Recovery Rate while affected by Vitality\r\n{variant:87}{range:0.5}Regenerate (1-1.5)% of Life per second while affected by Vitality\r\n{variant:88}{range:0.5}(70-100)% increased Critical Strike Chance while affected by Wrath\r\n{variant:89}{range:0.5}(40-60)% increased Lightning Damage while affected by Wrath\r\n{variant:90}{range:0.5}(1-1.5)% of Lightning Damage is Leeched as Energy Shield while affected by Wrath\r\n{variant:91}{range:0.5}(1-1.5)% of Lightning Damage is Leeched as Mana while affected by Wrath\r\n{variant:92}{range:0.5}Damage Penetrates (10-15)% Lightning Resistance while affected by Wrath\r\n{variant:93}{range:0.5}Gain (15-25)% of Physical Damage as Extra Lightning Damage while affected by Wrath\r\n{variant:94}{range:0.5}(25-40)% of Physical Damage Converted to Lightning Damage while affected by Wrath\r\n{variant:95}{range:0.5}(10-15)% increased Cast Speed while affected by Zealotry\r\n{variant:96}Effects of Consecrated Ground you create while affected by Zealotry Linger for 2 seconds\r\n{variant:97}{range:0.5}Consecrated Ground you create while affected by Zealotry causes enemies to take (8-10)% increased Damage\r\n{variant:98}{range:0.5}(100-120)% increased Critical Strike Chance against Enemies on Consecrated Ground while affected by Zealotry\r\n{variant:99}{range:0.5}Critical Strikes Penetrate (8-10)% of Enemy Elemental Resistances while affected by Zealotry\r\n{variant:100}Gain Arcane Surge for 4 seconds when you create Consecrated Ground while affected by Zealotry\r\n{variant:101}30% increased Maximum total Energy Shield Recovery per second from Leech while affected by Zealotry\r\n\t\t\t<ModRange range=\"0.5\" id=\"1\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"2\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"3\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"4\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"5\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"6\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"7\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"8\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"9\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"10\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"11\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"12\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"13\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"14\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"15\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"16\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"17\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"18\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"19\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"20\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"21\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"23\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"25\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"26\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"27\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"28\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"29\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"30\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"31\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"32\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"33\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"34\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"36\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"37\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"41\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"42\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"43\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"44\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"45\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"46\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"47\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"48\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"49\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"50\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"53\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"56\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"57\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"58\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"59\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"60\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"63\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"65\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"66\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"67\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"68\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"69\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"72\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"76\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"80\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"83\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"84\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"85\"/>\r\n\t\t\t<ModRange range=\"1\" id=\"86\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"87\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"88\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"89\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"90\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"91\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"92\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"93\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"94\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"95\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"96\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"97\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"98\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"100\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"101\"/>\r\n\t\t\t<ModRange range=\"0.5\" id=\"102\"/>\r\n\t\t</Item>"))
                };

                #endregion
                
                #region Agony Trail

                // This is an odd edge case where the xml says there are 2 implicits but its
                // actually one implicit split into two lines
                //
                // trade site shows a carriage return in the implicite listing
                // This implicit is also an enchant, does this only occur on enchnants?
                //
                // Item info is pulled from an actuall item that the characters had, not made in PoB. 
                // Does this occur only on those types of items

                yield return new object[]
                {
                    new ItemXmlHelper(
                        new Item
                        {
                            Rarity = "Rare",
                            Name = "Agony Trail",
                            BaseType = "Dragonscale Boots",
                            Influences = "",
                            PobItemId = 13,
                            ItemLevel = 72,
                            LevelReq = 65,
                            Sockets = "B-B G R",
                            Id = 0,
                            CostInChaos = 0,
                            ImplicitMods = "[\"8% chance to Dodge Spell Hits if you've\",\"taken Spell Damage Recently\"]"

                        },
                        XElement.Parse("	\t\t<Item id=\"13\">\r\n\t\t\tRarity: RARE\r\nAgony Trail\r\nDragonscale Boots\r\nUnique ID: 783c87d635e14193a0f7dca22f03a1d7e20d73a740d8a3bf1bd5e94f7d53fc0f\r\nItem Level: 72\r\nQuality: 0\r\nSockets: B-B G R\r\nLevelReq: 65\r\nImplicits: 2\r\n{crafted}8% chance to Dodge Spell Hits if you&apos;ve\r\ntaken Spell Damage Recently\r\n+28 to Strength\r\n+60 to maximum Life\r\n30% increased Rarity of Items found\r\n+41% to Lightning Resistance\r\n30% increased Movement Speed\r\n5% increased Movement Speed if you haven&apos;t been Hit Recently\r\n\t\t</Item>"))
                };

                #endregion

                #region E. Amulet Agate Amulet

                yield return new object[]
                {
                    new ItemXmlHelper(
                        new Item
                        {
                            Rarity = "Rare",
                            Name = "E. Amulet",
                            BaseType = "Agate Amulet",
                            Influences = "Hunter",
                            PobItemId = 36,
                            ItemLevel = 0,
                            LevelReq = 68,
                            Sockets = "B-B G R",
                            Id = 0,
                            CostInChaos = 0,
                            ImplicitMods = "[\"Allocates Corruption\",\"+24 to Strength and Intelligence\"]"

                        },
                        XElement.Parse("	\t\t<Item id=\"36\">\r\n\t\t\tRarity: RARE\r\nE. Amulet\r\nAgate Amulet\r\nHunter Item\r\nCrafted: true\r\nPrefix: {range:0.574}IncreasedLife7\r\nPrefix: {range:0.5}GlobalChaosGemLevelInfluence1__\r\nPrefix: None\r\nSuffix: {range:0.556}ChaosDamageOverTimeMultiplierInfluence2\r\nSuffix: {range:0.831}LightningResist6\r\nSuffix: {range:1}AllAttributes9_\r\nCatalyst: Fertile\r\nCatalystQuality: 20\r\nQuality: 0\r\nLevelReq: 68\r\nImplicits: 2\r\n{crafted}Allocates Corruption\r\n{tags:attribute}{range:1}+(16-24) to Strength and Intelligence\r\n+35 to all Attributes\r\n+15% to Chaos Damage over Time Multiplier\r\n+90 to maximum Life\r\n+40% to Lightning Resistance\r\n+1 to Level of all Chaos Skill Gems\r\n{tags:resource,mana}{crafted}{range:0}Non-Channelling Skills have -(9-8) to Total Mana Cost\r\n\t\t\t<ModRange range=\"1\" id=\"2\"/>\r\n\t\t\t<ModRange range=\"0\" id=\"8\"/>\r\n\t\t</Item>"))
                };

                #endregion
            }
            
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
   
}
