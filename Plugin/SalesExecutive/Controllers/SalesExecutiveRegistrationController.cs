using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Services.Sales;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesExecutive.Controllers
{
    [Area(AreaNames.SalesExecutive)]
    public class SalesExecutiveRegistrationController : BaseController
    {
        private readonly ISalesExecutiveRegistrationService _salesExecutiveRegistrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IWareHouseService _wareHouseService;

        public SalesExecutiveRegistrationController(
                                                   ISalesExecutiveRegistrationService salesExecutiveRegistrationService,
                                                   IWareHouseService wareHouseService,
                                                   IWebHostEnvironment hostingEnvironment
                                                   )
        {
            _salesExecutiveRegistrationService = salesExecutiveRegistrationService;
            _wareHouseService = wareHouseService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult SalesExecutiveRegistrationCreate(Int64? SalesExecutiveRegistrationId)
        {
            ViewBag.WarehouseList = _wareHouseService.GetWareHouseList();

            SalesExecutiveRegistrationDTO salesExecutiveRegistrationDTO = new SalesExecutiveRegistrationDTO();

            if (SalesExecutiveRegistrationId != null)
            {
                SalesExecutiveRegistration d = _salesExecutiveRegistrationService.GetSalesExecutiveRegistrationsById(int.Parse(SalesExecutiveRegistrationId.ToString()));

                salesExecutiveRegistrationDTO.SalesExecutiveName = d.SalesExecutiveName;
                salesExecutiveRegistrationDTO.PANCardNumber = d.PANCardNumber;
                salesExecutiveRegistrationDTO.AadharCardNumber = d.AadharCardNumber;
                salesExecutiveRegistrationDTO.WareHuoseId = d.WareHuoseId;
                salesExecutiveRegistrationDTO.PrimaryPhone = d.PrimaryPhone;
                salesExecutiveRegistrationDTO.AlternatePhone = d.AlternatePhone;
                salesExecutiveRegistrationDTO.MailId = d.MailId;
                salesExecutiveRegistrationDTO.Password = d.Password;
                salesExecutiveRegistrationDTO.Address = d.Address;
                salesExecutiveRegistrationDTO.Image = d.Image;
               
            }
            return View("~/Plugins/SalesExecutive/Views/SalesExecutiveRegistrations/SalesExecutiveRegistrationCreate.cshtml", salesExecutiveRegistrationDTO);
        }

        [HttpPost]
        public IActionResult SalesExecutiveRegistrationCreate(SalesExecutiveRegistrationDTO salesExecutiveRegistrationDTO)
        {
            salesExecutiveRegistrationDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (salesExecutiveRegistrationDTO.ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(salesExecutiveRegistrationDTO.ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/SalesExec");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    salesExecutiveRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    salesExecutiveRegistrationDTO.Image = uniqueFileName;
                }
                if (salesExecutiveRegistrationDTO.SalesExecutiveRegistrationId == null)
                {
                    var a = _salesExecutiveRegistrationService.CreateSalesExecutive(salesExecutiveRegistrationDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SalesExecutive/SalesExecutiveRegistration/SalesExecutiveRegistrationView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "SalesExecutive Mobile Number Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _salesExecutiveRegistrationService.UpdateSalesExecutive(salesExecutiveRegistrationDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SalesExecutive/SalesExecutiveRegistration/SalesExecutiveRegistrationView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "SalesExecutive Mobile Number Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

			ViewBag.WarehouseList = _wareHouseService.GetWareHouseList();

			return View("~/Plugins/SalesExecutive/Views/SalesExecutiveRegistrations/SalesExecutiveRegistrationCreate.cshtml", salesExecutiveRegistrationDTO);

        }

        public IActionResult SalesExecutiveRegistrationView()
        {
            ViewBag.SalesExecutives = _salesExecutiveRegistrationService.GetAllSalesExecutiveRegistrations();

            return View("~/Plugins/SalesExecutive/Views/SalesExecutiveRegistrations/SalesExecutiveRegistrationView.cshtml");

        }

        [HttpGet]
        public IActionResult SalesExecutiveRegistrationDelete(Int64 SalesExecutiveRegistrationId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _salesExecutiveRegistrationService.SalesExecutiveRegistrationDelete(SalesExecutiveRegistrationId, DeletedBy);
            return Redirect("/SalesExecutive/SalesExecutiveRegistration/SalesExecutiveRegistrationView");
        }
    }
}
