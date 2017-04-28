using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RemoteMarket.Models;

namespace RemoteMarket.Controllers
{
    public class ProfileController : Controller
    {
        private WorkTypeContext db = new WorkTypeContext();

        // GET: WorkType
        public ActionResult Index()
        {
            return View();
        }

       
    }
}