using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers
{
    public class ImplicitModsParser : IParser<string>
    {

        string emptyMods = "[]";
        string craftedString = "{crafted}";
        string tagString = "{tags:";
        string rangeString = "{range:";
        string variantString = "{variant:";



        /// <summary>
        /// Parses XElement for Name of item.
        /// </summary>
        /// <param name="element">XElement with item tag.</param>
        /// <returns>Name of item as string.</returns>
        public string Parse(XElement element)
        {
            bool itemHasVariants = false;

            var eleSplitByLine = element.Value.Trim().Split("\n").Select(x => x.Trim()).ToList();
            var indexOfImplicitLine = eleSplitByLine.FindIndex(x => x.Contains("Implicits:")); // what if this is not found?

            if (indexOfImplicitLine == -1)
            {
                return emptyMods;
            }

            var implicitLine = eleSplitByLine[indexOfImplicitLine];


            var implicitNumStr = implicitLine.Replace("Implicits:", "").Trim();

            if (!int.TryParse(implicitNumStr, out var numOfImplicitMods))
            {
                return emptyMods;
            }

            if (numOfImplicitMods == 0)
            {
                return emptyMods;
            }


            var selectedVariantStr = eleSplitByLine.FirstOrDefault(x => x.Contains("Selected Variant:"));
            var variantNumStr = "";
            if (selectedVariantStr != null)
            {
                itemHasVariants = true;
                variantNumStr = selectedVariantStr.Split(":").Last().Trim();
            }


            StringBuilder sb = new StringBuilder();
            sb.Append("[" + '"');

            var foundImplicites = 0;
            var index = 0;
            while (foundImplicites != numOfImplicitMods)
            {
                var implicitMod = eleSplitByLine[indexOfImplicitLine + index + 1];

                implicitMod = HandleCraftedTag(implicitMod);

                implicitMod = HandleStatTypeTag(implicitMod);

                if (HandleVariantTag(itemHasVariants, variantNumStr, ref implicitMod, ref index))
                    continue;

                implicitMod = HandleRangeTag(implicitMod);

                sb.Append(implicitMod);
                foundImplicites++;

                if (foundImplicites != numOfImplicitMods)
                {
                    sb.Append("\",\"");
                }

                index++;
            }

            sb.Append('"' + "]");
            return sb.ToString();
        }

        private string HandleRangeTag(string implicitMod)
        {
            if (implicitMod.Contains(rangeString))
            {
                implicitMod = TransformRange(implicitMod);
            }

            return implicitMod;
        }

        private bool HandleVariantTag(bool itemHasVariants, string variantNumStr, ref string implicitMod, ref int index)
        {
            if (itemHasVariants && implicitMod.Contains(variantString))
            {
                if (!implicitMod.Split('}').Any(x => x.Contains(variantString) && x.Contains(variantNumStr)))
                {
                    index++;
                    return true;
                }

                implicitMod = RemoveVariantString(implicitMod);
            }

            return false;
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
                return string.Empty;

            var startIndex = mod.IndexOf(tagString, StringComparison.Ordinal);
            var endIndex = mod.IndexOf("}", StringComparison.Ordinal);
            var result = mod.Remove(startIndex, endIndex + 1);
            return result;
        }

        string RemoveVariantString(string mod)
        {
            if (!mod.Contains(variantString))
                return string.Empty;

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
                return string.Empty;

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
