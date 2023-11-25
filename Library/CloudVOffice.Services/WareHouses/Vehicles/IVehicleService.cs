using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Vehicles;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Vehicles
{
    public interface IVehicleService
    {
        public MessageEnum VehicleCreate(VehicleDTO vehicleDTO);
        public Vehicle GetVehicleByVehicleId(Int64 vehicleId);
        public List<Vehicle> GetVehicleList();
        public MessageEnum VehicleUpdate(VehicleDTO vehicleDTO);
        public MessageEnum VehicleDelete(Int64 pinCodeId, Int64 DeletedBy);
    }
}
