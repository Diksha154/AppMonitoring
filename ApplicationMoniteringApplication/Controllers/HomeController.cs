using ApplicationMoniteringApplication.BusinessLayer;
using ApplicationMoniteringApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ApplicationMoniteringApplication.Controllers
{
    public interface IPatientRepository
    {       
        JsonResult GetFilteredData(string duration, string category);
    }
    public class HomeController : Controller
    {
        public readonly IPatientRepository mPatientRepository;

        public HomeController(IPatientRepository patientRepository)
        {
            mPatientRepository = patientRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFilteredData(string duration, string category)
        {
            string duration_val = duration;
            string cat_val = category;

            //string cat_val = Request.Form["Category"];  //or
            //cat_val = Request["Category"];
            //string duration_val = Request.Form["Duration"];  //or
            //duration_val = Request["Duration"];  

            if (!string.IsNullOrEmpty(cat_val) && !string.IsNullOrEmpty(duration_val))
            {
                if (cat_val != "0" && duration_val != "0")
                {
                    HomeBusiness homeBusiness = new HomeBusiness();

                    //Daily
                    //if (duration_val == "1")
                    //{
                    if (cat_val == "1")//Longest running job 
                    {
                        var filterData = homeBusiness.GetLongestRuningJobs(duration_val);
                        return Json(filterData, JsonRequestBehavior.AllowGet);
                    }
                    else if (cat_val == "2") //Maximum number of failures
                    {
                        var filterData = homeBusiness.GetMaxFailureApp(duration_val);
                        return Json(filterData, JsonRequestBehavior.AllowGet);
                    }
                    else if (cat_val == "3") //Maximum number of recurring job failures
                    {
                        var filterData = homeBusiness.GetRecurringJobFailure(duration_val);
                        return Json(filterData, JsonRequestBehavior.AllowGet);
                    }
                    else if (cat_val == "4") //P1-P2 incidents
                    {
                        var filterData = homeBusiness.GetHightCriticalIncidents(duration_val);
                        return Json(filterData, JsonRequestBehavior.AllowGet);
                    }
                    //}

                    else
                    {
                        return new JsonResult();
                    }
                    //Monthly
                    //else if (duration_val == "2")
                    //{
                    //    if (cat_val == "1") //Longest running job
                    //    {
                    //        filterdData = homeBusiness.GetLongestRuningJobs(duration_val);
                    //        return View("Index", filterdData);
                    //    }
                    //    else if (cat_val == "2")//Maximum number of failures 
                    //    {
                    //        filterdData = homeBusiness.GetMaxFailureApp(duration_val);
                    //        return View("Index", filterdData);
                    //    }
                    //    else if (cat_val == "3") //Maximum number of recurring job failures 
                    //    {

                    //    }
                    //    else if (cat_val == "4") //P1-P2 incidents 
                    //    {

                    //    }
                    //}

                    ////Yearly
                    //else if (duration_val == "3")
                    //{
                    //    if (cat_val == "1")//Longest running job 
                    //    {
                    //        filterdData = homeBusiness.GetLongestRuningJobs(duration_val);
                    //        return View("Index", filterdData);
                    //    }
                    //    else if (cat_val == "2") //Maximum number of failures                         {
                    //    {
                    //        filterdData = homeBusiness.GetMaxFailureApp(duration_val);
                    //        return View("Index", filterdData);
                    //    }
                    //    else if (cat_val == "3")//Maximum number of recurring job failures
                    //    {

                    //    }
                    //    else if (cat_val == "4") //P1-P2 incidents 
                    //    {

                    //    }
                    //}
                }
                else
                {
                    return new JsonResult();
                }
            }
            else
            {
                return new JsonResult();
            }


            return new JsonResult();

            //IndexFilteredModel indexFilteredModel1 = new IndexFilteredModel()
            //{
            //    ApplicationName = "abc1",
            //    JobName = "job1",
            //    Runtime = "234",
            //    ScheduleTypeId = "1"
            //};
            //IndexFilteredModel indexFilteredModel2 = new IndexFilteredModel()
            //{
            //    ApplicationName = "def1",
            //    JobName = "job2",
            //    Runtime = "234",
            //    ScheduleTypeId = "1"
            //};
            //IndexFilteredModel indexFilteredModel3 = new IndexFilteredModel()
            //{
            //    ApplicationName = "ghi1",
            //    JobName = "job3",
            //    Runtime = "234",
            //    ScheduleTypeId = "1"
            //};

            //filterdData.Add(indexFilteredModel1);
            //filterdData.Add(indexFilteredModel2);
            //filterdData.Add(indexFilteredModel3);

            //return View("Index", filterdData);
        }

        public JsonResult GetIncidentData(string id)
        {
            if (id == null || string.IsNullOrEmpty(id))
            {
                return new JsonResult();
            }
            HomeBusiness homeBusiness = new HomeBusiness();

            var filterData = homeBusiness.GetIncidentData(id);
            return Json(filterData, JsonRequestBehavior.AllowGet);
            //return new JsonResult();
        }

        public ActionResult GetJobData(string id, string duration)
        {
            if (id == null || string.IsNullOrEmpty(id))
            {
                return new JsonResult();
            }
            HomeBusiness homeBusiness = new HomeBusiness();
            var filterData = homeBusiness.GetJobData(id, duration);
            return Json(filterData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetApplicationJobData(string id, string jobId, string duration)
        {
            if (id == null || string.IsNullOrEmpty(id) || jobId == null || string.IsNullOrEmpty(jobId))
            {
                return new JsonResult();
            }
            HomeBusiness homeBusiness = new HomeBusiness();
            var filterData = homeBusiness.GetApplicationJobData(id,jobId, duration);
            return Json(filterData, JsonRequestBehavior.AllowGet);
        }
    }
}
