using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class WareHouseDashboardController : BasePluginController 
    {
        private readonly IWebHostEnvironment _hostEnvironment;
       
        public WareHouseDashboardController(IWebHostEnvironment hostEnvironment)

        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View("~/Plugins/Warehouse.Management/Views/WareHouseDashboard/Dashboard.cshtml");
        }
    }
}
