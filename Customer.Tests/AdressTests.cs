using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;
using FluentValidation.TestHelper;
using CustomerInformation;

namespace AddressTests;

public class AddressTest
{
    public AddressValidator validator = new AddressValidator();
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
        Address checkedAddress = new Address("Road Street", "Maint Avenue", AdressType.Billing, "Toronto", "346330", "Alberta", AvailableCountries.Canada);

        Assert.Equal("Road Street", checkedAddress.FirstLine);
        Assert.Equal("Maint Avenue", checkedAddress.SecondLine);
        Assert.Equal(AdressType.Billing, checkedAddress.Type);
        Assert.Equal("Toronto", checkedAddress.City);
        Assert.Equal("346330", checkedAddress.PostalCode);
        Assert.Equal("Alberta", checkedAddress.State);
        Assert.Equal(AvailableCountries.Canada, checkedAddress.Country);
    }


    [Fact]
    public void ShouldReturnLengthErrors()
    {
        Address checkedAddress = new Address(
            RandomString(105),
            RandomString(105),
            AdressType.Billing,
            RandomString(55),
            RandomString(8),
            RandomString(25),
            AvailableCountries.Canada);

        var validationResult = (validator.TestValidate(checkedAddress)).Errors.Select(res => res.ErrorMessage);
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
        Address checkedAddress = new Address(
            String.Empty,
            String.Empty,
            AdressType.Billing,
            String.Empty,
            String.Empty,
            String.Empty,
            AvailableCountries.Canada);

        var validationResult = (validator.TestValidate(checkedAddress)).Errors.Select(res => res.ErrorMessage);

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
        Address checkedAddress = new Address("Road Street", "Maint Avenue", AdressType.Billing, "Toronto", "346330", "Alberta", AvailableCountries.Canada);

        var validationResult = (validator.TestValidate(checkedAddress)).Errors.Select(res => res.ErrorMessage);
        Assert.Empty(validationResult);
    }


}