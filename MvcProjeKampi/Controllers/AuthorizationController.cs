using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());


        public ActionResult Index()
        {
            var adminValues = adminManager.GetList();
            return View(adminValues);
        }

        //[HttpGet]
        //public ActionResult AddAdmin()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddAdmin(Admin p)
        //{
        //    AdminValidator admVal = new AdminValidator();
        //    ValidationResult results = admVal.Validate(p);
        //    if (results.IsValid)
        //    {
        //        adminManager.AdminAdd(p);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        foreach (var item in results.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
          
        //}

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueAdminRole = (from c in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleId.ToString()

                                                   }).ToList();

            ViewBag.valuedmin = valueAdminRole;

            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adminManager.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}