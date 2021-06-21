using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = abm.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult DisableAbout(int id)
        {
            var aboutValue = abm.GetById(id);
            aboutValue.AboutStatus = false;
            abm.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }

        public ActionResult EnableAbout(int id)
        {
            var aboutValue = abm.GetById(id);
            aboutValue.AboutStatus = true;
            abm.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }
    }
}