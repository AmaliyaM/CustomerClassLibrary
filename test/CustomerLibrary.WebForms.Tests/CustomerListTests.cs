using CustomerInformation;
using CustomerLibrary.Interfaces;
using Moq;

namespace CustomerLibrary.WebForms.Tests
{
    public class CustomerListTests
    {
        [Fact]
        public void ShouldBeLoadCustomersFromDatabase()
        {
            var customerRepositoryMock = new Mock<IRepository<CustomerClass>>();
            customerRepositoryMock.Setup(item => item.GetAll()).Returns(()=>new List<CustomerClass>() 
            {
                new CustomerClass(),
                new CustomerClass()
            });
            var customerList = new CustomerList(customerRepositoryMock.Object);
            customerList.LoadCustomersFromDatabase();
            Assert.Equal(2, customerList.Customers.Count);
        }
    }
}