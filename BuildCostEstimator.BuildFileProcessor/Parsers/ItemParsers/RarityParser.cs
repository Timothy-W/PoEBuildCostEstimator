using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Linq;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers.ItemParsers
{
    public class RarityParser : IParser<string>
    {
        /// <summary>
        /// Parses XElement for rarity of item.
        /// </summary>
        /// <param name="element">XElement with item tag.</param>
        /// <returns>Rarity of item as string.</returns>
        public string Parse(XElement element)
        {
            var elementStrings = element.Value.Trim();
            var eleSplitByLine = elementStrings.Split("\n").Select(x => x.Trim()).ToArray();

            var rarityInCaps = eleSplitByLine.ElementAt(0).Split(" ").ElementAt(1).ToLower();
            var rarity = rarityInCaps.First().ToString().ToUpper() + rarityInCaps.Substring(1);

            return rarity;
        }
    }
}
