using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class SiteContext:DbContext
    {
        public SiteContext() : base("SiteContext") { }
        public DbSet<RequestSite> RequestSites { get; set; }
    }
}