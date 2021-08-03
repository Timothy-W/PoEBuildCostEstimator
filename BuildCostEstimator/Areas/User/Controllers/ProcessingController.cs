using BuildCostEstimator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BuildCostEstimator.DataAccess.Repository.IRepository;
using BuildCostEstimator.Models.ViewModels;
using BuildCostEstimator.PriceCheck;
using BuildCostEstimator.Utilities;
using BuildCostEstimator.Utilities.Extensions;
using Microsoft.Extensions.Caching.Memory;


namespace BuildCostEstimator.Areas.User.Controllers
{
    [Area("User")]
    public class ProcessingController : Controller
    {
        private readonly ILogger<ProcessingController> _logger;

        private readonly IUnitOfWork _unitOfWork;
        private IHttpClientFactory _httpClientFactory;
        private IMemoryCache _memoryCache;

        public ProcessingController(ILogger<ProcessingController> logger, IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index(int pastebinId) 
        {
            var url = _unitOfWork.PastebinLinks.Get(pastebinId);


            Tuple<Build, List<ItemSet>> tupleOfBuildInfo = null;//new Tuple<Build, List<ItemSet>>(new Build(), new List<ItemSet>());
            try
            {
                tupleOfBuildInfo = await ProcessBuild(url);
            }
            catch (InvalidDataException e)
            {
               
                var objFromDb = _unitOfWork.PastebinLinks.Get(url.Id);

                if (objFromDb != null)
                {
                    _unitOfWork.PastebinLinks.Remove(pastebinId);
                    _unitOfWork.Save();
                }
               
                return RedirectToAction("ErrorProcessingException", "Home", new ProcessingErrorViewModel() { PastebinLink = url.PastebinUrl, Message = e.Message});
            }



            var build = tupleOfBuildInfo.Item1;
            var builditemSets = tupleOfBuildInfo.Item2;


            // Add Item objects to database
            var itemSetRelationshipList = builditemSets.SelectMany(x => x.ItemSetRelationships).ToList();
            var itemList = itemSetRelationshipList.Select(x => x.Item);
            var itemPobIdToDbIdMapping = AddedItemsToDb(itemList);
        

            List<Tuple<int, int>> itemPobIdToitemSetXmlIdMapping = GetPobItemIdToItemSetXmlIdMapping(
                itemSetRelationshipList);


            // Add Build object to database
            build.PastebinLinkId = pastebinId;
            var newBuildId = AddBuildObjectToDb(build);


            // Add ItemSet objects to database
            Dictionary<int,int> itemSetXmlIdToDbIdMapping = AddedItemSetsToDb(builditemSets, newBuildId);

            
            // Add relationships to database
            foreach (var tuple in itemPobIdToitemSetXmlIdMapping)
            {
                var itemDbId = itemPobIdToDbIdMapping[tuple.Item1];
                var itemSetDbId = itemSetXmlIdToDbIdMapping[tuple.Item2];

                var existingRelationship = _unitOfWork.ItemSetRelationships.GetFirstOrDefault(
                    r => r.ItemId == itemDbId
                         && r.ItemSetId == itemSetDbId);

                if (existingRelationship == null)
                {
                    var relationship = new ItemSetRelationship
                    {
                        Item = _unitOfWork.Items.Get(itemDbId),
                        ItemSet = _unitOfWork.ItemSets.Get(itemSetDbId)
                    };
                    //TODO Do I need to update item/item set again here to trigger an update to their relationship sets?
                    _unitOfWork.ItemSetRelationships.Add(relationship);
                }
            
                _unitOfWork.Save();
            }
            

            return RedirectToAction("Index", "Build",new { buildId = newBuildId });
        }

        private Dictionary<int,int> AddedItemsToDb(IEnumerable<Item> itemList)
        {
            // Dictionary<items pob id, items database id>
            Dictionary<int,int> result = new Dictionary<int, int>();
            

            

            foreach (var item in itemList)
            {
                int id;
                //Do we want to check pobItemId?
                // Yes: Path of Building saves item once and reuses the pob item id.
                var existingItem = _unitOfWork.Items.GetFirstOrDefault(
                    x => x.BaseType == item.BaseType
                    && x.PobItemId == item.PobItemId
                    && x.LevelReq == item.LevelReq
                    && x.ItemLevel == item.ItemLevel
                    && x.Name == item.Name
                    && x.Rarity == item.Rarity
                    && x.Sockets == item.Sockets
                    && x.Influences == item.Influences
                    && x.ImplicitMods == item.ImplicitMods
                    && x.AffixMods == item.AffixMods
                    && x.IsCorrupted == item.IsCorrupted
                );

                if (existingItem != null)
                {
                    // Item exists, update it
                    id = existingItem.Id;
                    item.Id = existingItem.Id;
                    _unitOfWork.Items.Update(item);

                }
                else
                {
                    // Add new iem to db
                    _unitOfWork.Items.Add(item);
                    _unitOfWork.Save();
                    id = item.Id;
                }

                result[item.PobItemId] = id;
            }

            return result;
        }

        private List<Tuple<int, int>> GetPobItemIdToItemSetXmlIdMapping(IEnumerable<ItemSetRelationship> relationships)
        {
            List<Tuple<int, int>> result = new List<Tuple<int, int>>();

            foreach (var element in relationships)
            {
                result.Add(new Tuple<int, int>(element.ItemId, element.ItemSetId));
            }

            return result;
        }

        private Dictionary<int, int> AddedItemSetsToDb(List<ItemSet> builditemSets, int buildId)
        {
            Dictionary<int, int> results = new Dictionary<int, int>();

            foreach (var set in builditemSets)
            {
                int itemSetId;
                
                // Always null, need to figure out why
                var existingItemSet = _unitOfWork.ItemSets.GetFirstOrDefault(
                    x => x.ItemSetTitle == set.ItemSetTitle
                         && x.ItemSetXmlId == set.ItemSetXmlId
                         && x.BuildId == buildId);

                if (existingItemSet == null)
                {
                    // Add ItemSet
                    set.BuildId = buildId;
                    set.ItemSetRelationships.Clear();

                    _unitOfWork.ItemSets.Add(set);
                    _unitOfWork.Save();
                    itemSetId = set.Id;
                }
                else
                {
                    itemSetId = existingItemSet.Id;
                }

                results.Add(set.ItemSetXmlId, itemSetId);
            }

            return results;
        }

        private int AddBuildObjectToDb(Build build)
        {
            int newId;
            
            var existingBuild = _unitOfWork.Builds.GetFirstOrDefault(
                x => x.Ascendancy == build.Ascendancy 
                     && x.Class == build.Class 
                     && x.PastebinLinkId == build.PastebinLinkId
            ); // Not sure about the URL

            
            
            if (existingBuild == null)
            {
                
                _unitOfWork.Builds.Add(build);
                _unitOfWork.Save();
                newId = build.Id;

    

            } else {
                newId = existingBuild.Id;
            }


            return newId;

        }


        private async Task<Tuple<Build, List<ItemSet>>> ProcessBuild(PastebinLink url)
        {
            // Process pastebin url
            var xmlXDoc = PastebinDataService.ProcessUrl(url, _httpClientFactory); // Make Async
            
            // TODO: Explore validation through XmlSchemaSet. Roll own solution for now.
            xmlXDoc.ValidatePobXmlDoc();
            
            //Use BuildXmlParser here to retrieve items from the xml data
            var buildProcessor = new BuildFileProcessor.BuildFileProcessor(xmlXDoc, new PriceCheckService(_httpClientFactory, _memoryCache));
            Tuple<Build, List<ItemSet>> build = await buildProcessor.ProcessBuildFullAsync();
            
            return build;
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
