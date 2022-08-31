using System;
namespace CustomerLibrary.Entities
{
    public class Address
    {

        public string FirstLine { get; set; } = String.Empty;

        public string SecondLine { get; set; } = String.Empty;

        public AddressType Type { get; set; } = AddressType.Billing;

        public string City { get; set; } = String.Empty;

        public string PostalCode { get; set; } = String.Empty;

        public string State { get; set; } = String.Empty;

        public AvailableCountries Country { get; set; } = AvailableCountries.Canada;

        public int CustomerId { get; set; }

        public int AddressId { get; set; }

    }
}

