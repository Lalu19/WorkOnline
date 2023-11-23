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
                    WareHuose wareHouses = new WareHuose();

                    wareHouses.WarehouseName = wareHousesDTO.WarehouseName;
                    //wareHouses.PinCodeId = wareHousesDTO.PinCodeId;
                    wareHouses.IsActive = wareHousesDTO.IsActive;
                    wareHouses.CreatedBy = wareHousesDTO.CreatedBy;
                    var obj = _wareHouseRepo.Insert(wareHouses);
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
                var warehouses = _dbContext.WareHouses.Where(x => x.IsActive == true).ToList();
                return warehouses;
            }
            catch
            {
                throw;
            }
        }

        public MessageEnum WareHouseUpdate(WareHouseDTO wareHousesDTO)
        {
            try
            {
                var ware = _dbContext.WareHouses.Where(w => w.WareHuoseId != wareHousesDTO.WareHuoseId && w.WarehouseName == wareHousesDTO.WarehouseName && w.Deleted == false).FirstOrDefault();

                if (ware == null)
                {
                    var warehouse = _dbContext.WareHouses.FirstOrDefault(x => x.WareHuoseId == wareHousesDTO.WareHuoseId);

                    if (warehouse != null)
                    {
                        warehouse.WarehouseName = wareHousesDTO.WarehouseName;
                        //warehouse.PinCodeId = wareHousesDTO.PinCodeId;
                        warehouse.IsActive = warehouse.IsActive;
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

                    return MessageEnum.Deleted;
                }
                else { return MessageEnum.Invalid; }
            }
            catch
            {
                throw;
            }
        }
    }
}
