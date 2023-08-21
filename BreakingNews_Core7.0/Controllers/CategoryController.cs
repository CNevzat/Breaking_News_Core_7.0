using BreakingNews_Core7._0.Models.Entity;
using BreakingNews_Core7._0.Models.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BreakingNews_Core7._0.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _categoryRepository.GetList().ToList();
            return View(categoryList);
        }
        [HttpGet]
        public IActionResult Add()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category c)
        {
            _categoryRepository.Add(c);
            TempData["Successful"] = "Yeni kategori eklendi";
            _categoryRepository.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0 )
            {
                return NotFound();
            }
            Category? categoryVT = _categoryRepository.Get(x => x.CategoryID == id);
            
            if (categoryVT == null) 
            {
                return NotFound();
            }

            return View(categoryVT);
        }

        [HttpPost]
        public IActionResult Update(Category c)
        {
            _categoryRepository.Update(c);
            _categoryRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
