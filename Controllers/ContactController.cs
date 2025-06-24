using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using xRootServices.Models; // Use the actual namespace of your ContractModel

namespace xRootServices.Controllers
{

    public class ContactController : Controller
    {
        //OLD WORKING
        //    public IActionResult Index()
        //    {
        //        return View();
        //    }


        //MY NEW
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContractModel());
        }

        [HttpPost]
        public IActionResult Index(ContractModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = $"<p><strong>Name:</strong> {model.Name}</p>" +
                               $"<p><strong>Email:</strong> {model.Email}</p>" +
                               $"<p><strong>Subject:</strong> {model.Subject}</p>" +
                               $"<p><strong>Message:</strong> {model.Description}</p>";

                    var message = new MailMessage();
                    message.To.Add(new MailAddress("sales@xrootservices.com"));  // replace with your receiving email
                    message.From = new MailAddress("sales@xrootservices.com");      // replace with your from email
                    message.Subject = model.Subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient("smtp.hostinger.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("sales@xrootservices.com", "Xroot@sales25$");
                        smtp.EnableSsl = true;
                        smtp.Send(message);
                    }

                    ViewBag.Message = "✅ Message sent successfully!";
                    ModelState.Clear(); // reset form
                    return View(new ContractModel());
                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"Error sending message: {ex.Message}";
                }
            }

            return View(model);
        }















    }




}
