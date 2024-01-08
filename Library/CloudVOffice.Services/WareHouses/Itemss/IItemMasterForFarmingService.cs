using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.WareHouses.Items;
using Org.BouncyCastle.Asn1.Mozilla;

namespace CloudVOffice.Services.WareHouses.Itemss
{
    public interface IItemMasterForFarmingService
    {
		public ItemMasterForFarmingDTO CreateItemMasterForFarming(ItemMasterForFarmingDTO itemMasterForFarmingDTO);
        public MessageEnum UpdateItemMasterForFarming(ItemMasterForFarmingDTO itemMasterForFarmingDTO);
        public void GenerateAndSaveBarcodeImage(string itemMasterForFarmingId);
        public List<Sector> GetSectorListforFarmerProduces();
        public ItemMasterForFarming GetItemMasterForFarmingByItemMasterForFarmingId(Int64 itemMasterForFarmingId);
        public ItemMasterForFarming GetItemMasterForFarmingById(Int64 itemMasterForFarmingId);
        public List<ItemMasterForFarming> GetItemMasterForFarmingList();
        public MessageEnum DeleteItemMasterForFarming(Int64 itemMasterForFarmingId, Int64 DeletedBy);
    }
}
