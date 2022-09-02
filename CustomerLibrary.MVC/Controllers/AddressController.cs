using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using CustomerLibrary.MVC.Models;
using CustomerLibrary.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CustomerLibrary.MVC.Controllers
{
    public class AddressController : Controller
    {
        private readonly IRepository<CustomerClass> _customerRepository;
        private NoteRepository _noteRepository;
        private AddressRepository _addressRepository;

        public AddressController()
        {
            _addressRepository = new AddressRepository();
        }

        public AddressController(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
            

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(int customerId, Address address)
        {
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View();
            }
            _addressRepository.Create(address);

            return RedirectToAction("Details", "Customer", new { id = customerId });
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            var address = _addressRepository.Read(id);
            return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, int? customerId, Address address)
        {
            address.AddressId = id;
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View(address);
            }
            _addressRepository.Update(address);

            return RedirectToAction("Details", "Customer", new { id = customerId });
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, int? customerId)
        {
            _addressRepository.Delete(id);

            if (customerId.HasValue)
            {
                return RedirectToAction("Details", "Customer", new { id = customerId });
            }
            else return View(); ;
        }
    }
}
