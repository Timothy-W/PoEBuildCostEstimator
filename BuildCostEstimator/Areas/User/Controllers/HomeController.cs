using BuildCostEstimator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BuildCostEstimator.DataAccess.Repository.IRepository;
using BuildCostEstimator.Models.ViewModels;

namespace BuildCostEstimator.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //This version of Upsert handles the HttpPosts that are sent when the user sends us data
        // We end up here when the user clicks "Update" in the editor version of the Upsert.cshtml
        //         or they click the "Create" button after fulling out the form to create new category
        public IActionResult Index(PastebinLink newLink)
        {
            if (ModelState.IsValid) // checks if validations from model are true. Server side validation, sorta
            {
                var existingLink =
                    _unitOfWork.PastebinLinks.GetFirstOrDefault(x => x.PastebinUrl == newLink.PastebinUrl);

                if (existingLink == null)
                {
                    _unitOfWork.PastebinLinks.Add(newLink);
                    _unitOfWork.Save();
                }

                var routeVal = new {pastebinId = existingLink?.Id ?? newLink.Id};

                return RedirectToAction("Index", "Processing", routeVal);
            }

            return View();
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ErrorProcessingException(ProcessingErrorViewModel error)
        {
            return View(error);
        }

    }
}
