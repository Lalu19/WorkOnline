using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Vehicles;
using CloudVOffice.Data.DTO.WareHouses.Vehicles;
using CloudVOffice.Services.WareHouses.Vehicles;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class VehicleController : BasePluginController
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        [HttpGet]
        public IActionResult VehicleCreate(int? vehicleId)
        {
            VehicleDTO vehicleDTO = new VehicleDTO();
            if (vehicleId != null)
            {

                Vehicle d = _vehicleService.GetVehicleByVehicleId(int.Parse(vehicleId.ToString()));
                vehicleDTO.VehicleName = d.VehicleName;
                vehicleDTO.VehicleNumber = d.VehicleNumber;
                vehicleDTO.BrandName = d.BrandName;
                vehicleDTO.ChasisNo = d.ChasisNo;
                vehicleDTO.FuelType = d.FuelType;
                vehicleDTO.NoC = d.NoC;
                vehicleDTO.RC = d.RC;
                vehicleDTO.InsuranceDetails = d.InsuranceDetails;
                vehicleDTO.PurchaseYear = d.PurchaseYear;
            }

            return View("~/Plugins/Warehouse.Management/Views/Vehicle/VehicleCreate.cshtml", vehicleDTO);

        }

        [HttpPost]
        public IActionResult VehicleCreate(VehicleDTO vehicleDTO)
        {
            vehicleDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


            if (ModelState.IsValid)
            {
                if (vehicleDTO.VehicleId == null)
                {
                    var a = _vehicleService.VehicleCreate(vehicleDTO);
                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/Vehicle/VehicleView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Vehicle Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _vehicleService.VehicleUpdate(vehicleDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/Vehicle/VehicleView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Vehicle Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }
            return View("~/Plugins/Warehouse.Management/Views/Vehicle/VehicleCreate.cshtml", vehicleDTO);
        }


        public IActionResult VehicleView()
        {
            ViewBag.vehicles = _vehicleService.GetVehicleList();

            return View("~/Plugins/Warehouse.Management/Views/Vehicle/VehicleView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteVehicle(Int64 vehicleId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _vehicleService.VehicleDelete(vehicleId, DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/Vehicle/VehicleView");
        }
    }
}
