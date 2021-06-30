using System;
using System.Collections;
using BuildCostEstimator.BuildFileProcessor.Builders;
using BuildCostEstimator.BuildFileProcessor.Parsers;
using BuildCostEstimator.BuildFileProcessor.Parsers.Interfaces;
using BuildCostEstimator.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace BuildCostEstimator.BuildFileProcessor.Factories
{
    public class ItemSetFactory : Factory<ItemSet> 
    {

        
        // What is using this item factory? The controller? Anther class used by the controller?
        public ItemSetFactory()
        {
            
            // Make more dynamic, maybe with reflection
            stringParsers = new List<IParser<string>>() { };
            intParsers = new List<IParser<int>>() { };    
        }




        public override ItemSet CreateObj(XElement itemSetElement)
        {
            string setTitle = itemSetElement.Attribute("title")?.Value;
            int setXmlId = int.Parse(itemSetElement.Attribute("id")?.Value ?? throw new InvalidDataException());


            var newItemSet = new ItemSet()
            {
                ItemSetTitle = setTitle ?? "Default", 
                ItemSetXmlId = setXmlId
            };

            // Loop over Slot elements
            //var slotElements = itemSetElement.Elements("Slot");

            var pobItemIds = itemSetElement.Descendants("Slot")
                        .Where( x => x.Attribute("itemId").Value != "0")
                        .Select(x => int.Parse(x.Attribute("itemId").Value))
                        .ToList();

            foreach (var id in pobItemIds)
            {
                newItemSet.ItemSetRelationships.Add(new ItemSetRelationship {ItemSetId = newItemSet.ItemSetXmlId, ItemId = id});
            }

            return newItemSet;
        }

  
    }
}
