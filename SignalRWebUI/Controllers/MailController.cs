using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;
using SignalRWebUI.Dtos.MessagesDto;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMessagesDto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("SignalR Rezarvasyon", "Mail");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMessagesDto.ReciverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder { HtmlBody = createMessagesDto.MBody };
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = createMessagesDto.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("aspnetcoreprojeler@gmail.com", "pirm hmfv ugxr rcwq");
            client.Send(mimeMessage);
            client.Disconnect(true);
            //pirm hmfv ugxr rcwq

            return RedirectToAction("Index","Category");
        }
    }
}
