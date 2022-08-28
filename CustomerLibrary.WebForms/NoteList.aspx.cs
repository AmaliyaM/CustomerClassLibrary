using CustomerInformation;
using CustomerLibrary.Entities;
using CustomerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomerLibrary.WebForms
{
    public partial class NoteList : System.Web.UI.Page
    {
        private NoteRepository _noteRepository;
        public List<Note> Notes { get; set; }

        public NoteList()
        {
            _noteRepository = new NoteRepository();
        }

        public NoteList(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }


        public void LoadNotesFromDatabase(int customerId)
        {
            Notes = _noteRepository.GetAllCustomerNotes(customerId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            LoadNotesFromDatabase(customerIdReq);
        }

        public void OnClickAddNote(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            Response.Redirect($"EditNote.aspx?customerId={customerIdReq}");
        }
    }
}