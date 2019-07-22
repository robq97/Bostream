using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Bostream.Controllers
{
    public class InformationController : Controller
    {
        /// <summary>
        /// Muestra formulario de contacto.
        /// </summary>
        /// <returns>Vista de formulario de contacto.</returns>
        public ActionResult InformationForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string name, string lastName, string company, string receiver, string phone
            ,string service1, string service2, string service3, string service4, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("bostreamMarketing@gmail.com", "Bostream Marketing");
                    var receiverEmail = new MailAddress(receiver, name + " " + lastName);
                    var password = "bostream2019";
                    var sub = "Confirmación de Recibido";
                    var body = "Gracias por contactarnos " + name + ", nos aseguremos de contactarlo por medio de este medio" +
                        " o bien al número ingresado (" + phone + ") para brindarle más información del servicio en questión. \n \n" +
                        "Atentamente, Mattia Masanes - Gerente general.";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return RedirectToAction("InformationForm");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return RedirectToAction("InformationForm");
        }
    }
}