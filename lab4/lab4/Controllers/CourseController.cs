using lab4.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab4.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var db = new lab4Entities();
            var courses = db.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cours course)
        {
            var db = new lab4Entities();
            db.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new lab4Entities();
            var course = (from c in db.Courses
                           where c.Id == id
                           select c).SingleOrDefault();
            return View(course);
        }
        [HttpPost]
        public ActionResult Edit(Cours course)
        {
            var db = new lab4Entities();
            db.Courses.AddOrUpdate(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var db = new lab4Entities();
            var course = (from c in db.Courses
                           where c.Id == id
                           select c).SingleOrDefault();
            return View(course);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new lab4Entities();
            var course = (from c in db.Courses
                           where c.Id == id
                           select c).SingleOrDefault();
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}