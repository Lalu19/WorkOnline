namespace Seller_Login.Web.Model.SellerUsers
{
	public partial record LoginModel
	{
		public string UserMobileNumber { get; set; }
		public string Password { get; set; }
	}
}
