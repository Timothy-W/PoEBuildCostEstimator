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
    public class ImplicitModsParser : StringParser
    {
        readonly string emptyMods = "[]";
        readonly string craftedString = "{crafted}";
        readonly string tagString = "{tags:";
        readonly string rangeString = "{range:";
        readonly string variantString = "{variant:";

        /// <summary>
        /// Parses XElement for Name of item.
        /// </summary>
        /// <param name="element">XElement with item tag.</param>
        /// <returns>Name of item as string.</returns>
        public override string Parse(XElement element)
        {
            bool itemHasVariants = false;

            var eleSplitByLine = element.Value.Trim().Split("\n").Select(x => x.Trim()).ToList();
            var indexOfImplicitLine = eleSplitByLine.FindIndex(x => x.Contains("Implicits:")); // what if this is not found?

            if (indexOfImplicitLine == -1)
            {
                return emptyMods;
            }

            var implicitLineText = eleSplitByLine[indexOfImplicitLine];


            if (!int.TryParse(implicitLineText.Replace("Implicits:", "").Trim(), out var numOfImplicitMods))
            {
                return emptyMods;
            }

            if (numOfImplicitMods == 0)
            {
                return emptyMods;
            }


            var selectedVariantText = eleSplitByLine.FirstOrDefault(x => x.Contains("Selected Variant:"));
            var selectedVariantVal = "";
            if (selectedVariantText != null)
            {
                itemHasVariants = true;
                selectedVariantVal = selectedVariantText.Split(":").Last().Trim();
            }

            List<string> allImplicitMods = new List<string>();

            for (int i = 0; i < numOfImplicitMods; i++)
            {
                allImplicitMods.Add(eleSplitByLine[indexOfImplicitLine + 1 + i]);
            }

            if (itemHasVariants)
            {
                allImplicitMods = FilterVariants(allImplicitMods, selectedVariantVal);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            foreach (var mod in allImplicitMods)
            {
                sb.Append("\"");
                var implicitMod = mod;

                implicitMod = HandleCraftedTag(implicitMod);
                implicitMod = HandleStatTypeTag(implicitMod);
                implicitMod = RemoveVariantString(implicitMod);
                implicitMod = HandleRangeTag(implicitMod);

                sb.Append(implicitMod);

                sb.Append("\"");

                if (!mod.Equals(allImplicitMods.Last()))
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
        // {range:0}Non-Channelling Skills have -(9-8) to Total Mana Cost <-- Might not need to handle
        string TransformRange(string mod)
        {
            if (!mod.Contains(rangeString))
                return mod;

            var result = mod.Trim();
            var isAdditiveStat = result.Contains("+");
            
            var rangeValueStr = result.Substring(result.IndexOf('{'), result.IndexOf('}')).Replace(rangeString, ""); ;

            double rangeMultiplier;
            if (!double.TryParse(rangeValueStr, out rangeMultiplier))
            {
                return string.Empty;
            }

            result = result.Remove(result.IndexOf('{'), result.IndexOf('}') + 1);

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
            // Maybe ceiling of position stats, floor of negative stats?
            //
            //Need more samples
            val = isAdditiveStat ? Math.Ceiling(val) : Math.Floor(val);

            result = result.Replace("(" + minMaxValuesStr + ")", val.ToString());

            return result;
        }

    }
}
