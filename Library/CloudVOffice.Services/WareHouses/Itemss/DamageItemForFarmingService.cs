using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.WareHouses.Items;
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
          
			try
            {
				var ObjCheck = _dbContext.DamageItemForFarmings.Where(opt => opt.DamageItemForFarmingId == damageItemForFarmingDTO.DamageItemForFarmingId && opt.Deleted == false).FirstOrDefault();

				if (ObjCheck == null)
                {
                    DamageItemForFarming damageItemForFarming = new DamageItemForFarming();

                    damageItemForFarming.ItemMasterForFarmingId = damageItemForFarmingDTO.ItemMasterForFarmingId;
                    damageItemForFarming.WareHouseName = damageItemForFarmingDTO.WareHouseName;
                    damageItemForFarming.EmployeeName = damageItemForFarmingDTO.EmployeeName;
                    damageItemForFarming.VendorName = damageItemForFarmingDTO.VendorName;
                    damageItemForFarming.DistrictName = damageItemForFarmingDTO.DistrictName;
                    damageItemForFarming.UnitId = damageItemForFarmingDTO.UnitId;
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
				var damageproduct = _dbContext.DamageItemForFarmings.Where(x => x.DamageItemForFarmingId != damageItemForFarmingDTO.DamageItemForFarmingId && x.ItemMasterForFarmingId==damageItemForFarmingDTO.ItemMasterForFarmingId && x.Deleted == false).FirstOrDefault();
				
                if (damageproduct == null)
				{
					var a = _dbContext.DamageItemForFarmings.FirstOrDefault(x => x.DamageItemForFarmingId == damageItemForFarmingDTO.DamageItemForFarmingId);
					if (a != null)
					{
						a.ItemMasterForFarmingId = damageItemForFarmingDTO.ItemMasterForFarmingId;
						a.WareHouseName = damageItemForFarmingDTO.WareHouseName;
						a.EmployeeName = damageItemForFarmingDTO.EmployeeName;
						a.VendorName = damageItemForFarmingDTO.VendorName;
						a.DistrictName = damageItemForFarmingDTO.DistrictName;
						a.UnitId = damageItemForFarmingDTO.UnitId;
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
        public List<DamageItemForFarming> GetDamageItemForFarmingList()
        {
            try
            {
                return _dbContext.DamageItemForFarmings.Where(x => x.Deleted == false).ToList();
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
