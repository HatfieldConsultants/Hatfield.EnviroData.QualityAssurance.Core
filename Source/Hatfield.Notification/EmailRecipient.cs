using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.Notification
{
    public class EmailRecipient
    {
        private string _name;
        private string _email;

        public EmailRecipient(string name, string email)
        {
            _name = name;
            _email = email;
        }

        public string Name {
            get {
                return _name;
            }
        }

        public string Email {
            get {
                return _email;
            }
        }
    }
}
