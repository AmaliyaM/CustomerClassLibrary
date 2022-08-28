using CustomerInformation;
using CustomerLibrary.Repositories;

namespace Customer.Tests
{
    public class AddressRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateAddressRepository()
        {
            var repository = new AddressRepository();

            Assert.NotNull(repository);
        }

        [Fact]
        public void ShouldBeAbleToCreateAddress()
        {
            var address = AddressFixture.CreateMockAddress();
            Assert.NotNull(address);

        }

        [Fact]
        public void ShouldBeAbleToReadAddress()
        {
            AddressFixture.CreateMockAddress();
            var createdAddress = AddressFixture.CreateAddressRepository().Read("780");
            Assert.Equal(createdAddress.FirstLine, "updated2");

        }

        [Fact]
        public void ShouldBeAbleToUpdateAddress()
        {
            var address = AddressFixture.CreateMockAddress();
            var repository = AddressFixture.CreateAddressRepository();
            address.FirstLine = "updated2";
            repository.Update(address);
            var result = repository.Read("780").FirstLine;
            Assert.Equal(result, "updated2");

        }

        [Fact]
        public void ShouldBeAbleToDeleteAddress()
        {
            var address = AddressFixture.CreateMockAddress();
            var repository = AddressFixture.CreateAddressRepository();
            repository.Delete(address);
            var deletedAddress = repository.Read("569");
            Assert.Null(deletedAddress);
        }


        public class AddressFixture
        {
            public static Address CreateMockAddress()
            {
                Address address = new Address {
                    FirstLine = "Road Street",
                    SecondLine = "Maint Avenue",
                    Type = AddressType.Billing,
                    City = "Toronto",
                    PostalCode = "346330",
                    State = "Alberta",
                    Country = AvailableCountries.Canada,
                    CustomerId = 780
                };
                var repository = new AddressRepository();
                repository.Create(address);
                return address;

            }

            public static AddressRepository CreateAddressRepository() => new AddressRepository();
        }

    }
}
