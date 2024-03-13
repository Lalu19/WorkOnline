using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Buyers;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Data.DTO.RetailerModel;
using CloudVOffice.Data.Migrations;
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


		//[HttpGet("{UserMobileNumber}/{Password}")]
		//public IActionResult BuyerLogin(string UserMobileNumber, string Password)
		//{
		//	var buyer = _dbContext.BuyerRegistrations.FirstOrDefault(x => x.PrimaryPhone ==  UserMobileNumber);
		//	var seller = _dbContext.SellerRegistrations.FirstOrDefault(x => x.PrimaryPhone == UserMobileNumber);

		//	if (buyer == null && seller == null)
		//	{
		//		return BadRequest("UserMobileNumber is incorrect or Number not in use");
		//	}

		//	else if (buyer != null)
		//	{
		//		if (buyer.Password == Password)
		//		{
		//			return Ok(new { Buyer = buyer });
		//		}
		//		else
		//		{
		//			return BadRequest("Mobile Number is correct but the Password is wrong");
		//		}
		//	}

		//	else if (seller != null)
		//	{
		//		if (seller.Password == Password)
		//		{
		//			return Ok(new { Seller = seller });
		//		}
		//		else
		//		{
		//			return BadRequest("Mobile Number is correct but the Password is wrong");
		//		}
		//	}

		//	else
		//	{
		//		return BadRequest("Mobile Number is correct but the Password is wrong");
		//	}
		//}



        [HttpGet("{UserMobileNumber}/{Password}")]
        public IActionResult BuyerLogin(string UserMobileNumber, string Password)
        {
            var buyer = _dbContext.BuyerRegistrations.FirstOrDefault(x => x.PrimaryPhone == UserMobileNumber);

            if (buyer == null)
            {
                return BadRequest("UserMobileNumber is incorrect or Number not in use");
            }

            if (buyer.Password == Password)
            {
                return Ok(new { Buyer = buyer });
            }
            else
            {
                return BadRequest("Mobile Number is correct but the Password is wrong");
            }
        }


        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var buyer = _dbContext.BuyerRegistrations.FirstOrDefault(x => x.PrimaryPhone == changePasswordDTO.UserMobileNumber);

            if (buyer == null)
            {
                return BadRequest("User not found");
            }

            if (buyer.Password != changePasswordDTO.OldPassword)
            {
                return BadRequest("Old password is incorrect");
            }

            if (changePasswordDTO.NewPassword != changePasswordDTO.RetypePassword)
            {
                return BadRequest("New password and retype password do not match");
            }

            buyer.Password = changePasswordDTO.NewPassword;
            buyer.FirstLogin = true;

            _dbContext.SaveChanges();

            return Ok("Password changed successfully");
        }



        //[HttpPost]
        //public IActionResult ChangePassword(ChangePasswordDTO changePasswordDTO)
        //{
        //    var buyer = _dbContext.BuyerRegistrations.FirstOrDefault(x => x.PrimaryPhone == changePasswordDTO.UserMobileNumber);
        //    var seller = _dbContext.SellerRegistrations.FirstOrDefault(x => x.PrimaryPhone == changePasswordDTO.UserMobileNumber);

        //    if (buyer == null && seller == null)
        //    {
        //        return BadRequest("User not found");
        //    }

        //    var user = (buyer != null) ? (object)buyer : seller;

        //    if (user is BuyerRegistration && ((BuyerRegistration)user).Password != changePasswordDTO.OldPassword)
        //    {
        //        return BadRequest("Old password is incorrect");
        //    }
        //    else if (user is SellerRegistration && ((SellerRegistration)user).Password != changePasswordDTO.OldPassword)
        //    {
        //        return BadRequest("Old password is incorrect");
        //    }

        //    if (changePasswordDTO.NewPassword != changePasswordDTO.RetypePassword)
        //    {
        //        return BadRequest("New password and retype password do not match");
        //    }

        //    if (user is BuyerRegistration)
        //    {
        //        var buyerToUpdate = (BuyerRegistration)user;
        //        buyerToUpdate.Password = changePasswordDTO.NewPassword;
        //        buyerToUpdate.FirstLogin = true;
        //    }
        //    else if (user is SellerRegistration)
        //    {
        //        var sellerToUpdate = (SellerRegistration)user;
        //        sellerToUpdate.Password = changePasswordDTO.NewPassword;
        //    }

        //    _dbContext.SaveChanges();

        //    return Ok("Password changed successfully");
        //}




		[HttpGet("{UserMobileNumber}/{Password}")]
		public IActionResult SellerLogin(string UserMobileNumber, string Password)
		{
			var seller = _dbContext.SellerRegistrations.FirstOrDefault(a => a.PrimaryPhone == UserMobileNumber);

			if (seller == null)
			{
				return BadRequest("The Mobile Number is wrong");
			}
			else
			{
				if(seller.Password == Password)
                {
                    return Ok(new { Seller = seller });
                }
                else
                {
                    return BadRequest("Mobile Number is correct but the Password is wrong");
                }
            }
		}


        [HttpPost]
        public IActionResult ChangeSellerPassword(ChangePasswordDTO changePasswordDTO)
        {
            var seller = _dbContext.SellerRegistrations.FirstOrDefault(x => x.PrimaryPhone == changePasswordDTO.UserMobileNumber);

            if (seller == null)
            {
                return BadRequest("Seller not found");
            }

            if (seller.Password != changePasswordDTO.OldPassword)
            {
                return BadRequest("Old password is incorrect");
            }

            if (changePasswordDTO.NewPassword != changePasswordDTO.RetypePassword)
            {
                return BadRequest("New password and retype password do not match");
            }

            seller.Password = changePasswordDTO.NewPassword;
            _dbContext.SaveChanges();

            return Ok("Seller password changed successfully");
        }





        [HttpGet("{UserMobileNumber}/{Password}")]
        public IActionResult SalesExecutiveLogin(string UserMobileNumber, string Password)
        {
            var executive = _dbContext.SalesExecutiveRegistrations.FirstOrDefault(a => a.PrimaryPhone == UserMobileNumber);

            if (executive == null)
            {
                return BadRequest("The Mobile Number is wrong");
            }
            else
            {
                if (executive.Password == Password)
                {
                    return Ok(new { SalesExecutive = executive });
                }
                else
                {
                    return BadRequest("Mobile Number is correct but the Password is wrong");
                }
            }
        }


        [HttpPost]
        public IActionResult ChangeSalesExecutivePassword(ChangePasswordDTO changePasswordDTO)
        {
            var SalesExecutive = _dbContext.SalesExecutiveRegistrations.FirstOrDefault(x => x.PrimaryPhone == changePasswordDTO.UserMobileNumber);

            if (SalesExecutive == null)
            {
                return BadRequest("Seller not found");
            }

            if (SalesExecutive.Password != changePasswordDTO.OldPassword)
            {
                return BadRequest("Old password is incorrect");
            }

            if (changePasswordDTO.NewPassword != changePasswordDTO.RetypePassword)
            {
                return BadRequest("New password and retype password do not match");
            }

            SalesExecutive.Password = changePasswordDTO.NewPassword;
            _dbContext.SaveChanges();

            return Ok("Seller password changed successfully");
        }


        [HttpGet("{UserMobileNumber}/{Password}")]
        public IActionResult DeliveryAgentLogin(string UserMobileNumber, string Password)
        {
            var deliveryAgent = _dbContext.DeliveryPartners.FirstOrDefault(a => a.OwnerContact == UserMobileNumber);

            if (deliveryAgent == null)
            {
                return BadRequest("The Mobile Number is wrong");
            }
            else
            {
                if (deliveryAgent.Password == Password)
                {
                    return Ok(new { DeliveryAgent = deliveryAgent });
                }
                else
                {
                    return BadRequest("Mobile Number is correct but the Password is wrong");
                }
            }
        }


        [HttpPost]
        public IActionResult ChangeDeliveryAgentPassword(ChangePasswordDTO changePasswordDTO)
        {
            var deliveryAgent = _dbContext.DeliveryPartners.FirstOrDefault(x => x.OwnerContact == changePasswordDTO.UserMobileNumber);

            if (deliveryAgent == null)
            {
                return BadRequest("Seller not found");
            }

            if (deliveryAgent.Password != changePasswordDTO.OldPassword)
            {
                return BadRequest("Old password is incorrect");
            }

            if (changePasswordDTO.NewPassword != changePasswordDTO.RetypePassword)
            {
                return BadRequest("New password and retype password do not match");
            }

            deliveryAgent.Password = changePasswordDTO.NewPassword;
            _dbContext.SaveChanges();

            return Ok("Seller password changed successfully");
        }




    }
}
