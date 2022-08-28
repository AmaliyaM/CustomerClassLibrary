using CustomerInformation;
using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using CustomerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerLibrary.WebForms
{
    public partial class DeleteNote : System.Web.UI.Page
    {
        private IRepository<Note> _noteRepository;
        public DeleteNote()
        {
            _noteRepository = new NoteRepository();
        }

        public DeleteNote(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Request.QueryString["customerId"];
            var note = new Note()
            {
                NoteId = Convert.ToInt32(Request.QueryString["id"]),
            };
            _noteRepository.Delete(note);
            Response.Redirect($"NoteList.aspx?customerId={customerIdReq}");

        }
    }
}