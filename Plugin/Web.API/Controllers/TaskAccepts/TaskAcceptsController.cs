using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.DeliveryPartners;
using CloudVOffice.Services.DeliveryPartners;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers.TaskAccepts
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TaskAcceptsController : Controller
	{
		private readonly IWareHouseDAAcceptService _wareHouseDAAcceptService;
		private readonly IWebHostEnvironment _hostingEnvironment;

		public TaskAcceptsController(IWareHouseDAAcceptService wareHouseDAAcceptService, IWebHostEnvironment hostingEnvironment)
		{
			_wareHouseDAAcceptService = wareHouseDAAcceptService;
			_hostingEnvironment = hostingEnvironment;
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


				if (a == MessageEnum.Success)
				{
					return Ok(a);
				}
				else if (a == MessageEnum.Exists)
				{
					return BadRequest("Task has already been assigned");
				}
				else if (a == MessageEnum.InvalidInput)
				{
					return BadRequest("Either DeliveryPartnerId or One of DATasksWarehouseId/DATasksDistributorId is missing");
				}
				else if (a == MessageEnum.Error)
				{
					return BadRequest("The provided TaskId does not exists");
				}

				return Ok(a);
			}
			catch
			{
				throw;
			}
		}

		[HttpGet]
		public IActionResult GetDAAcceptList()
		{
			var list = _wareHouseDAAcceptService.GetWareHouseDAAcceptList();
			return Ok(list);
		}

		[HttpGet("{WareHouseDAAcceptId}")]
		public IActionResult GetDAAcceptById(Int64 WareHouseDAAcceptId)
		{
			var a = _wareHouseDAAcceptService.GetWareHouseDAAcceptListById(WareHouseDAAcceptId);
			return Ok(a);
		}



		[HttpGet("{DeliveryPartnerId}")]
		public IActionResult GetDAAcceptListByDeliveryPartnerId(Int64 DeliveryPartnerId)
		{
			var a = _wareHouseDAAcceptService.GetWareHouseDAAcceptListByDeliveryPartnerId(DeliveryPartnerId);
			return Ok(a);
		}

		[HttpGet]
		public IActionResult GetDAAcceptListByWarehouseTasks()
		{
			var a = _wareHouseDAAcceptService.GetWareHouseDAAcceptListByWarehouseTasks();
			return Ok(a);
		}


		[HttpGet]
		public IActionResult GetDAAcceptListByDistributorTasks()
		{
			var a = _wareHouseDAAcceptService.GetWareHouseDAAcceptListByDistributorTasks();
			return Ok(a);
		}

		[HttpGet("{DATasksWareHouseId}")]
		public IActionResult GetDAAcceptByDATasksWareHouseId(Int64 DATasksWareHouseId)
		{
			var a = _wareHouseDAAcceptService.GetWareHouseDAAcceptByDATasksWareHouseId(DATasksWareHouseId);
			return Ok(a);
		}



		[HttpGet("{DATasksDistributorId}")]
		public IActionResult GetDAAcceptByDATasksDistributorId(Int64 DATasksDistributorId)
		{
			var a = _wareHouseDAAcceptService.GetWareHouseDAAcceptByDATasksDistributorId(DATasksDistributorId);
			return Ok(a);
		}
	}
}

