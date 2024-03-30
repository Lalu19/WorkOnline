using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.DeliveryPartners
{
	public class DATasksWarehouseDTO
	{
		public Int64? DATasksWarehouseId { get; set; }
        public DateTime? ArrivalDate { get; set; }   //to be fixed statically
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public Int64 DeliveryPartnerId { get; set; }
		public Int64 WareHuoseId { get; set; }
		public double Orderweight { get; set; }
		public double OrderAmount { get; set; }
		public bool TaskAccepted { get; set; }
		public string DPOUniqueNo { get; set; }
		public Int64 DistributorRegistrationId { get; set; }   //to be filled by Mobile Team
		public string AssignmentCode { get; set; }

		public Int64 CreatedBy { get; set; }

	}
}
