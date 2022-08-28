using CustomerInformation;
using CustomerLibrary.Interfaces;
using Moq;
using System;

namespace CustomerLibrary.WebForms.Tests
{
    public class CustomerEditTests
    {
        [Fact]
        public void ShouldCreateCountry()
        {
            var customerRepositoryMock = new Mock<IRepository<CustomerClass>>();
            var customerEdit = new CustomerEdit(customerRepositoryMock.Object);
            customerEdit.OnClickSave(this, EventArgs.Empty);
            customerRepositoryMock.Verify(item => item.Create(It.IsAny<CustomerClass>()));
        }
    }
}
