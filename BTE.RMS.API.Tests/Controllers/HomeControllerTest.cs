using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BTE.RMS.API;
using BTE.RMS.API.Controllers;

namespace BTE.RMS.API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
