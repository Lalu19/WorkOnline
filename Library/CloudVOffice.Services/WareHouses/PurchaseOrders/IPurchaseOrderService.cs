using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Core.Domain.WareHouses.States;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.WareHouses.States;
using Org.BouncyCastle.Utilities;

namespace CloudVOffice.Services.WareHouses.PurchaseOrders
{
	public interface IPurchaseOrderService
	{
		public MessageEnum PurchaseOrderCreate(PurchaseOrderDTO purchaseOrderDTO);
		public PurchaseOrder GetPurchaseOrderById(Int64 purchaseOrderId);
		public List<PurchaseOrder> GetPurchaseOrderList();
		public MessageEnum PurchaseOrderUpdate(PurchaseOrderDTO purchaseOrderDTO);
		public MessageEnum PurchaseOrderDelete(Int64 purchaseOrderId, Int64 DeletedBy);
		public List<Item> ItemsFromSellerRegisteredSector(Int64 sellerRegistrationId);
		public Int64 ItemIdFromItemName(string itemName);
		public Item GetItemFromItemId(int itemId);
        public List<PurchaseOrder> GetItemsByPurchaseOrderParentId(Int64 PurchaseOrderParentId);
		public List<PurchaseOrder> GetPurchaseOrderByPurchaseOrderParentId(Int64 PurchaseOrderParentId);
    }
}
