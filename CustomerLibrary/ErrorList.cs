using System;
namespace CustomerInformation
{
    public class ErrorList
    {
        public const string FirstNameError = "First name is too long.";
        public const string LastNameErrorLength = "Last name is too long.";
        public const string LastNameExsistanceError = "Last name is required";
        public const string PhoneNumberError = "Please enter valid phone number.";
        public const string EmailError = "Please enter valid email";
        public const string NotesLengthError = "At list singe note required";
        public const string AddressError = "At list singe address required";
        public const string PurchaseError = "Purchase amount can't be negative";


        public const string FirstAddressLineError= "First adress line is required";
        public const string FirstAddressLineLengthError = "First line is too long.";
        public const string SecondAddressLineLengthError = "Second line is too long.";
        public const string AddressTypeExsistanceError = "Address type is required";
        public const string AddressTypeFormatError = "Type only can be 'shipping' or 'billing'";
        public const string CityExsistanceError = "City  is required";
        public const string CityLengthError = "Invalid length of city.";
        public const string PostalCodeExsistanceError = "Postal code  is required";
        public const string PostalCodeError = "Invalid length of postal code.";
        public const string StateExsistanceError = "State  is required";
        public const string StateError = "Invalid length of state.";
        public const string CountryExsistanceError = "Contry  is required";
        public const string CountryFormatLength = "Contry only can be 'Canada' or 'US'";
  
    }
}

