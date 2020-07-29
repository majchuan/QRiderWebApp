using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRiderWebApp.Models;

namespace QRiderWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AcceptVerbs("POST")]
        public ActionResult SendMessage(FormCollection form)
        {
            var name = form["name"];
            var emailAddress = form["email"];
            var phoneNumber = form["phone"];
            var message = form["message"];
            Email aEmail = new Email();
            aEmail.SenderName= name;
            aEmail.PhoneNumber = phoneNumber;
            aEmail.EmailAddress = emailAddress;
            aEmail.Message = message;

            aEmail.SendEmail();

            return RedirectToAction("Index");
        }
    }
}