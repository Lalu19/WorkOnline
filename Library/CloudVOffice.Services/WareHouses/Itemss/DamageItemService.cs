using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
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
using Npgsql.PostgresTypes;

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
					var wh = _dbContext.WareHouses.FirstOrDefault(wh => wh.WareHouseName ==  damageItemDTO.WareHouseName);
					var dis = _dbContext.AddDistricts.FirstOrDefault(di => di.DistrictName == damageItemDTO.DistrictName);
					var ven = _dbContext.Vendors.FirstOrDefault(v => v.VendorName ==  damageItemDTO.VendorName);
					var emp = _dbContext.Employees.FirstOrDefault(v => v.EmployeeName  == damageItemDTO.EmployeeName);
					var unit = _dbContext.Units.FirstOrDefault(u => u.ShortName == damageItemDTO.ShortName);
					var han = _dbContext.HandlingTypes.FirstOrDefault(h => h.HandlingTypeName == damageItemDTO.HandlingType);


					DamageItem damageItem = new DamageItem();
					damageItem.ItemId = (long)damageItemDTO.ItemId;
					damageItem.ItemName = damageItemDTO.ItemName;
					damageItem.WareHouseName = wh.WareHuoseId.ToString();
					damageItem.DistrictName = dis.AddDistrictId.ToString();
					damageItem.VendorName = ven.VendorId.ToString();
					damageItem.EmployeeName = emp.EmployeeId.ToString();
					damageItem.HandlingType = han.HandlingTypeId.ToString();
					damageItem.ShortName = unit.UnitId.ToString();
					//damageItem.UnitId = unit.UnitId;

					damageItem.CompanyName = damageItemDTO.CompanyName;
					damageItem.BrandName = damageItemDTO.BrandName;
					damageItem.ProductWeight = damageItemDTO.ProductWeight;
					//damageItem.UnitId = damageItemDTO.UnitId;
					damageItem.CaseWeight = damageItemDTO.CaseWeight;
					damageItem.UnitPerCase = damageItemDTO.UnitPerCase;
					damageItem.ManufactureDate = damageItemDTO.ManufactureDate;
					damageItem.ExpiryDate = damageItemDTO.ExpiryDate;
					damageItem.MRP = damageItemDTO.MRP;
					damageItem.PurchaseCost = damageItemDTO.PurchaseCost;
					damageItem.SalesCost = damageItemDTO.SalesCost;
					damageItem.SGST = damageItemDTO.SGST;
					damageItem.CGST = damageItemDTO.CGST;
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

					var wh = _dbContext.WareHouses.FirstOrDefault(wh => wh.WareHouseName == damageItemDTO.WareHouseName);
					var dis = _dbContext.AddDistricts.FirstOrDefault(di => di.DistrictName == damageItemDTO.DistrictName);
					var ven = _dbContext.Vendors.FirstOrDefault(v => v.VendorName == damageItemDTO.VendorName);
					var emp = _dbContext.Employees.FirstOrDefault(v => v.EmployeeName == damageItemDTO.EmployeeName);
					var unit = _dbContext.Units.FirstOrDefault(u => u.ShortName == damageItemDTO.ShortName);
					var han = _dbContext.HandlingTypes.FirstOrDefault(h => h.HandlingTypeName == damageItemDTO.HandlingType);

					a.WareHouseName = wh.WareHuoseId.ToString();
					a.DistrictName = dis.AddDistrictId.ToString();
					a.VendorName = ven.VendorId.ToString();
					a.EmployeeName = emp.EmployeeId.ToString();
					a.HandlingType = han.HandlingTypeId.ToString();
					a.ShortName = unit.UnitId.ToString();
					//a.UnitId = unit.UnitId;

					a.ItemName = damageItemDTO.ItemName;
					a.CompanyName = damageItemDTO.CompanyName;
					a.BrandName = damageItemDTO.BrandName;
					a.ProductWeight = damageItemDTO.ProductWeight;
					//a.UnitId = damageItemDTO.UnitId;
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

		//public List<DamageItem> GetDamageItemList()
		//{
		//	try
		//	{
		//		return _dbContext.DamageItems.Where(x => x.Deleted == false).ToList();
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//}


		public List<DamageItem> GetDamageItemList()
		{
			try
			{

				List<WareHuose> warehouses = _dbContext.WareHouses.Where(x => x.Deleted == false).ToList();
				List<AddDistrict> districts = _dbContext.AddDistricts.Where(x => x.Deleted == false).ToList();
				List<Employee> employees = _dbContext.Employees.Where(x => x.Deleted == false).ToList();
				List<Vendor> vendors = _dbContext.Vendors.Where(x => x.Deleted == false).ToList();
				List<HandlingType> handlingTypes = _dbContext.HandlingTypes.Where(h => h.Deleted == false).ToList();
				List<Unit> units = _dbContext.Units.Where(i => i.Deleted == false).ToList();

				List<DamageItem> damageItems = _dbContext.DamageItems.Where(d => d.Deleted == false).ToList();


				foreach (var item in damageItems)
				{
					HandlingType handlingType = handlingTypes.FirstOrDefault(h => h.HandlingTypeId == Convert.ToInt32(item.HandlingType));
					WareHuose wareHuose = warehouses.FirstOrDefault(h => h.WareHuoseId == Convert.ToInt32(item.WareHouseName));
					AddDistrict district = districts.FirstOrDefault(h => h.AddDistrictId == Convert.ToInt32(item.DistrictName));
					Vendor vendor = vendors.FirstOrDefault(h => h.VendorId == Convert.ToInt32(item.VendorName));
					Employee emp = employees.FirstOrDefault(h => h.EmployeeId == Convert.ToInt32(item.EmployeeName));
					Unit uni = units.FirstOrDefault(u => u.UnitId == Convert.ToInt32(item.ShortName));

					item.HandlingType = handlingType != null ? handlingType.HandlingTypeName : null;
					item.WareHouseName = wareHuose != null ? wareHuose.WareHouseName : null;
					item.DistrictName = district != null ? district.DistrictName : null;
					item.VendorName = vendor != null ? vendor.VendorName : null;
					item.EmployeeName = emp != null ? emp.EmployeeName : null;
					item.ShortName = uni != null ? uni.ShortName : null;
				}

				return damageItems;
			}
			catch
			{
				throw;
			}
		}

	}
}
