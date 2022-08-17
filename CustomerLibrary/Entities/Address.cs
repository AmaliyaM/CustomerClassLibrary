using System;
using System.ComponentModel.DataAnnotations;
namespace CustomerInformation
{
    public class Address
    {

        public string FirstLine { get; set; } = String.Empty;

        public string SecondLine { get; set; } = String.Empty;

        public AdressType Type { get; set; } = AdressType.Billing;

        public string City { get; set; } = String.Empty;

        public string PostalCode { get; set; } = String.Empty;

        public string State { get; set; } = String.Empty;

        public AvailableCountries Country { get; set; } = AvailableCountries.Canada;

        public Address (string firstLine, string secondLine, AdressType type, string city, string postalCode, string state, AvailableCountries country)
        {
            FirstLine = firstLine;
            SecondLine = secondLine;
            Type = type;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }
        
        
    }
}

