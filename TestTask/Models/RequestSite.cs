using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class RequestSite
    {
        public Int32 RequestSiteId { get; set; }
        [Url]
        public String SiteName { get; set; }
        public Int32 RequetsTime { get; set; }
    }
}