using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Services.Authentication;
using CloudVOffice.Services.Company;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sellers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
//using Seller_Login.Web.Model.SellerUsers;
using CloudVOffice.Data.Persistence;
using Microsoft.AspNetCore.Authorization;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.Users;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Services.Distributors;
using Distributor_partner.Model.DistributorUsers;

namespace Distributor_partner.Controllers
{
	public class DistributorPartnerController : Controller
	{
		private readonly IUserAuthenticationService _userauthenticationService;
		private readonly ICompanyDetailsService _companyDetailsService;
		private readonly ICategoryService _categoryService;
		private readonly ApplicationDBContext _dbContext;
		private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly IDistributorRegistrationService _distributorRegistrationService;

		public DistributorPartnerController(IUserAuthenticationService userauthenticationService,
			ICompanyDetailsService companyDetailsService,
			ICategoryService categoryService, ApplicationDBContext dbContext, IWebHostEnvironment hostingEnvironment, IDistributorRegistrationService distributorRegistrationService
			)
		{
			_userauthenticationService = userauthenticationService;
			_companyDetailsService = companyDetailsService;
			_categoryService = categoryService;
			_dbContext = dbContext;
			_hostingEnvironment = hostingEnvironment;
			_distributorRegistrationService = distributorRegistrationService;

		}
		public IActionResult DistributorLogin()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> DistributorLogin(LoginModel model, string? ReturnUrl)
		{
			if (ModelState.IsValid)
			{
				var MobileNumber = model.UserMobileNumber?.Trim();
				// var Password = model.Password?.Trim();
				var loginResult = await _userauthenticationService.DistributorValidateUserAsync(MobileNumber, model.Password);
				switch (loginResult)
				{
					case UserLoginResults.Successful:
						{

							var DistributorDetails = await _distributorRegistrationService.GetDistributorLoginAsync(MobileNumber, model.Password);

							var claims = new List<Claim>
								{
									new Claim(ClaimTypes.MobilePhone, DistributorDetails.PrimaryPhone),
									new Claim("DistributorName",DistributorDetails.Name),
									new Claim("Image",DistributorDetails.Image),
									new Claim("PrimaryPhoneNumber",DistributorDetails.PrimaryPhone),
									new Claim("Address",DistributorDetails.Address),
									new Claim("Country",DistributorDetails.Country),
									new Claim("State",DistributorDetails.State),
									new Claim("MailId",DistributorDetails.MailId),
									new Claim("GSTNumber",DistributorDetails.GSTNumber),
									new Claim("WareHuoseId",DistributorDetails.WareHuoseId.ToString()),
									new Claim("PinCodeId",DistributorDetails.PinCodeId.ToString()),
									new Claim("SectorId",DistributorDetails.SectorId.ToString()),
									new Claim("DistributorRegistrationId",DistributorDetails.DistributorRegistrationId.ToString()),

								};
							var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
							var authProperties = new AuthenticationProperties() { IsPersistent = true };
							await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


							return Redirect(ReturnUrl == null ? "/DistributorHome" : ReturnUrl);
						}
					case UserLoginResults.UserNotExist:
						ModelState.AddModelError("UserMobileNumber", "User Not Exists.");
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

		[HttpGet("/DistributorHome")]
		[Authorize]
		public IActionResult DistributorHome()
		{
			Int64 DistributorRegistrationId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString());
			string Name = User.Claims.FirstOrDefault(x => x.Type == "DistributorName").ToString();
			string Image = User.Claims.FirstOrDefault(x => x.Type == "Image").ToString();
			string PrimaryPhone = User.Claims.FirstOrDefault(x => x.Type == "PrimaryPhoneNumber").ToString();
			string Address = User.Claims.FirstOrDefault(x => x.Type == "Address").ToString();
			string Country = User.Claims.FirstOrDefault(x => x.Type == "Country").ToString();
			string State = User.Claims.FirstOrDefault(x => x.Type == "State").ToString();
			string MailId = User.Claims.FirstOrDefault(x => x.Type == "MailId").ToString();
			string GSTNumber = User.Claims.FirstOrDefault(x => x.Type == "GSTNumber").ToString();
			int WareHuoseId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "WareHuoseId").Value.ToString());
			int PinCodeId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "PinCodeId").Value.ToString());
			int SectorId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "SectorId").Value.ToString());

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> DistributorLogOut()
		{
			//SignOutAsync is Extension method for SignOut    
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			//Redirect to home page    
			return LocalRedirect("/DistributorPartner/DistributorLogin");
		}
	}
}
