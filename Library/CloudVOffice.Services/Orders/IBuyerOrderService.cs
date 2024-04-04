using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Orders
{
    public interface IBuyerOrderService
    {
        public BuyerOrder BuyerOrderCreate(BuyerOrderDTO BuyerOrderDTO);
        public List<BuyerOrder> GetBuyerOrderListByUserId(int UserId);

        public List<Item> GetItemsByPincodeId(int pincodeId);
        public List<BuyerOrder> GetBuyerOrderListByPincode(Int64 PincodeId, Int64 BrandId);
        public List<BuyerOrder> GetBuyerOrderListByBuyerOrderId(Int64 BuyerOrderId);
        public BuyerOrder GetsingleBuyerOrderListByBuyerOrderId(Int64 BuyerOrderId);

	}
}
