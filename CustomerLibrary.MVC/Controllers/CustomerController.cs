using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using CustomerLibrary.Repositories;
using System.Web.Mvc;
using PagedList;
using System.Reflection;
using System.Dynamic;

namespace CustomerLibrary.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<CustomerClass> _customerRepository;
        private  NoteRepository _noteRepository;
        private AddressRepository _addressRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository(); 
        }

        public CustomerController(IRepository<CustomerClass> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: Customer1
        public ActionResult Index(int? page)
        {   
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var customers = _customerRepository.GetAll();
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Customer1/Details/5
        public ActionResult Details(int id)
        {
            _noteRepository = new NoteRepository();
            _addressRepository = new AddressRepository();
            dynamic model = new ExpandoObject();
            model.Id = id;
            model.Customer = _customerRepository.Read(id);
            var notes = _noteRepository.GetAllCustomerNotes(id);
            var addresses = _addressRepository.GetAllCustomerAdresses(id);
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
        public ActionResult Create(int page,CustomerClass customer)
        {
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View(customer);
            }
                _customerRepository.Create(customer);

                return RedirectToAction("Index", new { page });
        }

        // GET: Customer1/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerRepository.Read(id);
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
            _customerRepository.Update(customer);

                return RedirectToAction("Index");

        }

        // GET: Customer1/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerRepository.Read(id);
            return View();
        }

        // POST: Customer1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerClass customer)
        {
                _customerRepository.Delete(id);

                return RedirectToAction("Index");
        }
    }
}
