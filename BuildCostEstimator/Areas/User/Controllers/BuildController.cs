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

                if (build != null)
                {
                    return View(build);
                    
                }

            }
            
            // Create a null build to pass to view
            return View(new Build() { Class = null, Ascendancy = null, PastebinLinkId = -1, Url = null, ItemSets = null});

           
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
