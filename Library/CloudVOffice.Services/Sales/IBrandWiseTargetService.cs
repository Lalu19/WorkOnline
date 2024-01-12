using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;

namespace CloudVOffice.Services.Sales
{
    public interface IBrandWiseTargetService
    {
        public MessageEnum BrandWiseTargetCreate(BrandWiseTargetsDTO brandWiseTargetDTO);
        public BrandWiseTarget GetBrandWiseTargetById(Int64 brandWiseTargetId);
        public List<BrandWiseTarget> GetBrandWiseTargetList();
        public MessageEnum BrandWiseTargetUpdate(BrandWiseTargetsDTO brandWiseTargetDTO);
        public MessageEnum BrandWiseTargetDelete(Int64 brandWiseTargetId, Int64 DeletedBy);
    }
}
