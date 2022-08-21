namespace CustomerInformation
{
    public class AddressValidator
    {
        const int MaxAdressLength = 100;
        const int MaxCityLength = 50;
        const int MaxPostalCodeLength = 6;
        const int MaxStateLength = 20;


        public static List<string> ValidateAddress(Address checkedAddress)
        {

            List<string> errorList = new List<string>();

            if (checkedAddress.FirstLine.Length > MaxAdressLength)
            {
                errorList.Add(ErrorList.FirstAddressLineLengthError);
            }

            if (checkedAddress.FirstLine == string.Empty)
            {
                errorList.Add(ErrorList.FirstAddressLineError);
            }

            if (checkedAddress.SecondLine.Length > MaxAdressLength)
            {
                errorList.Add(ErrorList.SecondAddressLineLengthError);
            }

            if ((checkedAddress.Type != AddressType.Billing) && (checkedAddress.Type != AddressType.Shipping))
            {
                errorList.Add(ErrorList.AddressTypeFormatError);
            }

            if (checkedAddress.City.Length > MaxCityLength)
            {
                errorList.Add(ErrorList.CityLengthError);
            }

            if (checkedAddress.City == string.Empty)
            {
                errorList.Add(ErrorList.CityExsistanceError);
            }

            if (checkedAddress.PostalCode.Length > MaxPostalCodeLength)
            {
                errorList.Add(ErrorList.PostalCodeError);
            }

            if (checkedAddress.PostalCode == string.Empty)
            {
                errorList.Add(ErrorList.PostalCodeExsistanceError);
            }
            if (checkedAddress.State.Length > MaxStateLength)
            {
                errorList.Add(ErrorList.StateError);
            }

            if (checkedAddress.State == string.Empty)
            {
                errorList.Add(ErrorList.StateExsistanceError);
            }


            return errorList;


        }
    }

}

