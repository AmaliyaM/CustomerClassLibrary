using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using CustomerLibrary.Services;
using System.Web.Mvc;

namespace CustomerLibrary.MVC.Controllers
{
    public class NoteController : Controller
    {
        private INoteService _noteService;

        public NoteController()
        {
            _noteService = new NoteService();
        }

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int customerId, Note note)
        {
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View();
            }
            _noteService.Create(note);

            return RedirectToAction("Details", "Customer", new { id = customerId });
        }


        public ActionResult Edit(int id)
        {
            var note = _noteService.GetNote(id);
            return View(note);
        }


        [HttpPost]
        public ActionResult Edit(int id, int? customerId, Note note)
        {
            note.NoteId = id;
            if (!this.ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Enter valid values!";
                return View(note);
            }
            _noteService.Update(note);

            return RedirectToAction("Details", "Customer", new { id = customerId });
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, int? customerId)
        {
            _noteService.Delete(id);

            if (customerId.HasValue)
            {
                return RedirectToAction("Details", "Customer", new { id = customerId });
            }
            else return View(); ;

        }
    }
}