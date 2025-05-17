using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Empresa_Access_Granted.Models;

namespace Empresa_Access_Granted.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IConfiguration _config;

        public ContactoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(EmailFormModel model)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(_config["Email:User"], _config["Email:Password"]),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress(model.Correo),
                Subject = "Contacto desde AccessGranted",
                Body = $"Nombre: {model.Nombre}\nCorreo: {model.Correo}\nMensaje:\n{model.Mensaje}",
                IsBodyHtml = false,
            };
            mail.To.Add(model.Correo); // Cambia esto por tu correo real

            await smtpClient.SendMailAsync(mail);
            ViewBag.Message = "Mensaje enviado con éxito.";
            return View();
        }
    }
}
