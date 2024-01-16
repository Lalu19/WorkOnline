using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Core.Domain.WareHouses.States;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
using CloudVOffice.Data.Migrations;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CloudVOffice.Services.WareHouses.PurchaseOrders
{
	public class PurchaseOrderService : IPurchaseOrderService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<PurchaseOrder> _purchaseRepo;

		public PurchaseOrderService(ApplicationDBContext dbContext,
								   ISqlRepository<PurchaseOrder> purchaseOrderRepo

									)
		{
			_dbContext = dbContext;
			_purchaseRepo = purchaseOrderRepo;

		}


		public MessageEnum PurchaseOrderCreate(PurchaseOrderDTO purchaseOrderDTO)
		{
			try
			{
				var objCheck = _dbContext.PurchaseOrders.FirstOrDefault(p => p.PurchaseOrderId == purchaseOrderDTO.PurchaseOrderId);

				if (objCheck == null)
				{
					PurchaseOrder purchaseOrder = new PurchaseOrder();

					purchaseOrder.SellerRegistrationId = purchaseOrderDTO.SellerRegistrationId;
					purchaseOrder.ItemId = purchaseOrderDTO.ItemId;
					purchaseOrder.Quantity = purchaseOrderDTO.Quantity;
					purchaseOrder.CreatedBy = purchaseOrderDTO.CreatedBy;
					purchaseOrder.CreatedDate = DateTime.Now;

					_purchaseRepo.Insert(purchaseOrder);
					 return MessageEnum.Success;

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

		public PurchaseOrder GetPurchaseOrderById(Int64 purchaseOrderId)
		{
			try
			{

				PurchaseOrder a = _dbContext.PurchaseOrders.FirstOrDefault(p => p.PurchaseOrderId == purchaseOrderId);
				return a;
			}
			catch
			{
				throw;
			}

		}

		public List<PurchaseOrder> GetPurchaseOrderList()
		{
			//var orders = _dbContext.PurchaseOrders.Where(o => o.Deleted == false).ToList();
			//return orders;

			try
			{
                var a = _dbContext.PurchaseOrders
            .Include(s => s.SellerRegistration)
			.Include(s => s.Item)
            .Where(x => x.Deleted == false).ToList();
                return a;
            }

			catch
			{
				throw;
			}
        }		

		public MessageEnum PurchaseOrderDelete(Int64 purchaseOrderId, Int64 DeletedBy)
		{
			try
			{
				var order = _dbContext.PurchaseOrders.FirstOrDefault(o => o.PurchaseOrderId == purchaseOrderId);
				if (order != null)
				{
					order.Deleted = true;
					order.UpdatedDate = DateTime.Now;
					order.UpdatedBy = DeletedBy;
					_dbContext.SaveChanges();
					return MessageEnum.Deleted;
				}
				else { return MessageEnum.Invalid; }
			}
			catch
			{
				throw;
			}

		}

		public MessageEnum PurchaseOrderUpdate(PurchaseOrderDTO purchaseOrderDTO)
		{
			try
			{
				var order = _dbContext.PurchaseOrders.FirstOrDefault(o => o.PurchaseOrderId == purchaseOrderDTO.PurchaseOrderId);

				if (order != null)
				{
					order.SellerRegistrationId = purchaseOrderDTO.SellerRegistrationId;
					order.Quantity = purchaseOrderDTO.Quantity;
					order.ItemId = purchaseOrderDTO.ItemId;
					order.UpdatedDate = DateTime.Now;

					_purchaseRepo.Update(order);

					return MessageEnum.Success;
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

		public List<Item> ItemsFromSellerRegisteredSector(Int64 sellerRegistrationId)
		{
			var sellerSectorId = _dbContext.SellerRegistrations.Where(s => s.SellerRegistrationId == sellerRegistrationId).Select(s => s.SectorId)
						  .FirstOrDefault();

			var items = _dbContext.Items.Where(i => i.SectorId == sellerSectorId).ToList();

			return items;
		}

		public Int64 ItemIdFromItemName(string itemName)
		{
			var itemId = _dbContext.Items.Where(i=> i.ItemName == itemName).Select(i => i.ItemId).FirstOrDefault();
			return itemId;
		}

	}
}
