using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationMoniteringApplication.Models
{
    public class PriorIncidentsModel
    {
        public string Application { get; set; }
        public string Incidents { get; set; }
        public string Priority { get; set; }
        public string Duration { get; set; }
    }
}