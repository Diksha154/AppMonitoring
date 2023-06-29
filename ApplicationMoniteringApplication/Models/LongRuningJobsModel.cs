using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationMoniteringApplication.Models
{
    public class LongRuningJobsModel
    {
        public string Application { get; set; }
        public string JobName { get; set; }
        public int RunTime { get; set; }
        public string Duration { get; set; }
    }
}