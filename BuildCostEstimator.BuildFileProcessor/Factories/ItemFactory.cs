using System;
using System.Collections;
using BuildCostEstimator.BuildFileProcessor.Builders;
using BuildCostEstimator.BuildFileProcessor.Parsers;
using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using BuildCostEstimator.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Factories
{
    public class ItemFactory : Factory<Item> 
    {

        
        // What is using this item factory? The controller? Anther class used by the controller?
        public ItemFactory()
        {
            // Make more dynamic, maybe with reflection
            stringParsers = new List<IParser<string>>() { new NameParser(), new BaseTypeParser(), new RarityParser(), new SocketsParser(), new InfluencesParser() };
            intParsers = new List<IParser<int>>() { new PobItemIdParser(), new ItemLevelParser(), new LevelReqParser() };
        }




        public override Item CreateObj(XElement itemXElement)
        {
            var newItem = new Item();

            if (stringParsers == null || intParsers == null)
            {
                return newItem;
            }

            //TODO Find a way to combine these foreach loops

            // Iterate over string parsers
            foreach (var parser in stringParsers)
            {
                
                // Grab parser type
                Type parserType = parser.GetType();

                //Find start and ending index of "Parser" then remove it.
                var indexOfParserSubstring = parserType.Name.IndexOf("Parser", StringComparison.Ordinal);
                var parserSubstringLen = "Parser".Length;
                var propName = parserType.Name.Remove(indexOfParserSubstring,parserSubstringLen);

                // Grab property from the class and set its value
                var propInfo = typeof(Item).GetProperty(propName);


                if (propInfo != null)
                {
                    propInfo.SetValue(newItem, parser.Parse(itemXElement));

                }
                
            }

            // Iterate over int parsers
            foreach (var parser in intParsers)
            {
                                
                // Grab parser type
                Type parserType = parser.GetType();

                //Find start and ending index of "Parser" then remove it.
                var indexOfParserSubstring = parserType.Name.IndexOf("Parser", StringComparison.Ordinal);
                var parserSubstringLen = "Parser".Length;
                var propName = parserType.Name.Remove(indexOfParserSubstring,parserSubstringLen);

                // Grab property from the class and set its value
                var propInfo = typeof(Item).GetProperty(propName);


                if (propInfo != null)
                {
                    propInfo.SetValue(newItem, parser.Parse(itemXElement));

                }
            }

            return newItem;
        }

        

    }
}
