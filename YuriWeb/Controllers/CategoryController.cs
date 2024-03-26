using Microsoft.AspNetCore.Mvc;
using YuriWeb.Data;
using YuriWeb.Models;

namespace YuriWeb.Controllers
{
	public class CategoryController : Controller
	{

		private readonly ApplicationDbContext _db;


		public CategoryController(ApplicationDbContext db)
		{

			_db = db;
		}

		// action method 
		public IActionResult Index()
		{

			List<Category> objCategoryList = _db.Categories.ToList();
			return View(objCategoryList);
		}


		public IActionResult Create()
		{
			return View();
		}


		//  Entity framework core 
		[HttpPost]
		public IActionResult Create(Category obj)
		{

			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
			}


			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj); // keeping track of what it has to add
				_db.SaveChanges(); // actually go to the database and create that category 
				return RedirectToAction("Index"); // RedirectionToAction을 INDEX로 한 이유: ADD한 것을 INDEX메소드에서 DB에 RELOAD해야하니깐.

			}
			return View();
		}
	}
}
