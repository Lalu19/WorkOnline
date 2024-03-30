using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CloudVOffice.Data.DTO.DeliveryPartners
{
	public class WareHouseDAAcceptDTO
	{
		public Int64? WareHouseDAAcceptId { get; set; }
		public Int64 DATasksWarehouseId { get; set; }
		public Int64 DeliveryPartnerId { get; set; }
		public DateTime StartTime { get; set; }
		public double StartKM { get; set; }
		public string? StartMeterPhoto { get; set; }
		public DateTime EndTime { get; set; }
		public double EndKM { get; set; }
		public string? EndMeterPhoto { get; set; }


		public IFormFile? StartMeterPhotoUp { get; set; }
		public IFormFile? EndMeterPhotoUp { get; set; }


		public Int64 CreatedBy { get; set; }

	}
}
