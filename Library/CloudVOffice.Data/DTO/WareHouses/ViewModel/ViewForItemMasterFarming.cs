using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.Items;

namespace CloudVOffice.Data.DTO.WareHouses.ViewModel
{
    public class ViewForItemMasterFarming
    {
        public ItemMasterForFarmingDTO CreatedItemMasterFarmingDTO { get; set; }
        public List<Sector> Sectors { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory1> SubCategories { get; set; }
    }
}
