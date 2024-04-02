using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Data.DTO.Buyers;
using CloudVOffice.Data.DTO.DeliveryPartners;
using CloudVOffice.Services.Banners;
using CloudVOffice.Services.DeliveryPartners;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;

namespace Web.API.Controllers.DeliveryPartners
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeliveryPartnerController : Controller
    {

        private readonly IDeliveryPartnerService _deliveryPartnerService;
        private readonly IDATasksWarehouseService _dATasksWarehouseService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IWareHouseDAAcceptService _wareHouseDAAcceptService;
        public DeliveryPartnerController(IDeliveryPartnerService deliveryPartnerService, IWebHostEnvironment hostingEnvironment, IDATasksWarehouseService dATasksWarehouseService, IWareHouseDAAcceptService wareHouseDAAcceptService)
        {
            _deliveryPartnerService = deliveryPartnerService;
            _hostingEnvironment = hostingEnvironment;
            _dATasksWarehouseService = dATasksWarehouseService;
            _wareHouseDAAcceptService = wareHouseDAAcceptService;
        }

        [HttpPost]
        public IActionResult DeliveryPartnerCreate([FromForm] DeliveryPartnerDTO deliveryPartnerDTO)
        {
            try
            {
                if (deliveryPartnerDTO.OwnerPhotoUp != null)
                {
                    FileInfo fileInfo = new FileInfo(deliveryPartnerDTO.OwnerPhotoUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(deliveryPartnerDTO.OwnerPhotoUp.FileName);

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\DeliveryPartners");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Copy the uploaded image to the specified path
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        deliveryPartnerDTO.OwnerPhotoUp.CopyTo(stream);
                    }

                    deliveryPartnerDTO.OwnerPhoto = filename;
                }

                if (deliveryPartnerDTO.DriverPhotoUp != null)
                {
                    FileInfo fileInfo = new FileInfo(deliveryPartnerDTO.DriverPhotoUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(deliveryPartnerDTO.DriverPhotoUp.FileName);

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\DeliveryPartners");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Copy the uploaded image to the specified path
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        deliveryPartnerDTO.DriverPhotoUp.CopyTo(stream);
                    }

                    deliveryPartnerDTO.DriverPhoto = filename;
                }


                if (deliveryPartnerDTO.VehicleFrontPhotoUp != null)
                {
                    FileInfo fileInfo = new FileInfo(deliveryPartnerDTO.VehicleFrontPhotoUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(deliveryPartnerDTO.VehicleFrontPhotoUp.FileName);

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\DeliveryPartners");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Copy the uploaded image to the specified path
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        deliveryPartnerDTO.VehicleFrontPhotoUp.CopyTo(stream);
                    }

                    deliveryPartnerDTO.VehicleFrontPhoto = filename;
                }

                if (deliveryPartnerDTO.VehicleBackPhotoUp != null)
                {
                    FileInfo fileInfo = new FileInfo(deliveryPartnerDTO.VehicleBackPhotoUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(deliveryPartnerDTO.VehicleBackPhotoUp.FileName);

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\DeliveryPartners");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Copy the uploaded image to the specified path
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        deliveryPartnerDTO.VehicleBackPhotoUp.CopyTo(stream);
                    }

                    deliveryPartnerDTO.VehicleBackPhoto = filename;
                }


                var a = _deliveryPartnerService.CreateDeliveryPartner(deliveryPartnerDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult DeliveryPartnerList()
        {
            var a = _deliveryPartnerService.GetDeliveryPartnerList();
            return Ok(a);
        }

        [HttpGet("{deliveryPartnerId}")]
        public IActionResult SingleDeliveryPartnerListbyId(Int64 deliveryPartnerId)
        {
            var a = _deliveryPartnerService.GetDeliveryPartnerById(deliveryPartnerId);
            return Ok(a);
        }

        [HttpPost]
        public IActionResult UpdateDeliveryPartner(DeliveryPartnerDTO deliveryPartnerDTO)
        {
            try
            {
                var a = _deliveryPartnerService.UpdateDeliveryPartner(deliveryPartnerDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{deliveryPartnerId}/{DeletedBy}")]
        public ActionResult DeleteDeliveryPartner(Int64 deliveryPartnerId, int DeletedBy)
        {
            var a = _deliveryPartnerService.DeleteDeliveryPartner(deliveryPartnerId, DeletedBy);
            return Ok(a);
        }


        

        [HttpGet("{WHouseManagerId}")]
        public IActionResult GetDeliveryAgentsByWareHouseManagerId(Int64 WHouseManagerId)
        {
            var DAgents = _deliveryPartnerService.GetDeliveryAgentsByManagerId(WHouseManagerId);

            return Ok(DAgents);
        }


        [HttpGet("{WareHouseId}")]
        public IActionResult GetDeliveryAgentsByWareHouseId(Int64 WareHouseId)
        {
            var DAgents = _deliveryPartnerService.GetDeliveryPartnersByWareHouseId(WareHouseId);

            return Ok(DAgents);
        }


        [HttpGet("{DistributorId}")]
        public IActionResult GetDeliveryAgentsByDistributorId(Int64 DistributorId)
        {
            var DAgents = _deliveryPartnerService.GetDeliveryPartnersByDistributorId(DistributorId);

            return Ok(DAgents);
        }

        [HttpGet("{AssignedCode}")]
        public IActionResult GetDeliveryAgentsByAssignedCode(string AssignedCode)
        {
            var DAgents = _deliveryPartnerService.GetDeliveryPartnersbyAssignedCode(AssignedCode);

            return Ok(DAgents);
        }

        [HttpPost("{DeliveryPartnerId}")]
        public IActionResult ChangeAvailability(Int64 DeliveryPartnerId)
        {
            try
            {
                var a = _deliveryPartnerService.ChangeAvailabiltyStatus(DeliveryPartnerId);

                if (a == null)
                {
                    return BadRequest();
                }

                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult AgentTaskAcceptCreatePage([FromForm] WareHouseDAAcceptDTO wareHouseDAAcceptDTO)
        {
            try
            {
				if (wareHouseDAAcceptDTO.StartMeterPhotoUp != null)
				{
					FileInfo fileInfo = new FileInfo(wareHouseDAAcceptDTO.StartMeterPhotoUp.FileName);
					string extn = fileInfo.Extension.ToLower();
					Guid id = Guid.NewGuid();
					string filename = id.ToString() + Path.GetExtension(wareHouseDAAcceptDTO.StartMeterPhotoUp.FileName);

					string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\AcceptedTasks");

					if (!Directory.Exists(uploadsFolder))
					{
						Directory.CreateDirectory(uploadsFolder);
					}

					string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
					string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

					// Copy the uploaded image to the specified path
					using (var stream = new FileStream(imagePath, FileMode.Create))
					{
						wareHouseDAAcceptDTO.StartMeterPhotoUp.CopyTo(stream);
					}

					wareHouseDAAcceptDTO.StartMeterPhoto = filename;
				}


				if (wareHouseDAAcceptDTO.EndMeterPhotoUp != null)
				{
					FileInfo fileInfo = new FileInfo(wareHouseDAAcceptDTO.EndMeterPhotoUp.FileName);
					string extn = fileInfo.Extension.ToLower();
					Guid id = Guid.NewGuid();
					string filename = id.ToString() + Path.GetExtension(wareHouseDAAcceptDTO.EndMeterPhotoUp.FileName);

					string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\AcceptedTasks");

					if (!Directory.Exists(uploadsFolder))
					{
						Directory.CreateDirectory(uploadsFolder);
					}

					string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
					string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

					// Copy the uploaded image to the specified path
					using (var stream = new FileStream(imagePath, FileMode.Create))
					{
						wareHouseDAAcceptDTO.EndMeterPhotoUp.CopyTo(stream);
					}

					wareHouseDAAcceptDTO.EndMeterPhoto = filename;
				}


                var a = _wareHouseDAAcceptService.CreateWareHouseDAAccept(wareHouseDAAcceptDTO);


                if(a == MessageEnum.Success)
                {
                    return Ok(a);
                }
                else if (a == MessageEnum.Exists)
                {
                    return BadRequest("Task has already been assigned");
                }
                else if (a == MessageEnum.InvalidInput)
                {
                    return BadRequest("Either DeliveryPartnerId or DATasksWarehouseId is missing");
                }

                return Ok(a);
			}
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult GetWareHouseDAAcceptList()
        {
            var list = _wareHouseDAAcceptService.GetWareHouseDAAcceptList();
            return Ok(list);
        }

        [HttpGet("{WareHouseDAAcceptId}")]
        public IActionResult GetWareHouseDAAcceptById(Int64 WareHouseDAAcceptId)
        {
            var a = _wareHouseDAAcceptService.GetWareHouseDAAcceptListById(WareHouseDAAcceptId);
            return Ok(a);
        }
    }
}
