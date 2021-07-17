using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingValidator headingValidator = new HeadingValidator();
        WriterValidator writerValidator = new WriterValidator();
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];        
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = writerManager.GetById(id);                 
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (Request.Files.Count > 0 || results.IsValid)
            {  
                //Bu kısım writer image güncellemek için
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/avatar/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.WriterImage = "/avatar/" + dosyaAdi + uzanti;
              

                p.WriterStatus = true;
                p.WriterRole = "A";
                writerManager.WriterUpdate(p);
                return RedirectToAction("AllHeadings", "WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = hm.GetListByWriter(writerIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            ValidationResult results = headingValidator.Validate(p);
            if (results.IsValid)
            {
                string writerMailInfo = (string)Session["WriterMail"];
                var writerIdInfo = c.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterID).FirstOrDefault();
                p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerIdInfo;
                p.HeadingStatus = true;
                hm.HeadingAdd(p);
                return RedirectToAction("MyHeading");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = hm.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeadings(int p = 1)
        {
            var headings = hm.GetList().ToPagedList(p,10);
            return View(headings);
        }


    }
}