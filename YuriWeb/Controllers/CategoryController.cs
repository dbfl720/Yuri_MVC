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


		public IActionResult Index()
		{

			List<Category> objCategoryList = _db.Categories.ToList();
			return View(objCategoryList);
		}





		//Create  , action method 
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
				TempData["success"] = "Category created successfully.";
				return RedirectToAction("Index"); // RedirectionToAction을 INDEX로 한 이유: ADD한 것을 INDEX메소드에서 DB에 RELOAD해야하니깐.

			}
			return View();
		}







		// Edit
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);
			//Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
			//Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}


		//  Entity framework core 
		[HttpPost]
		public IActionResult Edit(Category obj)
		{



			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj); // keeping track of what it has to add
				_db.SaveChanges(); // actually go to the database and create that category 
				TempData["success"] = "Category updated successfully.";
				return RedirectToAction("Index"); // RedirectionToAction을 INDEX로 한 이유: ADD한 것을 INDEX메소드에서 DB에 RELOAD해야하니깐.

			}
			return View();
		}








		// Delete
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);


			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}


		//  Entity framework core 
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category? obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges(); // actually go to the database and create that category 
			TempData["success"] = "Category deleted successfully.";
			return RedirectToAction("Index"); // RedirectionToAction을 INDEX로 한 이유: ADD한 것을 INDEX메소드에서 DB에 RELOAD해야하니깐.

		}
	}
}
