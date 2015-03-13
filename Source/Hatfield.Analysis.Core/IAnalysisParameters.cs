using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.Notification;

namespace Hatfield.Analysis.Core
{
    public interface IAnalysisParameters
    {
        AnalysisResultLevel LevelToSendNotification { get; }
        AnalysisResultLevel LevelToContinue { get; }

        IEnumerable<INotificationContent> Notifications { get; }        
    }
}
