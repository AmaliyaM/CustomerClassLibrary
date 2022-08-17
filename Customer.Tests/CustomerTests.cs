using  CustomerInformation;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Customer.Tests;

public class CustomerTest
{
    [Fact]
    public void ShouldBeAbleToCreateCustomer()
    {   List<Address> adressList = new List<Address>();
        Address addItem = new Address("Road Street", "Maint Avenue", AdressType.Billing, "Toronto", "346330", "Alberta", AvailableCountries.Canada);
        adressList.Add(addItem);
        List<string> notes = new List<string>();
        notes.Add("note1");
        CustomerClass customer = new CustomerClass("John", "Second",adressList, notes, "ashfjfnh@gmail.com", "+16175551212", 4);
        customer.Notes = notes;

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
        Address addItem = new Address("Road Street", "Maint Avenue", AdressType.Billing, "Toronto", "346330", "Alberta", AvailableCountries.Canada);
        adressList.Add(addItem);
        List<string> notes = new List<string>();
        notes.Add("note1");

        CustomerClass customer = new CustomerClass("John", "Second", adressList, notes, "ashfjfnh@gmail.com", "+16175551212", 0);

        customer.Notes = notes;
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
        List<string> notes = new List<string>();
        notes.Clear();
        CustomerClass customer = new CustomerClass(
            "000000000000000009hg6162727bshw0000009hg6162727bshwsdvsdv",
            "",
            adressList,
            notes,
            "nonumber",
            "noemail",
             -9);

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
        Address addItem = new Address("Road Street", "Maint Avenue", AdressType.Billing, "Toronto", "346330", "Alberta", AvailableCountries.Canada);
        adressList.Add(addItem);
        List<string> notes = new List<string>();
        notes.Add("note1");
        CustomerClass customer = new CustomerClass(
             "john",
             "000000000000000009hg6162727bshw0000009hg6162727bshwsdvsdv",
             adressList,
             notes,
             "alejdmj@gmail.com",
             "+66666666666",
              9);
         
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
        Address addItem = new Address("Road Street", "Maint Avenue", AdressType.Billing, "Toronto", "346330", "Alberta", AvailableCountries.Canada);
        adressList.Add(addItem);
        List<string> notes = new List<string>();
        notes.Add("note1");
        CustomerClass customer = new CustomerClass("John", "Second", adressList, notes, "ashfjfnh@gmail.com", "+16175551212", 4);
        customer.Notes = notes;

        var validationResult = CustomerValidator.ValidateCustomer(customer);
        Assert.Empty(validationResult);
    }

}
