using System;
using System.ComponentModel.DataAnnotations;
namespace CustomerLibrary.Entities
{
    public abstract class Person
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
    }
    
}

