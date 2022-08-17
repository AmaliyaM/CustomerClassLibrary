using System;
using System.ComponentModel.DataAnnotations;
namespace CustomerInformation

{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Address> adressList = new List<Address>();
            Address addItem = new Address("Road Street", "Maint Avenue", AdressType.Billing, "Toronto", "346330", "Alberta", AvailableCountries.Canada);
            adressList.Add(addItem);
            List<string> notes = new List<string>();
            notes.Add("note1");
            CustomerClass customer = new CustomerClass("anhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhggggggfbdgtbgxfdg", "",adressList,notes,"hshdh@fhhf.com","89281989",3);
            Console.WriteLine(customer);
        }
    }
}

