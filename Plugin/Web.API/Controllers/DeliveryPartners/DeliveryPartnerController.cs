using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Data.DTO.Buyers;
using CloudVOffice.Data.DTO.DeliveryPartners;
using CloudVOffice.Services.Banners;
using CloudVOffice.Services.DeliveryPartners;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.DeliveryPartners
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeliveryPartnerController : Controller
    {

        private readonly IDeliveryPartnerService _deliveryPartnerService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public DeliveryPartnerController(IDeliveryPartnerService deliveryPartnerService , IWebHostEnvironment hostingEnvironment)
        {
            _deliveryPartnerService = deliveryPartnerService;
            _hostingEnvironment = hostingEnvironment;
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

        [HttpGet("{bannerId}")]
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



    }
}
