using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Itemss
{
	public class DamageItemService : IDamageItemService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<DamageItem> _damageItemRepo;
		public DamageItemService(ApplicationDBContext dbContext, ISqlRepository<DamageItem> damageItemRepo)
		{

			_dbContext = dbContext;
			_damageItemRepo = damageItemRepo;
		}
		public MessageEnum DamageItemCreate(DamageItemDTO damageItemDTO)
		{
			var ObjCheck = _dbContext.DamageItems.FirstOrDefault(opt => opt.DamageItemId == damageItemDTO.DamageItemId && opt.Deleted == false);
			try
			{

				if (ObjCheck == null)
				{

					DamageItem damageItem = new DamageItem();
					damageItem.ItemId = (long)damageItemDTO.ItemId;
					damageItem.ItemName = damageItemDTO.ItemName;
					damageItem.WareHouseName = damageItemDTO.WareHouseName;
					damageItem.DistrictName = damageItemDTO.DistrictName;
					damageItem.VendorName = damageItemDTO.VendorName;
					damageItem.EmployeeName = damageItemDTO.EmployeeName;
					damageItem.CompanyName = damageItemDTO.CompanyName;
					damageItem.BrandName = damageItemDTO.BrandName;
					damageItem.ProductWeight = damageItemDTO.ProductWeight;
					damageItem.UnitId = damageItemDTO.UnitId;
					damageItem.CaseWeight = damageItemDTO.CaseWeight;
					damageItem.UnitPerCase = damageItemDTO.UnitPerCase;
					damageItem.ManufactureDate = damageItemDTO.ManufactureDate;
					damageItem.ExpiryDate = damageItemDTO.ExpiryDate;
					damageItem.MRP = damageItemDTO.MRP;
					damageItem.PurchaseCost = damageItemDTO.PurchaseCost;
					damageItem.SalesCost = damageItemDTO.SalesCost;
					damageItem.SGST = damageItemDTO.SGST;
					damageItem.CGST = damageItemDTO.CGST;
					damageItem.HandlingType = damageItemDTO.HandlingType;
					damageItem.InvoiceNo = damageItemDTO.InvoiceNo;
					damageItem.ReceivedDate = damageItemDTO.ReceivedDate;
					damageItem.Reason = damageItemDTO.Reason;
					damageItem.DamagePics = damageItemDTO.DamagePics;
					damageItem.DamageUnits = damageItemDTO.DamageUnits;
					damageItem.CreatedBy = damageItemDTO.CreatedBy;
					_damageItemRepo.Insert(damageItem);
					_dbContext.SaveChangesAsync();


					return MessageEnum.Success;
				}
				else if (ObjCheck != null)
				{
					return MessageEnum.AlreadyCreate;
				}
				return MessageEnum.UnExpectedError;
			}
			catch
			{
				throw;
			}


		}

		public MessageEnum DamageItemDelete(int damageItemId, int DeletedBy)
		{
			try
			{
				var a = _dbContext.DamageItems.Where(x => x.DamageItemId == damageItemId).FirstOrDefault();
				if (a != null)
				{
					a.Deleted = true;
					a.UpdatedBy = DeletedBy;
					a.UpdatedDate = DateTime.Now;
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

		public MessageEnum DamageItemUpdate(DamageItemDTO damageItemDTO)
		{
			try
			{

				var a = _dbContext.DamageItems.Where(x => x.DamageItemId == damageItemDTO.DamageItemId).FirstOrDefault();
				if (a != null)
				{
					
					a.ItemName = damageItemDTO.ItemName;
					a.WareHouseName = damageItemDTO.WareHouseName;
					a.DistrictName = damageItemDTO.DistrictName;
					a.VendorName = damageItemDTO.VendorName;
					a.EmployeeName = damageItemDTO.EmployeeName;
					a.CompanyName = damageItemDTO.CompanyName;
					a.BrandName = damageItemDTO.BrandName;
					a.ProductWeight = damageItemDTO.ProductWeight;
					a.UnitId = damageItemDTO.UnitId;
					a.CaseWeight = damageItemDTO.CaseWeight;
					a.UnitPerCase = damageItemDTO.UnitPerCase;
					a.ManufactureDate = damageItemDTO.ManufactureDate;
					a.ExpiryDate = damageItemDTO.ExpiryDate;
					a.MRP = damageItemDTO.MRP;
					a.PurchaseCost = damageItemDTO.PurchaseCost;
					a.SalesCost = damageItemDTO.SalesCost;
					a.SGST = damageItemDTO.SGST;
					a.CGST = damageItemDTO.CGST;
					a.HandlingType = damageItemDTO.HandlingType;
					a.InvoiceNo = damageItemDTO.InvoiceNo;
					a.ReceivedDate = damageItemDTO.ReceivedDate;
					a.Reason = damageItemDTO.Reason;
					a.DamagePics = damageItemDTO.DamagePics;
					a.DamageUnits = damageItemDTO.DamageUnits;
					a.CreatedBy = damageItemDTO.CreatedBy;
					a.UpdatedDate = DateTime.Now;
					_dbContext.SaveChanges();
					return MessageEnum.Updated;
				}
				else
					return MessageEnum.Invalid;


			}
			catch
			{
				throw;
			}
		}

		public DamageItem GetDamageItem()
		{
			try
			{
				return _dbContext.DamageItems.Where(c => c.Deleted == false).FirstOrDefault();
			}
			catch
			{
				throw;
			}
		}

		public DamageItem GetDamageItemByDamageItemId(int damageItemId)
		{
			try
			{
				return _dbContext.DamageItems.Where(x => x.DamageItemId == damageItemId && x.Deleted == false).SingleOrDefault();

			}
			catch
			{
				throw;
			}
		}

		public List<DamageItem> GetDamageItemList()
		{
			try
			{
				return _dbContext.DamageItems.Where(x => x.Deleted == false).ToList();
			}
			catch
			{
				throw;
			}
		}

	}
}
