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
            InformationController controller = new InformationController();
            //e-mail sample data
            string name = "Andres";
            string lastName = "Pereira";
            string company = "ULACIT";
            string receiver = "test@gmail.com";
            string phone = "12345678";
            string service1 = "service-test-1";
            string service2 = "service-test-2";
            string service3 = "service-test-3";
            string service4 = "service-test-4";
            string subject = "test";
            string message = "testing";

            // Act
            ViewResult result = controller.SendEmail(name, lastName, company, receiver, phone, service1, service2,
                service3, service4, subject, message) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
