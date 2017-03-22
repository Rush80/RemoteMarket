using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RemoteMarket.Models;

namespace RemoteMarket.Controllers
{
    public class WorkTypeController : Controller
    {
        private WorkTypeContext db = new WorkTypeContext();


        // Fetch Country
        public JsonResult GetWorkTypes()
        {
            List<WorkType> allCountry = new List<WorkType>();
            allCountry = db.WorkTypes.OrderBy(a => a.Name).ToList();
            return new JsonResult { Data = allCountry, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        // GET: WorkType
        public ActionResult Index()
        {
            return View(db.WorkTypes.ToList());
        }

        public ActionResult Delete(int id)
        {
            var type = db.WorkTypes.Where(c => c.WorkTypeId.Equals(id)).SingleOrDefault();
            db.WorkTypes.Remove(type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(db.WorkTypes.Where(c=>c.WorkTypeId.Equals(id)).SingleOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(WorkType type)
        {
            db.Entry<WorkType>(type).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(WorkType type)
        {
            db.WorkTypes.Add(type);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}