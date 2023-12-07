using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.Vendors
{
    public class Vendor: IAuditEntity, ISoftDeletedEntity
    {
        public Int64 VendorId { get; set; }
		public int SectorId { get; set; }
		public int CategoryId { get; set; }
		public Int64 WareHuoseId { get; set; }
		public string VendorName { get; set; }
        public string CompanyName { get; set; }
		public Int64 GSTId { get; set; }
		public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
       
        public string? MailId { get; set; }
        public string? PoCName { get; set; }
		public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
