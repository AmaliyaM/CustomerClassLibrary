using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using CustomerLibrary.Repositories;
using CustomerLibrary.Services;
using System.Web.Mvc;
using PagedList;
using System.Reflection;
using System.Dynamic;

namespace CustomerLibrary.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customer1
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var customers = _customerService.GetCustomers();
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Customer1/Details/5
        public ActionResult Details(int id)
        {
            dynamic model = new ExpandoObject();
            model.Id = id;
            model.Customer = _customerService.GetCustomer(id);
            var notes = _customerService.GetAllNotes(id);
            var addresses = _customerService.GetAllAddresses(id);
            model.Notes = notes;
            model.Addresses = addresses;
            return View(model);
        }

        // GET: Customer1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer1/Create
        [HttpPost]
        public ActionResult Create(int page, CustomerClass customer)
        {
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View(customer);
            }
            _customerService.Create(customer);

            return RedirectToAction("Index", new { page });
        }

        // GET: Customer1/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomer(id);
            return View(customer);
        }

        // POST: Customer1/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerClass customer)
        {
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View(customer);
            }
            _customerService.UpdateCustomer(customer);

            return RedirectToAction("Index");

        }

        // GET: Customer1/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerService.GetCustomer(id);
            return View();
        }

        // POST: Customer1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerClass customer)
        {
            _customerService.DeleteCustomer(id);

            return RedirectToAction("Index");
        }
    }
}
