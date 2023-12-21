using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.WareHouses.Items;

namespace CloudVOffice.Services.WareHouses.Itemss
{
    public interface IDamageItemForFarmingService
    {
        public MessageEnum DamageItemForFarmingCreate(DamageItemForFarmingDTO damageItemForFarmingDTO);
        public DamageItemForFarming GetDamageItemForFarmingById(Int64 damageItemForFarmingId);
        public List<DamageItemForFarming> GetDamageItemForFarmingList();
        public MessageEnum DamageItemForFarmingUpdate(DamageItemForFarmingDTO damageItemForFarmingDTO);
        public MessageEnum DamageItemForFarmingDelete(Int64 damageItemForFarmingId, Int64 DeletedBy);
    }
}
