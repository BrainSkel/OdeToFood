using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _db = dbContext;
            _logger = logger;
        }

        public IActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new { label = r.Name });
            return Json(model);
        }


        public IActionResult Index(string searchTerm = null)
        {
            var model = _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Take(10)
                .Select(r => new Restaurant
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country

                }
                );
            //var model = _db.Restaurants.ToList();
            if(Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Sennah";
            model.Location ="Tallinn, Estonia";
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
