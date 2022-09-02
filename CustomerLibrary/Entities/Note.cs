using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLibrary.Entities
{
    public class Note
    {
        [ForeignKey("CustomerClass")]
        public int CustomerId { get; set; }

        [MaxLength(50)]
        public string NoteLine { get; set; }

        [Key]
        public int NoteId { get; set; }


    }
}
