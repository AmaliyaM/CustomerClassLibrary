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
    public partial class EditNote : System.Web.UI.Page
    {
        private NoteRepository _noteRepository;
        public List<Note> Notes { get; set; }

        public EditNote()
        {
            _noteRepository = new NoteRepository();
        }

        public EditNote(NoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var noteIdReq = Request.QueryString["id"]; 
                if (noteIdReq != null)
                {
                    var note = _noteRepository.Read(noteIdReq);

                    noteLine.Text = note.NoteLine;

                }
            }

        }

        public void OnClickSave(object sender, EventArgs e)
        {
            var customerIdReq = Convert.ToInt32(Request.QueryString["customerId"]);
            var noteIdReq = Convert.ToInt32(Request.QueryString["id"]);
            
            var note = new Note()
            {
                NoteLine = noteLine?.Text,
                CustomerId = customerIdReq,
                NoteId = noteIdReq
            };
            if (Request.QueryString["id"] == null)
                _noteRepository.Create(note);
            else _noteRepository.Update(note);

            Response.Redirect($"NoteList.aspx?customerId={customerIdReq}");

        }
    }
}