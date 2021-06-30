using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers
{
    public class InfluencesParser : IParser<string>
    {
        /// <summary>
        /// Parses XElement for Name of item.
        /// </summary>
        /// <param name="element">XElement with item tag.</param>
        /// <returns>Name of item as string.</returns>
        public string Parse(XElement element)
        {
            HashSet<string> influencesSet = new HashSet<string>()
            {
                {"Crusader Item"},
                {"Hunter Item"  },
                {"Redeemer Item"},
                {"Warlord Item" },
                {"Shaper Item"  },
                {"Elder Item"   } 
            };



            var influences = "";
            var eleSplitByLine =  element.Value.Trim().Split("\n").Select(x => x.Trim()).ToHashSet();

            var intersection = influencesSet.Intersect(eleSplitByLine);

            foreach (var str in intersection)
            {
                influences += str.Remove(str.Length - "Item".Length);
            }   
            
            
            influences = influences.TrimStart().TrimEnd().Replace(" ", ","); 

            // Not sure how to do this without magic numbers
            return influences; 
        }
    }
}
