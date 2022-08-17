namespace CustomerInformation
{
    public class CustomerClass : Person
    {
        public List<Address> Addresses { get; set; } = new List<Address>();

        public string? PhoneNumber { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public List<string> Notes { get; set; } = new List<string>();

        public decimal? TotalPurchasesAmount { get; set; } = 0;

        public CustomerClass(string firstName, string lastName, List<Address> address, List<string> notes, string email, string phoneNumber, decimal amount)
        {
            FirstName = firstName;
            LastName = lastName;
            Addresses = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Notes = notes;
            TotalPurchasesAmount = amount;
        }
    }

}

