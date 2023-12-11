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
    public interface IVendorOnboarding
    {
        public MessageEnum VendorOnboardingCreate(VendorOnboardingDTO vendorOnboardingDTO);
        public VendorOnboarding GetVendorByVendorOnboardingId(int VendorOnboardingId);
        public List<VendorOnboarding> GetVendorOnboardingList();
        public MessageEnum VendorOnboardingUpdate(VendorOnboardingDTO vendorOnboardingDTO);
        public MessageEnum VendorOnboardingDelete(int VendorOnboardingId, Int64 DeletedBy);
    }
}
