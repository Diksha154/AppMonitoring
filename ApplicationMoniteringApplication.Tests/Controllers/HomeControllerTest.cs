using ApplicationMoniteringApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Collections.Generic;
using ApplicationMoniteringApplication.Controllers;
using Moq;
using ApplicationMoniteringApplication.Models;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Text;

namespace ApplicationMoniteringApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        public Mock<IPatientRepository> patientRepoMock;
        public HomeController target;

        
        //[TestMethod]
        //public void Index()
        //{
        //    // Arrange
        //    //HomeController controller = new HomeController();

        //    // Act


        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void GetFilteredData()
        {
            string duration_val = null;
            string cat_val = null;
            patientRepoMock = new Mock<IPatientRepository>();
            target = new HomeController(patientRepoMock.Object);

            var data = new JsonResult
                {
                    Data =
                    new IndexFilteredModel
                    { 
                        ApplicationName="",
                        JobName = "",
                        ApplicationNo = "",
                        FilterOn="",
                        ScheduleTypeId=""
                    }
            };

            // Arrange
            patientRepoMock.Setup(r => r.GetFilteredData(duration_val,cat_val)).Returns(data);
            var result = target.GetFilteredData(duration_val, cat_val);

            Assert.IsNotNull(result);
            Assert.IsNull(result);        
     
        }

        //[TestMethod]
        //public void GetFilteredData_catNotNull()
        //{
        //    string duration_val = "1";
        //    string cat_val = "1";
        //   //string result = "";

        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    JsonResult result = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void GetFilteredData_IsDurationNull(string duration, string category)
        //{
        //    string duration_val = null;
        //    string cat_val = null;
        //    string jsonResult = "";

        //    if (!string.IsNullOrEmpty(cat_val) && !string.IsNullOrEmpty(duration_val))
        //    {
        //        return Json(jsonResult, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return new JsonResult();
        //    }
        //}

        ////[TestMethod]
        //public JsonResult GetFilteredData_IsDurationNotNull(string duration, string category)
        //{
        //    string duration_val = "1";
        //    string cat_val = "1";


        //    if (!string.IsNullOrEmpty(cat_val) && !string.IsNullOrEmpty(duration_val))
        //    {

        //    }
        //    else
        //    {
        //        return new JsonResult();
        //    }
        //}
    }
}
