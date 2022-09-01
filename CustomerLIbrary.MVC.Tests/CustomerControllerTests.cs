using CustomerLibrary.Entities;
using CustomerLibrary.Interfaces;
using CustomerLibrary.MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var customersResult = controller.Index(3);
            var customersView = customersResult as ViewResult;
            var customerModel = customersView.Model as List<CustomerClass>;
            Assert.IsTrue(customerModel.Exists(x => x.ID == 1053));
        }


        [TestMethod]
        public void ShouldCreateCustomer()
        {
            var customerControllerMock = new Mock<IRepository<CustomerClass>>();
            var customersController = new CustomerController(customerControllerMock.Object);
            customersController.Create();
            var result = customersController.Create(new CustomerClass()
            {
                FirstName = "Created",
                LastName = "AtControllerTest",
                Email = "new2@gmail.com",
                PhoneNumber = "+16175551212",
                TotalPurchasesAmount = 4
            }) as RedirectToRouteResult;

            Assert.IsNotNull(result);

        }
    }
}
