using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.RetailerModel;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.Authentication;
using CloudVOffice.Services.Company;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sellers;
using Microsoft.AspNetCore.Mvc;

namespace Seller_Login.Web.Controllers
{
	public class ChangePasswordController : Controller
	{
        private readonly ISellerRegistrationService _sellerRegistrationService;
        private readonly ApplicationDBContext _dbContext;

        public ChangePasswordController(
                                       ISellerRegistrationService sellerRegistrationService,
                                       ApplicationDBContext dbContext
                                       )
        {
            _sellerRegistrationService = sellerRegistrationService;
            _dbContext = dbContext;
        }

        public IActionResult ChangePasswordPage()
		{
            Int64 SellerRegistrationId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "SellerRegistrationId").Value.ToString());
            ViewBag.Sellerdetails = _sellerRegistrationService.GetSellerRegistrationById(SellerRegistrationId);
            return View();
		}

		[HttpPost]
		public async Task<IActionResult> ChangePasswordPage(SellerUpdateDTO sellerUpdateDTO)
		{
            if (sellerUpdateDTO.SellerRegistrationId != null)
            {
                var result = await _sellerRegistrationService.UpdateSellerPassword(sellerUpdateDTO);
                if (result == MessageEnum.Updated)
                {
                    TempData["updateSuccessMessage"] = "Your page has been updated successfully!";
                   // return RedirectToAction("SellerHome");
                    return Redirect("/SellerHome");
                }
                else
                {
                    TempData["errorMessage"] = "An unexpected error occurred. Please try again.";
                    ModelState.AddModelError("", "Un-Expected Error");
                }
            }

            return View(sellerUpdateDTO);
		}
	}
}
