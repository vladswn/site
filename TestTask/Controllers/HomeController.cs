using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        SiteContext context = new SiteContext();
        public ActionResult Index()
        {

            var site = context.RequestSites.ToList();

            var last = site.Last();

            var minForPage = context.RequestSites.Where(s => s.SiteName == last.SiteName).Min(s => s.RequetsTime);

            var maxForPage = context.RequestSites.Where(s => s.SiteName == last.SiteName).Max(s => s.RequetsTime);

            var max = site.Max(s => s.RequetsTime);

            ViewBag.MaxForPage = maxForPage;
            ViewBag.MinForPage = minForPage;
            ViewBag.MaxTime = max;


            return View(last);
        }
        [HttpPost]
        public ActionResult Index(RequestSite site)
        {
            if (!String.IsNullOrEmpty(site.SiteName))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(site.SiteName);

                Stopwatch sw = new Stopwatch();
                sw.Start();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();

                sw.Stop();

                site = new RequestSite
                {
                    SiteName = site.SiteName,
                    RequetsTime = sw.Elapsed.Milliseconds
                };


                context.Entry(site).State = EntityState.Added;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetSites()
        {
            var result = context.RequestSites.ToList();

            return Json(new { SitesList = result }, JsonRequestBehavior.AllowGet);
        }
      

        public ActionResult ListRequets()
        {
            var site = context.RequestSites.ToList();
            return View(site);
        }

    }
}