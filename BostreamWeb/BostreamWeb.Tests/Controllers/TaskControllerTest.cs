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
    class TaskControllerTest
    {

      
        public void NewTask()
        {
            // Arrange
            TaskController controller = new TaskController();

            // Act
            ViewResult result = controller.NewTask() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
