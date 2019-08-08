using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BostreamWeb;
using Bostream.Controllers;
using BostreamWeb.Models;

namespace BostreamWeb.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void Login()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            ViewResult result = controller.LogIn() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        public void LogOut()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            ViewResult result = controller.LogOut() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.
        }
        public void Authentication()
        {
            // Arrange
            AdminController controller = new AdminController();
            Admin sampleAdmin = new Admin();
            sampleAdmin.AdminId = 1;
            sampleAdmin.password = "1234";
            sampleAdmin.PersonId = 1;
            sampleAdmin.username = "test";

            // Act
            ViewResult result = controller.Authentication(sampleAdmin) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

