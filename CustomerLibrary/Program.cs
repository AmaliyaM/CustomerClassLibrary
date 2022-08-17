using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.TestHelper;
//using LINQ;



namespace CustomerInformation

{
    public class Program
    {
        static void Main(string[] args)
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
         CustomerValidator validator = new CustomerValidator();
        //var validationResult = (validator.TestValidate(customer)).ToArray();
            //Console.Write(validationResult);

        }
    }
}

