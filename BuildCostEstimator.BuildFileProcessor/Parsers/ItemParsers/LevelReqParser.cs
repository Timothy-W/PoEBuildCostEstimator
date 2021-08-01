using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers.ItemParsers
{
    public class LevelReqParser : IParser<int>
    {
        /// <summary>
        /// Parses XElement for level requirement of item.
        /// </summary>
        /// <param name="element">XElement with item tag.</param>
        /// <returns>Level requirement of item as int.</returns>
        public int Parse(XElement element)
        {
            var elementStrings = element.Value.Trim();
            var eleSplitByLine = elementStrings.Split("\n").Select(x => x.Trim()).ToArray();

            var levelReqString = eleSplitByLine.FirstOrDefault(x => x.Contains("LevelReq"));

            if (levelReqString == null)
            {
                return 0;
            }

            return int.Parse(levelReqString.Split(" ").ElementAt(1));
        }
    }
}
