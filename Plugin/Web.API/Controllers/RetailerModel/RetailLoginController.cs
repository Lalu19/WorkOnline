using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Data.DTO.RetailerModel;
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
			var buyer = _dbContext.BuyerRegistrations.FirstOrDefault(x => x.PrimaryPhone ==  UserMobileNumber);
			var seller = _dbContext.SellerRegistrations.FirstOrDefault(x => x.PrimaryPhone == UserMobileNumber);

			if (buyer == null && seller == null)
			{
				return BadRequest("UserMobileNumber is incorrect or Number not in use");
			}

			else if (buyer != null)
			{
				if (buyer.Password == Password)
				{
					return Ok(new { Buyer = buyer });
				}
				else
				{
					return BadRequest("Mobile Number is correct but the Password is wrong");
				}
			}

			else if (seller != null)
			{
				if (seller.Password == Password)
				{
					return Ok(new { Seller = seller });
				}
				else
				{
					return BadRequest("Mobile Number is correct but the Password is wrong");
				}
			}

			else
			{
				return BadRequest("Mobile Number is correct but the Password is wrong");
			}
		}
		



		[HttpPost]
		public IActionResult ChangePassword(ChangePasswordDTO changePasswordDTO)
		{
			var a = _dbContext.BuyerRegistrations.FirstOrDefault(x => x.PrimaryPhone == changePasswordDTO.UserMobileNumber);
			var seller = _dbContext.SellerRegistrations.FirstOrDefault(x => x.PrimaryPhone == changePasswordDTO.UserMobileNumber);

			if (a == null && seller == null)
			{
				return BadRequest("User not found");
			}

			if (a.Password != changePasswordDTO.OldPassword)
			{
				return BadRequest("Old password is incorrect");
			}
			if (changePasswordDTO.NewPassword != changePasswordDTO.RetypePassword)
			{
				return BadRequest("New password and retype password do not match");
			}

			a.Password = changePasswordDTO.NewPassword;
			a.FirstLogin = true;

			_dbContext.SaveChanges();

			return Ok("Password changed successfully");
		}
	}
}
