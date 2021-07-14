using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildCostEstimator.Models;

namespace BuildCostEstimator.Utilities
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
            //return
            //    "Item Class: Body Armours\r\n"
            //        + "Rarity: Rare\r\n"
            //        + "Skull Guardian\r\n"
            //        + "Crypt Armour\r\n"
            //        + "--------\r\n"
            //        + "Evasion Rating: 339 (augmented)\r\n"
            //        + "Energy Shield: 66 (augmented)\r\n"
            //        + "--------\r\n"
            //        + "Requirements:\r\n"
            //        + "Level: 70\r\n"
            //        + "--------\r\n"
            //        + "Sockets: G-R-B-B-R-B \r\n"
            //        + "--------\r\n"
            //        + "Item Level: 57\r\n"
            //        + "--------\r\n"
            //        + "{ Prefix Modifier \"Opalescent\" (Tier: 6) — Mana }\r\n"
            //        + "+49(45-49) to maximum Mana\r\n"
            //        + "{ Prefix Modifier \"Stalwart\" (Tier: 10) — Life }\r\n"
            //        + "+38(30-39) to maximum Life\r\n"
            //        + "{ Prefix Modifier \"Mosquito's\" (Tier: 6) — Defences }\r\n"
            //        + "10(6-13)% increased Evasion and Energy Shield\r\n"
            //        + "6(6-7)% increased Stun and Block Recovery\r\n"
            //        + "{ Suffix Modifier \"of the Sage\" (Tier: 4) — Attribute }\r\n"
            //        + "+36(33-37) to Intelligence\r\n"
            //        + "{ Suffix Modifier \"of the Yeti\" (Tier: 5) — Elemental, Cold, Resistance }\r\n"
            //        + "+26(24-29)% to Cold Resistance\r\n"
            //        + "{ Suffix Modifier \"of Adamantite Skin\" (Tier: 2) }\r\n"
            //        + "23(23-25)% increased Stun and Block Recovery\r\n"
            //        + "--------\r\n"
            //        + "Corrupted";

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

