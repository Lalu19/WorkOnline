using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Data.DTO.WareHouses.Items;

namespace CloudVOffice.Data.DTO.WareHouses.ViewModel
{
	public class ViewForItem
	{
		public ItemDTO CreatedItemDTO { get; set; }
		public List<Sector> Sectors { get; set; }
		public List<HandlingType> HandlingTypes { get; set; }
		public List<GST> GST { get; set; }
		public List<Category> Category { get; set; }
		public List<SubCategory1> SubCategory1 { get; set; }
		public List<SubCategory2> SubCategory2 { get; set; }
		public List<WareHuose> WareHuose { get; set; }
		public List<AddDistrict> AddDistrict { get; set; }
		public List<Vendor> Vendor { get; set; }
		public List<Employee> Employee { get; set; }
		public List<Unit> Unit { get; set; }
	}
}
