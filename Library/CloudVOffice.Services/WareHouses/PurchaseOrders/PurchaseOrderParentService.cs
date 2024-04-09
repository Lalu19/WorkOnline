using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
//using CloudVOffice.Data.Migrations;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.PurchaseOrders
{
    public class PurchaseOrderParentService: IPurchaseOrderParentService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<PurchaseOrderParent> _purchaseOrderParentRepo;
        private readonly IPurchaseOrderService _PurchaseOrderService;

        public PurchaseOrderParentService(ApplicationDBContext dbContext,
                                   ISqlRepository<PurchaseOrderParent> purchaseOrderParentRepo,
                                   IPurchaseOrderService PurchaseOrderService
                                    )
        {
            _dbContext = dbContext;
            _purchaseOrderParentRepo = purchaseOrderParentRepo;
            _PurchaseOrderService = PurchaseOrderService;

        }
		//    public MessageEnum PurchaseOrderParentCreate(PurchaseOrderParentDTO purchaseOrderParentDTO)
		//    {
		//        try
		//        {
		//           // var objcheck = _dbContext.PurchaseOrderParents.SingleOrDefault(opt => opt.Deleted == false && opt.PurchaseOrderParentId == purchaseOrderParentDTO.PurchaseOrderParentId);
		//var objCheck = _dbContext.PurchaseOrderParents.FirstOrDefault(p => p.PurchaseOrderParentId == purchaseOrderParentDTO.PurchaseOrderParentId);

		//if (objCheck == null)
		//            {
		//                PurchaseOrderParent purchaseOrderParent = new PurchaseOrderParent();
		//	purchaseOrderParent.TotalAmount = purchaseOrderParentDTO.TotalAmount;
		//	purchaseOrderParent.TotalQuantity = purchaseOrderParentDTO.TotalQuantity;
		//	purchaseOrderParent.SellerRegistrationId = purchaseOrderParentDTO.SellerRegistrationId;
		//	purchaseOrderParent.OrderShipped = purchaseOrderParentDTO.OrderShipped;
		//	purchaseOrderParent.CreatedBy = purchaseOrderParentDTO.CreatedBy;
		//	purchaseOrderParent.CreatedDate = System.DateTime.Now;
		//                var obj = _purchaseOrderParentRepo.Insert(purchaseOrderParent);
		//                return MessageEnum.Success;
		//            }
		//            else
		//            {
		//                return MessageEnum.Duplicate;
		//            }
		//        }
		//        catch
		//        {
		//            throw;
		//        }
		//    }


		public PurchaseOrderParent PurchaseOrderParentCreate(PurchaseOrderParentDTO purchaseOrderParentDTO)
		{
			try
			{
				var objCheck = _dbContext.PurchaseOrderParents.FirstOrDefault(p => p.PurchaseOrderParentId == purchaseOrderParentDTO.PurchaseOrderParentId);

				if (objCheck == null)
				{
					Random random=new Random();
					PurchaseOrderParent purchaseOrderParent = new PurchaseOrderParent();
					purchaseOrderParent.TotalAmount = purchaseOrderParentDTO.TotalAmount;
					purchaseOrderParent.TotalQuantity = purchaseOrderParentDTO.TotalQuantity;
					purchaseOrderParent.SellerRegistrationId = purchaseOrderParentDTO.SellerRegistrationId;
					purchaseOrderParent.WareHuoseId = purchaseOrderParentDTO.WareHuoseId;
					purchaseOrderParent.OrderShipped = purchaseOrderParentDTO.OrderShipped;
					purchaseOrderParent.POPUniqueNumber = random.Next(100000, 1000000).ToString();
                    purchaseOrderParent.TotalWeight = purchaseOrderParentDTO.TotalWeight;
					purchaseOrderParent.CreatedBy = purchaseOrderParentDTO.CreatedBy;
					purchaseOrderParent.CreatedDate = System.DateTime.Now;
					
					var obj = _purchaseOrderParentRepo.Insert(purchaseOrderParent);

					return obj;
				}
				else
				{
					// You may want to throw an exception or handle this case differently based on your requirements
					throw new Exception("Duplicate entry found");
				}
			}
			catch
			{
				throw;
			}
		}


		public List<PurchaseOrderParent> GetPurchaseOrderParentList()
        {
            try
            {
                return _dbContext.PurchaseOrderParents.Where(x => x.Deleted == false && x.OrderShipped == false).ToList();
            }
            catch
            {
                throw;
            }
        }

		public List<PurchaseOrderParent> GetPurchaseOrderParentListBySellerId(Int64 SellerId)
		{
			try
			{
				return _dbContext.PurchaseOrderParents.Where(x => x.Deleted == false && x.OrderShipped == false && x.SellerRegistrationId == SellerId).ToList();
			}
			catch
			{
				throw;
			}
		}

        public List<PurchaseOrderParent> GetPurchaseOrderParentListsimple()
		{
			try
			{
				return _dbContext.PurchaseOrderParents.Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}

		public MessageEnum PurchaseOrderParentUpdate(PurchaseOrderParentDTO purchaseOrderParentDTO)
        {
            try
            {
                var updatePurchaseOrderParent = _dbContext.PurchaseOrderParents.Where(x => x.PurchaseOrderParentId != purchaseOrderParentDTO.PurchaseOrderParentId && x.PurchaseOrderParentId == purchaseOrderParentDTO.PurchaseOrderParentId && x.Deleted == false).FirstOrDefault();
                if (updatePurchaseOrderParent == null)
                {
                   // var a = _dbContext.PurchaseOrderParents.Where(x => x.PurchaseOrderParentId == purchaseOrderParentDTO.PurchaseOrderParentId).FirstOrDefault();
					var order = _dbContext.PurchaseOrderParents.FirstOrDefault(o => o.PurchaseOrderParentId == purchaseOrderParentDTO.PurchaseOrderParentId);
					if (order != null)
                    {
						order.TotalAmount = purchaseOrderParentDTO.TotalAmount;
						order.TotalQuantity = purchaseOrderParentDTO.TotalQuantity;
						order.SellerRegistrationId = purchaseOrderParentDTO.SellerRegistrationId;
						order.WareHuoseId = purchaseOrderParentDTO.WareHuoseId;
						order.OrderShipped = purchaseOrderParentDTO.OrderShipped;
                        order.TotalWeight = purchaseOrderParentDTO.TotalWeight;
						order.UpdatedBy = purchaseOrderParentDTO.CreatedBy;
						order.UpdatedDate = DateTime.Now;
                        _dbContext.SaveChanges();
                        return MessageEnum.Updated;
                    }
                    else
                        return MessageEnum.Invalid;
                }
                else
                {
                    return MessageEnum.Duplicate;
                }
            }
            catch
            {
                throw;
            }
        }
        public PurchaseOrderParent GetPurchaseOrderParentById(Int64 purchaseOrderParentId)
		{
			try
			{

				PurchaseOrderParent a = _dbContext.PurchaseOrderParents.FirstOrDefault(p => p.PurchaseOrderParentId == purchaseOrderParentId);
				return a;
			}
			catch
			{
				throw;
			}
		}

        public MessageEnum PurchaseOrderParentDelete(Int64 purchaseOrderParentId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.PurchaseOrderParents.Where(x => x.PurchaseOrderParentId == purchaseOrderParentId).FirstOrDefault();

                if (a != null)
                {
                    a.Deleted = true;
                    a.UpdatedBy = DeletedBy;
                    a.UpdatedDate = DateTime.Now;

                    var PurcheseOrder = _PurchaseOrderService.GetPurchaseOrderByPurchaseOrderParentId(purchaseOrderParentId);
                    foreach (var PurcheseOrderdetails in PurcheseOrder)
                    {
                        _PurchaseOrderService.PurchaseOrderDelete(PurcheseOrderdetails.PurchaseOrderId, DeletedBy);
                    }
                    _dbContext.SaveChanges();

                    return MessageEnum.Deleted;
                }
                else
                    return MessageEnum.Invalid;
            }
            catch
            {
                throw;
            }
        }
        public PurchaseOrderParent GetPOOrderByPurchaseOrderParentId(Int64 purchaseOrderParentId)
        {
            return _dbContext.PurchaseOrderParents
				.Include(x=> x.SellerRegistration)
				.ThenInclude(x=> x.WareHuose)
				.Include(x=> x.PurchaseOrders.Where(s=> s.Deleted == false))
				.ThenInclude(x=> x.Item)
				.Where(x => x.Deleted == false && x.PurchaseOrderParentId == purchaseOrderParentId).SingleOrDefault();
        }

        public List<PurchaseOrderParent> GetPurchaseOrderParentListbyWareHouseId(Int64 WareHuoseId)
        {
            return _dbContext.PurchaseOrderParents
                    .Include(x => x.PurchaseOrders).Where(x => x.Deleted == false)
                    .Include(x => x.WareHuose)
                    .Include(x => x.SellerRegistration)
                    .Where(x => x.Deleted == false && x.OrderShipped == false && x.WareHuoseId == WareHuoseId).ToList();
        }


        public List<PurchaseOrderParent> GetPurchaseOrdersBySellerId(Int64 SellerId)
        {
            try
            {
                var purchaseOrders = _dbContext.PurchaseOrderParents.Where(a => a.SellerRegistrationId == SellerId).ToList();
                return purchaseOrders;
            }
            catch
            {
                throw;
            }
        }

        public List<PurchaseOrderParent> GetPurchaseOrdersDispatchedBySellerId(Int64 SellerId)
        {
            try
            {
                var purchaseOrdersdispatched = _dbContext.PurchaseOrderParents.Where(a => a.SellerRegistrationId == SellerId && a.OrderShipped == true).ToList();
                return purchaseOrdersdispatched;
            }
            catch
            {
                throw;
            }            
        }

        public List<PurchaseOrderParent> GetPurchaseOrderParentsByDate(DateTime FromDate, DateTime ToDate)
        {
             return _dbContext.PurchaseOrderParents.Where(x => x.Deleted == false && x.CreatedDate.Date >= FromDate && x.CreatedDate.Date <= ToDate).ToList();
        }

    }
}
