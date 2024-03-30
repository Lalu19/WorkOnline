using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Data.DTO.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Services.Distributors;
using CloudVOffice.Services.WareHouses.SalesOrders;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class WareHouseSalesOrderController : BasePluginController
    {
        private readonly IWarehouseSalesOrderParentService _warehouseSalesOrderParentService;
        private readonly IWareHouseSalesOrderItemService _wareHouseSalesOrderItemService;
        private readonly IDPOService _dPOService;
        private readonly IDPOItemsService _dPOItemsService;

        public WareHouseSalesOrderController(IWarehouseSalesOrderParentService warehouseSalesOrderParentService, IWareHouseSalesOrderItemService wareHouseSalesOrderItemService, IDPOService dPOService, IDPOItemsService dPOItemsService)
        {
            _warehouseSalesOrderParentService = warehouseSalesOrderParentService;
            _wareHouseSalesOrderItemService = wareHouseSalesOrderItemService;
            _dPOService = dPOService;
            _dPOItemsService = dPOItemsService;
        }


        [HttpGet]
        public IActionResult CreateWareHouseSalesOrder()
        {
            //Int64 createdBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            ViewBag.DpoList = _dPOService.GetAllDPOList();

            return View("~/Plugins/Warehouse.Management/Views/SalesOrders/WareHouseSalesOrderCreate.cshtml");
        }



        [HttpPost]
        public IActionResult CreateWareHouseSalesOrder([FromBody] WareHouseSalesOrderMasterDTO wareHouseSalesOrderMasterDTO)
        {
            Int64 createdBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


            wareHouseSalesOrderMasterDTO.Parent.CreatedBy = createdBy;
            //wareHouseSalesOrderMasterDTO.Parent.DPOUniqueNo

            var obj = _warehouseSalesOrderParentService.CreateWarehouseSalesOrderParent(wareHouseSalesOrderMasterDTO.Parent);

            var result  = _wareHouseSalesOrderItemService.CreateWareHouseSalesOrderItem(obj.WarehouseSalesOrderParentId, createdBy, wareHouseSalesOrderMasterDTO.Itemss);

            if (result == MessageEnum.Success)
            {
                TempData["msg"] = MessageEnum.Success;
                return Redirect("/WareHouse/Month/MonthView");
            }
            else if (result == MessageEnum.Duplicate)
            {
                TempData["msg"] = MessageEnum.Duplicate;
                ModelState.AddModelError("", "Order Already Exists");
            }
            else
            {
                TempData["msg"] = MessageEnum.UnExpectedError;
                ModelState.AddModelError("", "Un-Expected Error");
            }


            return View();
        }



        public List<DPO> GetDPOItemsByParentId(int parentId)
        {
            var a = _dPOService.GetAllDPOListbyParentId(parentId);
            return a;
        }

    }
}
