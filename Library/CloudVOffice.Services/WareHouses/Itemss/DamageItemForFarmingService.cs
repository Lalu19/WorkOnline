using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Data.DTO.WareHouses.Vehicles;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.WareHouses.Itemss
{
	public class DamageItemForFarmingService : IDamageItemForFarmingService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<DamageItemForFarming> _damageItemForFarmingRepo;
		public DamageItemForFarmingService(ApplicationDBContext dbContext, ISqlRepository<DamageItemForFarming> damageItemForFarmingRepo)
		{

			_dbContext = dbContext;
			_damageItemForFarmingRepo = damageItemForFarmingRepo;
		}
		public MessageEnum DamageItemForFarmingCreate(DamageItemForFarmingDTO damageItemForFarmingDTO)
		{
			var ObjCheck = _dbContext.DamageItemForFarmings.Where(opt => opt.DamageItemForFarmingId == damageItemForFarmingDTO.DamageItemForFarmingId && opt.Deleted == false).FirstOrDefault();
			try
			{

				if (ObjCheck == null)
				{

					var wh = _dbContext.WareHouses.FirstOrDefault(wh => wh.WareHouseName == damageItemForFarmingDTO.WareHouseName);
					var dis = _dbContext.AddDistricts.FirstOrDefault(di => di.DistrictName == damageItemForFarmingDTO.DistrictName);
					var ven = _dbContext.Vendors.FirstOrDefault(v => v.VendorName == damageItemForFarmingDTO.VendorName);
					var emp = _dbContext.Employees.FirstOrDefault(v => v.EmployeeName == damageItemForFarmingDTO.EmployeeName);
					var unit = _dbContext.Units.FirstOrDefault(u => u.ShortName == damageItemForFarmingDTO.ShortName);


					DamageItemForFarming damageItemForFarming = new DamageItemForFarming();

					damageItemForFarming.ItemMasterForFarmingId = damageItemForFarmingDTO.ItemMasterForFarmingId;

					//damageItemForFarming.WareHouseName = damageItemForFarmingDTO.WareHouseName;
					//damageItemForFarming.EmployeeName = damageItemForFarmingDTO.EmployeeName;
					//damageItemForFarming.VendorName = damageItemForFarmingDTO.VendorName;
					//damageItemForFarming.DistrictName = damageItemForFarmingDTO.DistrictName;
					//damageItemForFarming.UnitId = damageItemForFarmingDTO.UnitId;

					damageItemForFarming.WareHouseName = wh.WareHuoseId.ToString();
					damageItemForFarming.DistrictName = dis.AddDistrictId.ToString();
					damageItemForFarming.VendorName = ven.VendorId.ToString();
					damageItemForFarming.EmployeeName = emp.EmployeeId.ToString();
					damageItemForFarming.ShortName = unit.UnitId.ToString();


					damageItemForFarming.ProductName = damageItemForFarmingDTO.ProductName;
					damageItemForFarming.QtyPerKg = damageItemForFarmingDTO.QtyPerKg;
					damageItemForFarming.Price = damageItemForFarmingDTO.Price;
					damageItemForFarming.MinQty = damageItemForFarmingDTO.MinQty;
					damageItemForFarming.GST = damageItemForFarmingDTO.GST;
					damageItemForFarming.HSN = damageItemForFarmingDTO.HSN;
					damageItemForFarming.HarvestDate = damageItemForFarmingDTO.HarvestDate;
					damageItemForFarming.Reason = damageItemForFarmingDTO.Reason;
					damageItemForFarming.DamagePic = damageItemForFarmingDTO.DamagePic;
					damageItemForFarming.DamageUnits = damageItemForFarmingDTO.DamageUnits;
					damageItemForFarming.InvoiceNo = damageItemForFarmingDTO.InvoiceNo;
					damageItemForFarming.ReceivedDate = damageItemForFarmingDTO.ReceivedDate;
					damageItemForFarming.CreatedBy = damageItemForFarmingDTO.CreatedBy;

					var obj = _damageItemForFarmingRepo.Insert(damageItemForFarming);

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
		public MessageEnum DamageItemForFarmingUpdate(DamageItemForFarmingDTO damageItemForFarmingDTO)
		{
			try
			{
				//var damageproduct = _dbContext.DamageItemForFarmings.Where(x => x.DamageItemForFarmingId != damageItemForFarmingDTO.DamageItemForFarmingId && x.ItemMasterForFarmingId==damageItemForFarmingDTO.ItemMasterForFarmingId && x.Deleted == false).FirstOrDefault();
				var a = _dbContext.DamageItemForFarmings.Where(x => x.DamageItemForFarmingId == damageItemForFarmingDTO.DamageItemForFarmingId).FirstOrDefault();

				if (a != null)
				{

					//a.ItemMasterForFarmingId = damageItemForFarmingDTO.ItemMasterForFarmingId;
					//a.WareHouseName = damageItemForFarmingDTO.WareHouseName;
					//a.EmployeeName = damageItemForFarmingDTO.EmployeeName;
					//a.VendorName = damageItemForFarmingDTO.VendorName;
					//a.DistrictName = damageItemForFarmingDTO.DistrictName;
					//a.UnitId = damageItemForFarmingDTO.UnitId;

					var wh = _dbContext.WareHouses.FirstOrDefault(wh => wh.WareHouseName == damageItemForFarmingDTO.WareHouseName);
					var dis = _dbContext.AddDistricts.FirstOrDefault(di => di.DistrictName == damageItemForFarmingDTO.DistrictName);
					var ven = _dbContext.Vendors.FirstOrDefault(v => v.VendorName == damageItemForFarmingDTO.VendorName);
					var emp = _dbContext.Employees.FirstOrDefault(v => v.EmployeeName == damageItemForFarmingDTO.EmployeeName);
					var unit = _dbContext.Units.FirstOrDefault(u => u.ShortName == damageItemForFarmingDTO.ShortName);

					a.WareHouseName = wh.WareHuoseId.ToString();
					a.DistrictName = dis.AddDistrictId.ToString();
					a.VendorName = ven.VendorId.ToString();
					a.EmployeeName = emp.EmployeeId.ToString();
					a.ShortName = unit.UnitId.ToString();


					a.ProductName = damageItemForFarmingDTO.ProductName;
					a.QtyPerKg = damageItemForFarmingDTO.QtyPerKg;
					a.Price = damageItemForFarmingDTO.Price;
					a.MinQty = damageItemForFarmingDTO.MinQty;
					a.GST = damageItemForFarmingDTO.GST;
					a.HSN = damageItemForFarmingDTO.HSN;
					a.HarvestDate = damageItemForFarmingDTO.HarvestDate;
					a.Reason = damageItemForFarmingDTO.Reason;
					a.DamagePic = damageItemForFarmingDTO.DamagePic;
					a.DamageUnits = damageItemForFarmingDTO.DamageUnits;
					a.InvoiceNo = damageItemForFarmingDTO.InvoiceNo;
					a.ReceivedDate = damageItemForFarmingDTO.ReceivedDate;
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
		//public List<DamageItemForFarming> GetDamageItemForFarmingList()
		//{
		//	try
		//	{
		//		return _dbContext.DamageItemForFarmings.Where(x => x.Deleted == false).ToList();
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//}




		public List<DamageItemForFarming> GetDamageItemForFarmingList()
		{
			try
			{
				List<WareHuose> warehouses = _dbContext.WareHouses.Where(x => x.Deleted == false).ToList();
				List<AddDistrict> districts = _dbContext.AddDistricts.Where(x => x.Deleted == false).ToList();
				List<Employee> employees = _dbContext.Employees.Where(x => x.Deleted == false).ToList();
				List<Vendor> vendors = _dbContext.Vendors.Where(x => x.Deleted == false).ToList();
				List<Unit> units = _dbContext.Units.Where(i => i.Deleted == false).ToList();

				List<DamageItemForFarming> damageFarmingItems = _dbContext.DamageItemForFarmings.Where(d => d.Deleted == false).ToList();

				foreach (var item in damageFarmingItems)
				{
					WareHuose wareHuose = warehouses.FirstOrDefault(h => h.WareHuoseId == Convert.ToInt32(item.WareHouseName));
					AddDistrict district = districts.FirstOrDefault(h => h.AddDistrictId == Convert.ToInt32(item.DistrictName));
					Vendor vendor = vendors.FirstOrDefault(h => h.VendorId == Convert.ToInt32(item.VendorName));
					Employee emp = employees.FirstOrDefault(h => h.EmployeeId == Convert.ToInt32(item.EmployeeName));
					Unit uni = units.FirstOrDefault(u => u.UnitId == Convert.ToInt32(item.ShortName));

					item.WareHouseName = wareHuose != null ? wareHuose.WareHouseName : null;
					item.DistrictName = district != null ? district.DistrictName : null;
					item.VendorName = vendor != null ? vendor.VendorName : null;
					item.EmployeeName = emp != null ? emp.EmployeeName : null;
					item.ShortName = uni != null ? uni.ShortName : null;
				}

				return damageFarmingItems;
			}
			catch
			{
				throw;
			}
		}



		public DamageItemForFarming GetDamageItemForFarmingById(Int64 damageItemForFarmingId)
		{
			try
			{
				return _dbContext.DamageItemForFarmings.Where(x => x.DamageItemForFarmingId == damageItemForFarmingId && x.Deleted == false).SingleOrDefault();

			}
			catch
			{
				throw;
			}
		}
		public MessageEnum DamageItemForFarmingDelete(Int64 damageItemForFarmingId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.DamageItemForFarmings.Where(x => x.DamageItemForFarmingId == damageItemForFarmingId).FirstOrDefault();
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

	}
}
