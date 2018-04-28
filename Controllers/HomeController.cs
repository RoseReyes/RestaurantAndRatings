using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restauranter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;


namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        
        private RestaurantContext _context;
 
        public HomeController(RestaurantContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("addreview")]
        public IActionResult reviews(Review newreview)
        {
           if(ModelState.IsValid) 
            {
                if (newreview.dov > DateTime.Today) 
                {
                    TempData["error"] = "Date should not be future-date";
                    return View("Index");
                }
                    //Save to DB
                    _context.Add(newreview);
                    _context.SaveChanges();
                    return RedirectToAction("displayreview");
            }
            return View("Index");

        }

        [HttpGet]
        [Route("displayreview")]
        public IActionResult displayreview(Review newreview)
        {
            //Display all Reviews
            List<Review> ReturnedValues = _context.user_reviews.OrderByDescending(d => d.created_at).ToList();
            ViewBag.Results = ReturnedValues;
            return View("success");
        }
    }
}
