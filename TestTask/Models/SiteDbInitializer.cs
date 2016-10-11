using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestTask.Models
{
    public class SiteDbInitializer:DropCreateDatabaseIfModelChanges<SiteContext>
    {
        protected override void Seed(SiteContext context)
        {
            context.RequestSites.Add(new RequestSite { SiteName = "https://www.google.com/", RequetsTime=200 });

            base.Seed(context);
        }
    }
}