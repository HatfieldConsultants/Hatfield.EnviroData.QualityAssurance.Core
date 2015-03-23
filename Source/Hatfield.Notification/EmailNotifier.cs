using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using MailKit;

namespace Hatfield.Notification
{
    public class EmailNotifier : INotifier
    {
        private string _serverAddress;
        private int _port;
        private string _userName;
        private string _passWord;
        private string _serverSenderName;
        private string _serverSenderEmail;

        public EmailNotifier(
            string serverAddress,
            int port,
            string userName, 
            string passWord, 
            string serverSenderName, 
            string serverSenderEmail)
        {
            _serverAddress = serverAddress;
            _port = port;
            _userName = userName;
            _passWord = passWord;
            _serverSenderName = serverSenderName;
            _serverSenderEmail = serverSenderEmail;
        }

        public bool SendNotification(INotificationContent content, string notificationResult)
        {
            var emailContent = content as EmailNotificationContent;
            if(emailContent == null)
            {
                throw new InvalidCastException("The content type could not be casted as email content");
            }

            var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            smtpClient.Connect(_serverAddress, _port, true);
            // Note: since we don't have an OAuth2 token, disable
            // the XOAUTH2 authentication mechanism.
            smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
            smtpClient.Authenticate(_userName, _passWord);

            var message = new MimeKit.MimeMessage();
            message.Subject = emailContent.Subject;

            foreach(var recipient in emailContent.Recipients)
            {
                message.To.Add(new MimeKit.MailboxAddress(recipient.Name, recipient.Email));
            }

            message.From.Add(new MimeKit.MailboxAddress(_serverSenderName, _serverSenderEmail));

            var builder = new MimeKit.BodyBuilder();

            builder.HtmlBody = emailContent.Content + "<br/>" + notificationResult;
            // TODO: add a plain text part too?

            message.Body = builder.ToMessageBody();

            smtpClient.Send(message);
            smtpClient.Disconnect(true);

            return true;
        }
    }
}
