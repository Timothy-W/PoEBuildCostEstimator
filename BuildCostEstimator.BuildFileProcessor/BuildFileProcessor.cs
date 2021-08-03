using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BuildCostEstimator.BuildFileProcessor.Factories;
using BuildCostEstimator.Models;
using BuildCostEstimator.PriceCheck;
using BuildCostEstimator.PriceCheck.IPriceCheck;

namespace BuildCostEstimator.BuildFileProcessor
{
    public class BuildFileProcessor
    {
        private XmlParser _xmlParser;
        private IPriceCheckService _priceCheckService;

        public BuildFileProcessor(XDocument xmlXDoc, IPriceCheckService priceCheckService) // POOR SOLUTION, NEED TO FIX
        {
            _xmlParser = new XmlParser(xmlXDoc, new ItemFactory(), new ItemSetFactory(), new BuildFactory());
            _priceCheckService = priceCheckService;
        }


        public async Task<Tuple<Build, List<ItemSet>>> ProcessBuildFullAsync()
        {
            //Using Async versions of these methods is too granular and much much slower
            var parseItemsTask = Task.Run(() => _xmlParser.ParseItemElementsToDict());
            var itemSetsTask = Task.Run(() => _xmlParser.ParseItemSetElementsToList());
            var parseBuildTask = Task.Run(() => _xmlParser.ParseBuildInfo());

            await Task.WhenAll(parseItemsTask, itemSetsTask, parseBuildTask);

            var itemSetsInBuild = itemSetsTask.Result;
            var itemsInBuild = parseItemsTask.Result;

            var pricedItems = (List<Item>) await _priceCheckService.MultiplePriceCheckAsync(itemsInBuild.Values.ToList());

            var itemDict = pricedItems.ToDictionary(x => x.PobItemId);

            foreach (var set in itemSetsInBuild)
            {
                foreach (var relationship in set.ItemSetRelationships)
                {
                    relationship.Item = itemDict[relationship.ItemId];
                    relationship.ItemSet = set;
                }
            }

            // Process build info
            var build = parseBuildTask.Result;
            
            return Tuple.Create(build, itemSetsInBuild);
        }

        
        public async Task<Tuple<Build, List<ItemSet>>> ProcessBuildFull()
        {
            // Process items
            var itemList = _xmlParser.ParseItemElementsToDict();

            // Process item sets
            var itemSetList = _xmlParser.ParseItemSetElementsToList();
            foreach (var set in itemSetList)
            {
                foreach (var relationship in set.ItemSetRelationships)
                {
                    relationship.Item =
                        await _priceCheckService.SinglePriceCheckAsync(
                            itemList[relationship.ItemId]); // Using PobItemId for indexing
                    //Price check here, need a better solution
                    relationship.ItemSet = set;
                }
            }

            // Process build info
            var build = _xmlParser.ParseBuildInfo();

            //build.ItemSets = itemSetList.ToHashSet();
            var buildItemSets = itemSetList;

            return Tuple.Create(build, buildItemSets);
        }
    }
}
