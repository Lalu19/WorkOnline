using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.PushNotifications;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.Buyers;
using CloudVOffice.Services.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Web.API.Controllers.PushNotifications
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class PushNotificationsController : Controller
    {
        private readonly IPushNotificationService _pushNotificationService;
        private readonly ApplicationDBContext _dbContext;

        public PushNotificationsController(IPushNotificationService pushNotificationService, ApplicationDBContext dbContext)
        {
            _pushNotificationService = pushNotificationService;
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreatePushNotification(PushNotificationDTO pushNotificationDTO)
        {
            var a = _pushNotificationService.CreatePushNotification(pushNotificationDTO);

            if(a == MessageEnum.Success)
            {
                return Ok(a);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetPushNotificationList()
        {
            var a = _pushNotificationService.PushNotificationsList();
            return Ok(a);
        }



    }
}
