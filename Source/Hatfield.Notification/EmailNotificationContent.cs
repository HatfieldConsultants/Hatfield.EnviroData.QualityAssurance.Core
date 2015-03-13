using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.Notification
{
    public class EmailNotificationContent : INotificationContent
    {
        private string _subject;
        private string _content;
        private IEnumerable<EmailRecipient> _recipients;
        private NotificationSendingOption _sendingOption;

        public EmailNotificationContent(string subject, string content, IEnumerable<EmailRecipient> recipients, NotificationSendingOption sendingOption)
        {
            _subject = subject;
            _content = content;
            _recipients = recipients;
            _sendingOption = sendingOption;
        }

        public string Subject {
            get {
                return _subject;
            }
        }

        public string Content {
            get {
                return _content;
            }
        }

        public IEnumerable<EmailRecipient> Recipients {
            get {
                return _recipients;
            }
        }

        public NotificationSendingOption SendingOption
        {
            get { return _sendingOption; }
        }
    }
}
