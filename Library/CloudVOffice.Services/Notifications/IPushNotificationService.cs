using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.PushNotifications;
using CloudVOffice.Data.DTO.PushNotifications;

namespace CloudVOffice.Services.Notifications
{
    public interface IPushNotificationService
    {
        public MessageEnum CreatePushNotification(PushNotificationDTO pushNotificationDTO);
        public List<PushNotification> PushNotificationsList();
    }
}
