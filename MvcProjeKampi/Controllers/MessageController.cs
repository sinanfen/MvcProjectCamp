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

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        DraftController draftController = new DraftController();

        [Authorize]
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListInbox(p);
            return View(messagelist);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListSendbox(p);
            return View(messagelist);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message p, string button)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (button == "draft")
            {
                results = messageValidator.Validate(p);
                if (results.IsValid)
                {
                    Draft draft = new Draft();
                    draft.ReceiverMail = p.ReceiverMail;
                    draft.Subject = p.Subject;
                    draft.DraftContent = p.MessageContent;
                    draft.DraftDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    draftController.AddDraft(draft);
                    return RedirectToAction("Draft", "Draft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            else if (button == "save")
            {
                results = messageValidator.Validate(p);
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.SenderMail = "admin@gmail.com";
                    messageManager.MessageAdd(p);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }


        public ActionResult IsRead(int id)
        {
            var result = messageManager.GetById(id);
            if (result.IsRead == false)
            {
                result.IsRead = true;
            }
            messageManager.MessageUpdate(result);
            return RedirectToAction("ReadMessage");
        }

        public ActionResult ReadMessage()
        {
            var readMessage = messageManager.GetList().Where(x => x.IsRead == true).ToList();
            return View(readMessage);
        }

        public ActionResult UnreadMessage()
        {
            var readMessage = messageManager.GetListUnread();
            return View(readMessage);
        }
    }
}