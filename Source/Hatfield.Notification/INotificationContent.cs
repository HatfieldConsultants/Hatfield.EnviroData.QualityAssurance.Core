﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.Notification
{
    public interface INotificationContent
    {
        NotificationSendingOption SendingOption
        {
            get;
        }
    }
}
