using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Distributor_partner.Model.DistributorUsers
{
	public partial record LoginModel
	{
		[DataType(DataType.PhoneNumber)]
		[DisplayName("Mobile Number")]
		public string UserMobileNumber { get; set; }

		[DataType(DataType.Password)]
		[DisplayName("Password")]
		public string Password { get; set; }
	}
}
