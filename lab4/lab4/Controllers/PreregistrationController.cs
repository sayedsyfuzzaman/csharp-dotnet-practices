using lab4.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab4.Controllers
{
    public class PreregistrationController : Controller
    {
        // GET: Preregistration
        public ActionResult Index()
        {
            var db = new lab4Entities();
            var courses = db.Courses.ToList();
            return View(courses);
        }
    }
}