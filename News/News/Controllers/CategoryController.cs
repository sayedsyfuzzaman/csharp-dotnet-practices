using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(CategoryServices.Get());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel data)
        {
            if (ModelState.IsValid)
            {
                var cservice = new CategoryServices();
                cservice.Create(data);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cservice = new CategoryServices();
            cservice.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(CategoryServices.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(CategoryModel data)
        {
            if (ModelState.IsValid)
            {
                var cservice = new CategoryServices();
                cservice.Update(data);
            }
            return RedirectToAction("Index");
        }
    }
}