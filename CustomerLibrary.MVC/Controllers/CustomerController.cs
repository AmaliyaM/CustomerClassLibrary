using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using CustomerLibrary.MVC.Models;
using CustomerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerLibrary.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<CustomerClass> _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository(); 
        }

        public CustomerController(IRepository<CustomerClass> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: Customer1
        public ActionResult Index()
        {
            var customers = _customerRepository.GetAll();

            return View(customers);
        }

        // GET: Customer1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer1/Create
        [HttpPost]
        public ActionResult Create(CustomerClass customer)
        {
            try
            {
                _customerRepository.Create(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer1/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerRepository.Read(id.ToString());
            return View(customer);
        }

        // POST: Customer1/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerClass customer)
        {
            try
            {
                _customerRepository.Update(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer1/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerRepository.Read(id.ToString());
            return View();
        }

        // POST: Customer1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerClass customer)
        {
            try
            {
                _customerRepository.Delete(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
