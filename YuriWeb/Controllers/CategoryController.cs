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
	}
}
