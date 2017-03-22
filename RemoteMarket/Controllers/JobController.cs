using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RemoteMarket.Models;

namespace RemoteMarket.Controllers
{
    public class JobController : Controller
    {
        private WorkTypeContext db = new WorkTypeContext();
        private JobContext jobTypeContext = new JobContext();

        private IEnumerable<Job> GetWorkTypes(int workTypeId)
        {
            return jobTypeContext.JobTypes.ToList().Where(c => c.WorkTypeId.Equals(workTypeId));
        }


        // Fetch State by Country ID
        public JsonResult GetJobs(int workTypeId)
        {
            List<Job> jobs = new List<Job>();
            jobs = jobTypeContext.JobTypes.Where(a => a.WorkTypeId.Equals(workTypeId)).OrderBy(a => a.Name).ToList();
            return new JsonResult { Data = jobs, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: Job
        public ActionResult Index(int ? workTypeId)
        {
            if (workTypeId == null)
                workTypeId = db.WorkTypes.First().WorkTypeId;
            SelectList list = new SelectList(db.WorkTypes, "Worktypeid", "Name", workTypeId);
            
            ViewBag.WorkTypes = list;
            
            return View(GetWorkTypes(Convert.ToInt32(workTypeId)));
        }

        public ActionResult Add(int workTypeId, string jobName)
        {
            Job job = new Job();
            job.WorkTypeId = workTypeId;
            job.Name = jobName;
            jobTypeContext.JobTypes.Add(job);
            jobTypeContext.SaveChanges();
            SelectList list = new SelectList(db.WorkTypes, "Worktypeid", "Name", workTypeId);
            ViewBag.WorkTypes = list;
            return View("Index", GetWorkTypes(workTypeId));
        }


        public ActionResult Delete(int id)
        {
            var type = jobTypeContext.JobTypes.Where(c => c.JobId.Equals(id)).SingleOrDefault();
            jobTypeContext.JobTypes.Remove(type);
            jobTypeContext.SaveChanges();
            return RedirectToAction("Index", new { workTypeId = type.WorkTypeId });
        }

        public ActionResult Edit(int id)
        {
            return View(jobTypeContext.JobTypes.Where(c => c.JobId.Equals(id)).SingleOrDefault());
        }


        [HttpPost]
        public ActionResult Edit(Job type)
        {
            jobTypeContext.Entry<Job>(type).State = System.Data.Entity.EntityState.Modified;
            jobTypeContext.SaveChanges();
            return RedirectToAction("Index", new { workTypeId = type.WorkTypeId });
        }
    }
}