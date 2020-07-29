using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace QRiderWebApp.Models
{
    public class Email
    {
        
        public String SenderName { get; set; }
        public String EmailAddress { get; set; }
        public String PhoneNumber { get; set; }
        public String Message { get; set; }

        public bool SendEmail()
        {
            if (String.IsNullOrEmpty(EmailAddress) == false)
            {
                MailMessage msg = new MailMessage();
                msg.To.Add("info@qriders.ca");
                msg.From = new MailAddress("noreply@qriders.ca");
                msg.Subject = "email from user phone number" + PhoneNumber + "and email address " + EmailAddress;
                msg.Body = Message;
                SmtpClient smtp = new SmtpClient
                {
                    Host = "relay-hosting.secureserver.net",
                    Port = 25
                };

                try
                {
                    smtp.Send(msg);
                    return true;
                }catch(Exception )
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}