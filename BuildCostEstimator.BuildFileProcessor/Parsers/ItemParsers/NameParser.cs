using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Linq;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers
{
    public class NameParser : IParser<string>
    {
        /// <summary>
        /// Parses XElement for Name of item.
        /// </summary>
        /// <param name="element">XElement with item tag.</param>
        /// <returns>Name of item as string.</returns>
        public string Parse(XElement element)
        {
            var eleSplitByLine =  element.Value.Trim().Split("\n").Select(x => x.Trim()).ToArray();

            var name = eleSplitByLine.ElementAt(1);
            
            // Handles issue with names starting with "^2"
            name = name.Replace("^2", ""); 

            // Not sure how to do this without magic numbers
            return name; 
        }
    }
}
