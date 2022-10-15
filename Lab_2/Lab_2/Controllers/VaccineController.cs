using Lab_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_2.Controllers
{
    public class VaccineController : Controller
    {
        // GET: Vaccine
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Person person)
        {
            return View(person);
        }

    }
}