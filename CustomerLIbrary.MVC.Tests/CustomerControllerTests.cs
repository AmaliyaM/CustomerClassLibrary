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
    public class CustomerControllerTests
    {
        [TestMethod]
        public void ShouldCreateCustomerController()
        {
            var controller = new CustomerController();
            Assert.IsNotNull(controller);
        }


        [TestMethod]
        public void ShouldReturnListOfCustomers()
        {
            var controller = new CustomerController();
            var customersResult = controller.Index(1);
            var customersView = customersResult as ViewResult;
            var customerModel = customersView.Model as PagedList<CustomerClass>;
            Assert.IsTrue(customerModel.Count != 0);
        }


        [TestMethod]
        public void ShouldCreateCustomer()
        {
            var customerControllerMock = new Mock<ICustomerService>();
            var customersController = new CustomerController(customerControllerMock.Object);
            customersController.Create();
            var result = customersController.Create(1, new CustomerClass()
            {
                FirstName = "Created",
                LastName = "AtControllerTest",
                Email = "new2@gmail.com",
                PhoneNumber = "+16175551212",
                TotalPurchasesAmount = 4
            }) as RedirectToRouteResult;

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ShouldBeAbleToDeleteCustomer()
        {
            var customerControllerMock = new Mock<ICustomerService>();
            var customersController = new CustomerController(customerControllerMock.Object);
            var result = customersController.Delete(1053);
            customerControllerMock.Verify(x => x.DeleteCustomer(1053));
        }

        [TestMethod]
        public void ShouldBeAbleToUpdateCustomer()
        {
            var customerControllerMock = new Mock<ICustomerService>();
            var customersController = new CustomerController(customerControllerMock.Object);
           var result = customersController.Edit(new CustomerClass()
            {
                ID = 1053,
                FirstName = "update"

            });

            Assert.IsNotNull(result);

        }
    }
}
