using BuildCostEstimator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using BuildCostEstimator.BuildFileProcessor;
using BuildCostEstimator.BuildFileProcessor.Factories;
using BuildCostEstimator.DataAccess.Migrations;
using BuildCostEstimator.DataAccess.Repository.IRepository;
using BuildCostEstimator.Models.ViewModels;
using BuildCostEstimator.PriceCheck;
using BuildCostEstimator.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace BuildCostEstimator.Areas.User.Controllers
{
    [Area("User")]
    public class BuildController : Controller
    {
        private readonly ILogger<BuildController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public BuildController(ILogger<BuildController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int buildId) 
        {

            if (ModelState.IsValid) // checks if validations from model are true. Server side validation, sorta
            {
                var build = _unitOfWork.Builds.GetFirstOrDefault(x => x.Id == buildId,"Url");
                
                build.ItemSets = _unitOfWork.ItemSets.GetAll(x => x.BuildId == build.Id).ToHashSet();

                foreach (var set in build.ItemSets)
                {
                    set.ItemSetRelationships =
                        _unitOfWork.ItemSetRelationships.GetAll(x => x.ItemSetId == set.Id, null,"ItemSet,Item").ToList();
                }

                return View(build);

            }
            
            // Create a null build to pass to view
            return View(new Build() { Class = null, Ascendancy = null, PastebinLinkId = -1, Url = null, ItemSets = null});

           
        }

        [HttpPost]
        public IActionResult GetItemsInSetWithIdOf(int id)
        {
            var itemSet = _unitOfWork.ItemSets.GetFirstOrDefault(x => x.Id == id,"ItemSetRelationships");

            List<Item> itemsInSet = new List<Item>();
            //query.Include(e => e.Level1Collection.Select(l1 => l1.Level2Reference))
            foreach (var relationship in itemSet.ItemSetRelationships)
            {
                var item = _unitOfWork.Items.Get(relationship.ItemId);
                if (item != null){
                    itemsInSet.Add(_unitOfWork.Items.Get(relationship.ItemId));
                }
            }

            var data = itemsInSet;
            //var options = new JsonSerializerOptions();
            //options.ReferenceHandler = ReferenceHandler.Preserve;

            string output = JsonSerializer.Serialize(data);
            // Throwing error here. 
            // Something about cycles in Json. Probably not formatted correctly
            // Look into using ReferenceHandler.Preserve
            return Json(new { data = itemsInSet });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
