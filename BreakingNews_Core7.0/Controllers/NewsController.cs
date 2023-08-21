using BreakingNews_Core7._0.Models.Entity;
using BreakingNews_Core7._0.Models.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BreakingNews_Core7._0.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public NewsController(INewsRepository newsRepository, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _newsRepository = newsRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<News> newsList = _newsRepository.GetList(includeProps: "Category").ToList();
            return View(newsList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            IEnumerable<SelectListItem> CategoryList = _categoryRepository.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryID.ToString()
                });
            ViewBag.CategoryList = CategoryList;

            return View();
        }
        [HttpPost]
        public IActionResult Add(News n, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath; // wwwroot'un pathini verir
            string newsPath = Path.Combine(wwwRootPath, @"img");

            if (file != null)
            {
                using (var fileStream = new FileStream(Path.Combine(newsPath, file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                n.ImageURL = @"\img\" + file.FileName;

                _newsRepository.Add(n);
                TempData["Successful"] = "Yeni haber eklendi";
                _newsRepository.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _categoryRepository.GetList()
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryID.ToString()
            });
            ViewBag.CategoryList = CategoryList;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            News? newsVT = _newsRepository.Get(x => x.ID == id);
            if (newsVT == null)
            {
                return NotFound();
            }
            return View(newsVT);
        }

        [HttpPost]
        public IActionResult Update(News n)
        {
            _newsRepository.Update(n);
            _newsRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            IEnumerable<SelectListItem> Category = _categoryRepository.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.CategoryID.ToString()
                });

            if (id == null || id == 0)
                        {
                return NotFound();
             }
             News? newsVT = _newsRepository.Get(x => x.ID == id);
             if (newsVT == null)
             {
                return NotFound();
             }
             return View(newsVT);
        }

        public IActionResult NewsByCategory(int? id)
        {
            IEnumerable<SelectListItem> Category = _categoryRepository.GetList()
               .Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = x.CategoryID.ToString()
               });

            if (id == null || id == 0)
            {
                return NotFound();
            }
            List<News> newsList = _newsRepository.getAllNewsByCategory(x=>x.CategoryID == id ,includeProps: "Category").ToList();
            return View(newsList);

        }

    }
}
