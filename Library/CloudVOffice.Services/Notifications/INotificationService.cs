using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;

namespace CloudVOffice.Services.Notifications
{
    public interface INotificationService
    {
        public Task<MessageEnum> SendNotification(string fcmToken, string message, string title);
    }
}
