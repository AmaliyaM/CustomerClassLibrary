using System.ComponentModel.DataAnnotations;
using System.Text;
using CustomerInformation;

namespace AddressTests;

public class CustomerTest
{
    private static Random random = new Random();

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }


    [Fact]
    public void ShouldBeAbleToCreateAdress()
    {
        Address checkedAddress = new Address
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

        Assert.Equal("Road Street", checkedAddress.FirstLine);
        Assert.Equal("Maint Avenue", checkedAddress.SecondLine);
        Assert.Equal(AddressType.Billing, checkedAddress.Type);
        Assert.Equal("Toronto", checkedAddress.City);
        Assert.Equal("346330", checkedAddress.PostalCode);
        Assert.Equal("Alberta", checkedAddress.State);
        Assert.Equal(AvailableCountries.Canada, checkedAddress.Country);
    }


    [Fact]
    public void ShouldReturnLengthErrors()
    {
        Address checkedAddress = new Address {
            FirstLine = RandomString(105),
            SecondLine = RandomString(105),
            Type = AddressType.Billing,
            City = RandomString(55),
            PostalCode = RandomString(8),
            State = RandomString(25),
            Country = AvailableCountries.Canada,
            CustomerId = 1};

        var validationResult = AddressValidator.ValidateAddress(checkedAddress);

        var expectedValidationResult = new List<string>()
            {
                ErrorList.FirstAddressLineLengthError,
                ErrorList.SecondAddressLineLengthError,
                ErrorList.CityLengthError,
                ErrorList.PostalCodeError,
                ErrorList.StateError,
            };

        Assert.Equal(expectedValidationResult, validationResult);
    }

    [Fact]
    public void ShouldReturnExsistanceErrors()
    {
        Address checkedAddress = new Address
        {
            FirstLine = String.Empty,
            SecondLine = String.Empty,
            Type = AddressType.Billing,
            City = String.Empty,
            PostalCode = String.Empty,
            State = String.Empty,
            Country = AvailableCountries.Canada,
            CustomerId = 1
        };

        var validationResult = AddressValidator.ValidateAddress(checkedAddress);

        var expectedValidationResult = new List<string>()
            {
                ErrorList.FirstAddressLineError,
                ErrorList.CityExsistanceError,
                ErrorList.PostalCodeExsistanceError,
                ErrorList.StateExsistanceError,
            };

        Assert.Equal(expectedValidationResult, validationResult);
    }

    [Fact]
    public void ShouldReturnEmptyErrorsList()
    {
        Address checkedAddress = new Address
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

        var validationResult = AddressValidator.ValidateAddress(checkedAddress);

        Assert.Empty(validationResult);
    }


}