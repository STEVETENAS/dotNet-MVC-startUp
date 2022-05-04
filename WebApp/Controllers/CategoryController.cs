using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        { _db = db; }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.categories;
            return View(categories);
        }
        public IActionResult Create()
        { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
                ModelState.AddModelError("SimilarDataError", "The Display Order cannot be the same as the Name");

            if (!ModelState.IsValid)
                return View(category);
            
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            _db.categories.Add(category);
            _db.SaveChanges();
            TempData["Create"] = "Category Created Succesfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var category = _db.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
                ModelState.AddModelError("SimilarDataError", "The Display Order cannot be the same as the Name");

            if (!ModelState.IsValid)
                return View(category);
            
            category.UpdatedAt = DateTime.Now;
            _db.categories.Update(category);
            _db.SaveChanges();
            TempData["Update"] = "Category Updated Succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var category = _db.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            category.UpdatedAt = DateTime.Now;
            _db.categories.Remove(category);
            _db.SaveChanges();
            TempData["Delete"] = "Category Deleted Succesfully";
            return RedirectToAction("Index");
        }

    }
}
