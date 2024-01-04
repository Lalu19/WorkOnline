using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.Buyers;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers.RetailerModel
{

	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RetailLoginController : Controller
	{
		private readonly IBuyerRegistrationService _buyerRegistrationService;
		private readonly ApplicationDBContext _dbContext;

		public RetailLoginController(IBuyerRegistrationService buyerRegistrationService, ApplicationDBContext dbContext)
		{
			_buyerRegistrationService = buyerRegistrationService;
			_dbContext = dbContext;
		}


		[HttpGet("{UserMobileNumber}/{Password}")]
		public IActionResult BuyerLogin(string UserMobileNumber, string Password)
		{
			var a = _dbContext.BuyerRegistrations.FirstOrDefault(x => x.PrimaryPhone ==  UserMobileNumber);

			if (a == null)
			{
				return BadRequest("UserMobileNumber is incorrect or Number not in use");
			}
			else
			{
				 if (a.Password == Password)
				 {
					return Ok(a);
				 }
				else
				{
					return BadRequest("Mobile Number is correct but the Password is wrong");
				}
			}
		}
	}
}
