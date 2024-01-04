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
			var a = _dbContext.BuyerRegistrations.FirstOrDefault(x => x.PrimaryPhone ==  UserMobileNumber);
			var b = _dbContext.SellerRegistrations.FirstOrDefault(x => x.PrimaryPhone == UserMobileNumber);

			if (a == null || b==null)
			{
				return BadRequest("UserMobileNumber is incorrect or Number not in use");
			}
			else
			{
				if(a.FirstLogin == false)
				{
					//return Redirect("/RetailLogin/ChangePassword");
					//return Redirect($"/RetailLogin/ChangePassword?UserMobileNumber={UserMobileNumber}");

					return RedirectToAction("ChangePassword", new { UserMobileNumber = UserMobileNumber });
				}


				 if (a.Password == Password)
				 {
					return Ok(new { Buyer = a, Seller = b });
				}
				else
				{
					return BadRequest("Mobile Number is correct but the Password is wrong");
				}
			}
		}



		[HttpPost("{UserMobileNumber}")]
		public IActionResult ChangePassword(string UserMobileNumber, ChangePasswordDTO changePasswordDTO)
		{
			var a = _dbContext.BuyerRegistrations.FirstOrDefault(x => x.PrimaryPhone == UserMobileNumber);

			if (a == null)
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
