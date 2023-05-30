using CoreDemoProduct.BusinessLayer.Concrete;
using CoreDemoProduct.BusinessLayer.ValidationRules;
using CoreDemoProduct.DataAccessLayer.EntityFramework;
using CoreDemoProduct.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoProduct.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        ProductManagerBL pm = new ProductManagerBL(new EfProductDAL());
        ProductValidator pv = new ProductValidator();
        
        public IActionResult Index()
        {
            var values = pm.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            ValidationResult results = pv.Validate(p);

            if (results.IsValid)
            {
                pm.TInsert(p);
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
        public IActionResult DeleteProduct(int id)
        {
            var prd = pm.TGetByID(id);
            pm.TDelete(prd);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var prd = pm.TGetByID(id);
            return View(prd);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            ValidationResult results = pv.Validate(p);

            if (results.IsValid)
            {
                pm.TUpdate(p);
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
