using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.PurchaseOrders
{
    public interface IPurchaseOrderParentService
    {
		//public MessageEnum PurchaseOrderParentCreate(PurchaseOrderParentDTO purchaseOrderParentDTO);

		public PurchaseOrderParent PurchaseOrderParentCreate(PurchaseOrderParentDTO purchaseOrderParentDTO);

		public PurchaseOrderParent GetPurchaseOrderParentById(Int64 purchaseOrderParentId);
        public List<PurchaseOrderParent> GetPurchaseOrderParentList();
        public MessageEnum PurchaseOrderParentUpdate(PurchaseOrderParentDTO purchaseOrderParentDTO);
        public MessageEnum PurchaseOrderParentDelete(Int64 purchaseOrderParentId, Int64 DeletedBy);
		
	}
}
