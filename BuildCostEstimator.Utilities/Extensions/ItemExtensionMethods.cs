using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BuildCostEstimator.Models;

namespace BuildCostEstimator.Utilities.Extensions
{
    public static class ItemExtensionMethods
    {
        public static string PoeNinjaCategory(this Item item)
        {
            if (item == null)
                return null;

            if (item.BaseType == "Rustic Sash" || item.BaseType == "Leather Belt")
            {
                return "Accessory";
            }


            var itemBaseType = item.BaseType;

            var splitBaseTypeString = itemBaseType.Split(" ").ToHashSet();

            if (splitBaseTypeString.Intersect(StaticDetails.WeaponCategories).Any()) { return "Weapon"; }
            if (splitBaseTypeString.Intersect(StaticDetails.ArmourCategories).Any()) { return "Armour"; }
            if (splitBaseTypeString.Intersect(StaticDetails.AccessoryCategories).Any()) { return "Accessory"; }
           
            if (itemBaseType.Contains("Jewel")) { return "Jewel"; }
            if (itemBaseType.Contains("Flask")) { return "Flask"; }

            

            return "Unknown";

        }

        public static string RawText(this Item item)
        {
            /*

                Item Class: Boots
                Rarity: Rare
                Spirit Urge
                Sharkskin Boots
                --------
                Quality: +20% (augmented)
                Evasion Rating: 268 (augmented)
                --------
                Requirements:
                Level: 68
                Str: 106
                Dex: 151
                --------
                Sockets: G-R-R-G 
                --------
                Item Level: 62
                --------
                50% increased Mana Regeneration Rate if you've cast a Spell Recently (enchant)
                        (Recently refers to the past 4 seconds) (enchant)
                --------
                65% increased Evasion Rating
                15% increased Movement Speed (crafted)
                22% increased Stun and Block Recovery
                +34% to Lightning Resistance
                +23% to Cold Resistance

            
            

                Item Class: Boots
                Rarity: Rare
                Pain Sole
                Vaal Greaves
                --------
                Quality: +20% (augmented)
                Armour: 334 (augmented)
                --------
                Requirements:
                Level: 62
                Str: 117
                --------
                Sockets: R-R-G-R 
                --------
                Item Level: 77
                --------
                120% increased Critical Strike Chance if you haven't Crit Recently
                --------
                32% increased Armour
                +86 to maximum Life
                +43% to Fire Resistance
                +45% to Cold Resistance
                30% increased Movement Speed
                +27% to Lightning Resistance (crafted)

            
             */






            StringBuilder rawText = new StringBuilder();


            #region Name
            rawText.Append($"Item Class: {StaticDetails.ItemClassToRawItemClassName[StaticDetails.BaseTypeToItemClass[item.BaseType]]}\r\n");
            rawText.Append($"Rarity: {item.Rarity}\r\n");
            rawText.Append($"{item.Name}\r\n");

            if (item.BaseType == "Flask")
            {
                rawText.Append($"{item.BaseType}\r\n");
            } else {
                rawText.Append($"{item.BaseType}\r\n");
            }
            
            rawText.Append($"--------\r\n");
            #endregion

            #region Stats
            // some stats not implemented
            //        + "Evasion Rating: 339 (augmented)\r\n"
            //        + "Energy Shield: 66 (augmented)\r\n"
            //        rawText.Append("--------\r\n");
            #endregion
            
            #region Requirements
            rawText.Append("Requirements:\r\n");
            rawText.Append($"Level: {item.LevelReq}\r\n");
            rawText.Append("--------\r\n");
            #endregion

            #region Sockets

            if (item.Sockets != "")
            {
                rawText.Append($"Sockets: {item.Sockets} \r\n"); //        + "Sockets: G-R-B-B-R-B \r\n"
                rawText.Append("--------\r\n");                  //        + "--------\r\n"
            }
      
            
            #endregion

            #region Item Level
            if (item.ItemLevel != 0){
                rawText.Append($"Item Level: {item.ItemLevel}\r\n");
                rawText.Append("--------\r\n");
            }
            #endregion

            #region Implicit Modifiers

            if (item.ImplicitMods != "[]")
            {
                var list = JsonSerializer.Deserialize<List<string>>(item.ImplicitMods);

                foreach (var mod in list)
                {
                    rawText.Append(mod + "\n");
                }
                rawText.Append("--------\r\n");
            }

            #endregion

            #region Prefixes

            //        + "{ Prefix Modifier \"Opalescent\" (Tier: 6) — Mana }\r\n"
            //        + "+49(45-49) to maximum Mana\r\n"
            //        + "{ Prefix Modifier \"Stalwart\" (Tier: 10) — Life }\r\n"
            //        + "+38(30-39) to maximum Life\r\n"
            //        + "{ Prefix Modifier \"Mosquito's\" (Tier: 6) — Defences }\r\n"
            //        + "10(6-13)% increased Evasion and Energy Shield\r\n"
            //        + "6(6-7)% increased Stun and Block Recovery\r\n"


            #endregion

            #region Suffixs

            //        + "{ Suffix Modifier \"of the Sage\" (Tier: 4) — Attribute }\r\n"
            //        + "+36(33-37) to Intelligence\r\n"
            //        + "{ Suffix Modifier \"of the Yeti\" (Tier: 5) — Elemental, Cold, Resistance }\r\n"
            //        + "+26(24-29)% to Cold Resistance\r\n"
            //        + "{ Suffix Modifier \"of Adamantite Skin\" (Tier: 2) }\r\n"
            //        + "23(23-25)% increased Stun and Block Recovery\r\n"
            //        + "--------\r\n"

            #endregion

            #region IsCorrupted

            //if (item.IsCorrupted)
            //{
            //    rawText.Append("Corrupted");
            //}

            #endregion



            return rawText.ToString();
        }
    }
}

