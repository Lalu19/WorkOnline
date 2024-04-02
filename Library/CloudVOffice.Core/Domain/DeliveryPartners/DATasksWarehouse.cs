using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace CloudVOffice.Core.Domain.DeliveryPartners
{
	public class DATasksWarehouse : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 DATasksWarehouseId { get; set; }
		public DateTime? ArrivalDate { get; set; }   //to be fixed statically
		public string? Address { get; set; }
		public string? Contact { get; set; }
        public Int64? DeliveryPartnerId { get; set; }   //to be filled by Mobile Team
        public Int64? WareHuoseId { get; set; }
		public double? Orderweight { get; set; }
		public double? OrderAmount { get; set; }
		public bool TaskAccepted { get; set; }
		public string? DPOUniqueNo { get; set; }
		public Int64? DistributorRegistrationId { get; set; } 
		public string? AssignmentCode { get; set; }
		public bool NotificationSent { get; set; }
		public bool TaskDone { get; set; }




		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
	}
}
