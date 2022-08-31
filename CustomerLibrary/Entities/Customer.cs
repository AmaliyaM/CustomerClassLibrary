using CustomerLibrary.Entities;
using System.Collections.Generic;
using CustomerInformation;
using System.ComponentModel.DataAnnotations;

namespace CustomerLibrary.Entities
{
    public class CustomerClass : Person
    {
        public List<Address> Addresses { get; set; } = new List<Address>();

        [RegularExpression(@"\+[1-9]\d{10,12}",
        ErrorMessage = "Invalid number format.")]
        public string? PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        [MaxLength(50)]
        public string? Email { get; set; } = string.Empty;

        public List<Note> Notes { get; set; } = new List<Note>();

        [RegularExpression(@"^[0-9]*[,][0-9]*$",
        ErrorMessage = "Enter money format.")]
        public decimal? TotalPurchasesAmount { get; set; } = 0;

        [Key]
        public int? ID { get; set; } = null;

    }

}

