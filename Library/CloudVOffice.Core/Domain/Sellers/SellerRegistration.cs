using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.ProductCategories;

namespace CloudVOffice.Core.Domain.Sellers
{
	public class SellerRegistration : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 SellerRegistrationId { get; set; }
		public string Name { get; set; }
		public string BusinessName { get; set; }
		public string Address { get; set; }
		public Int64 PinCodeId { get; set; }
		public string? Country { get; set; }
		public string? State { get; set; }
		public string PrimaryPhone { get; set; }
		public string? AlternatePhone { get; set; }
		public string? MailId { get; set; }
		public string SalesRepresentativeId { get; set; }
		public string? SalesRepresentativeContact { get; set; }
        public Int64? RetailModelId { get; set; }
        public string? GSTNumber { get; set; }
		public Int64? WareHuoseId { get; set; }
		public string? Password { get; set; }
        public bool FirstLogin { get; set; }
        public int? SectorId { get; set; }
		public string? Image { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }

		[ForeignKey("WareHuoseId")]
		public WareHuose WareHuose { get; set; }
	}
}
