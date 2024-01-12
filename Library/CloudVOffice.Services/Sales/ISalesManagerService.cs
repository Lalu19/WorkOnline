using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.DTO.WareHouses.Months;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Sales
{
	public interface ISalesManagerService
	{
		public MessageEnum SalesManagerCreate(SalesManagerDTO salesManagerDTO);
		public SalesManager GetSalesManagerById(Int64 SalesManagerId);
		public List<SalesManager> GetSalesManagerList();
		public MessageEnum SalesManagerUpdate(SalesManagerDTO salesManagerDTO);
		public MessageEnum MontSalesManagerDelete(Int64 SalesManagerId, Int64 DeletedBy);
		public Int64 GetSalesManagerIdByName(string Name);
	}
}
