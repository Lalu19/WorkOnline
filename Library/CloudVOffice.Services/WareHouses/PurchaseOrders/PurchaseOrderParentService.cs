using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
using CloudVOffice.Data.Migrations;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.PurchaseOrders
{
    public class PurchaseOrderParentService: IPurchaseOrderParentService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<PurchaseOrderParent> _purchaseOrderParentRepo;

        public PurchaseOrderParentService(ApplicationDBContext dbContext,
                                   ISqlRepository<PurchaseOrderParent> purchaseOrderParentRepo

                                    )
        {
            _dbContext = dbContext;
            _purchaseOrderParentRepo = purchaseOrderParentRepo;

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
					purchaseOrderParent.OrderShipped = purchaseOrderParentDTO.OrderShipped;
					purchaseOrderParent.POPUniqueNumber = random.Next(100000, 1000000).ToString();
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
						order.OrderShipped = purchaseOrderParentDTO.OrderShipped;
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
                //var a = _dbContext.PurchaseOrderParents.Where(x => x.PurchaseOrderParentId == PurchaseOrderParentId).FirstOrDefault();
				var order = _dbContext.PurchaseOrderParents.FirstOrDefault(o => o.PurchaseOrderParentId == purchaseOrderParentId);
				if (order != null)
                {
					order.Deleted = true;
                    order.UpdatedBy = DeletedBy;
					order.UpdatedDate = DateTime.Now;
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
		
	}
}
