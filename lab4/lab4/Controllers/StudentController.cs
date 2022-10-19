using lab4.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace lab4.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var db = new lab4Entities();
            var students = db.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            var db = new lab4Entities();
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new lab4Entities();
            var student = (from s in db.Students
                           where s.Id == id
                           select s).SingleOrDefault();
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var db = new lab4Entities();
            db.Students.AddOrUpdate(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var db = new lab4Entities();
            var student = (from s in db.Students
                           where s.Id == id
                           select s).SingleOrDefault();
            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new lab4Entities();
            var student = (from s in db.Students
                           where s.Id == id
                           select s).SingleOrDefault();
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}