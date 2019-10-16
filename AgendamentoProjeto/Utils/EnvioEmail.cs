using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoProjeto.Utils
{
    public class EnvioEmail
    {
        public void EnvioDeEmail(string Email, string Mensagem, string Title)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Admin",
            "projetoprofi2019@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Usuário",
            Email);
            message.To.Add(to);

            message.Subject = Title;
            Random randNum = new Random();
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<p>{Mensagem}<p>";
            bodyBuilder.TextBody = Title;
            message.Body = bodyBuilder.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("projetoprofi2019@gmail.com", "projetoMERDA123");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
