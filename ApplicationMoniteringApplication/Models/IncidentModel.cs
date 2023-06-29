using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationMoniteringApplication.Models
{
    public class IncidentModel
    {
        public string ApplicationName { get; set; }
        public string IncidentName { get; set; }
        public string Details { get; set; }

        public string CreatedOn { get; set; }
        public string Priority { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
    }
}