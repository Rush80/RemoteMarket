using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RemoteMarket.Models;

namespace RemoteMarket.Controllers
{
    public class ProjectController : Controller
    {
        private Hashtable GetDurations()
        {
            Hashtable list = new Hashtable();
            list.Add(1, "Невпевнений");
            list.Add(2, "Понад 6 місяців / Довгострокові");
            list.Add(3, "3 - 6 місяців");
            list.Add(4, "1 - 3 місяці");
            list.Add(5, "1 - 2 тижні");
            list.Add(6, "Менш ніж 1 тиждень");
            
            return list;
        }

        // GET: Project
        public ActionResult Index()
        {
            ViewBag.Durations = GetDurations();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Save(Project mode)
        {
            HttpRequestBase request = Request;
            request.Params.GetValues("ddlJobTypes").ToString();
            return null;
        }

        public void UploadFile()
        {
            
        }
    }
}