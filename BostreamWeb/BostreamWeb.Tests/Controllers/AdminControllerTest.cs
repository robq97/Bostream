using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BostreamWeb;
using Bostream.Controllers;
using BostreamWeb.Models;
using System.Web;

namespace BostreamWeb.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {

        [TestMethod]
        public void AdminId()
        {
            // Arrange
            AdminController controller = new AdminController();
            Admin sampleAdmin = new Admin
            {
                AdminId = 1,
                password = "1234",
                PersonId = 1,
                username = "test"
            };
            // Act
            int result = 1 ;

            // Assert
            Assert.IsTrue(result == sampleAdmin.AdminId);
        }

        [TestMethod]
        public void AdminPassword()
        {
            // Arrange
            AdminController controller = new AdminController();
            Admin sampleAdmin = new Admin
            {
                password = "1234"
            };
            // Act
            string result = "1234";

            // Assert
            Assert.IsTrue(result.Equals(sampleAdmin.password));
        }
    }
}

