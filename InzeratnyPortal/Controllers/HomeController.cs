using InzeratnyPortal.Data;
using InzeratnyPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace InzeratnyPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context.Item.Count() < 6)
            {
                return View(new ItemsCategories() { Items = _context.Item, Categories = _context.Category });
            }

            return View(new ItemsCategories() { Items = _context.Item.Take(6), Categories = _context.Category });
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

        public IActionResult DisplayItems(string what)
        {
            var categoryId = _context.Category.Where(cat => cat.Nazov == what).First().ID;
            var items = _context.Item.Where(item => item.CategoryID == categoryId);
            return View(new ItemsCategories() { Items = items, Categories = _context.Category });
        }


        [HttpPost]
        public IActionResult SearchResults(int category, string text, string priceTo, string priceFrom)
        {
            var categoryId = _context.Category.Where(cat => cat.ID == category).First().ID;
            var items = _context.Item.Where(item => item.CategoryID == categoryId);
            Console.WriteLine("sdf");
            Console.WriteLine(text);
            if (text != null)
            {
                items = items.Where(item => (item.Nazov.Contains(text) || item.Popis.Contains(text)));
            }

            if (priceFrom != null)
            {
                items = items.Where(item => item.Cena >= Convert.ToDecimal(priceFrom));
            }
            if (priceTo != null)
            {
                items = items.Where(item => item.Cena <= Convert.ToDecimal(priceTo));
            }


            return View("DisplayItems", new ItemsCategories() { Items = items, Categories = _context.Category });
        }


    }
}
