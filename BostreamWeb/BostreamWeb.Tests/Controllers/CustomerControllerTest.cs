using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BostreamWeb;
using BostreamWeb.Controllers;
using BostreamWeb.Models;

namespace BostreamWeb.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {

        [TestMethod]
        public void NewCustomer()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            ViewResult result = controller.NewCustomer() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DBInstance()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            BostreamEntities1 result = new BostreamEntities1(); ;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
