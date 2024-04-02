using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public DATasksWarehouseController(IDATasksWarehouseService dATasksWarehouseService, ApplicationDBContext dbContext)
        {
            _dATasksWarehouseService = dATasksWarehouseService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetDATasksWarehouseList()
        {
            var a = _dATasksWarehouseService.GetDATasksWarehouseList();
            return Ok(a);
        }

        [HttpGet("{AssignmentCode}")]
        public IActionResult GetTaskListByAssignmentCode(string AssignmentCode)   //for list inside agents mobile
        {
            var tasks = _dATasksWarehouseService.GetTaskListByAssignedCode(AssignmentCode);

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
        public IActionResult GetDATasksWHAcceptedListByAgentId(Int64 DeliveryPartnerId)
        {
            var a = _dATasksWarehouseService.GetDAAcceptedTasksWarehouseByDeliveryAgentId(DeliveryPartnerId);
            return Ok(a);
        }

    }
}
