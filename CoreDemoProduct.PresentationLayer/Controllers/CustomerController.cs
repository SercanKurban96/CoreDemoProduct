using CoreDemoProduct.BusinessLayer.Concrete;
using CoreDemoProduct.BusinessLayer.ValidationRules;
using CoreDemoProduct.DataAccessLayer.EntityFramework;
using CoreDemoProduct.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemoProduct.PresentationLayer.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManagerBL cm = new CustomerManagerBL(new EfCustomerDAL());
        CustomerValidator cv = new CustomerValidator();
        JobManagerBL jm = new JobManagerBL(new EfJobDAL());

        public IActionResult Index()
        {
            var values = cm.GetCustomersListWithJob();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {          
            List<SelectListItem> values = (from x in jm.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.JobName,
                                               Value = x.JobID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            ValidationResult results = cv.Validate(p);

            if (results.IsValid)
            {
                cm.TInsert(p);
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
        public IActionResult DeleteCustomer(int id)
        {
            var cus = cm.TGetByID(id);
            cm.TDelete(cus);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            List<SelectListItem> values = (from x in jm.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.JobName,
                                               Value = x.JobID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            var cus = cm.TGetByID(id);
            return View(cus);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            ValidationResult results = cv.Validate(p);

            if (results.IsValid)
            {
                cm.TUpdate(p);
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
