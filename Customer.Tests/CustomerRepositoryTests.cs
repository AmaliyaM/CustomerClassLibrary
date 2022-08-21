using CustomerInformation;
using CustomerLibrary.Repositories;
namespace Customer.Tests
{
    public class CustomerRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateRepository()
        {
            var repository = new CustomerRepository();

            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            CustomerFixture.CreateMockCustomer();

        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            CustomerFixture.CreateMockCustomer();
            var createdCustomer = CustomerFixture.CreateCustomerRepository().Read("ashfjfnh@gmail.com");

        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var customer = CustomerFixture.CreateMockCustomer();
            var repository = CustomerFixture.CreateCustomerRepository();
            customer.LastName = "updated2";
            repository.Update(customer);
            var result = repository.Read("ashfjfnh@gmail.com").LastName;
            Assert.Equal(result, "updated2");

        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customer = CustomerFixture.CreateMockCustomer();
            var repository = CustomerFixture.CreateCustomerRepository();
            repository.Delete(customer);
            var deletedCustomer = repository.Read("ashfjfnh@gmail.com");
            Assert.Null(deletedCustomer);
        }


        public class CustomerFixture
        {
            public static CustomerClass CreateMockCustomer()
            {
                List<Address> adressList = new List<Address>();
                Address addItem = new Address
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
                adressList.Add(addItem);
                List<string> notesList = new List<string>();
                notesList.Add("note1");
                var repository = new CustomerRepository();
                CustomerClass customer = new CustomerClass
                {
                    FirstName = "John",
                    LastName = "Second",
                    Addresses = adressList,
                    Notes = notesList,
                    Email = "ashfjfnh@gmail.com",
                    PhoneNumber = "+16175551212",
                    TotalPurchasesAmount = 4
                };
                repository.Create(customer);
                return customer;

            }

            public static CustomerRepository CreateCustomerRepository() => new CustomerRepository();
        }

    }
}