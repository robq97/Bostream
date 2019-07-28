using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BostreamWeb;
using BostreamWeb.Controllers;

namespace BostreamWeb.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void CustomerView()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            ViewResult result = controller.CustomerView() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        public void NewCustomer()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            ViewResult result = controller.NewCustomer() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
