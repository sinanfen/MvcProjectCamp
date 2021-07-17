using DataAccessLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart() //PIE
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 5
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 6
            });
            return ct;
        }
       
        public ActionResult WriterChart() //PIE
        {
            return View();
        }

        public List<WriterClass> WriterList()
        {
            List<WriterClass> writerClasses = new List<WriterClass>();
            using (var context = new Context())
            {
                writerClasses = context.Writers.Select(c => new WriterClass
                {
                    WriterNickname = c.WriterNickname,
                    WriterCount = c.Headings.Count()
                }).ToList();
            }

            return writerClasses;
        }

        public ActionResult WriterClass()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }

        #region Baslik  Icerik Sayisi Listesi Grafigi

        public ActionResult HeadingListChart()
        {
            return View();
        }
      
        public List<HeadingClass> HeadingList()
        {
            List<HeadingClass> headingClasses = new List<HeadingClass>();
            using (var context = new Context())
            {
                headingClasses = context.Headings.Select(x => new HeadingClass
                {
                    HeadingName = x.HeadingName,
                    HeadingCount = x.Contents.Count()
                }).ToList();
            }

            return headingClasses;
        }

        public ActionResult HeadingListClass()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Kategori  Icerik Sayisi Listesi Grafigi

        public ActionResult CategoryListChart()
        {
            return View();
        }

        public List<CategoryClass> CategoryList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            using (var context = new Context())
            {
                categoryClasses = context.Categories.Select(x => new CategoryClass
                {
                    CategoryName = x.CategoryName,
                    CategoryCount = x.Headings.Count()
                }
                ).ToList();
            }
            return categoryClasses;
        }

        public ActionResult CategoryListClass()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}