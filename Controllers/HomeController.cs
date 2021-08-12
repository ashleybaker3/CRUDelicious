using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CRUDelicious.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {

        private static DishContext _context;
        public HomeController(DishContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
            
            return View("Index", AllDishes);
        }
    }
}