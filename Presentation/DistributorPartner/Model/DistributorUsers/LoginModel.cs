using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DistributorPartner.Model.DistributorUsers
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
