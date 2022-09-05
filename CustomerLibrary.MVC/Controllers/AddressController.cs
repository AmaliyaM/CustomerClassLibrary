using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using CustomerLibrary.Services;
using System.Web.Mvc;

namespace CustomerLibrary.MVC.Controllers
{
    public class AddressController : Controller
    {
        private IAddressService _addressService;


        public AddressController()
        {
            _addressService = new AddressService();
        }

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
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
            _addressService.Create(address);

            return RedirectToAction("Details", "Customer", new { id = customerId });
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            var address = _addressService.GetAddress(id);
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
            _addressService.Update(address);

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
            _addressService.Delete(id);

            if (customerId.HasValue)
            {
                return RedirectToAction("Details", "Customer", new { id = customerId });
            }
            else return View(); ;
        }
    }
}
