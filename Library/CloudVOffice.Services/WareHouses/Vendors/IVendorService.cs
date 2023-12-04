using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Data.DTO.WareHouses.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Vendors
{
    public interface IVendorService
    {
        public MessageEnum VendorCreate(VendorDTO vendorDTO);
        public Vendor GetVendorByVendorId(Int64 vendorId);
        public List<Vendor> GetVendorList();
        public MessageEnum VendorUpdate(VendorDTO vendorDTO);
        public MessageEnum VendorDelete(Int64 vendorId, Int64 DeletedBy);
    }
}
