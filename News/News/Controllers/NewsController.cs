using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View(NewsServices.Get());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new NewsModel());
        }

        [HttpPost]
        public ActionResult Create(NewsModel data)
        {
            if (ModelState.IsValid)
            {
                var nservice = new NewsServices();
                nservice.Create(data);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var nservice = new NewsServices();
            nservice.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(NewsServices.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(NewsModel data)
        {
            if (ModelState.IsValid)
            {
                var nservice = new NewsServices();
                nservice.Update(data);
            }
            return RedirectToAction("Index");
        }
    }
}