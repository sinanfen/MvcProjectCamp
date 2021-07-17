using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var files = imageFileManager.GetList();
            return View(files);
        }
        
        [HttpGet]
        public ActionResult ImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageAdd(ImageFile imageFile)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/AdminLTE-3.0.4/Images/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                imageFile.ImagePath = "/AdminLTE-3.0.4/Images/" + fileName + extension;
                imageFileManager.ImageAdd(imageFile);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}