using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public class WareHouseSalesOrderItemService : IWareHouseSalesOrderItemService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<WareHouseSalesOrderItem> _wareHouseSalesOrderItemRepo;

        public WareHouseSalesOrderItemService(ApplicationDBContext dbContext,
                                   ISqlRepository<WareHouseSalesOrderItem> wareHouseSalesOrderItemRepo
                                    )
        {
            _dbContext = dbContext;
            _wareHouseSalesOrderItemRepo = wareHouseSalesOrderItemRepo;
        }

        public MessageEnum CreateWareHouseSalesOrderItem(Int64 ParentId, Int64 createdBy ,List<WareHouseSalesOrderItemDTO> wareHouseSalesOrderItemDTO)
        {
            try
            {
                foreach (var SalesOrderItemDTO in wareHouseSalesOrderItemDTO)
                {
                    WareHouseSalesOrderItem WHSOItem = new WareHouseSalesOrderItem();

                    WHSOItem.WarehouseSalesOrderParentId = ParentId;
                    WHSOItem.ItemId = SalesOrderItemDTO.ItemId;
                    WHSOItem.Quantity = SalesOrderItemDTO.Quantity;
                    WHSOItem.Amount = SalesOrderItemDTO.Amount;

                    _wareHouseSalesOrderItemRepo.Insert(WHSOItem);
                }
                return MessageEnum.Success;
            }
            catch
            {
                throw;
            }
        }
    }
}
