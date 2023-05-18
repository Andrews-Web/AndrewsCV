using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Website_CV.Models;


namespace Website_CV.Controllers
{
    public class Contact : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactModel model)
        {

            try {
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress("androidowens57@gmail.com");
                mm.To.Add("andrewkyleowens@gmail.com");
                mm.Subject = model.Name;
                mm.Body = "Name: " + model.Name + "<br>Email: " + model.Email + "<br>Number: " + model.Number +"<br>"+ model.Details;
                mm.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();

                //Create nerwork credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("androidowens57@gmail.com", "shpggsfkmszxebus");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Send(mm);

            }catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
