using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public class SalesOrderItemService : ISalesOrderItemService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SalesOrderItem> _salesOrderItemRepo;

        public SalesOrderItemService(ApplicationDBContext dbContext,
                                   ISqlRepository<SalesOrderItem> salesOrderItemRepo
                                    )
        {
            _dbContext = dbContext;
            _salesOrderItemRepo = salesOrderItemRepo;
        }

        public MessageEnum SalesOrderItemCreate(Int64 salesParentOrderId, Int64 createdBy , List<SalesOrderItemDTO> salesOrderItemDTO)
        {
            try
            {
                foreach (var salesOrder in salesOrderItemDTO)
                {
                    //salesOrderItem.SalesOrderParentId = salesOrder.SalesOrderParentId;

                    //if (_dbContext.SalesOrderItems.Any(item => item.SalesOrderParentId == salesOrder.SalesOrderParentId))
                    //{
                    //    return MessageEnum.Duplicate;
                    //}
                    SalesOrderItem salesOrderItem = new SalesOrderItem();

                    salesOrderItem.SalesOrderParentId = salesParentOrderId;
                    salesOrderItem.Quantity = salesOrder.Quantity;
                    salesOrderItem.Amount = salesOrder.MRP;
                    salesOrderItem.CGST = salesOrder.CGST;
                    salesOrderItem.SGST = salesOrder.SGST;
                    salesOrderItem.CreatedBy = createdBy;
                    salesOrderItem.CreatedDate = DateTime.Now;
                    salesOrderItem.ItemId = _dbContext.Items.Where(a=> a.ItemName == salesOrder.ItemName).Select(x => x.ItemId).FirstOrDefault();

                    _salesOrderItemRepo.Insert(salesOrderItem);
                }
                return MessageEnum.Success;
            }
            catch
            {
                throw;
            }
        }


        public List<SalesOrderItem> GetSalesOrderItemList()
        {
            try
            {
                var list = _dbContext.SalesOrderItems.Where(a => a.Deleted == false).ToList();
                return list;
            }
            catch
            {
                throw;
            }
        }

        public SalesOrderItem GetSalesOrderItemById(int salesOrderItemId)
        {
            try
            {
                var salesOrderItem = _dbContext.SalesOrderItems.FirstOrDefault(a=> a.SalesOrderItemId ==  salesOrderItemId);
                return salesOrderItem;
            }
            catch
            {
                throw;
            }
        }
		public List<SalesOrderItem> GetSalesOrderItemByParentId(Int64 SalesOrderParentId)
		{
			try
			{
				var salesOrderItem = _dbContext.SalesOrderItems.Where(a => a.SalesOrderParentId == SalesOrderParentId).ToList();

				return salesOrderItem;
			}
			catch
			{
				throw;
			}
		}



	}
}
