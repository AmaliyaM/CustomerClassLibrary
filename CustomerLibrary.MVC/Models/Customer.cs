using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CustomerLibrary.MVC.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [RegularExpression(@"\+[1-9]\d{10,12}",
         ErrorMessage = "Invalid number format.")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^[0-9]*[,][0-9]*$",
        ErrorMessage = "Enter money format.")]
        public decimal TotalPurchasesAmount { get; set; }


    }
}