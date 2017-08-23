using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebDuctDesigner.Models;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Configuration;

namespace WebDuctDesigner.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(EmailFormModel model)
        {
            if(ModelState.IsValid)
            {

                var body = "<h2>Duct Designer</h2><p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(ConfigurationManager.AppSettings["email"]));  // replace with valid value 
                message.From = new MailAddress(ConfigurationManager.AppSettings["email"]);  // replace with valid value
                message.Subject = "Duct Designer - " + model.Subject;
                message.Body = string.Format(body, model.Name, model.Email, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }

            }
                return View(model);
        }
        public FileResult Download()
        {
            var archive = Server.MapPath("~/App_Data/DuctDesign.zip");

            var file = new FileInfo(archive);
            if (file.Exists)
            {
                return File(archive, "application/zip", "DuctDesign.zip");
            }
            return null;
        }

    }
}