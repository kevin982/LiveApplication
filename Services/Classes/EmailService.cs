using BookStorePrueba.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BookStorePrueba.Services.Classes
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration Configuration = null;

        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task SendEmailAsync(string PathHTMLFile,string subject, List<Attachment> attachments,List<string> emailList, List<(string, string)> data)
        {
            
            MailMessage mail = new MailMessage
            {
                Subject = subject,
                Body = await File.ReadAllTextAsync(PathHTMLFile),
                From = new MailAddress(Configuration.GetValue<string>("SMTPConfig:EmailSender"), Configuration.GetValue<string>("SMTPConfig:SenderDisplayName")),
                IsBodyHtml = Configuration.GetValue<bool>("SMTPConfig:IsBodyHTML")
            };

            foreach (var tuple in data) mail.Body = mail.Body.Replace($"{{{{{tuple.Item1}}}}}", tuple.Item2); //Agregamos la data dinamica
            
            if(attachments.Count!=0) foreach (var attachment in attachments) mail.Attachments.Add(attachment); //Agregamos los documentos a adjuntar
            
            foreach (var email in emailList) mail.To.Add(email); //Agregamos los correos a los que vamos a enviar nuestro mail.


            SmtpClient smtpClient = new()
            {
                Host = Configuration.GetValue<string>("SMTPConfig:Host"),
                Port = Configuration.GetValue<int>("SMTPConfig:Port"),
                EnableSsl = Configuration.GetValue<bool>("SMTPConfig:EnableSSL"),
                Credentials = new NetworkCredential(Configuration.GetValue<string>("SMTPConfig:EmailSender"), Configuration.GetValue<string>("SMTPConfig:Password"))
            };


            await smtpClient.SendMailAsync(mail);
        }

    }
}
