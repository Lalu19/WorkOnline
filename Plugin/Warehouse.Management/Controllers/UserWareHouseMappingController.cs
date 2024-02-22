using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Data.DTO.Users;
using CloudVOffice.Data.DTO.WareHouses.Vendors;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.Users;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Services.WareHouses.Vendors;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class UserWareHouseMappingController : BasePluginController
    {
        
        private readonly ApplicationDBContext _dbContext;
        private readonly IUserWareHouseMappingService _UserWareHouseMappingService;
        private readonly IWareHouseService _WareHouseService;
        private readonly IUserService _UserService;

        public UserWareHouseMappingController(IUserWareHouseMappingService UserWareHouseMappingService,
            ApplicationDBContext dbContext, IWareHouseService WareHouseService, IUserService userService)
        {
            _UserWareHouseMappingService = UserWareHouseMappingService;
            _dbContext = dbContext;
            _WareHouseService = WareHouseService;
            _UserService = userService;
        }
        [HttpGet]
        public IActionResult UserWareHouseMappingCreate(int? UserWareHouseMappingId)
        {
            UserWareHouseMappingDTO UserWareHouseMappingDTO = new UserWareHouseMappingDTO();

            ViewBag.wareHouseList = _WareHouseService.GetWareHouseList();
            ViewBag.User = _UserService.GetAllUsers();

            if (UserWareHouseMappingId != null)
            {

                UserWareHouseMapping i = _UserWareHouseMappingService.UserWareHouseMappingById(int.Parse(UserWareHouseMappingId.ToString()));

                UserWareHouseMappingDTO.WareHuoseId = i.WareHuoseId;
                UserWareHouseMappingDTO.UserId = i.UserId;
            }
            return View("~/Plugins/Warehouse.Management/Views/UserWareHouse/UserWareHouseMappingCreate.cshtml", UserWareHouseMappingDTO);
        }
        [HttpPost]
        public IActionResult UserWareHouseMappingCreate(UserWareHouseMappingDTO UserWareHouseMappingDTO)
        {
            UserWareHouseMappingDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
            
            if (ModelState.IsValid)
            {
                if (UserWareHouseMappingDTO.UserWareHouseMappingId == null)
                {
                    var a = _UserWareHouseMappingService.UserWareHouseMappingCreate(UserWareHouseMappingDTO);
                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/UserWareHouseMapping/UserWareHouseMappingView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Mapping Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _UserWareHouseMappingService.UserWareHouseMappingUpdate(UserWareHouseMappingDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/UserWareHouseMapping/UserWareHouseMappingView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Mapping Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/Warehouse.Management/Views/UserWareHouse/UserWareHouseMappingCreate.cshtml", UserWareHouseMappingDTO);
        }

        public IActionResult UserWareHouseMappingView()
        {
            ViewBag.UserWareHousemappinglist = _UserWareHouseMappingService.UserWareHouseMappingList();

            return View("~/Plugins/Warehouse.Management/Views/UserWareHouse/UserWareHouseMappingView.cshtml");
        }


        [HttpGet]
        public IActionResult DeleteUserWareHouseMapping(int UserWareHouseMappingId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _UserWareHouseMappingService.UserWareHouseMappingDelete(UserWareHouseMappingId, DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/UserWareHouseMapping/UserWareHouseMappingView");
        }
    }
}
