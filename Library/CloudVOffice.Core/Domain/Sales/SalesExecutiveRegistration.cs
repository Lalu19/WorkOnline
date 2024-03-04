using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Sales
{
    public class SalesExecutiveRegistration : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 SalesExecutiveRegistrationId { get; set; }
        public string? SalesExecutiveName { get; set; }
        public string? PANCardNumber { get; set; }
        public string? AadharCardNumber { get; set; }
        public string? SalesExecutiveUniqueNumber { get; set; }
        public Int64? WareHuoseId { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? MailId { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }


        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
