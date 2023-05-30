using CoreDemoProduct.BusinessLayer.Concrete;
using CoreDemoProduct.BusinessLayer.ValidationRules;
using CoreDemoProduct.DataAccessLayer.EntityFramework;
using CoreDemoProduct.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoProduct.PresentationLayer.Controllers
{
    public class JobController : Controller
    {
        JobManagerBL jm = new JobManagerBL(new EfJobDAL());
        JobValidator jv = new JobValidator();

        public IActionResult Index()
        {
            var values = jm.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job p)
        {
            ValidationResult results = jv.Validate(p);

            if (results.IsValid)
            {
                jm.TInsert(p);
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
        public IActionResult DeleteJob(int id)
        {
            var job = jm.TGetByID(id);
            jm.TDelete(job);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var job = jm.TGetByID(id);
            return View(job);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job p)
        {
            ValidationResult results = jv.Validate(p);

            if (results.IsValid)
            {
                jm.TUpdate(p);
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
