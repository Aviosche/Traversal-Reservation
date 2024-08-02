using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal_Reservation.Models;

namespace Traversal_Reservation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", mailRequest.SenderMail);
            mimeMessage.From.Add(mailboxAddressFrom);
            
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.From.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequest.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate(mailRequest.SenderMail, "insert_gmail_app_password");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }



    }
}
