using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Web.Controllers
{
    [Area(AreaNames.Report)]
    public class ReportDashbordController : BasePluginController
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public ReportDashbordController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View("~/Plugins/Report.Web/Views/ReportDashbord/Dashboard.cshtml");
        }
    }
}
