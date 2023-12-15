using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Infrastructure.Applications;
using CloudVOffice.Core.Infrastructure.Http;
using CloudVOffice.Core.Infrastructure.JSON;
using CloudVOffice.Data.DTO.Permission;
using CloudVOffice.Services.Applications;
using CloudVOffice.Services.Plugins;
using CloudVOffice.Services.Roles;
using CloudVOffice.Web.Framework;
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
	public class SalesExecutiveDashboardController : Controller
	{
		private readonly IWebHostEnvironment _hostEnvironment;

		public SalesExecutiveDashboardController(IWebHostEnvironment hostEnvironment)

		{
			_hostEnvironment = hostEnvironment;
		}
		[HttpGet]
		public IActionResult Dashboard()
		{
			return View("~/Plugins/SalesExecutive/Views/SalesExecutiveDashboard/Dashboard.cshtml");
		}
	}
}
