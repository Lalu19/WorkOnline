using CloudVOffice.Data.DTO.RetailerModel;
using Microsoft.AspNetCore.Mvc;

namespace Seller_Login.Web.Controllers
{
	public class ChangePasswordController : Controller
	{
		public IActionResult ChangePasswordPage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ChangePasswordPage(ChangePasswordDTO changePasswordDTO)
		{
			return View();
		}
	}
}
