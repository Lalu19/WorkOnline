using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Web.ViewModel
{
	public class SellerTotalSaleModel
	{
		public Int64 SellerId { get; set; }
		public string WareHuoseName { get; set; }
		public string SectorName { get; set; }
		public string DateTime { get; set; }
		public string StateName { get; set; }
		public string ItemName { get; set; }
		public string CategoryName { get; set; }
		public string SubCategoryName { get; set; }
		public string subCategoryDetailsName { get; set; }
		public double TotalAmount { get; set; }
		public double Quantity { get; set; }
		public string BrandName { get; set; }
	}
}
