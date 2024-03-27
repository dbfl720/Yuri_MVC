using Microsoft.AspNetCore.Mvc;
using Yuri.DataAccess.Repository.IRepository;
using Yuri.Models;

namespace YuriWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;


		public CategoryController(IUnitOfWork unitOfWork)
		{

			_unitOfWork = unitOfWork;
		}


		public IActionResult Index()
		{

			List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
				_unitOfWork.Category.Add(obj); // keeping track of what it has to add
				_unitOfWork.Save(); // actually go to the database and create that category 
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
			Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
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
				_unitOfWork.Category.Update(obj); // keeping track of what it has to add
				_unitOfWork.Save(); // actually go to the database and create that category 
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
			Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);


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
			Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
			if (obj == null)
			{
				return NotFound();
			}
			_unitOfWork.Category.Remove(obj);
			_unitOfWork.Save(); // actually go to the database and create that category 
			TempData["success"] = "Category deleted successfully.";
			return RedirectToAction("Index"); // RedirectionToAction을 INDEX로 한 이유: ADD한 것을 INDEX메소드에서 DB에 RELOAD해야하니깐.

		}
	}
}
