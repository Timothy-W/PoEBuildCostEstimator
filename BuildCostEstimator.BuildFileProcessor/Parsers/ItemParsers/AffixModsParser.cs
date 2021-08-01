using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers.ItemParsers
{
    public class AffixModsParser : IParser<string>
    {

        private readonly string emptyMods = "[]";
        private readonly string craftedString = "{crafted}";
        private readonly string tagString = "{tags:";
        private readonly string rangeString = "{range:";
        private readonly string variantString = "{variant:";
        private readonly List<string> endOfAffixIndicators = new() {"-", "Corrupted","updated"};


        /// <summary>
        /// Parses XElement for Name of item.
        /// </summary>
        /// <param name="element">XElement with item tag.</param>
        /// <returns>Name of item as string.</returns>
        public string Parse(XElement element)
        {
            bool itemHasVariants = false;

            var eleSplitByLine = element.Value.Trim().Split("\n").Select(x => x.Trim()).ToList();
            var indexOfImplicitLine = eleSplitByLine.FindIndex(x => x.Contains("Implicits: ")); // what if this is not found?

            if (indexOfImplicitLine == -1)
            {
                return emptyMods;
            }

            var implicitLineText = eleSplitByLine[indexOfImplicitLine];

            
            var implicitNumStr = implicitLineText.Replace("Implicits:", "").Trim();

            if (!int.TryParse(implicitNumStr, out var numOfImplicitMods))
            {
                return emptyMods;
            }

      


            var selectedVariantStr = eleSplitByLine.FirstOrDefault(x => x.Contains("Selected Variant:"));
            var selectedVariantVal = "";
            if (selectedVariantStr != null)
            {
                itemHasVariants = true;
                selectedVariantVal = selectedVariantStr.Split(":").Last().Trim();
            }

            var affixStartIndex = indexOfImplicitLine + numOfImplicitMods + 1;
            
            List<string> preFilteredAffixMods = eleSplitByLine.GetRange(affixStartIndex, eleSplitByLine.Count - affixStartIndex);
            List<string> allAffixMods = new List<string>();

            foreach (var mod in preFilteredAffixMods)
            {
                var splitMod = mod.Split(" ");

                if (splitMod.Intersect(endOfAffixIndicators).Any())
                {
                    break;
                }
                allAffixMods.Add(mod);
            }


            if (itemHasVariants)
            {
                allAffixMods = FilterVariants(allAffixMods, selectedVariantVal);
            }





            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            foreach (var mod in allAffixMods)
            {

                sb.Append("\"");
                var affixMod = mod;

                affixMod = HandleCraftedTag(affixMod);
                affixMod = HandleStatTypeTag(affixMod);
                affixMod = RemoveVariantString(affixMod);
                affixMod = HandleRangeTag(affixMod);

                sb.Append(affixMod);

                sb.Append("\"");

                if (!mod.Equals(allAffixMods.Last()))
                {
                    sb.Append(",");
                }

            }

            sb.Append("]");
            return sb.ToString();
        }

        private List<string> FilterVariants(List<string> allImplicitMods, string selectedVariantVal)
        {
            var fullVariantString = variantString + selectedVariantVal + '}';

            List<string> newList = new List<string>();
            
            foreach (var ele in allImplicitMods)
            {
                if (!ele.Contains(variantString) || ele.Split('}').Any(x => x.Contains(variantString) && x.Contains(selectedVariantVal)))
                {
                    newList.Add(ele);
                }
            }

            return newList;
        }



        
        private string HandleRangeTag(string implicitMod)
        {
            if (implicitMod.Contains(rangeString))
            {
                implicitMod = TransformRange(implicitMod);
            }

            return implicitMod;
        }

        private string HandleStatTypeTag(string implicitMod)
        {
            if (implicitMod.Contains(tagString))
            {
                implicitMod = RemoveTagString(implicitMod);
            }

            return implicitMod;
        }

        private string HandleCraftedTag(string implicitMod)
        {
            return implicitMod.Replace(craftedString, "");
        }

        string RemoveTagString(string mod)
        {
            if (!mod.Contains(tagString))
                return mod;

            var startIndex = mod.IndexOf(tagString, StringComparison.Ordinal);
            var endIndex = mod.IndexOf("}", StringComparison.Ordinal);
            var result = mod.Remove(startIndex, endIndex + 1);
            return result;
        }

        string RemoveVariantString(string mod)
        {
            if (!mod.Contains(variantString))
                return mod;

            var startIndex = mod.IndexOf(variantString, StringComparison.Ordinal);
            var endIndex = mod.IndexOf("}", StringComparison.Ordinal);
            var result = mod.Remove(startIndex, endIndex + 1);
            return result;
        }

        // {range:1}(5-7)% increased maximum Life
        // {range:0.5}+(8-12) to all Elemental Resistances
        // {range:0.5}(15-25)%
        // {range:0}Non-Channelling Skills have -(9-8) to Total Mana Cost <-- Might not need to handle <-- Why? <--- ???
        // {range:0.5}75% chance to cause Enemies to Flee on use <-- edge case
        string TransformRange(string mod)
        {
            if (!mod.Contains(rangeString))
                return mod;

            var result = mod.Trim();
            var isAdditiveStat = result.Contains("+") || result.Contains("%");
            
            var rangeValueStr = result.Substring(result.IndexOf('{'), result.IndexOf('}')).Replace(rangeString, ""); ;

            double rangeMultiplier;
            if (!double.TryParse(rangeValueStr, out rangeMultiplier))
            {
                return string.Empty;
            }

            result = result.Remove(result.IndexOf('{'), result.IndexOf('}') + 1);

            if (!result.Contains('('))
            {
                // For whatever reason, no actual range to parse
                // Ex. Lion's Road Granite Flask
                return result;
            }

            var minMaxValuesStr = result.Split('(', ')')[1];
            var minMaxValues = minMaxValuesStr.Split('-');

            var min = int.Parse(minMaxValues[0]);
            var max = int.Parse(minMaxValues[1]);


            double val = max;

            if ((int)rangeMultiplier != 1)
            {
                val = rangeMultiplier * (max - min) + min;
            }

            // There might be an issue where we use ceiling for one calc and floor for another
            // took ceiling of ---> Prefix: {range:0.521}+(80-89) to maximum Life
            // took floor of ---> {range:0.524}-(20-10)% to all Elemental Resistances
            //
            // Maybe ceiling of position stats, floor of negative stats? Ceiling for %?
            // 
            // Need to explore Non-channelling stats and how they are properly calcualted
            //
            //Need more samples
            val = isAdditiveStat ? Math.Ceiling(val) : Math.Floor(val);

            result = result.Replace("(" + minMaxValuesStr + ")", val.ToString());

            return result;
        }

    }
}
