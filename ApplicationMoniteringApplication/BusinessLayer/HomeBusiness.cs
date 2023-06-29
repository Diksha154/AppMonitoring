using ApplicationMoniteringApplication.DatabaseLayer;
using ApplicationMoniteringApplication.Models;
using System;
using System.Collections.Generic;

namespace ApplicationMoniteringApplication.BusinessLayer
{
    public class HomeBusiness 
    {
        SqlGenericRepository genericRepository = new SqlGenericRepository();
        public List<IndexFilteredModel> GetLongestRuningJobs(string duration)
        {
            List<IndexFilteredModel> records = genericRepository.GetLongestRuningJobs(duration);
            return records;
        }
        public List<IndexFilteredModel> GetMaxFailureApp(string duration)
        {
            List<IndexFilteredModel> records = genericRepository.GetMaxFailureApp(duration);
            return records;
        }
        public List<IndexFilteredModel> GetRecurringJobFailure(string duration)
        {
            List<IndexFilteredModel> records = genericRepository.GetRecurringJobFailure(duration);
            return records;
        }

        public List<IndexFilteredModel> GetHightCriticalIncidents(string duration)
        {
            List<IndexFilteredModel> records = genericRepository.GetHightCriticalIncidents(duration);
            return records;
        }
        public List<IncidentModel> GetIncidentData(string id)
        {
            List<IncidentModel> records = genericRepository.GetIncidentData(id);
            return records;
        }

        public List<JobMonitorModel>  GetJobData(string id,string duration)
        {
            List<JobMonitorModel> records = genericRepository.GetJobData(id, duration);
            return records;
        }

        public List<JobMonitorModel> GetApplicationJobData(string id, string jobId, string duration)
        {
            List<JobMonitorModel> records = genericRepository.GetApplicationJobData(id,jobId,duration);
            return records;
        }
    }
}