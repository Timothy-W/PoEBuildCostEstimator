using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Parsers.ItemParsers
{

    /// <summary>
     /// Parses XElement for base type of item.
     /// </summary>
     /// <param name="element">XElement with item tag.</param>
     /// <returns>Base type of item as string.</returns>
    public class BaseTypeParser : StringParser
    {
        public override string Parse(XElement element)
        {

            //TODO Properly handle Magic and Normal items

            var eleSplitByLine =  element.Value.Trim().Split("\n").Select(x => x.Trim()).ToArray();

            // Not sure how to do this without magic numbers
            var name = eleSplitByLine.ElementAt(1);

            if (name.Contains("Flask"))
            {
                return FlaskBaseType(name);
            }

            var baseType = eleSplitByLine.ElementAt(2);

            // Handle case of "Two-Toned Boots (Armour/Evasion)"
            int index = baseType.IndexOf('(');
            if (index != -1)
                baseType = baseType.Substring(0, index).TrimStart().TrimEnd();



            return baseType; 
        }

        private string FlaskBaseType(string name)
        {
            var wordsInName = name.Split(" ");
            var indexOfWordFlask = Array.FindIndex(wordsInName, x => x == "Flask");
            var flaskType = wordsInName[indexOfWordFlask - 1];


            if (name.Contains("Life") || name.Contains("Mana") || name.Contains("Hybrid"))
            {
                var flaskSize = wordsInName[indexOfWordFlask - 2];

                return flaskSize + " " + flaskType + " "+ "Flask";
            }
            else
            {
                return flaskType + " " + "Flask";
            }
        }
    }
}


/**/