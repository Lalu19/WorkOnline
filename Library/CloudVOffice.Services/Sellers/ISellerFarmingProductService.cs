using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Data.DTO.Sellers;

namespace CloudVOffice.Services.Sellers
{
	public interface ISellerFarmingProductService
	{
		public MessageEnum SellerFarmingProductCreate(SellerFarmingProductDTO sellerFarmingProductDTO);
		public SellerFarmingProduct GetSellerFarmingProductById(Int64 sellerFarmingProductId);
		public List<SellerFarmingProduct> GetSellerFarmingProductList();
		public MessageEnum SellerFarmingProductUpdate(SellerFarmingProductDTO sellerFarmingProductDTO);
		public MessageEnum SellerFarmingProductDelete(Int64 sellerFarmingProductId, Int64 DeletedBy);
	}
}
