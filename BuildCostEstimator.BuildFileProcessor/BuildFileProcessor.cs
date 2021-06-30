using System;
using System.Collections.Generic;
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

        public async Task<Tuple<Build, List<ItemSet>>> ProcessBuildFull()
        {
            // Process items
            var itemList = _xmlParser.ParseItemElementsToList();

            // Process item sets
            var itemSetList = _xmlParser.ParseItemSetElementsToList();

            foreach (var set in itemSetList)
            {
                foreach (var relationship in set.ItemSetRelationships)
                {
                    relationship.Item = await _priceCheckService.SinglePriceCheckAsync(itemList[relationship.ItemId]); // Using PobItemId for indexing
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
