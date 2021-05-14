using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context _context = new Context();
        public ActionResult Index()
        {
            var value1 = _context.Categories.Count(); //Toplam kategori sayısını verir.
            ViewBag.totalCategoryNum = value1;

            var value2 = _context.Headings.Count(x=>x.CategoryID == 7 ); //Yazılım kategorisindeki başlık sayısı (id : 7)  
            ViewBag.softwareCategoryTitleNum = value2;

            var value3 = _context.Headings.Max(x => x.Category.CategoryName); //En fazla başlığa sahip kategori adı
            ViewBag.maxHeadingsOfCategories = value3;

            var value4 = _context.Categories.Count(x => x.CategoryStatus == true); //Kategoriler tablosundaki aktif kategori sayısı
            ViewBag.activeCategories = value4;

            var value5 = _context.Writers.Count(x => x.WriterName.Contains("s")); //Yazar adında "s" harfi geçen yazar sayısı
            ViewBag.writerNameIncludesByS = value5;
            return View();
        }
    }
}