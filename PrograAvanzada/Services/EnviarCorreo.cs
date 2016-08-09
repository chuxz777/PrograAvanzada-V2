using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PrograAvanzada.Models;
using System.Net.Mail;
using System.Net;

namespace PrograAvanzada.Services
{
    public class EnviarCorreo
    {
        public static void EnviaCorreoContraseña(string url)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("jesus.rojas.umana@outlook.com");
            mail.To.Add("jesus.rojas.umana@outlook.com");
            mail.Subject = "Recuperación de Contraseña";
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = "Click aca: " + url;
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("jesus.rojas.umana@outlook.com", "(jesus777)");
            SmtpServer.EnableSsl = true;

            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo enviar el correo para reestablecer contraseña\n\n" + e.ToString());
            }
        }

    }
}
