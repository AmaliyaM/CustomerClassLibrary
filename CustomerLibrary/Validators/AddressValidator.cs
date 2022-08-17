using FluentValidation;

namespace CustomerInformation
{

    public class AddressValidator : AbstractValidator<Address>
    {
        const int MaxAdressLength = 100;
        const int MaxCityLength = 50;
        const int MaxPostalCodeLength = 6;
        const int MaxStateLength = 20;

        public AddressValidator()
        {
            RuleFor(address => address.FirstLine).MaximumLength(MaxAdressLength).WithMessage(ErrorList.FirstAddressLineLengthError);

            RuleFor(address => address.FirstLine).NotEmpty().WithMessage(ErrorList.FirstAddressLineError);

            RuleFor(address => address.SecondLine).MaximumLength(MaxAdressLength).WithMessage(ErrorList.SecondAddressLineLengthError);

            RuleFor(address => address.Type).IsInEnum().WithMessage(ErrorList.AddressTypeFormatError);

            RuleFor(address => address.City).MaximumLength(MaxCityLength).WithMessage(ErrorList.CityLengthError);

            RuleFor(address => address.City).NotEmpty().WithMessage(ErrorList.CityExsistanceError);

            RuleFor(address => address.PostalCode).MaximumLength(MaxPostalCodeLength).WithMessage(ErrorList.PostalCodeError);

            RuleFor(address => address.PostalCode).NotEmpty().WithMessage(ErrorList.PostalCodeExsistanceError);

            RuleFor(address => address.State).MaximumLength(MaxStateLength).WithMessage(ErrorList.StateError);

            RuleFor(address => address.State).NotEmpty().WithMessage(ErrorList.StateExsistanceError);

        }
    }

}

