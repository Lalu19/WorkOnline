using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.DeliveryPartners
{
	public class WareHouseDAAccept : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 WareHouseDAAcceptId { get; set; }
		public Int64? DATasksWarehouseId { get; set; }
		public Int64? DeliveryPartnerId { get; set; }
		public DateTime? StartTime { get; set; }
		public double? StartKM { get; set; }
		public string? StartMeterPhoto { get; set; }
		public DateTime? EndTime { get; set; }
		public double? EndKM { get; set; }
		public string? EndMeterPhoto { get; set; }



		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }

	}
}
