using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Distributor
{
    public class DistributorAssignDTO
    {
        public Int64? DistributorAssignId { get; set; }
        public Int64 DistributorRegistrationId { get; set; }
        public List<Int64> PinCodeId { get; set; }
        public List<Int64> BrandId { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
