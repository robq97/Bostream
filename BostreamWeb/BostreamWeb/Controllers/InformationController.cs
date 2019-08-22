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

        /// <summary>
        /// funcion para enviar correos en la seccion de contactenos
        /// </summary>
        /// <param name="name">Nombre de la persona</param>
        /// <param name="lastName">Apellido de la persona</param>
        /// <param name="company">Compañia de la persona</param>
        /// <param name="receiver">Email del que recibe el email</param>
        /// <param name="phone">Numero de cel/tel de la persona</param>
        /// <param name="service1">Servicios disponibles</param>
        /// <param name="service2"></param>
        /// <param name="service3"></param>
        /// <param name="service4"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns>Email de confirmacion</returns>
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