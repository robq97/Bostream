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
    class WorkControllerTest
    {
        [TestMethod]
        public void WorkGallery()
        {
            // Arrange
            WorkController controller = new WorkController();

            // Act
            ViewResult result = controller.WorkGallery() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
