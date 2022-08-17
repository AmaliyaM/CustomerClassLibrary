using System.Text.RegularExpressions;
namespace CustomerInformation
{
    public class CustomerValidator
    {
        const int MaxNameLength = 50;
        const string PhoneNumberRule = @"^\+[1-9]\d{1,14}$";
        const string EmailRule = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public static List<string> ValidateCustomer(CustomerClass checkedCustomer)
        {

            List<string> errorList = new List<string>();

            if (checkedCustomer.FirstName.Length > MaxNameLength)
            {
                errorList.Add(ErrorList.FirstNameError);
            }

            if (String.IsNullOrEmpty(checkedCustomer.LastName))
            {
                errorList.Add(ErrorList.LastNameExsistanceError);
            }

            if (checkedCustomer.LastName.Length > MaxNameLength)
            {
                errorList.Add(ErrorList.LastNameErrorLength);
            }
                
            if (checkedCustomer.Addresses.Count <1)
            {
                errorList.Add(ErrorList.AddressError);
            }

            if (!Regex.IsMatch(checkedCustomer.PhoneNumber, PhoneNumberRule)) {

                errorList.Add(ErrorList.PhoneNumberError);

            }

            if (checkedCustomer.Notes.Count < 1)
            {
                errorList.Add(ErrorList.NotesLengthError);
            }

            if (!Regex.IsMatch(checkedCustomer.Email,EmailRule)) {

                errorList.Add(ErrorList.EmailError);

            }

            if(checkedCustomer.TotalPurchasesAmount < 0)
            {
                errorList.Add(ErrorList.PurchaseError);
            }

            return errorList;


        }
    }

}

