using  CustomerInformation;
namespace Customer.Tests;
using System.ComponentModel.DataAnnotations;

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


}
