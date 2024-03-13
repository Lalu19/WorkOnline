using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.WareHouses;

namespace CloudVOffice.Core.Domain.Distributors
{
    public class DistributorRegistration : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 DistributorRegistrationId { get; set; }
        public string Name { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string PrimaryPhone { get; set; }
        public string? AlternatePhone { get; set; }
        public string? MailId { get; set; }
        public string? GSTNumber { get; set; }
        public Int64? WareHuoseId { get; set; }
        public string? Password { get; set; }
        public string? Image { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("WareHuoseId")]
        public WareHuose WareHuose { get; set; }
    }
}
