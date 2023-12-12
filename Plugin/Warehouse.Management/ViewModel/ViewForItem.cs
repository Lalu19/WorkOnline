using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Data.DTO.WareHouses.Items;

namespace Warehouse.Management.ViewModel
{
	public class ViewForItem
	{
		public ItemDTO CreatedItemDTO { get; set; }
		public List<Sector> Sectors { get; set; }
		public List<HandlingType> HandlingType { get; set; }
		public List<GST> GST { get; set; }
		public List<Category> Category { get; set; }
		public List<SubCategory1> SubCategory1 { get; set; }
	}
}
