using FoodForAzure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FoodForAzure.Controllers
{
    public class FoodController : Controller
    {
        private static List<Food> _foods = new List<Food>
        {
            new Food { Id = 1, Name = "Pizza", Description = "Delicious cheese pizza", Price = 12.99m, IsAvailable = true },
            new Food { Id = 2, Name = "Burger", Description = "Juicy beef burger", Price = 8.99m, IsAvailable = true },
            new Food { Id = 3, Name = "Pasta", Description = "Creamy Alfredo pasta", Price = 10.99m, IsAvailable = false }
        };

        // GET: /Food/
        public IActionResult Index()
        {
            return View(_foods);
        }

        // GET: /Food/Details/1
        public IActionResult Details(int id)
        {
            var food = _foods.FirstOrDefault(f => f.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // GET: /Food/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Food/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                food.Id = _foods.Count + 1;
                _foods.Add(food);
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: /Food/Delete/1
        public IActionResult Delete(int id)
        {
            var food = _foods.FirstOrDefault(f => f.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: /Food/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var food = _foods.FirstOrDefault(f => f.Id == id);
            if (food != null)
            {
                _foods.Remove(food);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
