using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent

        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();

        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValues = cm.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writerIdInfo;
            content.ContentStatus = true;
            cm.ContentAdd(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}