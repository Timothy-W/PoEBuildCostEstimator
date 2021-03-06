using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers.ItemParsers
{
    public class PobItemIdParser : IntParser
    {
        /// <summary>
        /// Parses XElement for PoB item id of item.
        /// </summary>
        /// <param name="element">XElement with item tag.</param>
        /// <returns>PoB item id of item as int.</returns>
        public override int Parse(XElement element)
        {
            // Should never be null
            return int.Parse(element.Attribute("id").Value);
        }
    }
}
