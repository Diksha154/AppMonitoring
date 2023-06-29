using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationMoniteringApplication.Models
{
    public class JobMonitorModel
    {
        public string ApplicationName { get; set; }
        public string JobName { get; set; }
        public string ErrorDetails { get; set; }
        public string Runtime { get; set; }
        public string StartTime { get; set; }

        public string EndTime { get; set; }
        public string Status { get; set; }
    }
}