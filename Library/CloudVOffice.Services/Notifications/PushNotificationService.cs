using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.PushNotifications;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.PushNotifications;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.Notifications
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<PushNotification> _pushNotificationRepo;

        public PushNotificationService(ApplicationDBContext dbContext, ISqlRepository<PushNotification> pushNotificationRepo)
        {
            _dbContext = dbContext;
            _pushNotificationRepo = pushNotificationRepo;
        }


        public MessageEnum CreatePushNotification(PushNotificationDTO pushNotificationDTO)
        {
            try
            {
                var objcheck = _dbContext.PushNotifications.FirstOrDefault(a=> a.PushNotificationId == pushNotificationDTO.PushNotificationId);

                if (objcheck == null)
                {
                    PushNotification pushNotification = new PushNotification();

                    pushNotification.DeliveryPartnerId = pushNotificationDTO.DeliveryPartnerId;
                    pushNotification.AssignedCode = pushNotificationDTO.AssignedCode;
                    pushNotification.FCMToken = pushNotificationDTO.FCMToken;
                    pushNotification.CreatedBy = pushNotificationDTO.CreatedBy;
                    pushNotification.CreatedDate = DateTime.Now;

                    _pushNotificationRepo.Insert(pushNotification);

                    return MessageEnum.Success;
                }
                else
                {
                    return MessageEnum.Error;
                }
                
            }
            catch
            {
                throw;
            }
        }

        public List<PushNotification> PushNotificationsList()
        {
            try
            {
                var list = _dbContext.PushNotifications.Where(a=> a.Deleted == false).ToList();
                return list;
            }
            catch
            {
                throw;
            }

        }
    }
}
