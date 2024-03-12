using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Distributors
{
    public class DistributorAssign : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 DistributorAssignId { get; set; }
        public Int64 DistributorRegistrationId { get; set; }
        public Int64 PinCodeId { get; set; }
        public Int64 BrandId { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("DistributorRegistrationId")]
        public DistributorRegistration DistributorRegistrations { get; set; }

        [ForeignKey("PinCodeId")]
        public PinCode PinCodes { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brands { get; set; }
    }
}
