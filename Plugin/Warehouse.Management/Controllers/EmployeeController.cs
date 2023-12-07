using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Employees;
using CloudVOffice.Data.DTO.WareHouses.Employees;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.Employees;
using CloudVOffice.Services.WareHouses.Vehicles;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]
	public class EmployeeController : BasePluginController
	{
		private readonly IEmployeeService _employeeService;
		private readonly IWareHouseService _wareHouseService;
		private readonly ApplicationDBContext _dbContext;
		private readonly IVehicleService _vehicleService;
		public EmployeeController(IEmployeeService employeeService, ApplicationDBContext dbContext, IWareHouseService wareHouseService, IVehicleService vehicleService)
		{
			_employeeService = employeeService;
			_dbContext = dbContext;
			_wareHouseService = wareHouseService;
			_vehicleService = vehicleService;
		}

		[HttpGet]
		public IActionResult EmployeeCreate(int? employeeId)
		{
			ViewBag.WareHouses = _wareHouseService.GetWareHouseList();
			ViewBag.Vehicles = _vehicleService.GetVehicleList();


            EmployeeDTO employeeDTO = new EmployeeDTO();

			if (employeeId != null)   //this part is for Update, thats why we are sending code through "get" for display
									  //cause during Update only the employeeId will not be null
			{
				Employee employee = _employeeService.GetEmployeeById(int.Parse(employeeId.ToString()));

				employeeDTO.EmployeeName = employee.EmployeeName;
				employeeDTO.DateOfBirth = employee.DateOfBirth;
				employeeDTO.AssignedWareHouse = employee.AssignedWareHouse;
				employeeDTO.VehicleNumber = employee.VehicleNumber;
				employeeDTO.Position = employee.Position;
				employeeDTO.Mobile = employee.Mobile;
				employeeDTO.Priority = employee.Priority;
				employeeDTO.IsActive = employee.IsActive;
			}
			return View("~/Plugins/Warehouse.Management/Views/Employee/EmployeeCreate.cshtml", employeeDTO);
		}


		[HttpPost]
		public IActionResult EmployeeCreate(EmployeeDTO employeeDTO)
		{
			employeeDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			if(ModelState.IsValid)
			{
				if(employeeDTO.EmployeeId == null)   //during creation this will get true, as there will be no EmpId at creation
				{
					var a = _employeeService.EmployeeCreate(employeeDTO);
					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/Employee/EmployeeView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Employee Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _employeeService.EmployeeUpdate(employeeDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/Employee/EmployeeView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Employee Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}
            ViewBag.WareHouses = _wareHouseService.GetWareHouseList();
            ViewBag.Vehicles = _vehicleService.GetVehicleList();
            ViewBag.Employees = _employeeService.GetEmployees();
            return View("~/Plugins/Warehouse.Management/Views/Employee/EmployeeView.cshtml", employeeDTO);
		}

		[HttpGet]
		public IActionResult EmployeeView()
		{
			ViewBag.Employees = _employeeService.GetEmployees();

			return View("~/Plugins/Warehouse.Management/Views/Employee/EmployeeView.cshtml");
		}

		[HttpGet]
		public IActionResult DeleteEmployee(Int64 employeeId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _employeeService.EmployeeDelete(employeeId, DeletedBy);

			TempData["msg"] = a;
			return Redirect("/WareHouse/Employee/EmployeeView");

		}

	}
}
