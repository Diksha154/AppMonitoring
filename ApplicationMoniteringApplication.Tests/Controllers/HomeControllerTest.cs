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
        [TestMethod]
        public void Index_Return()
        {
            HomeController controller = new HomeController();

            var result = controller.Index();

            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType<ViewResult>(result);
        }

        [TestMethod]
        public void GetFilteredData()
        {
            HomeController controller = new HomeController();
            string duration_val = null;
            string cat_val = null;

            var data = "[{}]";

            // Arrange          

            JsonResult result = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(result);
            //Assert.IsNull(result);
        }

        [TestMethod]
        public void GetFilteredData_11()
        {
            HomeController controller = new HomeController();
            string duration_val = "1";
            string cat_val = "1";

            var expectedData = "[{'ApplicationNo':null,'ApplicationName':'AccountPayable','JobName':'AP0002','ScheduleTypeId':null,'FilterOn':'990 secound'},{'ApplicationNo':null,'ApplicationName':'AGI','JobName':'AGI001','ScheduleTypeId':null,'FilterOn':'990 secound'},{'ApplicationNo':null,'ApplicationName':'CGL','JobName':'CGL0001','ScheduleTypeId':null,'FilterOn':'990 secound'},{'ApplicationNo':null,'ApplicationName':'HyperionEssbase','JobName':'HE0001','ScheduleTypeId':null,'FilterOn':'990 secound'},{'ApplicationNo':null,'ApplicationName':'CVA','JobName':'CVA0001','ScheduleTypeId':null,'FilterOn':'990 secound'}]";
            //json indexFilteredModels= JsonConvert.SerializeObject(expectedData);

            //JsonConvert.SerializeObject(expectedData);

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(JsonConvert.DeserializeObject<List<IndexFilteredModel>>(expectedData), actualData.Data);
            //Assert.Equals(JsonConvert.DeserializeObject<List<IndexFilteredModel>>(expectedData)[0].FilterOn, )
        }

        [TestMethod]
        public void GetFilteredData_12()
        {
            HomeController controller = new HomeController();
            string duration_val = "1";
            string cat_val = "2";

            var expectedData = "[{'ApplicationNo':null,'ApplicationName':'AccountPayable','JobName':'AP0003','ScheduleTypeId':null,'FilterOn':'987 secound'},{'ApplicationNo':null,'ApplicationName':'AGI','JobName':'AGI0003','ScheduleTypeId':null,'FilterOn':'987 secound'},{'ApplicationNo':null,'ApplicationName':'CGL','JobName':'CGL0003','ScheduleTypeId':null,'FilterOn':'987 secound'},{'ApplicationNo':null,'ApplicationName':'HyperionEssbase','JobName':'HE0003','ScheduleTypeId':null,'FilterOn':'987 secound'},{'ApplicationNo':null,'ApplicationName':'CVA','JobName':'CVA0003','ScheduleTypeId':null,'FilterOn':'987 secound'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_13()
        {
            HomeController controller = new HomeController();
            string duration_val = "1";
            string cat_val = "3";

            var expectedData = "[{'ApplicationNo':null,'ApplicationName':'AccountPayable','JobName':'AP0004','ScheduleTypeId':null,'FilterOn':'901 secound'},{'ApplicationNo':null,'ApplicationName':'AGI','JobName':'AGI0004','ScheduleTypeId':null,'FilterOn':'901 secound'},{'ApplicationNo':null,'ApplicationName':'CGL','JobName':'CGL0004','ScheduleTypeId':null,'FilterOn':'901 secound'},{'ApplicationNo':null,'ApplicationName':'Murex','JobName':'MX0004','ScheduleTypeId':null,'FilterOn':'901 secound'},{'ApplicationNo':null,'ApplicationName':'Reporting','JobName':'RP0004','ScheduleTypeId':null,'FilterOn':'987 secound'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;
            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_21()
        {
            HomeController controller = new HomeController();
            string duration_val = "2";
            string cat_val = "1";

            var expectedData = "[{'ApplicationNo':'1','ApplicationName':'AccountPayable','JobName':null,'ScheduleTypeId':null,'FilterOn':'31'},{'ApplicationNo':'2','ApplicationName':'AGI','JobName':null,'ScheduleTypeId':null,'FilterOn':'30'},{'ApplicationNo':'3','ApplicationName':'CGL','JobName':null,'ScheduleTypeId':null,'FilterOn':'23'},{'ApplicationNo':'4','ApplicationName':'HyperionEssbase','JobName':null,'ScheduleTypeId':null,'FilterOn':'19'},{'ApplicationNo':'5','ApplicationName':'CVA','JobName':null,'ScheduleTypeId':null,'FilterOn':'16'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;
            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_22()
        {
            HomeController controller = new HomeController();
            string duration_val = "2";
            string cat_val = "2";

            var expectedData = "[{'ApplicationNo':'4','ApplicationName':'HyperionEssbase','JobName':null,'ScheduleTypeId':null,'FilterOn':'3'},{'ApplicationNo':'3','ApplicationName':'CGL','JobName':null,'ScheduleTypeId':null,'FilterOn':'3'},{'ApplicationNo':'2','ApplicationName':'AGI','JobName':null,'ScheduleTypeId':null,'FilterOn':'3'},{'ApplicationNo':'1','ApplicationName':'AccountPayable','JobName':null,'ScheduleTypeId':null,'FilterOn':'3'},{'ApplicationNo':'6','ApplicationName':'Murex','JobName':null,'ScheduleTypeId':null,'FilterOn':'2'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_23()
        {
            HomeController controller = new HomeController();
            string duration_val = "2";
            string cat_val = "3";

            var expectedData = "[{'ApplicationNo':'2','ApplicationName':'AGI','JobName':null,'ScheduleTypeId':null,'FilterOn':'2'},{'ApplicationNo':'5','ApplicationName':'CVA','JobName':null,'ScheduleTypeId':null,'FilterOn':'2'},{'ApplicationNo':'7','ApplicationName':'Reporting','JobName':null,'ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':'6','ApplicationName':'Murex','JobName':null,'ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':'3','ApplicationName':'CGL','JobName':null,'ScheduleTypeId':null,'FilterOn':'1'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_31()
        {
            HomeController controller = new HomeController();
            string duration_val = "3";
            string cat_val = "1";

            var expectedData = "[{'ApplicationNo':'1','ApplicationName':'AccountPayable','JobName':'AP0002','ScheduleTypeId':null,'FilterOn':'16'},{'ApplicationNo':'2','ApplicationName':'AGI','JobName':'AGI001','ScheduleTypeId':null,'FilterOn':'15'},{'ApplicationNo':'3','ApplicationName':'CGL','JobName':'CGL0002','ScheduleTypeId':null,'FilterOn':'15'},{'ApplicationNo':'4','ApplicationName':'HyperionEssbase','JobName':'HE0002','ScheduleTypeId':null,'FilterOn':'15'},{'ApplicationNo':'5','ApplicationName':'CVA','JobName':'CVA0001','ScheduleTypeId':null,'FilterOn':'8'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_32()
        {
            HomeController controller = new HomeController();
            string duration_val = "3";
            string cat_val = "2";

            var expectedData = "[{'ApplicationNo':'1','ApplicationName':'AccountPayable','JobName':'AP0003','ScheduleTypeId':null,'FilterOn':'3'},{'ApplicationNo':'2','ApplicationName':'AGI','JobName':'AGI0003','ScheduleTypeId':null,'FilterOn':'3'},{'ApplicationNo':'3','ApplicationName':'CGL','JobName':'CGL0003','ScheduleTypeId':null,'FilterOn':'3'},{'ApplicationNo':'4','ApplicationName':'HyperionEssbase','JobName':'HE0003','ScheduleTypeId':null,'FilterOn':'3'},{'ApplicationNo':'6','ApplicationName':'Murex','JobName':'MX0003','ScheduleTypeId':null,'FilterOn':'2'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_33()
        {
            HomeController controller = new HomeController();
            string duration_val = "3";
            string cat_val = "3";

            var expectedData = "[{'ApplicationNo':'1','ApplicationName':'AccountPayable','JobName':'AP0004','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':'2','ApplicationName':'AGI','JobName':'AGI0004','ScheduleTypeId':null,'FilterOn':'2'},{'ApplicationNo':'3','ApplicationName':'CGL','JobName':'CGL0004','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':'5','ApplicationName':'CVA','JobName':'CVA0004','ScheduleTypeId':null,'FilterOn':'2'},{'ApplicationNo':'6','ApplicationName':'Murex','JobName':'MX0004','ScheduleTypeId':null,'FilterOn':'1'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_41()
        {
            HomeController controller = new HomeController();
            string duration_val = "4";
            string cat_val = "1";

            var expectedData = "[{'ApplicationNo':null,'ApplicationName':'AccountPayable','JobName':'INCAP2001','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'AccountPayable','JobName':'INCAP2002','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'AccountPayable','JobName':'INCAP2003','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'AccountPayable','JobName':'INCAP2006','ScheduleTypeId':null,'FilterOn':'2'},{'ApplicationNo':null,'ApplicationName':'CGL','JobName':'IN32002','ScheduleTypeId':null,'FilterOn':'2'},{'ApplicationNo':null,'ApplicationName':'HyperionEssbase','JobName':'INCHE20004','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'HyperionEssbase','JobName':'INCHE20005','ScheduleTypeId':null,'FilterOn':'2'},{'ApplicationNo':null,'ApplicationName':'CVA','JobName':'IN52003','ScheduleTypeId':null,'FilterOn':'2'},{'ApplicationNo':null,'ApplicationName':'Reporting','JobName':'INCRP2001','ScheduleTypeId':null,'FilterOn':'2'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_42()
        {
            HomeController controller = new HomeController();
            string duration_val = "4";
            string cat_val = "2";

            var expectedData = "[{'ApplicationNo':null,'ApplicationName':'AGI','JobName':'INCAG2002','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'AGI','JobName':'INCAG2003','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'AGI','JobName':'INCAG2005','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'CGL','JobName':'IN32004','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'CVA','JobName':'IN52005','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'CVA','JobName':'IN52007','ScheduleTypeId':null,'FilterOn':'1'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetFilteredData_43()
        {
            HomeController controller = new HomeController();
            string duration_val = "4";
            string cat_val = "3";

            var expectedData = "[{'ApplicationNo':null,'ApplicationName':'AGI','JobName':'INCAG2008','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'CVA','JobName':'IN52002','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'Reporting','JobName':'INCRP2005','ScheduleTypeId':null,'FilterOn':'1'},{'ApplicationNo':null,'ApplicationName':'Reporting','JobName':'INCRP2006','ScheduleTypeId':null,'FilterOn':'1'}]";

            JsonResult actualData = controller.GetFilteredData(duration_val, cat_val) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetIncidentData_result()
        {
            HomeController controller = new HomeController();
            string incidentId = "INCAP2001";

            var expectedData = "[{'ApplicationName':'AccountPayable','IncidentName':'INCAP2001','Details':'Please perform database clean up ','CreatedOn':'5/1/2023 12:00:00 AM','Priority':'1','CreatedBy':'Hari','Title':'Database clean up'}]";
            JsonResult actualData = controller.GetIncidentData(incidentId) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
        }

        [TestMethod]
        public void GetJobData_result()
        {
            HomeController controller = new HomeController();
            string id = "4";
            string duration = "1";

            var expectedData = "[{'ApplicationName':'AccountPayable','IncidentName':'INCAP2001','Details':'Please perform database clean up ','CreatedOn':'5/1/2023 12:00:00 AM','Priority':'1','CreatedBy':'Hari','Title':'Database clean up'}]";
            JsonResult actualData = controller.GetJobData(id, duration) as JsonResult;

            Assert.IsNotNull(actualData);
            //Assert.AreEqual(expectedData, actualData);
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

