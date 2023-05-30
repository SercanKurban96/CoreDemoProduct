using CoreDemoProduct.BusinessLayer.Concrete;
using CoreDemoProduct.BusinessLayer.ValidationRules;
using CoreDemoProduct.DataAccessLayer.EntityFramework;
using CoreDemoProduct.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoProduct.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManagerBL cam = new CategoryManagerBL(new EfCategoryDAL());
        CategoryValidator cav = new CategoryValidator();

        public IActionResult Index()
        {
            var values = cam.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            ValidationResult results = cav.Validate(p);

            if (results.IsValid)
            {
                cam.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteCategory(int id)
        {
            var cat = cam.TGetByID(id);
            cam.TDelete(cat);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var cat = cam.TGetByID(id);
            return View(cat);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category p)
        {
            ValidationResult results = cav.Validate(p);

            if (results.IsValid)
            {
                cam.TUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
