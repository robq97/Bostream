using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BostreamWeb;
using Bostream.Controllers;

namespace BostreamWeb.Tests.Controllers
{
    [TestClass]
    class ServiceControllerTest
    {
        [TestMethod]
        public void ServiceList()
        {
            // Arrange
            ServiceController controller = new ServiceController();

            // Act
            ViewResult result = controller.ServiceList() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
