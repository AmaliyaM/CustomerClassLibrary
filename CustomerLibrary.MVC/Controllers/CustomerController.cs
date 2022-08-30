using CustomerInformation;
using CustomerLibrary.Interfaces;
using CustomerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace CustomerLibrary.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private  IRepository<CustomerClass> _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }



        // GET: Customers
        public ActionResult Index()
        {
            var customersList = _customerRepository.GetAll();
            return View(customersList);
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}