using Microsoft.AspNetCore.Mvc;
using Yuri.DataAccess.Repository.IRepository;
using Yuri.Models;

namespace YuriWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;


        public ProductController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {

            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }





        //Create  , action method 
        public IActionResult Create()
        {
            return View();
        }


        //  Entity framework core 
        [HttpPost]
        public IActionResult Create(Product obj)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj); // keeping track of what it has to add
                _unitOfWork.Save(); // actually go to the database and create that product 
                TempData["success"] = "Product created successfully.";
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
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //Product? productFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Product? productFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }


        //  Entity framework core 
        [HttpPost]
        public IActionResult Edit(Product obj)
        {



            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj); // keeping track of what it has to add
                _unitOfWork.Save(); // actually go to the database and create that product 
                TempData["success"] = "Product updated successfully.";
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
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);


            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }


        //  Entity framework core 
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save(); // actually go to the database and create that product 
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index"); // RedirectionToAction을 INDEX로 한 이유: ADD한 것을 INDEX메소드에서 DB에 RELOAD해야하니깐.

        }
    }
}
