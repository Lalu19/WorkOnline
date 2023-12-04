using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.Vendors
{
    public class VendorDTO
    {
        public Int64? VendorId { get; set; }
        public string VendorName { get; set; }
        public string CompanyName { get; set; }
        public string GST { get; set; }
        public string Address { get; set; }

        public string? Telephone { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        // public string Address { get; set; }
        public string MailId { get; set; }
        public string? PoCName { get; set; }
        public string Segment { get; set; }
        public string Category { get; set; }
        public string? WarehousesAffiliated { get; set; }

        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
