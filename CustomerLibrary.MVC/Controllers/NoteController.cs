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
    public class NoteController : Controller
    {
        private readonly IRepository<CustomerClass> _customerRepository;
        private NoteRepository _noteRepository;
        private AddressRepository _addressRepository;

        public NoteController()
        {
            _noteRepository = new NoteRepository();
        }

        public NoteController(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        // GET: Note/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Note/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Note/Edit/5
        public ActionResult Edit(int id)
        {
            var note = _noteRepository.Read(id);
            return View(note);
        }

        // POST: Note/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,int? customerId,Note note)
        {
            note.NoteId = id;
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View(note);
            }
             _noteRepository.Update(note);

            return RedirectToAction("Details", "Customer", new { id = customerId });
        }

        // GET: Note/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Note/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,int? customerId)
        {
            _noteRepository.Delete(id);

            if (customerId.HasValue)
            {
                return RedirectToAction("Details", "Customer", new { id = customerId });
            }
            else return View(); ;
  
        }
    }
}