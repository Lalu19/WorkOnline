using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.PushNotifications
{
    public class PushNotification : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 PushNotificationId { get; set; }
        //public Int64? WareHouseId { get; set; }
        //public Int64? DistributorRegistrationId { get; set; }
        public Int64? DeliveryPartnerId { get; set; }
		public string? AssignedCode { get; set; }
		public string? FCMToken { get; set; }


        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

    }
}
