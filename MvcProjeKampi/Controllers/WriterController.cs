using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer

        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
    
        public ActionResult Index(int p = 1)
        {
            var WriterValues = writerManager.GetList().ToPagedList(p,9);
            return View(WriterValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        public ActionResult AddWriter(Writer p)
        {
           
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                writerManager.WriterAdd(p); //WriterManager
                return RedirectToAction("Index");
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
        public ActionResult EditWriter(int id)
        {
           
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
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
                return RedirectToAction("Index");
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
    }
}