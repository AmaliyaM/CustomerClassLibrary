using CustomerLibrary.Entities;
using System.Collections.Generic;

namespace CustomerInformation
{
    public class CustomerClass : Person
    {
        public List<Address> Addresses { get; set; } = new List<Address>();

        public string? PhoneNumber { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public List<Note> Notes { get; set; } = new List<Note>();

        public decimal? TotalPurchasesAmount { get; set; } = 0;
        public int? ID { get; set; } = null;

    }

}

