using front_to_back.Areas.admin.ViewModels;
using front_to_back.DAL;
using front_to_back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace front_to_back.Areas.admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new CategoryIndexViewModel
            {
                Categories = await _appDbContext.Categories.ToListAsync()
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            bool isExist = await _appDbContext.Categories
                .AnyAsync(c => c.Title.ToUpper().Trim() == category.Title.ToUpper().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Title", "Bu adda title movcudur!!!");
                return View(category);
            }
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
    