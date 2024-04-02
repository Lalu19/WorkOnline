using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.PushNotifications
{
	public class PushNotificationDTO
	{
		public Int64? PushNotificationId { get; set; }
		public Int64? DeliveryPartnerId { get; set; }
		public string? AssignedCode { get; set; }
		public string? FCMToken { get; set; }


		public Int64 CreatedBy { get; set; }
	}
}
