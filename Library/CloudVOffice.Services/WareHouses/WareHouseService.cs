using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.WareHouses
{
    public class WareHouseService : IWareHouseService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<WareHuose> _wareHouseRepo;
        public WareHouseService(ApplicationDBContext dbContext, ISqlRepository<WareHuose> WareHouseRepo)
        {
            _dbContext = dbContext;
            _wareHouseRepo = WareHouseRepo;
        }

        public MessageEnum WareHouseCreate(WareHouseDTO wareHousesDTO)
        {
            try
            {
                var ware = _dbContext.WareHouses.Where(w => w.WareHuoseId == wareHousesDTO.WareHuoseId && w.Deleted == false).FirstOrDefault();
                if (ware == null)
                {
                    WareHuose wareHouse = new WareHuose();
                    Random random = new Random();

                    wareHouse.Address = wareHousesDTO.Address;
                    wareHouse.WareHouseName = wareHousesDTO.WareHouseName;
                    wareHouse.Area = wareHousesDTO.Area;
                    wareHouse.GSTNumber = wareHousesDTO.GSTNumber;
                    wareHouse.Mobile = wareHousesDTO.Mobile;
                    wareHouse.Telephone = wareHousesDTO.Telephone;
                    wareHouse.IsActive = wareHousesDTO.IsActive;
                    wareHouse.StateId = wareHousesDTO.StateId;					
					wareHouse.AssignmentCode = "WH" + GenerateRandomNumber(100000, 999999).ToString();
					wareHouse.CreatedBy = wareHousesDTO.CreatedBy;

                    var obj = _wareHouseRepo.Insert(wareHouse);
                    _dbContext.SaveChanges();

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

		private int GenerateRandomNumber(int minValue, int maxValue)
		{
			Random random = new Random();
			return random.Next(minValue, maxValue + 1);
		}


		public WareHuose GetWareHousebyWareHuoseId(Int64 WareHuoseId)
        {
            try
            {
                var ware = _dbContext.WareHouses.FirstOrDefault(wa => wa.WareHuoseId == WareHuoseId);
                return ware;
            }
            catch
            {
                throw;
            }
        }

        public List<WareHuose> GetWareHouseList()
        {
            try
            {
                var warehouses = _dbContext.WareHouses.Where(x => x.Deleted == false).ToList();
                return warehouses;
            }
            catch
            {
                throw;
            }
        }

        public MessageEnum WareHouseUpdate(WareHouseDTO wareHouseDTO)
        {
            try
            {
                var ware = _dbContext.WareHouses.Where(w => w.WareHuoseId != wareHouseDTO.WareHuoseId && w.WareHouseName == wareHouseDTO.WareHouseName && w.Deleted == false).FirstOrDefault();

                if (ware == null)
                {
                    var warehouse = _dbContext.WareHouses.FirstOrDefault(x => x.WareHuoseId == wareHouseDTO.WareHuoseId);

                    if (warehouse != null)
                    {
                        warehouse.Area = wareHouseDTO.Area;
                        warehouse.WareHouseName = wareHouseDTO.WareHouseName;
                        warehouse.Address = wareHouseDTO.Address;
                        warehouse.Telephone = wareHouseDTO.Telephone;
                        warehouse.Mobile = wareHouseDTO.Mobile;
                        warehouse.IsActive = wareHouseDTO.IsActive;
                        warehouse.StateId = wareHouseDTO.StateId;
                        warehouse.UpdatedDate = DateTime.Now;

                        _wareHouseRepo.Update(warehouse);
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

        public MessageEnum WareHouseDelete(Int64 WareHuoseId, Int64 DeletedBy)
        {
            try
            {
                var warehouse = _dbContext.WareHouses.Where(x => x.WareHuoseId == WareHuoseId).FirstOrDefault();
                if (warehouse != null)
                {
                    warehouse.Deleted = true;
                    warehouse.UpdatedBy = DeletedBy;
                    warehouse.UpdatedDate = DateTime.Now;
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

        public Int64 GetWareHouseByPOPUniqueNumber(string PopUniqueNumber)
        {
            var a = _dbContext.PurchaseOrderParents.Where(a => a.POPUniqueNumber == PopUniqueNumber && a.Deleted == false).FirstOrDefault();

            return a.WareHuoseId;
        }

    }
}
