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
    public class QuotationControllerTest
    {
        [TestMethod]
        public void NewQuotation()
        {
            // Arrange
            QuotationController controller = new QuotationController();

            // Act
            ViewResult result = controller.NewQuotation() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        public void QuotationList()
        {
            // Arrange
            QuotationController controller = new QuotationController();

            // Act
            ViewResult result = controller.QuotationList() as ViewResult;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DBInstance()
        {
            // Arrange
            QuotationController controller = new QuotationController();

            // Act
            BostreamEntities1 result = new BostreamEntities1(); ;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
