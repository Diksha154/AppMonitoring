using ApplicationMoniteringApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationMoniteringApplication.DatabaseLayer
{
    public class SqlGenericRepository
    {
        public List<IndexFilteredModel> GetLongestRuningJobs(string duration)
        {
            List<IndexFilteredModel> cmsList = new List<IndexFilteredModel>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UR_DataConnectionString"].ToString());
            //string sql = "SELECT distinct ApplicationName,JobID, Runtime, ScheduleTypeId,Status FROM(select *,ROW_NUMBER() over (partition by ApplicationName order by Runtime DESC) rn from AppMonitorDataset)X where rn=1 and Status=1 and   ScheduleTypeId = " + duration + " and Runtime >  MaximumRuntime;";
            //string sql = "SELECT ApplicationName,JobName, Runtime, ScheduleTypeId,Status FROM( select al.ApplicationName,jl.JobName,jl.MaximumRuntime,amd.Runtime,jl.ScheduleTypeId,amd.Status,ROW_NUMBER() over(partition by amd.ApplicationID order by Runtime DESC) rn from AppMonitorDataset amd inner join ApplicationLookup al on amd.ApplicationID = al.ApplicationId inner join JobLookup jl on amd.JobID = jl.JobID )X where rn = 1 and Status = 1 and ScheduleTypeId =  " + duration + " and Runtime > MaximumRuntime; ";

            string sql = "select top 5 ApplicationName,JobName,Runtime from(select al.ApplicationName,jl.JobName,amd.Runtime,ROW_NUMBER() over(partition by amd.ApplicationID order by amd.Runtime DESC) rn from AppMonitorDataset amd inner join ApplicationLookup al on amd.ApplicationID = al.ApplicationId inner join JobLookup jl on amd.JobID = jl.JobID where ScheduleTypeId =  " + duration + " and Status = 1 and Runtime > MaximumRuntime)X where rn = 1";
            //string sql = "SELECT ApplicationName,JobName, Runtime, ScheduleTypeId,Status FROM(select al.ApplicationName,jl.JobName,jl.MaximumRuntime,amd.Runtime,jl.ScheduleTypeId,amd.Status,ROW_NUMBER() over (partition by amd.ApplicationID order by Runtime DESC) rn from AppMonitorDataset amd inner join ApplicationLookup al on amd.ApplicationID = al.ApplicationId inner join JobLookup jl on amd.JobID = jl.JobID )X where rn=1 and Status=1 and ScheduleTypeId = " + duration + "  and Runtime >  MaximumRuntime and JobName='12345678';";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    IndexFilteredModel records = new IndexFilteredModel();
                    records.ApplicationName = Convert.ToString(reader["ApplicationName"]); //reader["ApplicationName"].ToString();
                    records.JobName = Convert.ToString(reader["JobName"]);//.ToString();
                    //records.FilterOn = "Runtime : " + reader["Runtime"].ToString();
                    records.FilterOn = Convert.ToString(reader["Runtime"]) + " secound";
                    cmsList.Add(records);
                }
            }
            catch (SqlException ex)
            {
                throw; // instead log the exception
            }
            finally
            {
                connection.Close();
            }
            return cmsList;
        }

        public List<JobMonitorModel> GetApplicationJobData(string id, string jobId, string duration)
        {
            List<JobMonitorModel> cmsList = new List<JobMonitorModel>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UR_DataConnectionString"].ToString());
            //string sql = "SELECT ApplicationName,IncidentNumber,Priority FROM App_Monitor.dbo.AppIncidents where priority <3  and ScheduleTypeId = " + duration + "  order by ApplicationName;";
            string sql = "SELECT al.ApplicationName,jl.JobID, amd.StartTime,amd.EndTime,amd.Status, amd.Runtime, amd.ErrorLog FROM  AppMonitorDataset  amd inner join ApplicationLookup al on amd.ApplicationID = al.ApplicationId inner join JobLookup jl on jl.JobID = amd.JobID WHERE Status = 0 and jl.ScheduleTypeId = " + duration + " and jl.ApplicationID = " + id + " and amd.JobID = '" + jobId + "'  order by amd.JobID  desc;";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    JobMonitorModel records = new JobMonitorModel();
                    records.ApplicationName = reader["ApplicationName"].ToString();
                    records.JobName = reader["JobID"].ToString();
                    records.StartTime = reader["StartTime"].ToString();
                    records.EndTime = reader["EndTime"].ToString();
                    records.Status = reader["Status"].ToString();
                    records.Runtime = reader["Runtime"].ToString();
                    records.ErrorDetails = reader["ErrorLog"].ToString();
                    cmsList.Add(records);
                }
            }
            catch (SqlException ex)
            {
                throw; // instead log the exception
            }
            finally
            {
                connection.Close();
            }
            return cmsList;
        }

        public List<JobMonitorModel> GetJobData(string id, string duration)
        {
            List<JobMonitorModel> cmsList = new List<JobMonitorModel>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UR_DataConnectionString"].ToString());
            //string sql = "SELECT ApplicationName,IncidentNumber,Priority FROM App_Monitor.dbo.AppIncidents where priority <3  and ScheduleTypeId = " + duration + "  order by ApplicationName;";
            string sql = "SELECT al.ApplicationName,jl.JobID, amd.StartTime,amd.EndTime,amd.Status, amd.Runtime,amd.ErrorLog FROM  AppMonitorDataset  amd inner join ApplicationLookup al on amd.ApplicationID = al.ApplicationId inner join JobLookup jl on jl.JobID = amd.JobID WHERE Status = 0 and jl.ScheduleTypeId = " + duration + " and jl.ApplicationID = " + id + " order by amd.JobID  desc;";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    JobMonitorModel records = new JobMonitorModel();
                    records.ApplicationName = reader["ApplicationName"].ToString();
                    records.JobName = reader["JobID"].ToString();
                    records.StartTime = reader["StartTime"].ToString();
                    records.EndTime = reader["EndTime"].ToString();
                    records.Status = reader["Status"].ToString();
                    records.Runtime = reader["Runtime"].ToString();
                    records.ErrorDetails = reader["ErrorLog"].ToString();
                    cmsList.Add(records);
                }
            }
            catch (SqlException ex)
            {
                throw; // instead log the exception
            }
            finally
            {
                connection.Close();
            }
            return cmsList;
        }

        public List<IndexFilteredModel> GetHightCriticalIncidents(string duration)
        {
            List<IndexFilteredModel> cmsList = new List<IndexFilteredModel>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UR_DataConnectionString"].ToString());
            //string sql = "SELECT ApplicationName,IncidentNumber,Priority FROM App_Monitor.dbo.AppIncidents where priority <3  and ScheduleTypeId = " + duration + "  order by ApplicationName;";
            string sql = "SELECT al.ApplicationName,ai.IncidentNumber,ai.Priority FROM App_Monitor.dbo.AppIncidents ai inner join ApplicationLookup al on ai.ApplicationId = al.ApplicationId where ai.priority < 3  and ai.ScheduleTypeId = " + duration + "  order by ai.ApplicationId; ";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    IndexFilteredModel records = new IndexFilteredModel();
                    records.ApplicationName = reader["ApplicationName"].ToString();
                    records.JobName = reader["IncidentNumber"].ToString();
                    records.FilterOn = reader["Priority"].ToString();
                    //records.ScheduleTypeId = GetSchedulerTypeName(reader["ScheduleTypeId"].ToString());
                    cmsList.Add(records);
                }
            }
            catch (SqlException ex)
            {
                throw; // instead log the exception
            }
            finally
            {
                connection.Close();
            }
            return cmsList;
        }

        public List<IndexFilteredModel> GetRecurringJobFailure(string duration)
        {
            List<IndexFilteredModel> cmsList = new List<IndexFilteredModel>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UR_DataConnectionString"].ToString());
            //string sql = "WITH failure_counts AS(SELECT ApplicationName, JobID, COUNT(*) as failure_count from AppMonitorDataset where Status=0  and  ScheduleTypeId =" + duration + " group by ApplicationName,JobID) select top 5 t.ApplicationName,t.JobID,t.failure_count from failure_counts t INNER JOIN(SELECT MAX(failure_count) as max_failure_count from failure_counts) max_counts ON t.failure_count= max_counts.max_failure_count;";
            //string sql = "WITH failure_counts AS(SELECT ApplicationName, JobID, COUNT(*) as failure_count from AppMonitorDataset where Status = 0  and ScheduleTypeId = " + duration + " group by ApplicationName,JobID) SELECT distinct ApplicationName,JobID,failure_count FROM(select *, ROW_NUMBER() over (partition by ApplicationName order by failure_count DESC) rn from failure_counts )X where rn = 1; ";
            string sql = "WITH failure_counts AS(SELECT amd.ApplicationID,al.ApplicationName, amd.JobID,COUNT(*) as failure_count from AppMonitorDataset amd inner join ApplicationLookup al on amd.ApplicationID = al.ApplicationId inner join JobLookup jl on amd.JobID = jl.JobID where amd.Status = 0  and jl.ScheduleTypeId = " + duration + " group by amd.ApplicationID,al.ApplicationName, amd.JobID) SELECT top 5 ApplicationID, ApplicationName,JobID,failure_count FROM(select*, ROW_NUMBER() over (partition by ApplicationID order by failure_count DESC) rn from failure_counts )X where rn = 1; ";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    IndexFilteredModel records = new IndexFilteredModel();
                    records.ApplicationNo = reader["ApplicationID"].ToString();
                    records.ApplicationName = reader["ApplicationName"].ToString();
                    records.JobName = reader["JobId"].ToString();
                    records.FilterOn = reader["failure_count"].ToString();
                    //records.ScheduleTypeId = GetSchedulerTypeName(reader["ScheduleTypeId"].ToString());
                    cmsList.Add(records);
                }
            }
            catch (SqlException ex)
            {
                throw; // instead log the exception
            }
            finally
            {
                connection.Close();
            }
            return cmsList;
        }

        public List<IndexFilteredModel> GetMaxFailureApp(object duration)
        {
            List<IndexFilteredModel> cmsList = new List<IndexFilteredModel>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UR_DataConnectionString"].ToString());
            //string sql = "SELECT DISTINCT ApplicationName, COUNT(JobID) as NumberOfFailures FROM AppMonitorDataset WHERE  Status = 0 and  ScheduleTypeId =" + duration + " group by  ApplicationName order by NumberOfFailures desc";
            string sql = "SELECT top 5 jl.ApplicationID, al.ApplicationName,COUNT(amd.JobID) as NumberOfFailures FROM  AppMonitorDataset  amd inner join ApplicationLookup al on amd.ApplicationID = al.ApplicationId inner join JobLookup jl on jl.JobID = amd.JobID WHERE Status = 0 and jl.ScheduleTypeId = " + duration + " group by jl.ApplicationID,al.ApplicationName order by NumberOfFailures desc;";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    IndexFilteredModel records = new IndexFilteredModel();
                    records.ApplicationNo = reader["ApplicationID"].ToString();
                    records.ApplicationName = reader["ApplicationName"].ToString();
                    // records.FilterOn = "Application no. of faliure : " + reader["NumberOfFailures"].ToString();
                    records.FilterOn = reader["NumberOfFailures"].ToString();
                    cmsList.Add(records);
                }
            }
            catch (SqlException ex)
            {
                throw; // instead log the exception
            }
            finally
            {
                connection.Close();
            }
            return cmsList;
        }

        public List<IncidentModel> GetIncidentData(string id)
        {
            List<IncidentModel> cmsList = new List<IncidentModel>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UR_DataConnectionString"].ToString());
            //string sql = "SELECT DISTINCT ApplicationName, COUNT(JobID) as NumberOfFailures FROM AppMonitorDataset WHERE  Status = 0 and  ScheduleTypeId =" + duration + " group by  ApplicationName order by NumberOfFailures desc";
            string sql = "SELECT al.ApplicationName,ai.IncidentNumber,ai.Title,ai.Detail,ai.CreatedOn,ai.CreatedBy,ai.Priority FROM App_Monitor.dbo.AppIncidents ai inner join ApplicationLookup al on ai.ApplicationId = al.ApplicationId where ai.IncidentNumber = '" + id + "' ; ";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    IncidentModel records = new IncidentModel();
                    records.IncidentName= reader["IncidentNumber"].ToString() ;
                    records.ApplicationName = reader["ApplicationName"].ToString();
                    records.Priority = reader["Priority"].ToString();
                    records.Details = reader["Detail"].ToString();
                    records.CreatedOn = reader["CreatedOn"].ToString();
                    records.Title = reader["Title"].ToString();
                    records.CreatedBy = reader["CreatedBy"].ToString();
                    cmsList.Add(records);
                }
            }
            catch (SqlException ex)
            {
                throw; // instead log the exception
            }
            finally
            {
                connection.Close();
            }
            return cmsList;
        }

    }
}