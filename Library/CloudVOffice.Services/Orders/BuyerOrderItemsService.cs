using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Orders
{
    public class BuyerOrderItemsService : IBuyerOrderItemsService
    {
        private readonly ApplicationDBContext _Context;
        private readonly ISqlRepository<BuyerOrderItems> _BuyerOrderItemsRepo;
        public BuyerOrderItemsService(ApplicationDBContext Context, 
                                    ISqlRepository<BuyerOrderItems> BuyerOrderItemsRepo)
        {
            _Context = Context;
            _BuyerOrderItemsRepo = BuyerOrderItemsRepo;
        }
        public MessageEnum BuyerOrderItemsCreate(Int64 BuyerOrderId, int ItemId, Int64 Quantity, Int64 createdBy)
        {
            BuyerOrderItems BuyerOrderItems = new BuyerOrderItems();
            BuyerOrderItems.ItemId = ItemId;
            BuyerOrderItems.Quantity = Quantity;
            BuyerOrderItems.BuyerOrderId = BuyerOrderId;
            BuyerOrderItems.CreatedBy = createdBy;
            BuyerOrderItems.CreatedDate = DateTime.Now;
            _BuyerOrderItemsRepo.Insert(BuyerOrderItems);
            return MessageEnum.Success;
        }
    }
}
