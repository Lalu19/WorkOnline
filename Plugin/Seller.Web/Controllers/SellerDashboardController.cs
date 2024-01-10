using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seller.Web.Controllers
{
    [Area(AreaNames.Seller)]
    public class SellerDashboardController : BasePluginController
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public SellerDashboardController(IWebHostEnvironment hostEnvironment)

        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View("~/Plugins/Seller.Web/Views/SellerDashboard/Dashboard.cshtml");
        }
    }
}
