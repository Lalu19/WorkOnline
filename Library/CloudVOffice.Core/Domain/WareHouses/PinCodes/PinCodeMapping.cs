using CloudVOffice.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.PinCodes
{
	public class PinCodeMapping : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 PinCodeMappingId { get; set; }
		public Int64 PinCodeId { get; set; }
		public Int64 WareHouseId { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }

		//[ForeignKey("WareHouseId")]
		//public WareHouse WareHouse { get; set; }

		[ForeignKey("PinCodeId")]
		public PinCode PinCode { get; set; }
	}
}
