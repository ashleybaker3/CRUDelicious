using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CRUDelicious.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDelicious.Controllers
{
    public class DishesController : Controller
    {
        private static DishContext _context;
        public DishesController(DishContext context)
        {
            _context = context;
        }

        [HttpGet("New")]
        [Route("dish/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("Create")]
        public IActionResult Create(Dish newDish)
        {
            if(ModelState.IsValid == false)
            {
                return View("New");
            }
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("/dish/view/{dishId}")]
        public IActionResult ViewDish(int DishID)
        {
            Dish ViewDish = _context.Dishes.FirstOrDefault(plate => plate.DishID == DishID);
            return View("ViewOne", ViewDish);
        }

        [HttpGet("/edit/{dishId}")]
        public IActionResult Edit(int DishID)
        {
            Dish RetrievedDish = _context.Dishes.SingleOrDefault(plate => plate.DishID == DishID);
            return View("Edit", RetrievedDish);
        }

        [HttpPost("/update/{dishId}")]

        public IActionResult Update(int dishID, Dish updatedDish)
        {
            if(ModelState.IsValid == false)
            {
                updatedDish.DishID = dishID;
                return View("Edit", updatedDish);
            }

            Dish RetrievedDish = _context.Dishes.SingleOrDefault(plate => plate.DishID == dishID);
            
            if(RetrievedDish == null)
            {
                return RedirectToAction("Index");
            }
                RetrievedDish.Name = updatedDish.Name;
                RetrievedDish.Chef = updatedDish.Chef;
                RetrievedDish.Calories = updatedDish.Calories;
                RetrievedDish.Tastiness = updatedDish.Tastiness;
                RetrievedDish.Description = updatedDish.Description;
                RetrievedDish.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            
            return RedirectToAction("ViewDish", dishID);
        }

        [HttpGet("/delete/{dishId}")]
        public IActionResult Delete(int DishID)
        {
            Dish RetrievedDish = _context.Dishes.SingleOrDefault(plate => plate.DishID == DishID);
            _context.Dishes.Remove(RetrievedDish);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }

        // [HttpGet("")]
        // public IActionResult Index()
        // {
        //     List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
            
        //     return View("Index", AllDishes);
        // }

    }
}