using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Data.DTO.Distributor;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.DeliveryPartners;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers.DATasksWarehouses
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class DATasksWarehouseController : Controller
    {

        private readonly IDATasksWarehouseService _dATasksWarehouseService;
        private readonly ApplicationDBContext _dbContext;
        private readonly IDATasksDistrbutorService _dATasksDistrbutorService;

        public DATasksWarehouseController(IDATasksWarehouseService dATasksWarehouseService, ApplicationDBContext dbContext, IDATasksDistrbutorService dATasksDistrbutorService)
        {
            _dATasksWarehouseService = dATasksWarehouseService;
            _dbContext = dbContext;
			_dATasksDistrbutorService = dATasksDistrbutorService;

		}


        [HttpPost]
        public IActionResult CreateWareHouseTask(WarehouseSalesOrderParentDTO warehouseSalesOrderParentDTO)
		{
            var a = _dATasksWarehouseService.CreateDATasksWarehouse(warehouseSalesOrderParentDTO);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateDistributorTask(DSODTO dSODTO)
        {
            var a = _dATasksDistrbutorService.CreateDATasksDistributor(dSODTO);
            return Ok();
        }

		[HttpGet]
        public IActionResult GetDATasksWarehouseList()
        {
            var a = _dATasksWarehouseService.GetDATasksWarehouseList();
            return Ok(a);
        }

		[HttpGet("{AssignmentCode}")]
        public IActionResult GetWareHouseTaskListByAssignedCode(string AssignmentCode)   //for list inside agents mobile
        {
            var tasks = _dATasksWarehouseService.GetWareHouseTaskListByAssignedCode(AssignmentCode);

            if (tasks != null)
            {
                return Ok(tasks);
            }
            else
            {
                return BadRequest("Either no delivery agents available or the Order Weight is greater than load capacity of the available agents");
            }
        }

		[HttpGet]
        public IActionResult GetDATasksWarehouseUnAcceptedList()
        {
            var a = _dATasksWarehouseService.GetDATasksWarehouseUnAcceptedList();
            return Ok(a);
        }

        [HttpGet]
        public IActionResult GetDATasksWarehouseAcceptedList()
        {
            var a = _dATasksWarehouseService.GetDATasksWarehouseAcceptedList();
            return Ok(a);
        }

		[HttpGet("{DeliveryPartnerId}")]
        public IActionResult GetDATasksAcceptedWareHouseListByAgentId(Int64 DeliveryPartnerId)
        {
            var a = _dATasksWarehouseService.GetDAAcceptedTasksWarehouseByDeliveryAgentId(DeliveryPartnerId);
            return Ok(a);
        }







		[HttpGet]
		public IActionResult GetDATasksDistributorList()
		{
			var a = _dATasksDistrbutorService.GetDATasksDistributorList();
			return Ok(a);
		}


		[HttpGet("{AssignmentCode}")]
		public IActionResult GetDistributorTaskListByAssignedCode(string AssignmentCode)   //for list inside agents mobile
		{
			var tasks = _dATasksDistrbutorService.GetDistributorTaskListByAssignedCode(AssignmentCode);

			if (tasks != null)
			{
				return Ok(tasks);
			}
			else
			{
				return BadRequest("Either no delivery agents available or the Order Weight is greater than load capacity of the available agents");
			}
		}

		[HttpGet("{DeliveryPartnerId}")]
		public IActionResult GetDATasksAcceptedDistributorListByAgentId(Int64 DeliveryPartnerId)
		{
			var a = _dATasksDistrbutorService.GetDAAcceptedTasksDistributorByDeliveryAgentId(DeliveryPartnerId);
			return Ok(a);
		}


		[HttpGet]
		public IActionResult GetDATasksDistributorAcceptedList()
		{
			var a = _dATasksDistrbutorService.GetAcceptedTasksDistributorList();
			return Ok(a);

		}

		[HttpGet]
		public IActionResult GetDATasksDistributorUnAcceptedList()
		{
			var a = _dATasksDistrbutorService.GetUnAcceptedTasksDistributorList();
			return Ok(a);
		}

	}
}
