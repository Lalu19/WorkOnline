using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public class SalesOrderItemService
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

        //public MessageEnum SalesOrderItemCreate(List<SalesOrderItemDTO> salesOrderItemDTO)
        //{
        //    try
        //    {

        //        SalesOrderItem salesOrderItem = new SalesOrderItem();

        //        foreach (var salesOrder in salesOrderItemDTO)
        //        {
        //            //salesOrderItem.SalesOrderParentId = salesOrder.SalesOrderParentId;

        //            salesOrderItem.SalesOrderParentId = salesOrder.SalesOrderParentId;
        //            salesOrderItem.Quantity = salesOrder.Quantity;
        //            salesOrderItem.Amount = salesOrder.MRP;
        //            salesOrderItem.CGST = salesOrder.CGST;
        //            salesOrderItem.SGST = salesOrder.SGST;
        //            salesOrderItem.CreatedBy = salesOrder.CreatedBy;
        //            salesOrderItem.CreatedDate = DateTime.Now;

        //            //salesOrderItem.ItemId = _dbContext.


        //            return MessageEnum.Success;
        //        }

        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //}


    }
}
