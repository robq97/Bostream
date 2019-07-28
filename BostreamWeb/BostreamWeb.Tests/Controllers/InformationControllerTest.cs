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
    public class InformationControllerTest
    {
        [TestMethod]
        public void InformationForm()
        {
            // Arrange
            InformationController controller = new InformationController();

            // Act
            ViewResult result = controller.InformationForm() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        public void SendEmail()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.SendEmail() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
