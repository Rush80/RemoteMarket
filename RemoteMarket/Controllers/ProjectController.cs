using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        // GET: Project
        public ActionResult Projects()
        {
            
            return View("Projects", projectContext.Projects);
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

            ProjectViewModel viewModel = new ProjectViewModel();
            viewModel.Project = project;
            viewModel.Duration = GetDurations()[project.Duration].ToString();
            return View("project_view", viewModel);
        }

        public void UploadFile()
        {
            //context.Response.ContentType = "text/plain";

           /* string dirFullPath = HttpContext.Current.Server.MapPath("~/MediaUploader/");
            string[] files;
            int numFiles;
            files = System.IO.Directory.GetFiles(dirFullPath);
            numFiles = files.Length;
            numFiles = numFiles + 1;

            string str_image = "";

            foreach (string s in context.Request.Files)
            {
                HttpPostedFile file = context.Request.Files[s];
                //  int fileSizeInBytes = file.ContentLength;
                string fileName = file.FileName;
                string fileExtension = file.ContentType;

                if (!string.IsNullOrEmpty(fileName))
                {
                    fileExtension = Path.GetExtension(fileName);
                    str_image = "MyPHOTO_" + numFiles.ToString() + fileExtension;
                    string pathToSave_100 = HttpContext.Current.Server.MapPath("~/MediaUploader/") + str_image;
                    file.SaveAs(pathToSave_100);
                }
            }*/
        }
    }
}