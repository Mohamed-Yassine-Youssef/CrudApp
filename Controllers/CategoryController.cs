using dotnetTuto.Data;
using dotnetTuto.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetTuto.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        public ActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //GET
         public ActionResult Create()
        {
            
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
          public ActionResult Create(Category obj)
        {
             if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }
            if(ModelState.IsValid)
            {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
           return Redirect("Index");
            }
             return View(obj);
        }


//GET
         public ActionResult Edit(int ? id)
        {
            if(id == null || id==0){
                return NotFound();
            }
            var categoryFormDb = _db.Categories.Find(id);
            if(categoryFormDb == null){
                return NotFound();
            }
            return View(categoryFormDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
          public ActionResult Edit(Category obj)
        {
             if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
        }
            if(ModelState.IsValid)
            {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
           return RedirectToAction("Index");
            }
             return View(obj);
        }


         public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    //POST
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Categories.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Categories.Remove(obj);
            _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
        
    }
         

    }
}
