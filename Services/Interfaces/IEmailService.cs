using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BookStorePrueba.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string PathHTMLFile, string subject, List<Attachment> attachments, List<string> emailList, List<(string, string)> data);
    }
}
