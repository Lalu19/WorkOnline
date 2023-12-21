using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Vehicles;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Vehicles;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Vehicle> _vehicleRepo;
        public VehicleService(ApplicationDBContext dbContext, ISqlRepository<Vehicle> vehicleRepo)
        {
            _dbContext = dbContext;
            _vehicleRepo = vehicleRepo;
        }

        public MessageEnum VehicleCreate(VehicleDTO vehicleDTO)
        {
            try
            {
                var vehicleNo = _dbContext.Vehicles.Where(x => x.VehicleNumber == vehicleDTO.VehicleNumber && x.Deleted == false).FirstOrDefault();
                if (vehicleNo == null)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleName = vehicleDTO.VehicleName;
                    vehicle.VehicleNumber = vehicleDTO.VehicleNumber;
                    vehicle.BrandName = vehicleDTO.BrandName;
                    vehicle.ChasisNo = vehicleDTO.ChasisNo;
                    vehicle.FuelType = vehicleDTO.FuelType;
                    vehicle.DL = vehicleDTO.DL;
                    vehicle.RC = vehicleDTO.RC;
                    vehicle.InsuranceDetails = vehicleDTO.InsuranceDetails;
                    vehicle.PurchaseYear = vehicleDTO.PurchaseYear;
                    vehicle.CreatedBy = vehicleDTO.CreatedBy;
                    var obj = _vehicleRepo.Insert(vehicle);

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
        public MessageEnum VehicleUpdate(VehicleDTO vehicleDTO)
        {
            try
            {
                var pin = _dbContext.Vehicles.Where(x => x.VehicleId != vehicleDTO.VehicleId && x.VehicleNumber == vehicleDTO.VehicleNumber && x.Deleted == false).FirstOrDefault();
                if (pin == null)
                {
                    var a = _dbContext.Vehicles.Where(x => x.VehicleId == vehicleDTO.VehicleId).FirstOrDefault();
                    if (a != null)
                    {
                        a.VehicleName = vehicleDTO.VehicleName;
                        a.VehicleNumber = vehicleDTO.VehicleNumber;
                        a.BrandName = vehicleDTO.BrandName;
                        a.ChasisNo = vehicleDTO.ChasisNo;
                        a.FuelType = vehicleDTO.FuelType;
                        a.DL = vehicleDTO.DL;
                        a.RC = vehicleDTO.RC;
                        a.InsuranceDetails = vehicleDTO.InsuranceDetails;
                        a.PurchaseYear = vehicleDTO.PurchaseYear;
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
        public Vehicle GetVehicleByVehicleId(Int64 vehicleId)
        {
            try
            {
                return _dbContext.Vehicles.Where(x => x.VehicleId == vehicleId && x.Deleted == false).SingleOrDefault();

            }
            catch
            {
                throw;
            }
        }
        public List<Vehicle> GetVehicleList()
        {
            try
            {
                return _dbContext.Vehicles.Where(x => x.Deleted == false).ToList();
            }
            catch
            {
                throw;
            }
        }
        public MessageEnum VehicleDelete(Int64 vehicleId, long DeletedBy)
        {
            try
            {
                var a = _dbContext.Vehicles.Where(x => x.VehicleId == vehicleId).FirstOrDefault();
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
