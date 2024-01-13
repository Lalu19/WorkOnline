using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Services.Authentication;
using CloudVOffice.Services.Company;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sellers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Seller_Login.Web.Model.SellerUsers;
using CloudVOffice.Data.Persistence;
using Microsoft.AspNetCore.Authorization;

namespace Seller_Login.Web.Controllers
{
	public class SellerUserController : Controller
	{
		private readonly IUserAuthenticationService _userauthenticationService;
		private readonly ICompanyDetailsService _companyDetailsService;
		private readonly ISellerRegistrationService _sellerRegistrationService;
		private readonly ICategoryService _categoryService;
        private readonly ApplicationDBContext _dbContext;

        public SellerUserController(IUserAuthenticationService userauthenticationService,
			ISellerRegistrationService sellerRegistrationService,
			ICompanyDetailsService companyDetailsService,
			ICategoryService categoryService, ApplicationDBContext dbContext


            )
		{
			_userauthenticationService = userauthenticationService;
			_companyDetailsService = companyDetailsService;
			_sellerRegistrationService = sellerRegistrationService;
			_categoryService = categoryService;
            _dbContext = dbContext;
        }
		public IActionResult SellerLogin()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SellerLogin(LoginModel model, string? ReturnUrl)
		{
			if (ModelState.IsValid)
			{
				var MobileNumber = model.UserMobileNumber?.Trim();
				// var Password = model.Password?.Trim();
				var loginResult = await _userauthenticationService.SellerValidateUserAsync(MobileNumber, ReturnUrl);
				switch (loginResult)
				{
					case UserLoginResults.Successful:
						{

							var SelleruserDetails = await _sellerRegistrationService.GetSellerLoginAsync(MobileNumber, model.Password);

							var claims = new List<Claim>
								{
									new Claim(ClaimTypes.MobilePhone, SelleruserDetails.PrimaryPhone),
									new Claim("SellerName",SelleruserDetails.Name),
									new Claim("PrimaryPhoneeNumber",SelleruserDetails.PrimaryPhone),
									new Claim("Address",SelleruserDetails.Address),
									new Claim("Country",SelleruserDetails.Country),
									new Claim("State",SelleruserDetails.State),
									new Claim("MailId",SelleruserDetails.MailId),
									new Claim("GSTNumber",SelleruserDetails.GSTNumber),
									new Claim("WareHuoseId",SelleruserDetails.WareHuoseId.ToString()),
									new Claim("PinCodeId",SelleruserDetails.PinCodeId.ToString()),
									new Claim("SectorId",SelleruserDetails.SectorId.ToString()),
									new Claim("SellerRegistrationId",SelleruserDetails.SellerRegistrationId.ToString()),

								};
							var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
							var authProperties = new AuthenticationProperties() { IsPersistent = true };
							await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


							return Redirect(ReturnUrl == null ? "/SellerLogin" : ReturnUrl);
						}
					case UserLoginResults.UserNotExist:
						ModelState.AddModelError("MobileNumber", "User Not Exists.");
						break;
					case UserLoginResults.Deleted:
						ModelState.AddModelError("", "Account Has Been Deleted.");
						break;

					case UserLoginResults.NotActive:
						ModelState.AddModelError("", "Account Has Been Suspended.");
						break;

					default:
						ModelState.AddModelError("Password", "Invalid Credentials");
						break;


				}
			}
			return View(model);
		}


		[HttpGet]
		public async Task<IActionResult> SellerLogOut()
		{
			//SignOutAsync is Extension method for SignOut    
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			//Redirect to home page    
			return LocalRedirect("/SellerUser/SellerLogin");
		}
       
    }
}
