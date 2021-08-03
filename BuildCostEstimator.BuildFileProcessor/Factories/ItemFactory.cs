using System;
using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using BuildCostEstimator.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using BuildCostEstimator.BuildFileProcessor.Parsers.ItemParsers;

namespace BuildCostEstimator.BuildFileProcessor.Factories
{
    public class ItemFactory : Factory<Item>
    {
    

        // What is using this item factory? The controller? Anther class used by the controller?
        public ItemFactory()
        {
            // Make more dynamic, maybe with reflection
            StringParsers = new List<IParser<string>>() { new NameParser(), new BaseTypeParser(), new RarityParser(), new SocketsParser(), new InfluencesParser(), new ImplicitModsParser(), new AffixModsParser() };
            IntParsers = new List<IParser<int>>() { new PobItemIdParser(), new ItemLevelParser(), new LevelReqParser(), new IsCorruptedParser() };
            
        }

        public override async Task<Item> CreateObjAsync(XElement itemXElement)
        {
            var newItem = new Item();

            if (StringParsers == null || IntParsers == null)
            {
                return newItem;
            }

            //TODO Find a way to combine these foreach loops

            // String parse tasks
            var affixModsParserTask = new AffixModsParser().ParseAsync(itemXElement);
            var implicitModsParserTask = new ImplicitModsParser().ParseAsync(itemXElement);
            var influencesParserTask = new InfluencesParser().ParseAsync(itemXElement);
            var nameParserTask = new NameParser().ParseAsync(itemXElement);
            var baseTypeParserTask = new BaseTypeParser().ParseAsync(itemXElement);
            var rarityParserTask = new RarityParser().ParseAsync(itemXElement);
            var socketsParserTask = new SocketsParser().ParseAsync(itemXElement);

            //Int parse tasks
            var pobItemIdParserTask = new PobItemIdParser().ParseAsync(itemXElement);
            var itemLevelParserTask = new ItemLevelParser().ParseAsync(itemXElement);
            var levelReqParserTask = new LevelReqParser().ParseAsync(itemXElement);
            var isCorruptedParserTask = new IsCorruptedParser().ParseAsync(itemXElement);

            await Task.WhenAll(nameParserTask, baseTypeParserTask, rarityParserTask, 
                socketsParserTask, influencesParserTask, implicitModsParserTask, affixModsParserTask, 
                pobItemIdParserTask, itemLevelParserTask, levelReqParserTask, isCorruptedParserTask);


            return new Item()
            {
                Name = nameParserTask.Result,
                BaseType = baseTypeParserTask.Result,
                Rarity = rarityParserTask.Result,
                Sockets = socketsParserTask.Result,
                Influences = influencesParserTask.Result,
                ImplicitMods = implicitModsParserTask.Result,
                AffixMods = affixModsParserTask.Result,
                 
                PobItemId = pobItemIdParserTask.Result,
                ItemLevel = itemLevelParserTask.Result,
                LevelReq = levelReqParserTask.Result,
                IsCorrupted = isCorruptedParserTask.Result,
            };
   
        }

        public override Item CreateObj(XElement itemXElement)
        {
            var newItem = new Item();

            if (StringParsers == null || IntParsers == null)
            {
                return newItem;
            }

            //TODO Find a way to combine these foreach loops

            // Iterate over string parsers
            foreach (var parser in StringParsers)
            {

                // Grab parser type
                Type parserType = parser.GetType();

                //Find start and ending index of "Parser" then remove it.
                var indexOfParserSubstring = parserType.Name.IndexOf("Parser", StringComparison.Ordinal);
                var parserSubstringLen = "Parser".Length;
                var propName = parserType.Name.Remove(indexOfParserSubstring, parserSubstringLen);

                // Grab property from the class and set its value
                var propInfo = typeof(Item).GetProperty(propName);


                if (propInfo != null)
                {
                    propInfo.SetValue(newItem, parser.Parse(itemXElement));

                }

            }

            // Iterate over int parsers
            foreach (var parser in IntParsers)
            {

                // Grab parser type
                Type parserType = parser.GetType();

                //Find start and ending index of "Parser" then remove it.
                var indexOfParserSubstring = parserType.Name.IndexOf("Parser", StringComparison.Ordinal);
                var parserSubstringLen = "Parser".Length;
                var propName = parserType.Name.Remove(indexOfParserSubstring, parserSubstringLen);

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
