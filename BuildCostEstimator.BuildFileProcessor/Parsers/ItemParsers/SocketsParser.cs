using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers
{
    public class SocketsParser : IParser<string>
    {
        /// <summary>
        /// Parses XElement for Name of item.
        /// </summary>
        /// <param name="element">XElement with item tag.</param>
        /// <returns>Name of item as string.</returns>
        public string Parse(XElement element)
        {
            var eleSplitByLine =  element.Value.Trim().Split("\n").Select(x => x.Trim()).ToArray();
            string sockets = "";


            foreach (var line in eleSplitByLine)
            {
                if (line.Contains("Sockets"))
                {
                    sockets = line.Remove(0, "Sockets: ".Length).TrimStart().TrimEnd();
                }

            }

            // Not sure how to do this without magic numbers
            return sockets; 
        }
    }
}
