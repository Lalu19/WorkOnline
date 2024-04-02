using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.Orders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Orders
{
    public class BuyerOrderService : IBuyerOrderService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<BuyerOrder> _BuyerOrderRepo;
        private readonly IItemService _ItemService;
        private readonly IBuyerOrderItemsService _BuyerOrderItemsService;
        public BuyerOrderService(ApplicationDBContext dbContext,
            ISqlRepository<BuyerOrder> BuyerOrderRepo,
            IItemService ItemService,
            IBuyerOrderItemsService BuyerOrderItemsService)
        {
            _dbContext = dbContext;
            _BuyerOrderRepo = BuyerOrderRepo;
            _ItemService = ItemService;
            _BuyerOrderItemsService = BuyerOrderItemsService;
        }
        public BuyerOrder BuyerOrderCreate(BuyerOrderDTO BuyerOrderDTO)
        {

            try
            {
                Random random = new Random();
                BuyerOrder BuyerOrder = new BuyerOrder();
                BuyerOrder.OrderUniqueNo = random.Next(100000, 1000000).ToString();
                BuyerOrder.TotalAmount = BuyerOrderDTO.TotalAmount;
                BuyerOrder.TotalQuantity = BuyerOrderDTO.TotalQuantity;
                BuyerOrder.OrderStatus = "Order Placed";
                BuyerOrder.CreatedBy = BuyerOrderDTO.CreatedBy;
                BuyerOrder.Address = BuyerOrderDTO.Address;
                BuyerOrder.MobileNumber = BuyerOrderDTO.MobileNumber;
                BuyerOrder.Pincode = BuyerOrderDTO.Pincode;
                BuyerOrder.BuyerCustomerLoginID = BuyerOrderDTO.BuyerCustomerLoginID;
                BuyerOrder.CreatedDate = System.DateTime.Now;

                var obj = _BuyerOrderRepo.Insert(BuyerOrder);
                int Quaninty = 0;
                for (int i = 0; i < BuyerOrderDTO.Items.Count; i++)
                {

                    Quaninty += BuyerOrderDTO.Quantity[i];
                    _BuyerOrderItemsService.BuyerOrderItemsCreate(obj.BuyerOrderId, BuyerOrderDTO.Items[i], BuyerOrderDTO.Quantity[i], BuyerOrderDTO.CreatedBy);
                }
                return obj;
            }
            catch
            {
                throw;
            }
        }

        public List<BuyerOrder> GetBuyerOrderListByUserId(int UserId)
        {
            return _dbContext.BuyerOrders
               .Include(s => s.BuyerOrderItems.Where(x => x.Deleted == false))
               .ThenInclude(s => s.Item)
               .Where(x => x.Deleted == false && x.CreatedBy == UserId).ToList();
        }


        public List<Item> GetItemsByPincodeId(int pincodeId)
        {
            var distributors = _dbContext.DistributorAssigns.Where(a => a.PinCodeId == pincodeId).ToList();
        //public List<Item> GetItemsByPincodeId(int pincodeId)
        //{

            List<Int64> brandIds = new List<Int64>();
        //    var distributors = _dbContext.DistributorRegistrations.Where(a => a.PinCodeId == pincodeId).ToList();

            foreach(var distributor in distributors)
            {
                brandIds.Add(distributor.BrandId);
            }

            List<Item> items = new List<Item>();

            foreach (var brand in brandIds)
            {
                var item = _dbContext.Items.Where(z => z.BrandId == brand).ToList();
                items.AddRange(item);
                //items.Add(item);
            }
            return items;
        }
		//}


		public List<BuyerOrder> GetBuyerOrderListByPincode(Int64 PincodeId, Int64 BrandId)
		{
			return _dbContext.BuyerOrders
			   .Include(s => s.BuyerOrderItems.Where(x => x.Deleted == false && x.Item.BrandId == BrandId))
			   .ThenInclude(s => s.Item)
			   .Where(x => x.Deleted == false && x.Pincode == PincodeId).ToList();
		}

		public List<BuyerOrder> GetBuyerOrderListByBuyerOrderId(Int64 BuyerOrderId)
		{
			return _dbContext.BuyerOrders
			   .Include(s => s.BuyerOrderItems.Where(x => x.Deleted == false))
			   .ThenInclude(s => s.Item)
			   .Where(x => x.Deleted == false && x.BuyerOrderId == BuyerOrderId).ToList();
		}

		public BuyerOrder GetsingleBuyerOrderListByBuyerOrderId(Int64 BuyerOrderId)
		{
			return _dbContext.BuyerOrders
			   .Where(x => x.Deleted == false && x.BuyerOrderId == BuyerOrderId).SingleOrDefault();
		}
	}
}
