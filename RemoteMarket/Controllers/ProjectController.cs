using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RemoteMarket.Models;

namespace RemoteMarket.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectContext projectContext = new ProjectContext();
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
        public ActionResult Save(Project project)
        {
            string userId = User.Identity.GetUserId();
            if (userId != null)
                project.UserId = userId;
            projectContext.Projects.Add(project);
            projectContext.SaveChanges();
            return null;
        }

        public void UploadFile()
        {
            
        }
    }
}