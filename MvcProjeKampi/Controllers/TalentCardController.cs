using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class TalentCardController : Controller
    {
        // GET: TalentCard

        TalentCardManager talentCardManager = new TalentCardManager(new EfTalentCardDal());

        public ActionResult Index()
        {
            Context context = new Context();
            var cardValues = talentCardManager.GetAll();

            var result1 = (context.TalentCards.Sum(x => x.SkillPoint1) * 100) / 85;
            ViewBag.result1 = result1;
            var result2 = context.TalentCards.Sum(x => x.SkillPoint2) * 100 / 65;
            ViewBag.result2 = result2;
            var result3 = context.TalentCards.Sum(x => x.SkillPoint3) * 100 / 65;
            ViewBag.result3 = result3;
            var result4 = context.TalentCards.Sum(x => x.SkillPoint4) * 100 / 90;
            ViewBag.result4 = result4;
            var result5 = context.TalentCards.Sum(x => x.SkillPoint5) * 100 / 90;
            ViewBag.result5 = result5;
            var result6 = context.TalentCards.Sum(x => x.SkillPoint6) * 100 / 90;
            ViewBag.result6 = result6;
            var result7 = context.TalentCards.Sum(x => x.SkillPoint7) * 100 / 90;
            ViewBag.result7 = result7;
            var result8 = context.TalentCards.Sum(x => x.SkillPoint8) * 100 / 80;
            ViewBag.result8 = result8;
            var result9 = context.TalentCards.Sum(x => x.SkillPoint9) * 100 / 90;
            ViewBag.result9 = result9;
            var result10 = context.TalentCards.Sum(x => x.SkillPoint10) * 50 / 90;
            ViewBag.result10 = result10;

            return View(cardValues);
        }
    }
}