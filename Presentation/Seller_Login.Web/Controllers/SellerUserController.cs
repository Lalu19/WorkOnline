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
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.Users;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.Banners;

namespace Seller_Login.Web.Controllers
{
	public class SellerUserController : Controller
	{
		private readonly IUserAuthenticationService _userauthenticationService;
		private readonly ICompanyDetailsService _companyDetailsService;
		private readonly ISellerRegistrationService _sellerRegistrationService;
		private readonly ICategoryService _categoryService;
        private readonly ApplicationDBContext _dbContext;
		private readonly IWebHostEnvironment _hostingEnvironment;

		public SellerUserController(IUserAuthenticationService userauthenticationService,
			ISellerRegistrationService sellerRegistrationService,
			ICompanyDetailsService companyDetailsService,
			ICategoryService categoryService, ApplicationDBContext dbContext, IWebHostEnvironment hostingEnvironment


			)
		{
			_userauthenticationService = userauthenticationService;
			_companyDetailsService = companyDetailsService;
			_sellerRegistrationService = sellerRegistrationService;
			_categoryService = categoryService;
            _dbContext = dbContext;
			_hostingEnvironment = hostingEnvironment;
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
				var loginResult = await _userauthenticationService.SellerValidateUserAsync(MobileNumber, model.Password);
				switch (loginResult)
				{
					case UserLoginResults.Successful:
						{

							var SelleruserDetails = await _sellerRegistrationService.GetSellerLoginAsync(MobileNumber, model.Password);

							var claims = new List<Claim>
								{
									new Claim(ClaimTypes.MobilePhone, SelleruserDetails.PrimaryPhone),
									new Claim("SellerName",SelleruserDetails.Name),
									new Claim("PrimaryPhoneNumber",SelleruserDetails.PrimaryPhone),
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


							return Redirect(ReturnUrl == null ? "/SellerHome" : ReturnUrl);
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

		[HttpGet("/SellerHome")]
		[Authorize]
		public IActionResult SellerHome()
		{
			Int64 SellerRegistrationId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "SellerRegistrationId").Value.ToString());
			string Name = User.Claims.FirstOrDefault(x => x.Type == "SellerName").ToString();
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
		public async Task<IActionResult> SellerLogOut()
		{
			//SignOutAsync is Extension method for SignOut    
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			//Redirect to home page    
			return LocalRedirect("/SellerUser/SellerLogin");
		}

        public IActionResult UpdateSellerProfile()
        {
            Int64 SellerRegistrationId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "SellerRegistrationId").Value.ToString());
            ViewBag.Sellerdetails = _sellerRegistrationService.GetSellerRegistrationById(SellerRegistrationId);
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> UpdateSellerProfile(SellerRegistrationDTO sellerRegistrationDTO)
		{
			if (sellerRegistrationDTO.ImageUp != null)
			{
				FileInfo fileInfo = new FileInfo(sellerRegistrationDTO.ImageUp.FileName);
				string extn = fileInfo.Extension.ToLower();
				Guid id = Guid.NewGuid();
				string filename = id.ToString() + extn;

				string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/SellerRegistration");
				if (!Directory.Exists(uploadsFolder))
				{
					Directory.CreateDirectory(uploadsFolder);
				}
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
				string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
				sellerRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
				sellerRegistrationDTO.Image = uniqueFileName;
			}
			if (sellerRegistrationDTO.SellerRegistrationId != null)
			{
				var result = await _sellerRegistrationService.UpdateSellerRegUser(sellerRegistrationDTO);
				if (result == MessageEnum.Updated)
				{
					TempData["updateSuccessMessage"] = "Your page has been updated successfully!";
					return RedirectToAction("SellerHome");
				}
				else
				{
					TempData["errorMessage"] = "An unexpected error occurred. Please try again.";
					ModelState.AddModelError("", "Un-Expected Error");
				}
			}

			return View(sellerRegistrationDTO);
		}

	}
}
