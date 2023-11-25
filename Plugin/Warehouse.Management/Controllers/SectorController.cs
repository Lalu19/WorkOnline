using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pipelines.Sockets.Unofficial.SocketConnection;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class SectorController : BasePluginController
    {
        private readonly ISectorService _sectorService;
        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }
        [HttpGet]
        public IActionResult SectorCreate(int? SectorId)
        {
            SectorDTO sectorDTO = new SectorDTO();
            if (SectorId != null)
            {

                Sector d = _sectorService.GetSectorById(int.Parse(SectorId.ToString()));

                sectorDTO.SectorName = d.SectorName;
            }
            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SectorCreate.cshtml", sectorDTO);
        }

        [HttpPost]
        public IActionResult SectorCreate(SectorDTO sectorDTO)
        {
            sectorDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (sectorDTO.SectorId == null)
                {
                    var a = _sectorService.SectorCreate(sectorDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/Sector/SectorView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Sector Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _sectorService.SectorUpdate(sectorDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/Sector/SectorView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Sector Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SectorCreate.cshtml", sectorDTO);

        }

        public IActionResult SectorView()
        {
            ViewBag.Sectors = _sectorService.GetSectorList();

            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SectorView.cshtml");
        }

        [HttpGet]
        public IActionResult SectorDelete(int SectorId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _sectorService.DeleteSector(SectorId, DeletedBy);
            return Redirect("/WareHouse/Sector/SectorView");
        }
    }
}
