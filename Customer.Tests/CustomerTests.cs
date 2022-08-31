using  CustomerInformation;
using CustomerLibrary.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customer.Tests;

public class CustomerTest
{
    [Fact]
    public void ShouldBeAbleToCreateCustomer()
    {   List<Address> adressList = new List<Address>();
        Address addItem = new Address
        {
            FirstLine = "Road Street",
            SecondLine = "Maint Avenue",
            Type = AddressType.Billing,
            City = "Toronto",
            PostalCode = "346330",
            State = "Alberta",
            Country = AvailableCountries.Canada,
            CustomerId = 1
        };
        adressList.Add(addItem);
        List<Note> notes = new List<Note>();
        CustomerClass customer = new CustomerClass
        {
            FirstName = "John",
            LastName = "Second",
            Addresses = adressList,
            Notes = notes,
            Email = "ashfjfnh@gmail.com",
            PhoneNumber = "+16175551212",
            TotalPurchasesAmount = 4
        };

        Assert.Equal("John", customer.FirstName);
        Assert.Equal("Second", customer.LastName);
        Assert.Equal(adressList, customer.Addresses);
        Assert.Equal("+16175551212", customer.PhoneNumber);
        Assert.Equal("ashfjfnh@gmail.com", customer.Email);
        Assert.Equal(notes, customer.Notes);
        Assert.Equal(4, customer.TotalPurchasesAmount);
    }

    [Fact]
    public void ShouldBeAbleToCreateCustomerWithNullPurchase()
    {
        List<Address> adressList = new List<Address>();
        Address addItem = new Address {
            FirstLine = "Road Street",
            SecondLine = "Maint Avenue",
            Type = AddressType.Billing,
            City = "Toronto",
            PostalCode = "346330",
            State = "Alberta",
            Country = AvailableCountries.Canada,
            CustomerId = 1};
        adressList.Add(addItem);
        List<Note> notes = new List<Note>();
        notes.Add(new Note()
        {
            NoteLine=""
        });

        CustomerClass customer = new CustomerClass
        {
            FirstName = "John",
            LastName = "Second",
            Addresses = adressList,
            Notes = notes,
            Email = "ashfjfnh@gmail.com",
            PhoneNumber = "+16175551212",
            TotalPurchasesAmount = 0
        };

        Assert.Equal("John", customer.FirstName);
        Assert.Equal("Second", customer.LastName);
        Assert.Equal(adressList, customer.Addresses);
        Assert.Equal("+16175551212", customer.PhoneNumber);
        Assert.Equal("ashfjfnh@gmail.com", customer.Email);
        Assert.Equal(notes, customer.Notes);
        Assert.Equal(0, customer.TotalPurchasesAmount);
    }


    [Fact]
    public void ShouldValidateErrors()
    {
        List<Address> adressList = new List<Address>();
        adressList.Clear();
        List<Note> notes = new List<Note>();
        notes.Clear();
        CustomerClass customer = new CustomerClass
        {
            FirstName = "000000000000000009hg6162727bshw0000009hg6162727bshwsdvsdv",
            LastName = "",
            Addresses = adressList,
            PhoneNumber = "nonumber",
            Email = "noemail",
            Notes = notes,
            TotalPurchasesAmount = -9
        };

        var validationResult = CustomerValidator.ValidateCustomer(customer);

        var expectedValidationResult = new List<string>()
            {
                ErrorList.FirstNameError,
                ErrorList.LastNameExsistanceError,
                ErrorList.AddressError,
                ErrorList.PhoneNumberError,
                ErrorList.NotesLengthError,
                ErrorList.EmailError,
                ErrorList.PurchaseError
            };

        Assert.Equal(expectedValidationResult, validationResult);
    }

    [Fact]
    public void ShouldValidateLongLastName()
    {
        List<Address> adressList = new List<Address>();
        Address addItem = new Address
        {
            FirstLine = "Road Street",
            SecondLine = "Maint Avenue",
            Type = AddressType.Billing,
            City = "Toronto",
            PostalCode = "346330",
            State = "Alberta",
            Country = AvailableCountries.Canada,
            CustomerId = 1
        };
        adressList.Add(addItem);
        List<Note> notes = new List<Note>();
        CustomerClass customer = new CustomerClass
        {
            FirstName = "john",
            LastName = "000000000000000009hg6162727bshw0000009hg6162727bshwsdvsdv",
            Addresses = adressList,
            Notes = notes,
            Email = "alejdmj@gmail.com",
            PhoneNumber = "+66666666666",
            TotalPurchasesAmount = 9
        };
         
        var validationResult = CustomerValidator.ValidateCustomer(customer);

        var expectedValidationResult = new List<string>()
            {
                ErrorList.LastNameErrorLength
            };

        Assert.Equal(expectedValidationResult, validationResult);
    }


    [Fact]
    public void ShouldNotReturnErrors()
    {
        List<Address> adressList = new List<Address>();
        Address addItem = new Address
        {
            FirstLine = "Road Street",
            SecondLine = "Maint Avenue",
            Type = AddressType.Billing,
            City = "Toronto",
            PostalCode = "346330",
            State = "Alberta",
            Country = AvailableCountries.Canada,
            CustomerId = 1
        };
        adressList.Add(addItem);
        List<Note> notes = new List<Note>();
        CustomerClass customer = new CustomerClass
        {
            FirstName = "john",
            LastName = "Second",
            Addresses = adressList,
            Notes = notes,
            Email = "alejdmj@gmail.com",
            PhoneNumber = "+16175551212",
            TotalPurchasesAmount = 9
        };

        var validationResult = CustomerValidator.ValidateCustomer(customer);
        Assert.Empty(validationResult);
    }

}
