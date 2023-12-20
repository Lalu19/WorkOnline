using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Data.DTO.WareHouses.Items;

namespace CloudVOffice.Data.DTO.WareHouses.ViewModel
{
    public class ViewForItemMasterFarming
    {
        public ItemMasterForFarmingDTO CreatedItemMasterFarmingDTO { get; set; }
        public List<Sector> Sectors { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory1> SubCategories1 { get; set; }
        public List<SubCategory2> SubCategories2 { get; set; }
        public List<WareHuose> WareHouses { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Vendor> Vendors { get; set; }
        public List<District> Districts { get; set; }
    }
}
