using ApplicationMoniteringApplication.BusinessLayer;
using ApplicationMoniteringApplication.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ApplicationMoniteringApplication.Controllers
{
    //public interface IPatientRepository
    //{       
    //    JsonResult GetFilteredData(string duration, string category);
    //}
    public class HomeController : Controller
    {
        //public readonly IPatientRepository mPatientRepository;

        //public HomeController(IPatientRepository patientRepository)
        //{
        //    mPatientRepository = patientRepository;
        //}
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFilteredData(string duration, string category)
        {
            string duration_val = duration;
            string cat_val = category;

            if (!string.IsNullOrEmpty(cat_val) && !string.IsNullOrEmpty(duration_val))
            {
                if (cat_val != "0" && duration_val != "0")
                {
                    HomeBusiness homeBusiness = new HomeBusiness();

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
                    else
                    {
                        return new JsonResult();
                    }
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
            var filterData = homeBusiness.GetApplicationJobData(id, jobId, duration);
            return Json(filterData, JsonRequestBehavior.AllowGet);
        }
    }
}
