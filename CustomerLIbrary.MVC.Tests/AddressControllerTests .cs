using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using CustomerLibrary.MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CustomerLIbrary.MVC.Tests
{
    [TestClass]
    public class AddressControllerTests
    {
        [TestMethod]
        public void ShouldCreateAddressController()
        {
            var controller = new AddressController();
            Assert.IsNotNull(controller);
        }



        [TestMethod]
        public void ShouldCreateAddress()
        {
            var addressControllerMock = new Mock<IAddressService>();
            var addressController = new AddressController(addressControllerMock.Object);
            addressController.Create();
            var result = addressController.Create(1053, new Address()
            {
                FirstLine = "Created",
                SecondLine = "AtControllerTest",
                City = "new2",
                State = "1212",
                Type = AddressType.Billing,
                Country = AvailableCountries.Canada
            }) as RedirectToRouteResult;

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ShouldBeAbleToDeleteAddress()
        {
            var addressControllerMock = new Mock<IAddressService>();
            var addressController = new AddressController(addressControllerMock.Object);
            var result = addressController.Delete(1053);
            addressController.Verify(x => x.Delete(1053));
        }

        [TestMethod]
        public void ShouldBeAbleToUpdateAddress()
        {
            var addressControllerMock = new Mock<IAddressService>();
            var addressController = new AddressController(addressControllerMock.Object);
           var result = addressController.Edit(14,1053,new Address()
            {
                AddressId = 14,
                FirstLine = "update",

            });

            Assert.IsNotNull(result);

        }
    }
}
