using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using Microsoft.Extensions.Configuration;

namespace ETicaretApi.Infrastructure.Service
{
   public class MailService : IMailService
   {   readonly private IConfiguration _configuration;



      public MailService(IConfiguration configuration)
      {
        _configuration=configuration;
      }

      public async Task SendCompletedOrderMailAsync(string to,string orderCode, DateTime orderDate, string UserName, string userSurname)
      {
        

          string mail=$"{UserName} {userSurname}  Hi <br>"+
          $"The order you placed on the {orderDate}th with code {orderCode} has been completed and shipped,received by the cargo";

          await SendMailAsync(to , $"Your order with code {orderCode} has been completed" , mail);
      }

      public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
      {
        await  SendMailAsync(new[]{to} , subject , body  , isBodyHtml);
      }

      public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
      {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml=isBodyHtml;
            foreach (var to in tos)
            {
              mail.To.Add(to);
              mail.Subject=subject;
              mail.Body=body;
              mail.From=new( _configuration["Mail:UserName"] , "Nalburla" , System.Text.Encoding.UTF8);
            }
      

        SmtpClient smtp = new SmtpClient();

        smtp.Credentials =  new NetworkCredential(_configuration["Mail:UserName"]  ,_configuration["Mail:Password"] );
        smtp.Port=587;
        smtp.EnableSsl=true;
        smtp.Host=_configuration["Mail:Host"] ;
        await smtp.SendMailAsync(mail);

          
      }

      public async Task SendPasswordResetMailAsync(string to , string userId , string resetToken)
      {
        StringBuilder mail = new StringBuilder();
        mail.AppendLine("Hi <br> If you want to enter a new password, you can update it from the link below!<br> <strong><a  target=\"_blank\"\"href=\"{}");
       mail.AppendLine(_configuration["AngularClientUrl"]);
       mail.AppendLine("/reset-password/");
        mail.AppendLine(userId);
        mail.AppendLine("/");
        mail.AppendLine(resetToken);
        mail.AppendLine("\"Click the link for a new password... </a></strong><br><br> <span  style\"font-size:12px;\">If this request is not made by you, there is a request from other parties to change your password.<span><br>Sincerely...<br><br><br>Nalburla");
       
        await SendMailAsync(to , "Password reset request" ,mail.ToString());
      
      }
   }
}