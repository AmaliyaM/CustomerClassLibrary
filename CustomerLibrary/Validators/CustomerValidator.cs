using System.Text.RegularExpressions;
using FluentValidation;
namespace CustomerInformation
{
    public class CustomerValidator : AbstractValidator<CustomerClass>
    {
        const int MaxNameLength = 50;
        const string PhoneNumberRule = @"^\+[1-9]\d{1,14}$";
        const string EmailRule = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).MaximumLength(MaxNameLength).WithMessage(ErrorList.FirstNameError);

            RuleFor(customer => customer.LastName).NotEmpty().WithMessage(ErrorList.LastNameExsistanceError);

            RuleFor(customer => customer.LastName).MaximumLength(MaxNameLength).WithMessage(ErrorList.LastNameErrorLength);

            RuleFor(customer => customer.Addresses).NotEmpty().WithMessage(ErrorList.AddressError);

            RuleFor(customer => customer.PhoneNumber).Matches(PhoneNumberRule).WithMessage(ErrorList.PhoneNumberError);

            RuleFor(customer => customer.Notes).NotEmpty().WithMessage(ErrorList.NotesLengthError);

            RuleFor(customer => customer.Email).Matches(EmailRule).WithMessage(ErrorList.EmailError);

            RuleFor(customer => customer.TotalPurchasesAmount).GreaterThan(0).WithMessage(ErrorList.PurchaseError);


        }
    }
}

