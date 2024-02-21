using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Orders;
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
	public class CheckoutService : ICheckoutService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<Checkout> _checkoutRepo;
		private readonly IItemService _itemService;
		public CheckoutService(ApplicationDBContext dbContext,
			ISqlRepository<Checkout> checkoutRepo,
			IItemService itemService)
		{
			_dbContext = dbContext;
			_checkoutRepo = checkoutRepo;
			_itemService = itemService;
		}
		public MessageEnum CheckoutCreate(CheckoutDTO checkoutDTO)
		{
			try
			{
				var objcheck = _dbContext.Checkouts.SingleOrDefault(opt => opt.Deleted == false && opt.ItemId == checkoutDTO.ItemId && opt.CreatedBy == checkoutDTO.CreatedBy);
				if (objcheck == null)
				{
					Checkout checkOut = new Checkout();
					checkOut.ItemId = checkoutDTO.ItemId;
					checkOut.Quantity = checkoutDTO.Quantity;
					checkOut.CreatedBy = checkoutDTO.CreatedBy;
					checkOut.CreatedDate = System.DateTime.Now;
					var obj = _checkoutRepo.Insert(checkOut);
					return MessageEnum.Success;

				}
				else
				{
					objcheck.Quantity += 1;
					_dbContext.SaveChanges();
					return MessageEnum.Success;
				}
			}
			catch
			{
				throw;
			}
		}
		public List<Checkout> CheckoutList()
		{
			return _dbContext.Checkouts
			  .Include(s => s.Item)
			  .Where(x => x.Deleted == false).ToList();
		}
		public Checkout CheckoutById(Int64 CheckoutId)
		{
			return _dbContext.Checkouts
				.Include(s => s.Item)
				.Where(x => x.CheckoutId == CheckoutId && x.Deleted == false).SingleOrDefault();
		}
		public MessageEnum CheckoutUpdate(CheckoutDTO checkoutDTO)
		{
			try
			{
				var updatecheckout = _dbContext.Checkouts.Where(x => x.CheckoutId != checkoutDTO.CheckoutId && x.ItemId == checkoutDTO.ItemId && x.Quantity == checkoutDTO.Quantity && x.Deleted == false).FirstOrDefault();

				if (updatecheckout == null)
				{
					var a = _dbContext.Checkouts.Where(x => x.CheckoutId == checkoutDTO.CheckoutId).FirstOrDefault();
					if (a != null)
					{
						a.ItemId = checkoutDTO.ItemId;
						a.Quantity = checkoutDTO.Quantity;
						a.UpdatedBy = checkoutDTO.CreatedBy;
						a.UpdatedDate = DateTime.Now;
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
		public MessageEnum CheckoutDelete(Int64 CheckoutId, Int64 DeletedBy)
		{
			try
			{
				var checkout = _dbContext.Checkouts.SingleOrDefault(x => x.CheckoutId == CheckoutId);

				if (checkout != null)
				{
					checkout.Deleted = true;
					checkout.UpdatedBy = DeletedBy;
					checkout.UpdatedDate = DateTime.Now;
					_dbContext.SaveChanges();
					return MessageEnum.Deleted;
				}
				else
				{
					return MessageEnum.Invalid;
				}
			}
			catch
			{
				throw;
			}
		}
		public MessageEnum CheckOutPlusUpdate(Int64 CheckoutId, Int64 Createdby)
		{

			try
			{
				var a = _dbContext.Checkouts.Where(x => x.CheckoutId == CheckoutId).FirstOrDefault();
				if (a != null)
				{
					a.Quantity = a.Quantity + 1;
					a.UpdatedBy = Createdby;
					a.UpdatedDate = DateTime.Now;
					_dbContext.SaveChanges();
					return MessageEnum.Updated;
				}
				else
				{
					return MessageEnum.Invalid;
				}

			}
			catch
			{
				throw;
			}
		}
		public MessageEnum CheckOutMinusUpdate(Int64 CheckoutId, Int64 Createdby)
		{
			try
			{
				var a = _dbContext.Checkouts.Where(x => x.CheckoutId == CheckoutId).FirstOrDefault();
				if (a != null)
				{
					int minQuantity = 1;

					if (a.Quantity > minQuantity)
					{

						a.Quantity = a.Quantity - 1;
						a.UpdatedBy = Createdby;
						a.UpdatedDate = DateTime.Now;
						_dbContext.SaveChanges();
						return MessageEnum.Updated;
					}
					else
					{
						return MessageEnum.MinimumQuantityReached;
					}

				}
				else
				{
					return MessageEnum.Invalid;
				}

			}
			catch
			{
				throw;
			}
		}
		public MessageEnum CheckOutDeleteAfterOrder(Int64 ItemId, Int64 DeletedBy, Int64 Createdby)
		{
			try
			{
				var checkout = _dbContext.Checkouts.SingleOrDefault(x => x.ItemId == ItemId && x.Deleted == false && x.CreatedBy == Createdby);

				if (checkout != null)
				{
					checkout.Deleted = true;
					checkout.UpdatedBy = DeletedBy;
					checkout.UpdatedDate = DateTime.Now;
					_dbContext.SaveChanges();
					return MessageEnum.Deleted;
				}
				else
				{
					return MessageEnum.Invalid;
				}
			}
			catch
			{
				throw;
			}
		}
        //public MessageEnum CheckOutUpdate(Int64 CheckoutId, int Quantity, Int64 UpdatedBy)
        //{
        //	try
        //	{
        //		var checkout = _dbContext.Checkouts.SingleOrDefault(x => x.CheckoutId == CheckoutId);

        //		if (checkout != null)
        //		{
        //			checkout.Quantity = Quantity;
        //			checkout.UpdatedBy = UpdatedBy;
        //			checkout.UpdatedDate = DateTime.Now;
        //			_dbContext.SaveChanges();
        //			return MessageEnum.Updated;
        //		}
        //		else
        //		{
        //			return MessageEnum.Invalid;
        //		}
        //	}
        //	catch
        //	{
        //		throw;
        //	}
        //}

        public List<Checkout> CheckOutListbyUserId(Int64 CreatedBy)
        {
            return _dbContext.Checkouts
              .Include(s => s.Item)
              .Where(x => x.Deleted == false && x.CreatedBy == CreatedBy).ToList();
        }

        
    }
}
